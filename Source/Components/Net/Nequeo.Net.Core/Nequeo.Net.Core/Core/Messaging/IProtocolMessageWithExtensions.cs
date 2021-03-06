﻿/*  Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
 *  Copyright :     Copyright © Nequeo Pty Ltd 2012 http://www.nequeo.com.au/
 * 
 *  File :          
 *  Purpose :       
 * 
 */

#region Nequeo Pty Ltd License
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
#endregion


namespace Nequeo.Net.Core.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.Contracts;

	/// <summary>
	/// A protocol message that supports adding extensions to the payload for transmission.
	/// </summary>
	[ContractClass(typeof(IProtocolMessageWithExtensionsContract))]
	public interface IProtocolMessageWithExtensions : IProtocolMessage {
		/// <summary>
		/// Gets the list of extensions that are included with this message.
		/// </summary>
		/// <remarks>
		/// Implementations of this interface should ensure that this property never returns null.
		/// </remarks>
		IList<IExtensionMessage> Extensions { get; }
	}

	/// <summary>
	/// Code contract for the <see cref="IProtocolMessageWithExtensions"/> interface.
	/// </summary>
	[ContractClassFor(typeof(IProtocolMessageWithExtensions))]
    public abstract class IProtocolMessageWithExtensionsContract : IProtocolMessageWithExtensions
    {
		/// <summary>
		/// Prevents a default instance of the <see cref="IProtocolMessageWithExtensionsContract"/> class from being created.
		/// </summary>
		private IProtocolMessageWithExtensionsContract() {
		}

		#region IProtocolMessageWithExtensions Members

		/// <summary>
		/// Gets the list of extensions that are included with this message.
		/// </summary>
		/// <remarks>
		/// Implementations of this interface should ensure that this property never returns null.
		/// </remarks>
		IList<IExtensionMessage> IProtocolMessageWithExtensions.Extensions {
			get {
				Contract.Ensures(Contract.Result<IList<IExtensionMessage>>() != null);
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IProtocolMessage Members

		/// <summary>
		/// Gets the level of protection this message requires.
		/// </summary>
		MessageProtections IProtocolMessage.RequiredProtection {
			get { throw new NotImplementedException(); }
		}

		/// <summary>
		/// Gets a value indicating whether this is a direct or indirect message.
		/// </summary>
		MessageTransport IProtocolMessage.Transport {
			get { throw new NotImplementedException(); }
		}

		#endregion

		#region IMessage Members

		/// <summary>
		/// Gets the version of the protocol or extension this message is prepared to implement.
		/// </summary>
		/// <remarks>
		/// Implementations of this interface should ensure that this property never returns null.
		/// </remarks>
		Version IMessage.Version {
			get {
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Gets the extra, non-standard Protocol parameters included in the message.
		/// </summary>
		/// <remarks>
		/// Implementations of this interface should ensure that this property never returns null.
		/// </remarks>
		IDictionary<string, string> IMessage.ExtraData {
			get {
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Checks the message state for conformity to the protocol specification
		/// and throws an exception if the message is invalid.
		/// </summary>
		/// <remarks>
		/// 	<para>Some messages have required fields, or combinations of fields that must relate to each other
		/// in specialized ways.  After deserializing a message, this method checks the state of the
		/// message to see if it conforms to the protocol.</para>
		/// 	<para>Note that this property should <i>not</i> check signatures or perform any state checks
		/// outside this scope of this particular message.</para>
		/// </remarks>
		/// <exception cref="ProtocolException">Thrown if the message is invalid.</exception>
		void IMessage.EnsureValidMessage() {
			throw new NotImplementedException();
		}

		#endregion
	}
}
