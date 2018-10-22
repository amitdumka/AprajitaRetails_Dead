using System;

namespace AprajitaRetailsDB.Models.Voyger

{
    public class InsertDataLog
    {
        public int InsertDataLogID { get; set; }

        public string BillNumber { get; set; }

        public int VoyBillID { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime InsertedOn { get; set; }

        public int SaleInvoiceID { get; set; }

        public int DailySaleID { get; set; }

        public string Remark { get; set; }
        public virtual VoyBill VoyBill { get; set; }
    }
}