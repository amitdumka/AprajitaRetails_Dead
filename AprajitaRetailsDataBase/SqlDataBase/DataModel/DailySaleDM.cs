using System;

namespace AprajitaRetailsDataBase.SqlDataBase.DataModel
{
    public class DailySaleDM
    {
        public int ID { set; get; }
        public DateTime SaleDate { set; get; }
        public string CustomerFullName { set; get; }
        public string CustomerMobileNo { set; get; }
        public string InvoiceNo { set; get; }
        public double Amount { set; get; }
        public double Discount { set; get; }
        public int RMZ { set; get; }
        public int Fabric { set; get; }
        public int Tailoring { set; get; }
        public int PaymentMode { set; get; }
        public int NewCustomer { set; get; }
    }
}