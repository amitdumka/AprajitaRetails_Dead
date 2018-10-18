namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    public class SalePaymentDetails
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public int PayMode { get; set; }
        public double CashAmount { get; set; }
        public double CardAmount { get; set; }
        public CardPaymentDetails CardDetails { get; set; }
    }
}