namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    public class CardPaymentDetails
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public int CardType { get; set; }
        public double Amount { get; set; }
        public int AuthCode { get; set; }
        public int LastDigit { get; set; }
    }
}