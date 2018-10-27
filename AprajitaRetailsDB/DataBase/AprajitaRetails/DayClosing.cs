namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DayClosing")]
    public partial class DayClosing
    {
        public int DayClosingID { get; set; }

        public DateTime OnDate { get; set; }

        public int TotalAmount { get; set; }

        public int? C2000 { get; set; }

        public int? C200 { get; set; }

        public int? C1000 { get; set; }

        public int? C500 { get; set; }

        public int? C100 { get; set; }

        public int? C50 { get; set; }

        public int? C20 { get; set; }

        public int? C10 { get; set; }

        public int? C5 { get; set; }

        public int? Coin10 { get; set; }

        public int? Coin5 { get; set; }

        public int? Coin2 { get; set; }

        public int? Coin1 { get; set; }
        [StringLength( 20 )]
        public string StoreCode { get; set; }

    }
}
