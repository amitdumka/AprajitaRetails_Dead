namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DailySale")]
    public partial class DailySale
    {
        public int DailySaleID { get; set; }

        public DateTime SaleDate { get; set; }

        public int CustomerID { get; set; }

        [StringLength(100)]
        public string InvoiceNo { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        [Column(TypeName = "money")]
        public decimal? Discount { get; set; }

        public int? RMZ { get; set; }

        public int? Fabric { get; set; }

        public int? Tailoring { get; set; }

        public int? PaymentModeID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual PaymentMode PaymentMode { get; set; }
    }
}
