//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AprajitaRetailsDB.DAL.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseItem
    {
        public int PurchaseItemId { get; set; }
        public string BarCode { get; set; }
        public double QTY { get; set; }
        public decimal MPR { get; set; }
        public decimal Cost { get; set; }
        public Nullable<double> IGST { get; set; }
        public Nullable<double> SGST { get; set; }
        public Nullable<double> CGST { get; set; }
        public Nullable<double> IGSTRate { get; set; }
        public Nullable<double> CGSTRate { get; set; }
        public Nullable<double> SGSTRate { get; set; }
        public Nullable<int> PurchaseInvoiceID { get; set; }
    
        public virtual ProductItem ProductItem { get; set; }
    }
}
