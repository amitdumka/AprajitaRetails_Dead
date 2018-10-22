namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PaymentDetail
    {
        [Key]
        public int PaymentDetailsID { get; set; }

        [Required]
        [StringLength(100)]
        public string InvoiceNo { get; set; }

        public int? PayMode { get; set; }

        [Column(TypeName = "money")]
        public decimal? CashAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? CardAmount { get; set; }

        public int? CardDetailsID { get; set; }

        public virtual CardPaymentDetail CardPaymentDetail { get; set; }

        public virtual SaleInvoice SaleInvoice { get; set; }
    }
}
