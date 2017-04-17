namespace AprajitaRetails
{

    /// <summary>
    /// Table Name: Sales
    /// </summary>
    public class SaleItemWise
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public string InvType { get; set; }
        public string InvDate { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string ItemDesc { get; set; }
        public string Barcode { get; set; }
        public string StyleCode { get; set; }
        public int QTY { get; set; }
        public double MRP { get; set; }
        public double Discount { get; set; }
        public double BasicRate { get; set; }
        public double Tax { get; set; }
        public double RoundOff { get; set; }
        public double LineTotal { get; set; }
        public double BillAmnt { get; set; }
        public string Saleman { get; set; }
        public string PaymentType { get; set; }
    }
}