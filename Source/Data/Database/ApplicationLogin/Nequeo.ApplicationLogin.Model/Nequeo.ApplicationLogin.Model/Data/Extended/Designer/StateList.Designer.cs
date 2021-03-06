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
    
    
    #region StateList Data Type
    /// <summary>
    /// The statelist data object class.
    /// </summary>
    [DataContractAttribute(Name = "StateList", IsReference = true)]
    [SerializableAttribute()]
    [KnownTypeAttribute(typeof(DataBase))]
    public partial class StateList : DataBase
    {
        
        private long _StateID;
        
        private string _StateName;
        
        private long _StateCodeID;
        
        private long _CountryID;
        
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
        public StateList()
        {
            OnCreated();
        }
        
        /// <summary>
        /// Gets sets, the stateid property for the object.
        /// </summary>
        [CategoryAttribute("Column")]
        [DescriptionAttribute("Gets sets, the stateid property for the object.")]
        [DataMemberAttribute(Name = "StateID")]
        [XmlElementAttribute(ElementName = "StateID", IsNullable = false)]
        [SoapElementAttribute(IsNullable = false)]
        public long StateID
        {
            get
            {
                return this._StateID;
            }
            set
            {
                if ((this._StateID != value))
                {
                    this._StateID = value;
                }
            }
        }
        
        /// <summary>
        /// Gets sets, the statename property for the object.
        /// </summary>
        [CategoryAttribute("Column")]
        [DescriptionAttribute("Gets sets, the statename property for the object.")]
        [DataMemberAttribute(Name = "StateName")]
        [XmlElementAttribute(ElementName = "StateName", IsNullable = false)]
        [SoapElementAttribute(IsNullable = false)]
        public string StateName
        {
            get
            {
                return this._StateName;
            }
            set
            {
                if ((this._StateName != value))
                {
                    this._StateName = value;
                }
            }
        }
        
        /// <summary>
        /// Gets sets, the statecodeid property for the object.
        /// </summary>
        [CategoryAttribute("Column")]
        [DescriptionAttribute("Gets sets, the statecodeid property for the object.")]
        [DataMemberAttribute(Name = "StateCodeID")]
        [XmlElementAttribute(ElementName = "StateCodeID", IsNullable = false)]
        [SoapElementAttribute(IsNullable = false)]
        public long StateCodeID
        {
            get
            {
                return this._StateCodeID;
            }
            set
            {
                if ((this._StateCodeID != value))
                {
                    this._StateCodeID = value;
                }
            }
        }
        
        /// <summary>
        /// Gets sets, the countryid property for the object.
        /// </summary>
        [CategoryAttribute("Column")]
        [DescriptionAttribute("Gets sets, the countryid property for the object.")]
        [DataMemberAttribute(Name = "CountryID")]
        [XmlElementAttribute(ElementName = "CountryID", IsNullable = false)]
        [SoapElementAttribute(IsNullable = false)]
        public long CountryID
        {
            get
            {
                return this._CountryID;
            }
            set
            {
                if ((this._CountryID != value))
                {
                    this._CountryID = value;
                }
            }
        }
        
        /// <summary>
        /// Create a new statelist data entity.
        /// </summary>
        /// <param name="stateID">Initial value of StateID.</param>
        /// <param name="stateName">Initial value of StateName.</param>
        /// <param name="stateCodeID">Initial value of StateCodeID.</param>
        /// <param name="countryID">Initial value of CountryID.</param>
        /// <returns>The Data.Extended.StateList entity.</returns>
        public static Data.Extended.StateList CreateStateList(long stateID, string stateName, long stateCodeID, long countryID)
        {
            Data.Extended.StateList stateList = new Data.Extended.StateList();
            stateList.StateID = stateID;
            stateList.StateName = stateName;
            stateList.StateCodeID = stateCodeID;
            stateList.CountryID = countryID;
            return stateList;
        }
    }
    #endregion
}
