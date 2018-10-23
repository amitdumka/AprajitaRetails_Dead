namespace AprajitaRetailsDB.DataBase.Voyager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VoyBill")]
    public partial class VoyBill
    {
        public int ID { get; set; }

        [StringLength(4000)]
        public string BillType { get; set; }

        [StringLength(4000)]
        public string BillNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? BillTime { get; set; }

        public double BillAmount { get; set; }

        public double BillGrossAmount { get; set; }

        public double BillDiscount { get; set; }

        [StringLength(4000)]
        public string CustomerName { get; set; }

        [StringLength(4000)]
        public string CustomerMobile { get; set; }

        [StringLength(4000)]
        public string StoreID { get; set; }
    }
}
