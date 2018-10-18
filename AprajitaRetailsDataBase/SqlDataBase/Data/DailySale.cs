using System;

//TODO: Modularity requries
namespace AprajitaRetailsDataBase.SqlDataBase.Data
{
    public class DailySale
    {
        public int ID { set; get; }
        public DateTime SaleDate { set; get; }
        public int CustomerID { set; get; }
        public string InvoiceNo { set; get; }
        public double Amount { set; get; }
        public double Discount { set; get; }
        public int RMZ { set; get; }
        public int Fabric { set; get; }
        public int Tailoring { set; get; }
        public int PaymentMode { set; get; }
    }
}