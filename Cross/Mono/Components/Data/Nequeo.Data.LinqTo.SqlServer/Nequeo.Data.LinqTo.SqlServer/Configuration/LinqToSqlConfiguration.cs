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
using System.Collections;
using System.Configuration;
using System.Xml;

namespace Nequeo.Data.Configuration
{
    #region LinqToSql Data Generic Base Configuration

    /// <summary>
    /// Class that contains the collection of all linq data
    /// entries within the configuration file.
    /// </summary>
    internal class LinqToSqlDataGenericBaseSection : ConfigurationSection
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public LinqToSqlDataGenericBaseSection()
        {
        }

        /// <summary>
        /// Gets sets, the linq data collection type.
        /// </summary>
        [ConfigurationProperty("LinqData")]
        public LinqToSqlDataCollection LinqToSqlDataSection
        {
            get { return (LinqToSqlDataCollection)this["LinqData"]; }
            set { this["LinqData"] = value; }
        }

        /// <summary>
        /// Reads XML from the configuration file.
        /// </summary>
        /// <param name="reader">The System.Xml.XmlReader object, 
        /// which reads from the configuration file.</param>
        protected override void DeserializeSection(XmlReader reader)
        {
            base.DeserializeSection(reader);
        }

        /// <summary>
        /// Creates an XML string containing an unmerged view of the 
        /// System.Configuration.ConfigurationSection
        /// object as a single section to write to a file.
        /// </summary>
        /// <param name="parentElement">The System.Configuration.ConfigurationElement 
        /// instance to use as the parent when performing the un-merge.</param>
        /// <param name="name">The name of the section to create.</param>
        /// <param name="saveMode">The System.Configuration.ConfigurationSaveMode 
        /// instance to use when writing to a string.</param>
        /// <returns>An XML string containing an unmerged view of the 
        /// System.Configuration.ConfigurationSection object.</returns>
        protected override string SerializeSection(
            ConfigurationElement parentElement, 
            string name, ConfigurationSaveMode saveMode)
        {
            return base.SerializeSection(parentElement, name, saveMode);
        }
    }

    /// <summary>
    /// Class that contains the default directory paths
    /// within the configuration file.
    /// </summary>
    internal class LinqToSqlDataGenericBaseDefaultSection : ConfigurationSection
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public LinqToSqlDataGenericBaseDefaultSection()
        {
        }

        /// <summary>
        /// Constructor with linq data attribute.
        /// </summary>
        /// <param name="linqDataName">The linq data name attribute.</param>
        public LinqToSqlDataGenericBaseDefaultSection(String linqDataName)
        {
            LinqDataName = linqDataName;
        }

        /// <summary>
        /// Gets sets, the directory name attribute value.
        /// </summary>
        [ConfigurationProperty("linqDataName", DefaultValue = "linqDataName", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 0, MaxLength = 300)]
        public String LinqDataName
        {
            get { return (String)this["linqDataName"]; }
            set { this["linqDataName"] = value; }
        }

        /// <summary>
        /// Gets sets, the linq data collection type.
        /// </summary>
        [ConfigurationProperty("LinqData")]
        public LinqToSqlDataElementDefault LinqDataSection
        {
            get { return (LinqToSqlDataElementDefault)this["LinqData"]; }
            set { this["LinqData"] = value; }
        }

        /// <summary>
        /// Reads XML from the configuration file.
        /// </summary>
        /// <param name="reader">The System.Xml.XmlReader object, 
        /// which reads from the configuration file.</param>
        protected override void DeserializeSection(XmlReader reader)
        {
            base.DeserializeSection(reader);
        }

        /// <summary>
        /// Creates an XML string containing an unmerged view of the 
        /// System.Configuration.ConfigurationSection
        ///  object as a single section to write to a file.
        /// </summary>
        /// <param name="parentElement">The System.Configuration.ConfigurationElement 
        /// instance to use as the parent when performing the un-merge.</param>
        /// <param name="name">The name of the section to create.</param>
        /// <param name="saveMode">The System.Configuration.ConfigurationSaveMode 
        /// instance to use when writing to a string.</param>
        /// <returns>An XML string containing an unmerged view of the 
        /// System.Configuration.ConfigurationSection object.</returns>
        protected override string SerializeSection(
            ConfigurationElement parentElement,
            string name, ConfigurationSaveMode saveMode)
        {
            return base.SerializeSection(parentElement, name, saveMode);
        }
    }

    /// <summary>
    /// Class that contains all the linq data attributes.
    /// </summary>
    public class LinqToSqlDataElementDefault : ConfigurationElement
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public LinqToSqlDataElementDefault()
        {
        }

        /// <summary>
        /// Constructor with linq data attributes
        /// </summary>
        /// <param name="cacheTimeOut">The cache time out attribute.</param>
        public LinqToSqlDataElementDefault(Int32 cacheTimeOut)
        {
            CacheTimeOut = cacheTimeOut;
        }

        /// <summary>
        /// Gets sets, the Cache Time Out attribute.
        /// </summary>
        [ConfigurationProperty("cacheTimeOut", DefaultValue = "120", IsRequired = true)]
        [IntegerValidator(MinValue = -1)]
        public Int32 CacheTimeOut
        {
            get { return (Int32)this["cacheTimeOut"]; }
            set { this["cacheTimeOut"] = value; }
        }
    }

    /// <summary>
    /// Class that contains all the linq data attributes.
    /// </summary>
    public class LinqToSqlDataElement : ConfigurationElement
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public LinqToSqlDataElement()
        {
        }

        /// <summary>
        /// Constructor with data attributes
        /// </summary>
        /// <param name="nameAttribute">The name attribute.</param>
        /// <param name="databaseName">The database name attribute.</param>
        /// <param name="tableName">The table name attribute.</param>
        /// <param name="referenceLazyLoading">The reference lazy loading attribute.</param>
        public LinqToSqlDataElement(String nameAttribute, String databaseName, String tableName,
            Boolean referenceLazyLoading)
        {
            Name = nameAttribute;
            DatabaseName = databaseName;
            TableName = tableName;
            ReferenceLazyLoading = referenceLazyLoading;
        }

        /// <summary>
        /// Gets sets, the name attribute.
        /// </summary>
        [ConfigurationProperty("name", DefaultValue = "default", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1)]
        public String Name
        {
            get { return (String)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// Gets sets, the connection name attribute.
        /// </summary>
        [ConfigurationProperty("databaseName", DefaultValue = "default", IsRequired = true)]
        [StringValidator(MinLength = 1)]
        public String DatabaseName
        {
            get { return (String)this["databaseName"]; }
            set { this["databaseName"] = value; }
        }

        /// <summary>
        /// Gets sets, the connection name attribute.
        /// </summary>
        [ConfigurationProperty("tableName", DefaultValue = "default", IsRequired = true)]
        [StringValidator(MinLength = 1)]
        public String TableName
        {
            get { return (String)this["tableName"]; }
            set { this["tableName"] = value; }
        }

        /// <summary>
        /// Gets sets, the connection name attribute.
        /// </summary>
        [ConfigurationProperty("referenceLazyLoading", DefaultValue = "false", IsRequired = true)]
        public Boolean ReferenceLazyLoading
        {
            get { return (Boolean)this["referenceLazyLoading"]; }
            set { this["referenceLazyLoading"] = value; }
        }
    }

    /// <summary>
    /// Class that contains all the linq data elements
    /// found in the configuration file.
    /// </summary>
    public class LinqToSqlDataCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public LinqToSqlDataCollection()
        {
            // Get the current linq data element.
            LinqToSqlDataElement linqData =
                (LinqToSqlDataElement)CreateNewElement();

            // Add the element to the collection.
            Add(linqData);
        }

        /// <summary>
        /// Create a new configuration element.
        /// </summary>
        /// <returns>A new linq data element.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new LinqToSqlDataElement();
        }

        /// <summary>
        /// Get the current element key.
        /// </summary>
        /// <param name="element">The current element.</param>
        /// <returns>The current linq data element key.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            // The current element key is the name attribute
            // of the linq data element.
            return ((LinqToSqlDataElement)element).Name;
        }

        /// <summary>
        /// Add a new linq data element type to the collection.
        /// </summary>
        /// <param name="element">The current linq data element.</param>
        public void Add(LinqToSqlDataElement element)
        {
            // Add the element to the base
            // ConfigurationElementCollection type.
            BaseAdd(element);
        }

        /// <summary>
        /// Indexer that gets the specified linq data element
        /// for the specified index.
        /// </summary>
        /// <param name="index">The index of the linq data element.</param>
        /// <returns>The current linq data element type.</returns>
        public LinqToSqlDataElement this[int index]
        {
            get { return (LinqToSqlDataElement)BaseGet(index); }
            set
            {
                // Remove the current linq data element
                // from the collection at this index.
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                // Add a new linq data element.
                BaseAdd(index, value);
            }
        }

        /// <summary>
        /// Indexer that gets the specified linq data element
        /// for the specified key name.
        /// </summary>
        /// <param name="Name">The key name of the element.</param>
        /// <returns>The current linq data element type.</returns>
        new public LinqToSqlDataElement this[string Name]
        {
            get { return (LinqToSqlDataElement)BaseGet(Name); }
        }
    }

    #endregion

    /// <summary>
    /// LinqToSql data section group configuration manager.
    /// </summary>
    public class LinqToSqlDataConfigurationManager
    {
        /// <summary>
        /// Gets, the LinqToSql data section collection.
        /// </summary>
        /// <param name="section">The config section group and section name.</param>
        /// <returns>The data collection; else null.</returns>
        public static LinqToSqlDataCollection LinqToSqlDataCollection(string section = "DataGenericBaseGroup/LinqToSqlDataGenericBaseSection")
        {
            try
            {
                // Refreshes the named section so the next time that it is retrieved it will be re-read from disk.
                System.Configuration.ConfigurationManager.RefreshSection(section);

                // Get the collection of linq data
                // configuration information
                // from the configuration manager.
                LinqToSqlDataGenericBaseSection linqData =
                    (LinqToSqlDataGenericBaseSection)System.Configuration.ConfigurationManager.GetSection(section);

                // Return the collection.
                return linqData.LinqToSqlDataSection;
            }
            catch { }
            {
                return null;
            }
        }

        /// <summary>
        /// Gets, the LinqToSql data default section elements.
        /// </summary>
        /// <param name="section">The config section group and section name.</param>
        /// <returns>The data collection; else null.</returns>
        public static LinqToSqlDataElementDefault LinqToSqlDataElement(string section = "DataGenericBaseGroup/LinqToSqlDataGenericBaseDefaultSection")
        {
            try
            {
                // Refreshes the named section so the next time that it is retrieved it will be re-read from disk.
                System.Configuration.ConfigurationManager.RefreshSection(section);

                // Get the default element
                // configuration information
                // from the configuration manager.
                LinqToSqlDataGenericBaseDefaultSection linqData =
                    (LinqToSqlDataGenericBaseDefaultSection)System.Configuration.ConfigurationManager.GetSection(section);

                // Return the element.
                return linqData.LinqDataSection;
            }
            catch { }
            {
                return null;
            }
        }
    }
}
