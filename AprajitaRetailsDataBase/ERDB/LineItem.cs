//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AprajitaRetailsDataBase.ERDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class LineItem
    {
        public int ID { get; set; }
        public int VoyBillId { get; set; }
        public string LineType { get; set; }
        public int Serial { get; set; }
        public string ItemCode { get; set; }
        public double Qty { get; set; }
        public double Rate { get; set; }
        public double Value { get; set; }
        public double DiscountValue { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}
