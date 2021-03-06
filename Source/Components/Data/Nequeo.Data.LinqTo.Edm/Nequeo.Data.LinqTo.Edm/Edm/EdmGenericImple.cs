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
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq.Expressions;
using System.Reflection.Emit;

using LinqTypes = Nequeo.Data.DataType.ProviderToDataTypes;

using Nequeo.Data.DataType;
using Nequeo.Data.Control;

namespace Nequeo.Data.Edm
{
    /// <summary>
    /// The base generic data access layer.
    /// </summary>
    /// <typeparam name="TDataContext">The linq connection context type.</typeparam>
    /// <typeparam name="TLinqEntity">The linq entity type.</typeparam>
    public class EdmAnonymousGenericBase<TDataContext, TLinqEntity> :
        Disposable, IEdmAnonymousGenericBase<TDataContext, TLinqEntity>
        where TDataContext : System.Data.Entity.DbContext, new()
        where TLinqEntity : class, new()
    {
        #region EdmAnonymousGenericBase Implementation Class

        #region Constructors
        /// <summary>
        /// Constructor for the current class.
        /// </summary>
        /// <param name="schemaName">The current data schema item object name.</param>
        /// <param name="connectionType">The connection type to use.</param>
        /// <param name="connectionDataType">The connection data type to use.</param>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public EdmAnonymousGenericBase(string schemaName, ConnectionContext.ConnectionType connectionType,
            ConnectionContext.ConnectionDataType connectionDataType, IDataAccess dataAccessProvider)
        {
            // Check to see if the critical parameters
            // have been set, throw exception on each.
            if (String.IsNullOrEmpty(schemaName)) throw new ArgumentNullException("schemaName");

            _connectionType = connectionType;
            _connectionDataType = connectionDataType;
            _dataAccessProvider = dataAccessProvider;
            _schemaItem = schemaName;
        }
        #endregion

        #region Private Fields
        private string _schemaItem = String.Empty;
        private ConnectionContext.ConnectionType _connectionType = ConnectionContext.ConnectionType.None;
        private ConnectionContext.ConnectionDataType _connectionDataType = ConnectionContext.ConnectionDataType.None;
        private IDataAccess _dataAccessProvider;
        #endregion

        #region Public Select Properties
        /// <summary>
        /// Gets, the select generic members.
        /// </summary>
        public ISelectEdmGenericBase<TDataContext, TLinqEntity> Select
        {
            get
            {
                return new SelectEdmGenericBase<TDataContext, TLinqEntity>(
                        _schemaItem, _connectionType, _connectionDataType, _dataAccessProvider);
            }
        }
        #endregion

        #region Public Delete Properties
        /// <summary>
        /// Gets, the select generic members.
        /// </summary>
        public IDeleteEdmGenericBase<TDataContext, TLinqEntity> Delete
        {
            get
            {
                return new DeleteEdmGenericBase<TDataContext, TLinqEntity>(
                        _schemaItem, _connectionType, _connectionDataType, _dataAccessProvider);
            }
        }
        #endregion

        #region Public Insert Properties
        /// <summary>
        /// Gets, the select generic members.
        /// </summary>
        public IInsertEdmGenericBase<TDataContext, TLinqEntity> Insert
        {
            get
            {
                return new InsertEdmGenericBase<TDataContext, TLinqEntity>(
                        _schemaItem, _connectionType, _connectionDataType, _dataAccessProvider);
            }
        }
        #endregion

        #region Public Update Properties
        /// <summary>
        /// Gets, the select generic members.
        /// </summary>
        public IUpdateEdmGenericBase<TDataContext, TLinqEntity> Update
        {
            get
            {
                return new UpdateEdmGenericBase<TDataContext, TLinqEntity>(
                        _schemaItem, _connectionType, _connectionDataType, _dataAccessProvider);
            }
        }
        #endregion

        #region Data Base Properties
        /// <summary>
        /// Gets, the data generic base members.
        /// </summary>
        public IEdmDataGenericBase<TDataContext, TLinqEntity> Common
        {
            get
            {
                return new EdmDataGenericBase<TDataContext, TLinqEntity>(
                        _schemaItem, _connectionType, _connectionDataType, _dataAccessProvider);
            }
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// The base generic data access layer.
    /// </summary>
    /// <typeparam name="TDataContext">The linq connection context type.</typeparam>
    /// <typeparam name="TLinqEntity">The linq entity type.</typeparam>
    public class EdmGenericBase<TDataContext, TLinqEntity> :
        Disposable, IEdmGenericBase<TDataContext, TLinqEntity>
        where TDataContext : System.Data.Entity.DbContext, new()
        where TLinqEntity : class, new()
    {
        #region EdmGenericBase Implementation Class

        #region Constructors
        /// <summary>
        /// Constructor for the current class.
        /// </summary>
        /// <param name="schemaName">The current data schema item object name.</param>
        /// <param name="connectionType">The connection type to use.</param>
        /// <param name="connectionDataType">The connection data type to use.</param>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public EdmGenericBase(string schemaName, ConnectionContext.ConnectionType connectionType,
            ConnectionContext.ConnectionDataType connectionDataType, IDataAccess dataAccessProvider)
        {
            // Check to see if the critical parameters
            // have been set, throw exception on each.
            if (String.IsNullOrEmpty(schemaName)) throw new ArgumentNullException("schemaName");

            _connectionDataType = connectionDataType;
            _connectionType = connectionType;
            _dataAccessProvider = dataAccessProvider;
            _schemaItem = schemaName;
        }
        #endregion

        #region Private Fields
        private string _schemaItem = String.Empty;
        private ConnectionContext.ConnectionType _connectionType = ConnectionContext.ConnectionType.None;
        private ConnectionContext.ConnectionDataType _connectionDataType = ConnectionContext.ConnectionDataType.None;
        private IDataAccess _dataAccessProvider;
        #endregion

        #region Public Select Properties
        /// <summary>
        /// Gets, the select generic members.
        /// </summary>
        public ISelectEdmGenericBase<TDataContext, TLinqEntity> Select
        {
            get
            {
                return new SelectEdmGenericBase<TDataContext, TLinqEntity>(
                        _schemaItem, _connectionType, _connectionDataType, _dataAccessProvider);
            }
        }
        #endregion

        #region Public Delete Properties
        /// <summary>
        /// Gets, the select generic members.
        /// </summary>
        public IDeleteEdmGenericBase<TDataContext, TLinqEntity> Delete
        {
            get
            {
                return new DeleteEdmGenericBase<TDataContext, TLinqEntity>(
                        _schemaItem, _connectionType, _connectionDataType, _dataAccessProvider);
            }
        }
        #endregion

        #region Public Insert Properties
        /// <summary>
        /// Gets, the select generic members.
        /// </summary>
        public IInsertEdmGenericBase<TDataContext, TLinqEntity> Insert
        {
            get
            {
                return new InsertEdmGenericBase<TDataContext, TLinqEntity>(
                        _schemaItem, _connectionType, _connectionDataType, _dataAccessProvider);
            }
        }
        #endregion

        #region Public Update Properties
        /// <summary>
        /// Gets, the select generic members.
        /// </summary>
        public IUpdateEdmGenericBase<TDataContext, TLinqEntity> Update
        {
            get
            {
                return new UpdateEdmGenericBase<TDataContext, TLinqEntity>(
                        _schemaItem, _connectionType, _connectionDataType, _dataAccessProvider);
            }
        }
        #endregion

        #region Data Base Properties
        /// <summary>
        /// Gets, the data generic base members.
        /// </summary>
        public IEdmDataGenericBase<TDataContext, TLinqEntity> Common
        {
            get
            {
                return new EdmDataGenericBase<TDataContext, TLinqEntity>(
                        _schemaItem, _connectionType, _connectionDataType, _dataAccessProvider);
            }
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// Data access generic data type transaction function handler.
    /// </summary>
    /// <typeparam name="TDataContext">The linq connection context type.</typeparam>
    /// <typeparam name="TLinqEntity">The linq entity type.</typeparam>
    public sealed class EdmTransactions<TDataContext, TLinqEntity> : IEdmTransactions<TDataContext, TLinqEntity>
        where TDataContext : System.Data.Entity.DbContext, new()
        where TLinqEntity : class, new()
    {
        #region DataTransactions Class

        #region Private Fields
        private string _configurationDatabaseConnection = string.Empty;
        private IInsertEdmGenericBase<TDataContext, TLinqEntity> _insertInstance;
        private IDeleteEdmGenericBase<TDataContext, TLinqEntity> _deleteInstance;
        private IUpdateEdmGenericBase<TDataContext, TLinqEntity> _updateInstance;
        private ISelectEdmGenericBase<TDataContext, TLinqEntity> _selectInstance;
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="configurationDatabaseConnection">The connection string or configuration key.</param>
        /// <param name="insertInstance">The insert instance; can be null if not in use.</param>
        /// <param name="deleteInstance">The delete instance; can be null if not in use.</param>
        /// <param name="updateInstance">The update instance; can be null if not in use.</param>
        /// <param name="selectInstance">The select instance; can be null if not in use.</param>
        public EdmTransactions(
            string configurationDatabaseConnection,
            IInsertEdmGenericBase<TDataContext, TLinqEntity> insertInstance,
            IDeleteEdmGenericBase<TDataContext, TLinqEntity> deleteInstance,
            IUpdateEdmGenericBase<TDataContext, TLinqEntity> updateInstance,
            ISelectEdmGenericBase<TDataContext, TLinqEntity> selectInstance)
        {
            // Check to see if the critical parameters
            // have been set, throw exception on each.
            if (String.IsNullOrEmpty(configurationDatabaseConnection)) throw new ArgumentNullException("configurationDatabaseConnection");

            _configurationDatabaseConnection = configurationDatabaseConnection;
            _insertInstance = insertInstance;
            _deleteInstance = deleteInstance;
            _updateInstance = updateInstance;
            _selectInstance = selectInstance;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="configurationDatabaseConnection">The connection string or configuration key.</param>
        /// <param name="connectionType">The database connection type.</param>
        /// <param name="connectionDataType">The database connection query type.</param>
        /// <param name="dataAccessProvider">The data access provider.</param>
        public EdmTransactions(
            string configurationDatabaseConnection,
            Nequeo.Data.DataType.ConnectionContext.ConnectionType connectionType,
            Nequeo.Data.DataType.ConnectionContext.ConnectionDataType connectionDataType,
            IDataAccess dataAccessProvider)
        {
            // Check to see if the critical parameters
            // have been set, throw exception on each.
            if (String.IsNullOrEmpty(configurationDatabaseConnection)) throw new ArgumentNullException("configurationDatabaseConnection");

            _configurationDatabaseConnection = configurationDatabaseConnection;
            // Create an instance of each type.
            _insertInstance = new InsertEdmGenericBase<TDataContext, TLinqEntity>
                (typeof(TLinqEntity).Name, connectionType, connectionDataType, dataAccessProvider);
            _deleteInstance = new DeleteEdmGenericBase<TDataContext, TLinqEntity>
                (typeof(TLinqEntity).Name, connectionType, connectionDataType, dataAccessProvider);
            _updateInstance = new UpdateEdmGenericBase<TDataContext, TLinqEntity>
                (typeof(TLinqEntity).Name, connectionType, connectionDataType, dataAccessProvider);
            _selectInstance = new SelectEdmGenericBase<TDataContext, TLinqEntity>
                (typeof(TLinqEntity).Name, connectionType, connectionDataType, dataAccessProvider);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Execute an insert action
        /// </summary>
        /// <param name="action">The insert action to execute.</param>
        public void Insert(Nequeo.Threading.ActionHandler<IInsertEdmGenericBase<TDataContext, TLinqEntity>> action)
        {
            // Check to see if the critical parameters
            // have been set, throw exception on each.
            if (action == null) throw new ArgumentNullException("action");
            if (_insertInstance == null) throw new ArgumentNullException("insertInstance");

            _insertInstance.DataContext = new TDataContext();
            _insertInstance.DataContext.Database.Connection.ConnectionString = _insertInstance.DefaultConnection(_configurationDatabaseConnection);
            action(_insertInstance);
        }

        /// <summary>
        /// Execute an insert action
        /// </summary>
        /// <typeparam name="TResult">The data type to execute the action on.</typeparam>
        /// <param name="action">The insert action to execute.</param>
        /// <returns>The execute action return type.</returns>
        public TResult Insert<TResult>(Nequeo.Threading.FunctionHandler<TResult, IInsertEdmGenericBase<TDataContext, TLinqEntity>> action)
        {
            // Check to see if the critical parameters
            // have been set, throw exception on each.
            if (action == null) throw new ArgumentNullException("action");
            if (_insertInstance == null) throw new ArgumentNullException("insertInstance");

            _insertInstance.DataContext = new TDataContext();
            _insertInstance.DataContext.Database.Connection.ConnectionString = _insertInstance.DefaultConnection(_configurationDatabaseConnection);
            return action(_insertInstance);
        }

        /// <summary>
        /// Execute a delete action
        /// </summary>
        /// <param name="action">The delete action to execute.</param>
        public void Delete(Nequeo.Threading.ActionHandler<IDeleteEdmGenericBase<TDataContext, TLinqEntity>> action)
        {
            // Check to see if the critical parameters
            // have been set, throw exception on each.
            if (action == null) throw new ArgumentNullException("action");
            if (_deleteInstance == null) throw new ArgumentNullException("deleteInstance");

            _deleteInstance.DataContext = new TDataContext();
            _deleteInstance.DataContext.Database.Connection.ConnectionString = _insertInstance.DefaultConnection(_configurationDatabaseConnection);
            action(_deleteInstance);
        }

        /// <summary>
        /// Execute a delete action
        /// </summary>
        /// <typeparam name="TResult">The data type to execute the action on.</typeparam>
        /// <param name="action">The delete action to execute.</param>
        /// <returns>The execute action return type.</returns>
        public TResult Delete<TResult>(Nequeo.Threading.FunctionHandler<TResult, IDeleteEdmGenericBase<TDataContext, TLinqEntity>> action)
        {
            // Check to see if the critical parameters
            // have been set, throw exception on each.
            if (action == null) throw new ArgumentNullException("action");
            if (_deleteInstance == null) throw new ArgumentNullException("deleteInstance");

            _deleteInstance.DataContext = new TDataContext();
            _deleteInstance.DataContext.Database.Connection.ConnectionString = _insertInstance.DefaultConnection(_configurationDatabaseConnection);
            return action(_deleteInstance);
        }

        /// <summary>
        /// Execute an update action
        /// </summary>
        /// <param name="action">The update action to execute.</param>
        public void Update(Nequeo.Threading.ActionHandler<IUpdateEdmGenericBase<TDataContext, TLinqEntity>> action)
        {
            // Check to see if the critical parameters
            // have been set, throw exception on each.
            if (action == null) throw new ArgumentNullException("action");
            if (_updateInstance == null) throw new ArgumentNullException("updateInstance");

            _updateInstance.DataContext = new TDataContext();
            _updateInstance.DataContext.Database.Connection.ConnectionString = _insertInstance.DefaultConnection(_configurationDatabaseConnection);
            action(_updateInstance);
        }

        /// <summary>
        /// Execute an update action
        /// </summary>
        /// <typeparam name="TResult">The data type to execute the action on.</typeparam>
        /// <param name="action">The update action to execute.</param>
        /// <returns>The execute action return type.</returns>
        public TResult Update<TResult>(Nequeo.Threading.FunctionHandler<TResult, IUpdateEdmGenericBase<TDataContext, TLinqEntity>> action)
        {
            // Check to see if the critical parameters
            // have been set, throw exception on each.
            if (action == null) throw new ArgumentNullException("action");
            if (_updateInstance == null) throw new ArgumentNullException("updateInstance");

            _updateInstance.DataContext = new TDataContext();
            _updateInstance.DataContext.Database.Connection.ConnectionString = _insertInstance.DefaultConnection(_configurationDatabaseConnection);
            return action(_updateInstance);
        }

        /// <summary>
        /// Execute a select action
        /// </summary>
        /// <param name="action">The select action to execute.</param>
        /// <param name="lazyLoading">Should lazy loading of references be applied.</param>
        public void Select(Nequeo.Threading.ActionHandler<ISelectEdmGenericBase<TDataContext, TLinqEntity>> action, Boolean lazyLoading = false)
        {
            // Check to see if the critical parameters
            // have been set, throw exception on each.
            if (action == null) throw new ArgumentNullException("action");
            if (_selectInstance == null) throw new ArgumentNullException("selectInstance");

            _selectInstance.DataContext = new TDataContext();
            _selectInstance.DataContext.Configuration.LazyLoadingEnabled = lazyLoading;
            _selectInstance.DataContext.Database.Connection.ConnectionString = _insertInstance.DefaultConnection(_configurationDatabaseConnection);
            action(_selectInstance);
        }

        /// <summary>
        /// Execute a select action
        /// </summary>
        /// <typeparam name="TResult">The data type to execute the action on.</typeparam>
        /// <param name="action">The select action to execute.</param>
        /// <param name="lazyLoading">Should lazy loading of references be applied.</param>
        /// <returns>The execute action return type.</returns>
        public TResult Select<TResult>(Nequeo.Threading.FunctionHandler<TResult, ISelectEdmGenericBase<TDataContext, TLinqEntity>> action, Boolean lazyLoading = false)
        {
            // Check to see if the critical parameters
            // have been set, throw exception on each.
            if (action == null) throw new ArgumentNullException("action");
            if (_selectInstance == null) throw new ArgumentNullException("selectInstance");

            _selectInstance.DataContext = new TDataContext();
            _selectInstance.DataContext.Configuration.LazyLoadingEnabled = lazyLoading;
            _selectInstance.DataContext.Database.Connection.ConnectionString = _insertInstance.DefaultConnection(_configurationDatabaseConnection);
            return action(_selectInstance);
        }
        #endregion

        #region Disposable class

        #region Private Fields
        private bool disposed = false;
        #endregion

        #region Dispose Object Methods.
        /// <summary>
        /// Implement IDisposable.
        /// Do not make this method virtual.
        /// A derived class should not be able to override this method.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SuppressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    if (this._insertInstance != null)
                        ((IDisposable)_insertInstance).Dispose();

                    if (this._deleteInstance != null)
                        ((IDisposable)_deleteInstance).Dispose();

                    if (this._updateInstance != null)
                        ((IDisposable)_updateInstance).Dispose();

                    if (this._selectInstance != null)
                        ((IDisposable)_selectInstance).Dispose();

                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                this._insertInstance = null;
                this._deleteInstance = null;
                this._updateInstance = null;
                this._selectInstance = null;

                // Note disposing has been done.
                disposed = true;
            }
        }

        /// <summary>
        /// Use C# destructor syntax for finalization code.
        /// This destructor will run only if the Dispose method
        /// does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructors in types derived from this class.
        /// </summary>
        ~EdmTransactions()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }
        #endregion

        #endregion

        #endregion
    }

    /// <summary>
    /// Data access generic data type transaction function handler.
    /// </summary>
    /// <typeparam name="TDataContext">The linq connection context type.</typeparam>
    /// <typeparam name="TLinqEntity">The linq entity type.</typeparam>
    public interface IEdmTransactions<TDataContext, TLinqEntity> : IDisposable
        where TDataContext : System.Data.Entity.DbContext, new()
        where TLinqEntity : class, new()
    {
        #region DataTransactions Class

        #region Public Methods
        /// <summary>
        /// Execute an insert action
        /// </summary>
        /// <param name="action">The insert action to execute.</param>
        void Insert(Nequeo.Threading.ActionHandler<IInsertEdmGenericBase<TDataContext, TLinqEntity>> action);

        /// <summary>
        /// Execute an insert action
        /// </summary>
        /// <typeparam name="TResult">The data type to execute the action on.</typeparam>
        /// <param name="action">The insert action to execute.</param>
        /// <returns>The execute action return type.</returns>
        TResult Insert<TResult>(Nequeo.Threading.FunctionHandler<TResult, IInsertEdmGenericBase<TDataContext, TLinqEntity>> action);

        /// <summary>
        /// Execute a delete action
        /// </summary>
        /// <param name="action">The delete action to execute.</param>
        void Delete(Nequeo.Threading.ActionHandler<IDeleteEdmGenericBase<TDataContext, TLinqEntity>> action);

        /// <summary>
        /// Execute a delete action
        /// </summary>
        /// <typeparam name="TResult">The data type to execute the action on.</typeparam>
        /// <param name="action">The delete action to execute.</param>
        /// <returns>The execute action return type.</returns>
        TResult Delete<TResult>(Nequeo.Threading.FunctionHandler<TResult, IDeleteEdmGenericBase<TDataContext, TLinqEntity>> action);

        /// <summary>
        /// Execute an update action
        /// </summary>
        /// <param name="action">The update action to execute.</param>
        void Update(Nequeo.Threading.ActionHandler<IUpdateEdmGenericBase<TDataContext, TLinqEntity>> action);

        /// <summary>
        /// Execute an update action
        /// </summary>
        /// <typeparam name="TResult">The data type to execute the action on.</typeparam>
        /// <param name="action">The update action to execute.</param>
        /// <returns>The execute action return type.</returns>
        TResult Update<TResult>(Nequeo.Threading.FunctionHandler<TResult, IUpdateEdmGenericBase<TDataContext, TLinqEntity>> action);

        /// <summary>
        /// Execute a select action
        /// </summary>
        /// <param name="action">The select action to execute.</param>
        /// <param name="lazyLoading">Should lazy loading of references be applied.</param>
        void Select(Nequeo.Threading.ActionHandler<ISelectEdmGenericBase<TDataContext, TLinqEntity>> action, Boolean lazyLoading = false);

        /// <summary>
        /// Execute a select action
        /// </summary>
        /// <typeparam name="TResult">The data type to execute the action on.</typeparam>
        /// <param name="action">The select action to execute.</param>
        /// <param name="lazyLoading">Should lazy loading of references be applied.</param>
        /// <returns>The execute action return type.</returns>
        TResult Select<TResult>(Nequeo.Threading.FunctionHandler<TResult, ISelectEdmGenericBase<TDataContext, TLinqEntity>> action, Boolean lazyLoading = false);

        #endregion

        #endregion
    }
}
