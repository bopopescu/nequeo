//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nequeo.DataAccess.ApplicationLogin.Data.Extended
{
    using System;
    using System.Linq;
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
    using Nequeo.Data.DataType;
    using Nequeo.Data;
    using Nequeo.Data.Linq;
    using Nequeo.Data.Control;
    using Nequeo.Data.Custom;
    using Nequeo.Data.LinqToSql;
    using Nequeo.Data.DataSet;
    using Nequeo.Data.Edm;
    using Nequeo.ComponentModel;
    
    
    #region RoleTypeList Data Type
    /// <summary>
    /// The roletypelist data object class.
    /// </summary>
    [DataContractAttribute(Name = "RoleTypeList", IsReference = true)]
    [SerializableAttribute()]
    [KnownTypeAttribute(typeof(DataBase))]
    public partial class RoleTypeList : DataBase
    {
        
        private long _RoleTypeID;
        
        private string _RoleTypeName;
        
        private long _RoleTypeCodeID;
        
        #region Extensibility Method Definitions
        /// <summary>
        /// On create data entity.
        /// </summary>
		partial void OnCreated();

        /// <summary>
        /// On load data entity.
        /// </summary>
		partial void OnLoaded();

		#endregion
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public RoleTypeList()
        {
            OnCreated();
        }
        
        /// <summary>
        /// Gets sets, the roletypeid property for the object.
        /// </summary>
        [CategoryAttribute("Column")]
        [DescriptionAttribute("Gets sets, the roletypeid property for the object.")]
        [DataMemberAttribute(Name = "RoleTypeID")]
        [XmlElementAttribute(ElementName = "RoleTypeID", IsNullable = false)]
        [SoapElementAttribute(IsNullable = false)]
        public long RoleTypeID
        {
            get
            {
                return this._RoleTypeID;
            }
            set
            {
                if ((this._RoleTypeID != value))
                {
                    this._RoleTypeID = value;
                }
            }
        }
        
        /// <summary>
        /// Gets sets, the roletypename property for the object.
        /// </summary>
        [CategoryAttribute("Column")]
        [DescriptionAttribute("Gets sets, the roletypename property for the object.")]
        [DataMemberAttribute(Name = "RoleTypeName")]
        [XmlElementAttribute(ElementName = "RoleTypeName", IsNullable = false)]
        [SoapElementAttribute(IsNullable = false)]
        public string RoleTypeName
        {
            get
            {
                return this._RoleTypeName;
            }
            set
            {
                if ((this._RoleTypeName != value))
                {
                    this._RoleTypeName = value;
                }
            }
        }
        
        /// <summary>
        /// Gets sets, the roletypecodeid property for the object.
        /// </summary>
        [CategoryAttribute("Column")]
        [DescriptionAttribute("Gets sets, the roletypecodeid property for the object.")]
        [DataMemberAttribute(Name = "RoleTypeCodeID")]
        [XmlElementAttribute(ElementName = "RoleTypeCodeID", IsNullable = false)]
        [SoapElementAttribute(IsNullable = false)]
        public long RoleTypeCodeID
        {
            get
            {
                return this._RoleTypeCodeID;
            }
            set
            {
                if ((this._RoleTypeCodeID != value))
                {
                    this._RoleTypeCodeID = value;
                }
            }
        }
        
        /// <summary>
        /// Create a new roletypelist data entity.
        /// </summary>
        /// <param name="roleTypeID">Initial value of RoleTypeID.</param>
        /// <param name="roleTypeName">Initial value of RoleTypeName.</param>
        /// <param name="roleTypeCodeID">Initial value of RoleTypeCodeID.</param>
        /// <returns>The Data.Extended.RoleTypeList entity.</returns>
        public static Data.Extended.RoleTypeList CreateRoleTypeList(long roleTypeID, string roleTypeName, long roleTypeCodeID)
        {
            Data.Extended.RoleTypeList roleTypeList = new Data.Extended.RoleTypeList();
            roleTypeList.RoleTypeID = roleTypeID;
            roleTypeList.RoleTypeName = roleTypeName;
            roleTypeList.RoleTypeCodeID = roleTypeCodeID;
            return roleTypeList;
        }
    }
    #endregion
}
