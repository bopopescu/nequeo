//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nequeo.DataAccess.NequeoCompany.Edm
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompanyPAYGInstalment
    {
        public int PAYGInstID { get; set; }
        public int CompanyID { get; set; }
        public string AssessmentYear { get; set; }
        public Nullable<double> InstalRate { get; set; }
        public Nullable<decimal> TaxOnIncome { get; set; }
        public Nullable<decimal> GDPTax { get; set; }
        public Nullable<decimal> InstalCalTaxOffice { get; set; }
        public Nullable<System.DateTime> InstalmentDate { get; set; }
        public string Comments { get; set; }
    }
}
