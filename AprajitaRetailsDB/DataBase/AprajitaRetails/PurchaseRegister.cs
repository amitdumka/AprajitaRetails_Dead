namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseRegister")]
    public partial class PurchaseRegister
    {
        public int PurchaseRegisterID { get; set; }

        public int? GRNNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? GRNDate { get; set; }

        [StringLength(50)]
        public string InvoiceNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InvoiceDate { get; set; }

        [StringLength(50)]
        public string SupplierName { get; set; }

        public double? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? MRP { get; set; }

        [Column(TypeName = "money")]
        public decimal? MRPValue { get; set; }

        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }

        [Column(TypeName = "money")]
        public decimal? CostValue { get; set; }

        [Column(TypeName = "money")]
        public decimal? TaxAmt { get; set; }
    }
}
