namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaleItem")]
    public partial class SaleItem
    {
        public int SaleItemID { get; set; }

        [Required]
        [StringLength(100)]
        public string InvoiceNo { get; set; }

        [Required]
        [StringLength(100)]
        public string BarCode { get; set; }

        [Column(TypeName = "money")]
        public decimal Qty { get; set; }
        public int UnitID { get; set; }

        [Column(TypeName = "money")]
        public decimal? MRP { get; set; }

        [Column(TypeName = "money")]
        public decimal? BasicAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? Discount { get; set; }

        [Column(TypeName = "money")]
        public decimal? Tax { get; set; }

        [Column(TypeName = "money")]
        public decimal? BillAmount { get; set; }

        public int SalesmanID { get; set; }

        public double? IGSTRate { get; set; }

        public double? CGSTRate { get; set; }

        public double? SGSTRate { get; set; }

        [Column(TypeName = "money")]
        public decimal? CGST { get; set; }

        [Column(TypeName = "money")]
        public decimal? SGST { get; set; }

        public int IsManualBill { get; set; }

        public int IsAdjusted { get; set; }

        [StringLength( 20 )]
        public string StoreCode { get; set; }


        public virtual ProductItem ProductItem { get; set; }

        public virtual SaleInvoice SaleInvoice { get; set; }

        public virtual Salesman Salesman { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
