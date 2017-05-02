using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectScriptingExtensions;
namespace AprajitaRetails.Data
{
    public class SaleInfo
    {
        public string TodaySale { get; set; }
        public string MonthlySale { get; set; }
        public string YearlySale { get; set; }
    }
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
    class Discounts
    {
        public int ID { set; get; }
        public string DiscountCode { set; get; }
    }
    class DiscountCodeGenerator
    {
        public int ID { set; get; }
        public string DiscountCode { set; get; }
        public DateTime GenDate { set; get; }
        //TODO: Implement with full secure
    }
}
