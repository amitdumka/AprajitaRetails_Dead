namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class PaymentDetails
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public int PayMode { get; set; }
        public double CashAmount { get; set; }
        public double CardAmount { get; set; }
        public int CardDetailsID { get; set; }
    }
}