﻿/*  Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
 *  Copyright :     Copyright © Nequeo Pty Ltd 2010 http://www.nequeo.com.au/
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Web;
using System.Reflection;
using System.Runtime.Remoting;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Specialized;

namespace Nequeo.Net.Http
{
    /// <summary>
    /// Http server response.
    /// </summary>
    public sealed class HttpResponse : Nequeo.Net.WebResponse
    {
        private string _deli = "\r\n";

        /// <summary>
        /// Configures the response to redirect the client to the specified URL.
        /// </summary>
        /// <param name="url">The URL that the client should use to locate the requested resource.</param>
        public void Redirect(string url)
        {
            // Get the redirection code.
            Nequeo.Net.Http.Common.HttpStatusCode statusCode = Nequeo.Net.Http.Utility.GetStatusCode(302);
            if (statusCode != null)
            {
                // Assign the status code.
                StatusCode = statusCode.Code;
                StatusDescription = statusCode.Description;
            }

            // Add the location header used for redirection.
            AddHeader("Location", url);
        }

        /// <summary>
        /// Write the response status to the stream.
        /// </summary>
        public void WriteHttpHeaders()
        {
            byte[] buffer = null;
            string data = "";

            // Write the response status to the stream.
            WriteWebResponseHeaders(false);

            // Send the header end space.
            data = _deli;
            buffer = Encoding.Default.GetBytes(data);
            Write(buffer, 0, buffer.Length);
        }
    }
}
