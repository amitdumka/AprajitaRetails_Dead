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
    
    public partial class PaymentDetail
    {
        public int PaymentDetailsID { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<int> PayMode { get; set; }
        public Nullable<decimal> CashAmount { get; set; }
        public Nullable<decimal> CardAmount { get; set; }
        public Nullable<int> CardDetailsID { get; set; }
    
        public virtual CardPaymentDetail CardPaymentDetail { get; set; }
        public virtual SaleInvoice SaleInvoice { get; set; }
    }
}
