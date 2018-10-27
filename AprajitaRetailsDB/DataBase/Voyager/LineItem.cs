namespace AprajitaRetailsDB.DataBase.Voyager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LineItem
    {
        public int ID { get; set; }

        public int VoyBillId { get; set; }

        [StringLength(100)]
        public string LineType { get; set; }

        public int Serial { get; set; }

        [StringLength(100)]
        public string ItemCode { get; set; }

        public double Qty { get; set; }

        public double Rate { get; set; }

        public double Value { get; set; }

        public double DiscountValue { get; set; }

        public double Amount { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
    }
}
