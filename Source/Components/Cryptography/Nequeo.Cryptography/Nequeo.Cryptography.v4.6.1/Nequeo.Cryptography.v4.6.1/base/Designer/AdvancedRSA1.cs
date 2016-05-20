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

namespace Nequeo.Cryptography
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
    
    #region AdvancedRSA Extension Type
    /// <summary>
    /// The AdvancedRSA object class.
    /// </summary>
    public partial class AdvancedRSA
    {
        private Exception _exception = null;
		private AdvancedRSAThread _threadAdvancedRSAContext = null;

		/// <summary>
        /// Gets the current async exception; else null;
        /// </summary>
        public Exception ExceptionAdvancedRSA
        {
            get { return _exception; }
        }

		/// <summary>
        /// Gets the AdvancedRSA threading context.
        /// </summary>
        public AdvancedRSAThread AdvancedRSAThreadContext
        {
            get { return _threadAdvancedRSAContext; }
        }

		/// <summary>
        /// On create.
        /// </summary>
        partial void OnCreated();

		/// <summary>
        /// On create instance of AdvancedRSA
        /// </summary>
		partial void OnCreated()
		{
			// Start the async control.
			_threadAdvancedRSAContext = new AdvancedRSAThread(this);
			_threadAdvancedRSAContext.AsyncError += new Threading.EventHandler<Exception>(_asyncAccount_AsyncError);
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
        /// AdvancedRSA threading handler.
        /// </summary>
        public class AdvancedRSAThread : Nequeo.Threading.AsyncExecutionHandler<AdvancedRSA>
        {
            /// <summary>
            /// AdvancedRSA threading handler.
            /// </summary>
            /// <param name="service">The AdvancedRSA type.</param>
            public AdvancedRSAThread(AdvancedRSA service)
                : base(service) { }
        }
    }
    #endregion
}

#pragma warning restore 169
