namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sale
    {
        [Key]
        public int SalesId { get; set; }

        [StringLength(50)]
        public string InvoiceNo { get; set; }

        [StringLength(50)]
        public string InvoiceDate { get; set; }

        [StringLength(50)]
        public string InvoiceType { get; set; }

        [StringLength(50)]
        public string BrandName { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string ItemDescrpetion { get; set; }

        [StringLength(50)]
        public string BarCode { get; set; }

        [StringLength(50)]
        public string StyleCode { get; set; }

        public double Qty { get; set; }

        [Column(TypeName = "money")]
        public decimal? MRP { get; set; }

        [Column(TypeName = "money")]
        public decimal? Discount { get; set; }

        [Column(TypeName = "money")]
        public decimal? BasicAmt { get; set; }

        [Column(TypeName = "money")]
        public decimal? TaxAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? LineTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal? RoundOff { get; set; }

        [Column(TypeName = "money")]
        public decimal? BillAmount { get; set; }

        [StringLength(50)]
        public string Salesman { get; set; }

        [StringLength(50)]
        public string PaymentMode { get; set; }

        [StringLength(50)]
        public string HSNCode { get; set; }

        [Column(TypeName = "money")]
        public decimal? SGST { get; set; }

        [Column(TypeName = "money")]
        public decimal? CGST { get; set; }

        [StringLength(50)]
        public string LP { get; set; }

        public DateTime? ImportDate { get; set; }

        [StringLength(50)]
        public string IsDataConsumed { get; set; }
        [StringLength( 20 )]
        public string StoreCode { get; set; }

    }
}
