//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewTry.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class W4
    {
        public int ID { get; set; }
        public int Applicant_ID { get; set; }
        public Nullable<int> Marital_Status { get; set; }
        public Nullable<bool> Last_Name_Differs { get; set; }
        public Nullable<int> Number_Of_Allowances { get; set; }
        public Nullable<decimal> Additional_Amount { get; set; }
        public string Exempt { get; set; }
    }
}
