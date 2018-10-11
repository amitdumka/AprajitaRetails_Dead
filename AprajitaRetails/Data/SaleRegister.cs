namespace AprajitaRetails
{
    /// <summary>
    /// TableName: SaleRegister
    /// </summary>
    public class SaleRegister
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public string InvType { get; set; }
        public string InvDate { get; set; }
        public int QTY { get; set; }
        public double MRP { get; set; }
        public double Discount { get; set; }
        public double BasicRate { get; set; }
        public double Tax { get; set; }
        public double RoundOff { get; set; }
        public double BillAmnt { get; set; }
        public string paymentType { get; set; }
    }
}