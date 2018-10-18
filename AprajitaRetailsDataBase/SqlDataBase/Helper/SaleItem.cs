namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class SaleItem
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public string BarCode { get; set; }
        public double Qty { get; set; }
        public double MRP { get; set; }
        public double BasicAmount { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double BillAmount { get; set; }
        public int SalesmanID { get; set; }
    }
}