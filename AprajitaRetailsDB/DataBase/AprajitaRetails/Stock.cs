namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]

    public partial class Stock
    {
        [Key]
        [StringLength(100)]
        public string BarCode { get; set; }

        public double Qty { get; set; }

        public int UnitID { get; set; }

        public double PurchaseQty { get; set; }

        public double SoldQty { get; set; }

        public double? MQty { get; set; }

        public double? AcutalQty { get; set; }

        [Column(TypeName = "money")]
        public decimal? CostValue { get; set; }

        [Column(TypeName = "money")]
        public decimal? MRPValue { get; set; }
        [StringLength( 20 )]
        public string StoreCode { get; set; }


        public virtual Unit Unit { get; set; }

        public virtual ProductItem ProductItem { get; set; }
    }
}
