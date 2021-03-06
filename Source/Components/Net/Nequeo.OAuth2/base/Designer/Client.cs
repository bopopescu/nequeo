﻿// Warning 169 (Disables the 'Never used' warning)
#pragma warning disable 169
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nequeo.Net.OAuth2
{
    using System;
    using System.Text;
    using System.Data;
    using System.Threading;
    using System.Diagnostics;
    using System.Data.SqlClient;
    using System.Data.OleDb;
    using System.Data.Odbc;
    using System.Collections;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.Runtime.Serialization;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    
    #region AuthClient Extension Type
    /// <summary>
    /// The AuthClient object class.
    /// </summary>
    public partial class AuthClient
    {
        private Exception _exception = null;
		private AuthClientThread _threadAuthClientContext = null;

		/// <summary>
        /// Gets the current async exception; else null;
        /// </summary>
        public Exception ExceptionAuthClient
        {
            get { return _exception; }
        }

		/// <summary>
        /// Gets the AuthClient threading context.
        /// </summary>
        public AuthClientThread AuthClientThreadContext
        {
            get { return _threadAuthClientContext; }
        }

		/// <summary>
        /// On create.
        /// </summary>
        partial void OnCreated();

		/// <summary>
        /// On create instance of AuthClient
        /// </summary>
		partial void OnCreated()
		{
			// Start the async control.
			_threadAuthClientContext = new AuthClientThread(this);
			_threadAuthClientContext.AsyncError += new Threading.EventHandler<Exception>(_asyncAccount_AsyncError);
		}

		/// <summary>
        /// Async error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e1"></param>
        private void _asyncAccount_AsyncError(object sender, Exception e1)
        {
            _exception = e1;
        }

		/// <summary>
        /// AuthClient threading handler.
        /// </summary>
        public class AuthClientThread : Nequeo.Threading.AsyncExecutionHandler<AuthClient>
        {
            /// <summary>
            /// AuthClient threading handler.
            /// </summary>
            /// <param name="service">The AuthClient type.</param>
            public AuthClientThread(AuthClient service)
                : base(service) { }
        }
    }
    #endregion
}

#pragma warning restore 169
