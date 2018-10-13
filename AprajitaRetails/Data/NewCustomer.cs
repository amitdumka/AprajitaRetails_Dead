using System;

namespace AprajitaRetails.Data
{
    public class NewCustomer
    {
        public int ID { set; get; }
        public int CustomerID { set; get; }
        public string InvoiceNo { set; get; }
        public DateTime OnDate { set; get; }
        public string CustomerFullName { get; set; }
    }
}