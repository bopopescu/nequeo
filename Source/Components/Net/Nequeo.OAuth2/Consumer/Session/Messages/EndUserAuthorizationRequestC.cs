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

namespace Nequeo.Net.OAuth2.Consumer.Session.Messages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Nequeo.Net.Core.Messaging;
    using Nequeo.Net.Core.Messaging.Reflection;
    using Nequeo.Net.OAuth2.Framework;
    using Nequeo.Net.OAuth2.Framework.Utility;
    using Nequeo.Net.OAuth2.Framework.Messages;
    using Nequeo.Net.OAuth2.Consumer.Session.ChannelElements;
    using Nequeo.Net.OAuth2.Consumer.Session.Messages;
    using Nequeo.Net.OAuth2.Consumer.Session.Authorization.Messages;

    /// <summary>
    /// A message sent by a web application Client to the AuthorizationServer
    /// via the user agent to obtain authorization from the user and prepare
    /// to issue an access token to the client if permission is granted.
    /// </summary>
    [Serializable]
    internal class EndUserAuthorizationRequestC : EndUserAuthorizationRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndUserAuthorizationRequestC"/> class.
        /// </summary>
        /// <param name="authorizationServer">The authorization server.</param>
        internal EndUserAuthorizationRequestC(AuthorizationServerDescription authorizationServer)
            : base(authorizationServer.AuthorizationEndpoint, authorizationServer.Version)
        {
        }
    }
}
