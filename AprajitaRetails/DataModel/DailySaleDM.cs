using System;

namespace AprajitaRetails.DataModel
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

    internal class DiscountsDM
    {
        public int ID { set; get; }
        public string DiscountCode { set; get; }
    }

    internal class DiscountCodeGeneratorDM
    {
        public int ID { set; get; }
        public string DiscountCode { set; get; }
        public DateTime GenDate { set; get; }
        //TODO: Implement with full secure
    }

    internal class DayClosingDM
    {
    }
}