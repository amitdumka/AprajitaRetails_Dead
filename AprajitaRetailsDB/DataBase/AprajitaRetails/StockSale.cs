namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockSale")]
    public partial class StockSale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StockSaleID { get; set; }

        [Required]
        [StringLength(100)]
        public string BarCode { get; set; }

        public double Qty { get; set; }

        public double? MQty { get; set; }

        public double? AcutalQty { get; set; }

        public virtual ProductItem ProductItem { get; set; }
    }
}
