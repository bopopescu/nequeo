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

namespace Nequeo.Net.OAuth2.Provider.Session.ChannelElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    using Nequeo.Net.Core.Messaging;
    using Nequeo.Net.Core.Messaging.Reflection;
    using Nequeo.Net.OAuth2.Framework;
    using Nequeo.Net.OAuth2.Framework.Utility;
    using Nequeo.Net.OAuth2.Framework.Messages;
    using Nequeo.Net.OAuth2.Framework.ChannelElements;
    using Nequeo.Net.OAuth2.Consumer.Session.ChannelElements;
    using Nequeo.Net.OAuth2.Consumer.Session.Messages;
    using Nequeo.Net.OAuth2.Consumer.Session.Authorization.Messages;
    using Nequeo.Net.OAuth2.Provider.Session.ChannelElements;
    using Nequeo.Net.OAuth2.Provider.Session.Messages;

    /// <summary>
    /// Reads client authentication information from the message payload itself (POST entity as a URI-encoded parameter).
    /// </summary>
    public class ClientCredentialMessagePartReader : ClientAuthenticationModule
    {
        /// <summary>
        /// Attempts to extract client identification/authentication information from a message.
        /// </summary>
        /// <param name="authorizationServerHost">The authorization server host.</param>
        /// <param name="requestMessage">The incoming message.</param>
        /// <param name="clientIdentifier">Receives the client identifier, if one was found.</param>
        /// <returns>The level of the extracted client information.</returns>
        public override ClientAuthenticationResult TryAuthenticateClient(IAuthorizationServerHost authorizationServerHost, AuthenticatedClientRequestBase requestMessage, out string clientIdentifier)
        {
            clientIdentifier = requestMessage.ClientIdentifier;
            return TryAuthenticateClientBySecret(authorizationServerHost, requestMessage.ClientIdentifier, requestMessage.ClientSecret);
        }
    }
}
