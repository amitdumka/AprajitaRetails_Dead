//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AprajitaRetailsDB.DAL.AprajitaRetails.HRM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attendence
    {
        public int AttendenceID { get; set; }
        public int EMPID { get; set; }
        public string EMPCode { get; set; }
        public Nullable<System.DateTime> OnDate { get; set; }
        public Nullable<decimal> AttendenceNo { get; set; }
        public Nullable<int> IsAbesent { get; set; }
        public Nullable<int> IsPaidLeave { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
