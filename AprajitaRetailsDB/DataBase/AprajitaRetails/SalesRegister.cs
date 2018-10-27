namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalesRegister")]
    public partial class SalesRegister
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesRegisterID { get; set; }

        [Key]
        [StringLength(50)]
        public string InvoiceNo { get; set; }

        [Required]
        [StringLength(50)]
        public string InvoiceDate { get; set; }

        [Required]
        [StringLength(50)]
        public string InvoiceType { get; set; }

        public int Qty { get; set; }

        [Column(TypeName = "money")]
        public decimal MRP { get; set; }

        [Column(TypeName = "money")]
        public decimal Discount { get; set; }

        [Column(TypeName = "money")]
        public decimal BasicAmt { get; set; }

        [Column(TypeName = "money")]
        public decimal TaxAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal RoundOff { get; set; }

        [Column(TypeName = "money")]
        public decimal BillAmount { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMode { get; set; }
        [StringLength( 20 )]
        public string StoreCode { get; set; }

    }
}
