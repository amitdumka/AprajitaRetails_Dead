namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CardPaymentDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CardPaymentDetail()
        {
            PaymentDetails = new HashSet<PaymentDetail>();
        }

        [Key]
        public int CardPaymentDetailsID { get; set; }

        [Required]
        [StringLength(100)]
        public string InvoiceNo { get; set; }

        public int CardType { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public int? AuthCode { get; set; }

        public int? LastDigit { get; set; }

        public virtual SaleInvoice SaleInvoice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
