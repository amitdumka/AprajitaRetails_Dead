namespace AprajitaRetailsDB.Models.Data
{
    //TODO: Use in ShareCode 
    public class SalePaymentDetails
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public int PayMode { get; set; }
        public decimal CashAmount { get; set; }
        public decimal CardAmount { get; set; }
        public CardPaymentDetails CardDetails { get; set; }
    }

    public class CardPaymentDetails
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public int CardType { get; set; }
        public decimal Amount { get; set; }
        public int AuthCode { get; set; }
        public int LastDigit { get; set; }
    }
}