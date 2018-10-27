namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaleInvoice")]
    public partial class SaleInvoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SaleInvoice()
        {
            CardPaymentDetails = new HashSet<CardPaymentDetail>();
            PaymentDetails = new HashSet<PaymentDetail>();
            SaleItems = new HashSet<SaleItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaleInvoiceID { get; set; }

        public int SaleTypeID { get; set; }

        public int? CustomerID { get; set; }

        public DateTime OnDate { get; set; }

        [Key]
        [StringLength(100)]
        public string InvoiceNo { get; set; }

        public int TotalItems { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalQty { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalBillAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalDiscountAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? RoundOffAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalTaxAmount { get; set; }

        public int IsManualBillAdjusted { get; set; }
        [StringLength( 20 )]
        public string StoreCode { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CardPaymentDetail> CardPaymentDetails { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }

        public virtual SaleType SaleType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleItem> SaleItems { get; set; }
    }
}
