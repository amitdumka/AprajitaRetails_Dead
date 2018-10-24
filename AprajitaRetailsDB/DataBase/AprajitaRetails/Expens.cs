namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Expenses")]
    public partial class Expens
    {
        [Key]
        public int ExpensesID { get; set; }

        public int? ExpensesCategoryID { get; set; }

        [StringLength(100)]
        public string ExpensesReason { get; set; }

        [StringLength(100)]
        public string ApprovedBy { get; set; }

        public int? PaymentModeID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        public int? BankDetailsID { get; set; }

        public virtual BankDetail BankDetail { get; set; }

        public virtual ExpensesCategory ExpensesCategory { get; set; }

        public virtual PaymentMode PaymentMode { get; set; }
    }
}