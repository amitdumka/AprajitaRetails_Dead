namespace AprajitaRetailsDB.DataBase.Voyager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InsertDataLog")]
    public partial class InsertDataLog
    {
        public int ID { get; set; }

        [Required]
        public string BillNumber { get; set; }

        public int VoyBillId { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime InsertedOn { get; set; }

        public int? SaleInvoiceId { get; set; }

        public int? DailySaleId { get; set; }

        public string Remark { get; set; }
    }
}
