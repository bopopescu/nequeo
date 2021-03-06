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

namespace Nequeo.Report.NequeoCompany.Employee
{
    /// <summary>
    /// Employee reports
    /// </summary>
    public partial class Employees
    {
        /// <summary>
        /// Show WageFromToDate report
        /// </summary>
        /// <param name="reportBindingSourceCollection">The report binding source collection.</param>
        public virtual void WageFromToDateShow(Nequeo.Model.DataSource.BindingSourceData[] reportBindingSourceCollection)
        {
            // Display the report
            ShowEmbedded(
                reportBindingSourceCollection,
                "Nequeo.Report.NequeoCompany.Employee.Wage.FromToDate.rdlc",
                "Employee Wages");
        }

        /// <summary>
        /// Show WageFromToDateID report
        /// </summary>
        /// <param name="reportBindingSourceCollection">The report binding source collection.</param>
        public virtual void WageFromToDateIDShow(Nequeo.Model.DataSource.BindingSourceData[] reportBindingSourceCollection)
        {
            // Display the report
            ShowEmbedded(
                reportBindingSourceCollection,
                "Nequeo.Report.NequeoCompany.Employee.Wage.FromToDateID.rdlc",
                "Employee Wages");
        }

        /// <summary>
        /// Show WageFromToDateSummary report
        /// </summary>
        /// <param name="reportBindingSourceCollection">The report binding source collection.</param>
        public virtual void WageFromToDateSummaryShow(Nequeo.Model.DataSource.BindingSourceData[] reportBindingSourceCollection)
        {
            // Display the report
            ShowEmbedded(
                reportBindingSourceCollection,
                "Nequeo.Report.NequeoCompany.Employee.Wage.FromToDateSummary.rdlc",
                "Employee Wages");
        }

        /// <summary>
        /// Show WageFromToDateBankID report
        /// </summary>
        /// <param name="reportBindingSourceCollection">The report binding source collection.</param>
        public virtual void WageFromToDateBankIDShow(Nequeo.Model.DataSource.BindingSourceData[] reportBindingSourceCollection)
        {
            // Display the report
            ShowEmbedded(
                reportBindingSourceCollection,
                "Nequeo.Report.NequeoCompany.Employee.Wage.FromToDateBankID.rdlc",
                "Employee Wages");
        }

        /// <summary>
        /// Create WageFromToDate binding s ource data
        /// </summary>
        /// <param name="fromDate">The fromDate value</param>
        /// <param name="toDate">The toDate value</param>
        /// <returns><returns>The report binding source collection.</returns></returns>
        public virtual Nequeo.Model.DataSource.BindingSourceData[] WageFromToDate(DateTime? fromDate, DateTime? toDate)
        {
            // Assign the binding sources
            Nequeo.DataAccess.NequeoCompany.DataSet.StoredProcedures dataSet = new Nequeo.DataAccess.NequeoCompany.DataSet.StoredProcedures();

            System.Windows.Forms.BindingSource bindingSource = new System.Windows.Forms.BindingSource();
            bindingSource.DataMember = "GetEmployeeWagesBetweenDate";
            bindingSource.DataSource = dataSet;

            // Get the data
            Nequeo.DataAccess.NequeoCompany.DataSet.StoredProceduresTableAdapters.GetEmployeeWagesBetweenDateTableAdapter tableAdapter =
                new Nequeo.DataAccess.NequeoCompany.DataSet.StoredProceduresTableAdapters.GetEmployeeWagesBetweenDateTableAdapter();
            tableAdapter.ClearBeforeFill = true;
            tableAdapter.Fill(dataSet.GetEmployeeWagesBetweenDate, fromDate, toDate);

            // Return the data within the binding source.
            return new Model.DataSource.BindingSourceData[]
            {
                new Model.DataSource.BindingSourceData() { DataSource = bindingSource, DataSourceName = "GetEmployeeWagesBetweenDate",
                    BindingSourceParameters = new Nequeo.Model.DataSource.BindingSourceParameter[] 
                    {
                        new Nequeo.Model.DataSource.BindingSourceParameter() 
                        { 
                            Name = "ReportTitle", 
                            Value = "Employee Wages From :" + fromDate.Value.ToShortDateString() + " To : " + toDate.Value.ToShortDateString(), 
                            ValueType = typeof(String) 
                        },
                    }},
            };
        }

        /// <summary>
        /// Create WageFromToDateID binding s ource data
        /// </summary>
        /// <param name="fromDate">The fromDate value</param>
        /// <param name="toDate">The toDate value</param>
        /// <param name="employeeID">The employeeID value</param>
        /// <returns><returns>The report binding source collection.</returns></returns>
        public virtual Nequeo.Model.DataSource.BindingSourceData[] WageFromToDateID(DateTime? fromDate, DateTime? toDate, int? employeeID)
        {
            // Assign the binding sources
            Nequeo.DataAccess.NequeoCompany.DataSet.StoredProcedures dataSet = new Nequeo.DataAccess.NequeoCompany.DataSet.StoredProcedures();

            System.Windows.Forms.BindingSource bindingSource = new System.Windows.Forms.BindingSource();
            bindingSource.DataMember = "GetSelectedEmployeeWageBetweenDate";
            bindingSource.DataSource = dataSet;

            // Get the data
            Nequeo.DataAccess.NequeoCompany.DataSet.StoredProceduresTableAdapters.GetSelectedEmployeeWageBetweenDateTableAdapter tableAdapter =
                new Nequeo.DataAccess.NequeoCompany.DataSet.StoredProceduresTableAdapters.GetSelectedEmployeeWageBetweenDateTableAdapter();
            tableAdapter.ClearBeforeFill = true;
            tableAdapter.Fill(dataSet.GetSelectedEmployeeWageBetweenDate, fromDate, toDate, employeeID);

            // Return the data within the binding source.
            return new Model.DataSource.BindingSourceData[]
            {
                new Model.DataSource.BindingSourceData() { DataSource = bindingSource, DataSourceName = "GetSelectedEmployeeWageBetweenDate" }
            };
        }

        /// <summary>
        /// Create WageFromToDateSummary binding s ource data
        /// </summary>
        /// <param name="fromDate">The fromDate value</param>
        /// <param name="toDate">The toDate value</param>
        /// <returns><returns>The report binding source collection.</returns></returns>
        public virtual Nequeo.Model.DataSource.BindingSourceData[] WageFromToDateSummary(DateTime? fromDate, DateTime? toDate)
        {
            // Assign the binding sources
            Nequeo.DataAccess.NequeoCompany.DataSet.StoredProcedures dataSet = new Nequeo.DataAccess.NequeoCompany.DataSet.StoredProcedures();

            System.Windows.Forms.BindingSource bindingSource = new System.Windows.Forms.BindingSource();
            bindingSource.DataMember = "GetEmployeeWagesBetweenDate";
            bindingSource.DataSource = dataSet;

            // Get the data
            Nequeo.DataAccess.NequeoCompany.DataSet.StoredProceduresTableAdapters.GetEmployeeWagesBetweenDateTableAdapter tableAdapter =
                new Nequeo.DataAccess.NequeoCompany.DataSet.StoredProceduresTableAdapters.GetEmployeeWagesBetweenDateTableAdapter();
            tableAdapter.ClearBeforeFill = true;
            tableAdapter.Fill(dataSet.GetEmployeeWagesBetweenDate, fromDate, toDate);

            // Return the data within the binding source.
            return new Model.DataSource.BindingSourceData[]
            {
                new Model.DataSource.BindingSourceData() { DataSource = bindingSource, DataSourceName = "GetEmployeeWagesBetweenDate",
                    BindingSourceParameters = new Nequeo.Model.DataSource.BindingSourceParameter[] 
                    {
                        new Nequeo.Model.DataSource.BindingSourceParameter() 
                        { 
                            Name = "ReportTitle", 
                            Value = "Employee Wages From :" + fromDate.Value.ToShortDateString() + " To : " + toDate.Value.ToShortDateString(), 
                            ValueType = typeof(String) 
                        },
                    }},
            };
        }

        /// <summary>
        /// Create WageFromToDateBankID binding s ource data
        /// </summary>
        /// <param name="fromDate">The fromDate value</param>
        /// <param name="toDate">The toDate value</param>
        /// <param name="employeeID">The employeeID value</param>
        /// <param name="bankAccountID">The bankAccountID value</param>
        /// <returns><returns>The report binding source collection.</returns></returns>
        public virtual Nequeo.Model.DataSource.BindingSourceData[] WageFromToDateBankID(DateTime? fromDate, DateTime? toDate, int? employeeID, int? bankAccountID)
        {
            // Assign the binding sources
            Nequeo.DataAccess.NequeoCompany.DataSet.StoredProcedures dataSet = new Nequeo.DataAccess.NequeoCompany.DataSet.StoredProcedures();

            System.Windows.Forms.BindingSource bindingSource = new System.Windows.Forms.BindingSource();
            bindingSource.DataMember = "GetSelectedEmployeeBankWageBetweenDate";
            bindingSource.DataSource = dataSet;

            // Get the data
            Nequeo.DataAccess.NequeoCompany.DataSet.StoredProceduresTableAdapters.GetSelectedEmployeeBankWageBetweenDateTableAdapter tableAdapter =
                new Nequeo.DataAccess.NequeoCompany.DataSet.StoredProceduresTableAdapters.GetSelectedEmployeeBankWageBetweenDateTableAdapter();
            tableAdapter.ClearBeforeFill = true;
            tableAdapter.Fill(dataSet.GetSelectedEmployeeBankWageBetweenDate, fromDate, toDate, employeeID, bankAccountID);

            // Return the data within the binding source.
            return new Model.DataSource.BindingSourceData[]
            {
                new Model.DataSource.BindingSourceData() { DataSource = bindingSource, DataSourceName = "GetSelectedEmployeeBankWageBetweenDate" }
            };
        }
    }
}
