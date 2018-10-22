using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprajitaRetailsDB.Models.Voyger
{
    public class VoyBill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoyBillID { get; set; }

        [Required]
        public string BillType { get; set; }

        [Required]
        public string BillNumber { get; set; }

        [Required]
        public DateTime BillTime { get; set; }

        public double BillAmount { get; set; }

        public double BillGrossAmount { get; set; }

        public double BillDiscount { get; set; }

        public string CustomerName { get; set; }

        public string CustomerMobile { get; set; }

        [Required]
        public string StoreID { get; set; }

        public virtual ICollection<VPaymentMode> VPaymentModes { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
        public virtual InsertDataLog InsertDataLogs { get; set; }
    }
}