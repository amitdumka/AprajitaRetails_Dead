namespace AprajitaRetailsDB.DataBase.Voyager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VPaymentMode")]
    public partial class VPaymentMode
    {
        public int ID { get; set; }

        public int VoyBillId { get; set; }

        [StringLength(4000)]
        public string PaymentMode { get; set; }

        [StringLength(4000)]
        public string PaymentValue { get; set; }

        [StringLength(4000)]
        public string Notes { get; set; }
    }
}
