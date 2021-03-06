/* Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
*  Copyright :     Copyright � Nequeo Pty Ltd 2016 http://www.nequeo.com.au/
*
*  File :          WebServer.cpp
*  Purpose :       WebSocket web server class.
*
*/

/*
Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.
*/

#include "stdafx.h"
#include "stdafx.cpp"

#include "WebServer.h"
#include "server_ws.hpp"
#include "server_wss.hpp"

using namespace Nequeo::Net::WebSocket;

std::atomic<int> serverWSCount;
concurrency::concurrent_unordered_map<int, std::shared_ptr<InternalWebSocketServer>> serverPtr;
concurrency::concurrent_unordered_map<int, std::shared_ptr<InternalSecureWebSocketServer>> serverSecurePtr;

void Accept(WebServer*, std::shared_ptr<InternalWebSocketServer>, std::function<void(const WebContext*)>);
void AcceptSecure(WebServer*, std::shared_ptr<InternalSecureWebSocketServer>, std::function<void(const WebContext*)>);

void StopAccept(std::shared_ptr<InternalWebSocketServer>);
void StopAcceptSecure(std::shared_ptr<InternalSecureWebSocketServer>);

void MakeWebContext(std::shared_ptr<WebContext>, std::shared_ptr<InternalWebSocketServer::Connection>);
void MakeSecureWebContext(std::shared_ptr<WebContext>, std::shared_ptr<InternalSecureWebSocketServer::Connection>);

///	<summary>
///	WebSocket web server.
///	</summary>
/// <param name="port">The listening port number.</param>
/// <param name="ipv">The IP version to use.</param>
/// <param name="isSecure">Is the server secure (must set the public and private key files).</param>
/// <param name="timeoutRequest">The request timeout (seconds).</param>
/// <param name="timeoutIdle">The send and receive timeout (600 seconds = 10 minutes).</param>
/// <param name="timeoutConnect">The time out (seconds) connect.</param>
/// <param name="numberOfThreads">The number of threads to use(set to 1 is more than statisfactory).</param>
WebServer::WebServer(unsigned short port, IPVersionType ipv, bool isSecure, size_t timeoutRequest, size_t timeoutIdle, size_t timeoutConnect, size_t numberOfThreads) :
	_disposed(false), _listening(false), _isSecure(isSecure), _port(port), _timeoutRequest(timeoutRequest), _timeoutIdle(timeoutIdle), _numberOfThreads(numberOfThreads),
	_timeoutConnect(timeoutConnect), _internalThread(false), _ipv(ipv), _hasEndpoint(false), _serverName("Nequeo WebSocket Web Server 16.26.1.1"),
	_serverIndex(-1), _endpoint(""), _privateKeyPassword("")
{
}

/// <summary>
/// WebSocket web server.
/// </summary>
/// <param name="port">The listening port number.</param>
/// <param name="endpoint">The endpoint address to listen on.</param>
/// <param name="isSecure">Is the server secure (must set the public and private key files).</param>
/// <param name="timeoutRequest">The request timeout (seconds).</param>
/// <param name="timeoutIdle">The send and receive timeout (600 seconds = 10 minutes).</param>
/// <param name="timeoutConnect">The time out (seconds) connect.</param>
/// <param name="numberOfThreads">The number of threads to use(set to 1 is more than statisfactory).</param>
WebServer::WebServer(unsigned short port, const std::string& endpoint, bool isSecure, size_t timeoutRequest, size_t timeoutIdle, size_t timeoutConnect, size_t numberOfThreads) :
	_disposed(false), _listening(false), _isSecure(isSecure), _port(port), _timeoutRequest(timeoutRequest), _timeoutIdle(timeoutIdle), _numberOfThreads(numberOfThreads),
	_timeoutConnect(timeoutConnect), _internalThread(false), _endpoint(endpoint), _hasEndpoint(true), _serverName("Nequeo WebSocket Web Server 16.26.1.1"),
	_serverIndex(-1), _privateKeyPassword("")
{
	_ipv = IPVersionType::IPv4;
}

///	<summary>
///	WebSocket web server.
///	</summary>
WebServer::~WebServer()
{
	if (!_disposed)
	{
		_disposed = true;

		// Stop listening.
		Stop();
		StopThread();

		if (_serverIndex >= 0)
		{
			serverPtr[_serverIndex] = nullptr;
		}

		if (_serverIndex >= 0)
		{
			serverSecurePtr[_serverIndex] = nullptr;
		}
	}

	_listening = false;
	_serverIndex = -1;
}

/// <summary>
/// On web context request.
/// </summary>
/// <param name="webContext">The web context callback function.</param>
void WebServer::OnWebContext(const WebContextHandler& webContext)
{
	_onWebContext = webContext;
}

///	<summary>
///	Stop the server.
///	</summary>
void WebServer::Stop()
{
	// If listening.
	if (_listening)
	{
		// If not secure.
		if (!_isSecure)
		{
			// Stop listening.
			if (_serverIndex >= 0)
				StopAccept(serverPtr[_serverIndex]);
		}
		else
		{
			// Stop listening.
			if (_serverIndex >= 0)
				StopAcceptSecure(serverSecurePtr[_serverIndex]);
		}

		_listening = false;
	}
}

///	<summary>
///	Stop the server.
///	</summary>
void WebServer::StopThread()
{
	// Stop the server.
	Stop();

	// If an internal thread was created.
	if (_internalThread)
	{
		try
		{
			_internalThread = false;
			_thread.join();
		}
		catch (...) {}
	}
}

///	<summary>
///	Start the server.
///	</summary>
void WebServer::StartThread()
{
	// If an internal thread has not been created.
	if (!_internalThread)
	{
		// Move-assign threads
		_internalThread = true;
		_thread = std::thread(std::bind(&WebServer::Start, this));
		_thread.detach();
	}
}

///	<summary>
///	Start the server.
///	</summary>
void WebServer::Start()
{
	// If not listening.
	if (!_listening)
	{
		_listening = true;

		// If not secure.
		if (!_isSecure)
		{
			// If not created.
			if (_serverIndex < 0)
			{
				++serverWSCount;
				_serverIndex = serverWSCount;

				// HTTP-server at port using 1 thread
				// Unless you do more heavy non-threaded processing in the resources,
				// 1 thread is usually faster than several threads
				serverPtr.insert(std::make_pair(_serverIndex, 
					std::make_shared<InternalWebSocketServer>(_port, _numberOfThreads, _ipv, _timeoutRequest, _timeoutIdle, _timeoutConnect)));

				// If an enpoint exists.
				if (_hasEndpoint)
					serverPtr[_serverIndex]->config.address = _endpoint;
			}

			// Start accepting;
			Accept(this, serverPtr[_serverIndex], _onWebContext);
		}
		else
		{
			// If not created.
			if (_serverIndex < 0)
			{
				++serverWSCount;
				_serverIndex = serverWSCount;

				// HTTPS-server at port using 1 thread
				// Unless you do more heavy non-threaded processing in the resources,
				// 1 thread is usually faster than several threads
				serverSecurePtr.insert(std::make_pair(_serverIndex, 
					std::make_shared<InternalSecureWebSocketServer>(_port, _numberOfThreads, _publicKeyFile, _privateKeyFile, _ipv, _timeoutRequest, _timeoutIdle, _timeoutConnect, _privateKeyPassword)));

				// If an enpoint exists.
				if (_hasEndpoint)
					serverSecurePtr[_serverIndex]->config.address = _endpoint;
			}

			// Start accepting;
			AcceptSecure(this, serverSecurePtr[_serverIndex], _onWebContext);
		}
	}
}

/// <summary>
/// On web context request.
/// </summary>
/// <param name="publicKeyFile">The public certificate file path.</param>
/// <param name="privateKeyFile">The private (un-encrypted, encrypted - use password) key file.</param>
/// <param name="privateKeyPassword">The private key password (decrypt encrypted private key file).</param>
void WebServer::SetSecurePublicPrivateKeys(const std::string& publicKeyFile, const std::string& privateKeyFile, const std::string& privateKeyPassword)
{
	_isSecure = true;
	_publicKeyFile = publicKeyFile;
	_privateKeyFile = privateKeyFile;
	_privateKeyPassword = privateKeyPassword;
}

/// <summary>
/// Is the server listening.
/// </summary>
/// <return>True if the server is listening; else false.</return>
bool WebServer::IsListening() const
{
	return _listening;
}

/// <summary>
/// Is the server secure.
/// </summary>
/// <return>True if the server is secure; else false.</return>
bool WebServer::IsSecure() const
{
	return _isSecure;
}

/// <summary>
/// The IP version type.
/// </summary>
/// <return>The IP version type.</return>
IPVersionType WebServer::IPVersion() const
{
	return _ipv;
}

/// <summary>
/// Gets or sets the server name.
/// </summary>
/// <param name="serverName">The server name.</param>
/// <return>The servername.</return>
const std::string& WebServer::GetServerName() const
{
	return _serverName;
}
void WebServer::SetServerName(const std::string& serverName)
{
	_serverName = serverName;
}

/// <summary>
/// Get the port number.
/// </summary>
/// <return>The port number.</return>
unsigned short WebServer::Port() const
{
	return _port;
}

/// <summary>
/// Get the endpoint.
/// </summary>
/// <return>The endpoint.</return>
const std::string& WebServer::GetEndpoint() const
{
	return _endpoint;
}

/// <summary>
/// Get the list of all current connections.
/// </summary>
/// <return>The list of all connections.</return>
const std::set<std::shared_ptr<WebContext>> WebServer::GetConnections() const
{
	std::set<std::shared_ptr<WebContext>> all_connections;

	// If listening.
	if (_listening)
	{
		// If not secure.
		if (!_isSecure)
		{
			// Get the server ref.
			auto server = serverPtr[_serverIndex];

			// For each connection.
			for (auto& e : server->get_connections())
			{
				// Get the connection ref.
				all_connections.insert(e->webContext);
			}
		}
		else
		{
			// Get the server ref.
			auto server = serverSecurePtr[_serverIndex];

			// For each connection.
			for (auto& e : server->get_connections())
			{
				// Get the connection ref.
				all_connections.insert(e->webContext);
			}
		}
	}

	// Return the connections.
	return all_connections;
}

///	<summary>
///	Accept connections for the server.
///	</summary>
/// <param name="webServer">The web server instance.</param>
/// <param name="server">The server instance.</param>
/// <param name="handler">The web context callback function.</param>
void Accept(WebServer* webServer, std::shared_ptr<InternalWebSocketServer> server, std::function<void(const WebContext*)> handler)
{
	// ws://localhost:8080/echo
	// auto& listener = server->endpoint["^/echo/?$"];

	// ws://localhost:8080/
	auto& listener = server->endpoint["^/?$"];

	// Open connection.
	listener.onopen = [&webServer, &handler](std::shared_ptr<InternalWebSocketServer::Connection> connection)
	{
		// Assign web context details.
		connection->webContext->SetIsSecure(webServer->IsSecure());
		connection->webContext->SetIPVersionType(webServer->IPVersion());
		connection->webContext->SetPort(webServer->Port());
		connection->webContext->SetServerName(webServer->GetServerName());

		// Make the web context.
		MakeWebContext(connection->webContext, connection);

		// Execute the web context handler.
		handler(connection->webContext.get());

		// If timeout connect cancelled.
		connection->CancelTimeoutConnect(connection->webContext->TimeoutConnectCancelled());
	};

	// Close connection.
	listener.onclose = [](std::shared_ptr<InternalWebSocketServer::Connection> connection, int status, const std::string& reason)
	{
		// If handler exists.
		if (connection->webContext != nullptr && connection->webContext->OnClose)
		{
			// Call close.
			connection->webContext->OnClose(status, reason);
			connection->webContext = nullptr;
		}
	};

	// Connection error.
	listener.onerror = [](std::shared_ptr<InternalWebSocketServer::Connection> connection, const boost::system::error_code& ec)
	{
		// If handler exists.
		if (connection->webContext != nullptr && connection->webContext->OnError)
		{
			// Call error.
			connection->webContext->OnError(ec.message());
		}
	};

	// Access expiry
	listener.onaccessexpiry = [](std::shared_ptr<InternalWebSocketServer::Connection> connection, std::shared_ptr<InternalWebSocketServer::Message> message)
	{
		// If handler exists.
		if (connection->webContext != nullptr && connection->webContext->OnAccessExpiry)
		{
			// Get the request and response.
			auto webMessage = connection->webContext->Message();

			// Call message.
			connection->webContext->OnAccessExpiry(webMessage);
		}
	};

	// Message.
	listener.onmessage = [](std::shared_ptr<InternalWebSocketServer::Connection> connection, std::shared_ptr<InternalWebSocketServer::Message> message)
	{
		// If handler exists.
		if (connection->webContext != nullptr && connection->webContext->OnMessage)
		{
			MessageType messageType = MessageType::Text;

			// Text
			if ((message->fin_rsv_opcode & 0x0f) == 1)
				messageType = MessageType::Text;

			// Binary
			if ((message->fin_rsv_opcode & 0x0f) == 2)
				messageType = MessageType::Binary;

			// Close
			if ((message->fin_rsv_opcode & 0x0f) == 8)
				messageType = MessageType::Close;

			// Ping
			if ((message->fin_rsv_opcode & 0x0f) == 9)
				messageType = MessageType::Ping;

			// Get the request and response.
			auto webMessage = connection->webContext->Message();
			webMessage->Received = message->rdbuf();

			// Call message.
			connection->webContext->OnMessage(messageType, message->size(), webMessage);
			if (connection->webContext != nullptr)
			{
				// If timeout connect cancelled.
				connection->CancelTimeoutConnect(connection->webContext->TimeoutConnectCancelled());

				// Check to see if there is an access expiry.
				connection->StartAccessExpiry(connection->webContext->AccessExpiry());
			}
		}
	};

	// Start the server.
	server->start();
}

///	<summary>
///	Accept connections for the server.
///	</summary>
/// <param name="webServer">The web server instance.</param>
/// <param name="server">The server instance.</param>
/// <param name="handler">The web context callback function.</param>
void AcceptSecure(WebServer* webServer, std::shared_ptr<InternalSecureWebSocketServer> server, std::function<void(const WebContext*)> handler)
{
	// ws://localhost:8080/echo
	// auto& listener = server->endpoint["^/echo/?$"];

	// ws://localhost:8080/
	auto& listener = server->endpoint["^/?$"];

	// Open connection.
	listener.onopen = [&webServer, &handler](std::shared_ptr<InternalSecureWebSocketServer::Connection> connection)
	{
		// Assign web context details.
		connection->webContext->SetIsSecure(webServer->IsSecure());
		connection->webContext->SetIPVersionType(webServer->IPVersion());
		connection->webContext->SetPort(webServer->Port());
		connection->webContext->SetServerName(webServer->GetServerName());

		// Make the web context.
		MakeSecureWebContext(connection->webContext, connection);

		// Execute the web context handler.
		handler(connection->webContext.get());
	};

	// Close connection.
	listener.onclose = [](std::shared_ptr<InternalSecureWebSocketServer::Connection> connection, int status, const std::string& reason)
	{
		// If handler exists.
		if (connection->webContext != nullptr && connection->webContext->OnClose)
		{
			// Call close.
			connection->webContext->OnClose(status, reason);
			connection->webContext = nullptr;
		}
	};

	// Connection error.
	listener.onerror = [](std::shared_ptr<InternalSecureWebSocketServer::Connection> connection, const boost::system::error_code& ec)
	{
		// If handler exists.
		if (connection->webContext != nullptr && connection->webContext->OnError)
		{
			// Call error.
			connection->webContext->OnError(ec.message());
		}
	};

	// Access expiry
	listener.onaccessexpiry = [](std::shared_ptr<InternalSecureWebSocketServer::Connection> connection, std::shared_ptr<InternalSecureWebSocketServer::Message> message)
	{
		// If handler exists.
		if (connection->webContext != nullptr && connection->webContext->OnAccessExpiry)
		{
			// Get the request and response.
			auto webMessage = connection->webContext->Message();

			// Call message.
			connection->webContext->OnAccessExpiry(webMessage);
		}
	};

	// Message.
	listener.onmessage = [](std::shared_ptr<InternalSecureWebSocketServer::Connection> connection, std::shared_ptr<InternalSecureWebSocketServer::Message> message)
	{
		// If handler exists.
		if (connection->webContext != nullptr && connection->webContext->OnMessage)
		{
			MessageType messageType = MessageType::Text;

			// Text
			if ((message->fin_rsv_opcode & 0x0f) == 1)
				messageType = MessageType::Text;

			// Binary
			if ((message->fin_rsv_opcode & 0x0f) == 2)
				messageType = MessageType::Binary;

			// Close
			if ((message->fin_rsv_opcode & 0x0f) == 8)
				messageType = MessageType::Close;

			// Ping
			if ((message->fin_rsv_opcode & 0x0f) == 9)
				messageType = MessageType::Ping;

			// Get the request and response.
			auto webMessage = connection->webContext->Message();
			webMessage->Received = message->rdbuf();

			// Call message.
			connection->webContext->OnMessage(messageType, message->size(), webMessage);
			if (connection->webContext != nullptr)
			{
				// If timeout connect cancelled.
				connection->CancelTimeoutConnect(connection->webContext->TimeoutConnectCancelled());

				// Check to see if there is an access expiry.
				connection->StartAccessExpiry(connection->webContext->AccessExpiry());
			}
		}
	};

	// Start the server.
	server->start();
}

///	<summary>
///	Stop the server.
///	</summary>
/// <param name="server">The server instance.</param>
void StopAccept(std::shared_ptr<InternalWebSocketServer> server)
{
	server->stop();
}

///	<summary>
///	Stop the server.
///	</summary>
/// <param name="server">The server instance.</param>
void StopAcceptSecure(std::shared_ptr<InternalSecureWebSocketServer> server)
{
	server->stop();
}

///	<summary>
///	Create the web context from the response and request.
///	</summary>
/// <param name="context">The web context.</param>
/// <param name="connection">The connection.</param>
void MakeWebContext(std::shared_ptr<WebContext> context, 
	std::shared_ptr<InternalWebSocketServer::Connection> connection)
{
	// Get the request and response.
	auto webRequest = context->Request();
	auto webMessage = context->Message();

	// Assign values.
	webRequest->SetMethod(connection->method);
	webRequest->SetPath(connection->path);
	webRequest->SetProtocolVersion(connection->http_version);
	webRequest->SetRemoteEndpointAddress(connection->remote_endpoint_address);
	webRequest->SetRemoteEndpointPort(connection->remote_endpoint_port);

	// Assign the headers.
	std::map<std::string, std::string> headers;
	typedef std::pair<std::string, std::string> headerPair;

	// For each header.
	for (auto& h : connection->header)
	{
		// Write header name and value.
		headers.insert(headerPair(h.first.c_str(), h.second.c_str()));
	}

	// Assign the header and content.
	webRequest->SetHeaders(headers);

	// Set the send message handler.
	webMessage->OnSend = [](MessageType messageType, std::streambuf* message, std::shared_ptr<void> connectionHandler)
	{
		// Create send stream.
		auto sendStream = std::make_shared<InternalWebSocketServer::SendStream>();
		*sendStream << message;

		unsigned char opcode = 129;

		// Set opcode
		switch (messageType)
		{
		case Nequeo::Net::WebSocket::MessageType::Text:
			opcode = 129;
			break;
		case Nequeo::Net::WebSocket::MessageType::Binary:
			opcode = 130;
			break;
		case Nequeo::Net::WebSocket::MessageType::Close:
			opcode = 136;
			break;
		case Nequeo::Net::WebSocket::MessageType::Ping:
			opcode = 137;
			break;
		default:
			break;
		}

		// Cast back.
		std::shared_ptr<InternalWebSocketServer::Connection> connHandler = 
			std::static_pointer_cast<InternalWebSocketServer::Connection>(connectionHandler);

		// Send the message.
		connHandler->socketServer->send(connHandler, sendStream,
			[&connHandler](const boost::system::error_code& ec)
		{
			try
			{
			}
			catch (...) {}

		}, opcode);
	};
}

///	<summary>
///	Create the web context from the response and request.
///	</summary>
/// <param name="context">The web context.</param>
/// <param name="connection">The connection.</param>
void MakeSecureWebContext(std::shared_ptr<WebContext> context, 
	std::shared_ptr<InternalSecureWebSocketServer::Connection> connection)
{
	// Get the request and response.
	auto webRequest = context->Request();
	auto webMessage = context->Message();

	// Assign values.
	webRequest->SetMethod(connection->method);
	webRequest->SetPath(connection->path);
	webRequest->SetProtocolVersion(connection->http_version);
	webRequest->SetRemoteEndpointAddress(connection->remote_endpoint_address);
	webRequest->SetRemoteEndpointPort(connection->remote_endpoint_port);

	// Assign the headers.
	std::map<std::string, std::string> headers;
	typedef std::pair<std::string, std::string> headerPair;

	// For each header.
	for (auto& h : connection->header)
	{
		// Write header name and value.
		headers.insert(headerPair(h.first.c_str(), h.second.c_str()));
	}

	// Assign the header and content.
	webRequest->SetHeaders(headers);

	// Set the send message handler.
	webMessage->OnSend = [](MessageType messageType, std::streambuf* message, std::shared_ptr<void> connectionHandler)
	{
		// Create send stream.
		auto sendStream = std::make_shared<InternalSecureWebSocketServer::SendStream>();
		*sendStream << message;

		unsigned char opcode = 129;

		// Set opcode
		switch (messageType)
		{
		case Nequeo::Net::WebSocket::MessageType::Text:
			opcode = 129;
			break;
		case Nequeo::Net::WebSocket::MessageType::Binary:
			opcode = 130;
			break;
		case Nequeo::Net::WebSocket::MessageType::Close:
			opcode = 136;
			break;
		case Nequeo::Net::WebSocket::MessageType::Ping:
			opcode = 137;
			break;
		default:
			break;
		}

		// Cast back.
		std::shared_ptr<InternalSecureWebSocketServer::Connection> connHandler =
			std::static_pointer_cast<InternalSecureWebSocketServer::Connection>(connectionHandler);

		// Send the message.
		connHandler->socketServer->send(connHandler, sendStream,
			[&connHandler](const boost::system::error_code& ec)
		{
			try
			{
			}
			catch (...) {}

		}, opcode);
	};
}