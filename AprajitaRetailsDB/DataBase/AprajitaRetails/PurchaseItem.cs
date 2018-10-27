namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseItem")]
    public partial class PurchaseItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PurchaseItemId { get; set; }

        [Required]
        [StringLength(100)]
        public string BarCode { get; set; }

        public double QTY { get; set; }

        [Column(TypeName = "money")]
        public decimal MPR { get; set; }

        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        public double? IGST { get; set; }

        public double? SGST { get; set; }

        public double? CGST { get; set; }

        public double? IGSTRate { get; set; }

        public double? CGSTRate { get; set; }

        public double? SGSTRate { get; set; }
        [StringLength( 20 )]
        public string StoreCode { get; set; }


        public int? PurchaseInvoiceID { get; set; }

        public virtual ProductItem ProductItem { get; set; }
    }
}
