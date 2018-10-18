namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    public class ProductItems

    {
        public int ID { set; get; }
        public string StyleCode { get; set; }
        public string Barcode { get; set; }

        public string SupplierId { get; set; }

        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string ItemDesc { get; set; }

        public double MRP { get; set; }
        public double Tax { get; set; }    // TODO:Need to Review in final Edition
        public double Cost { get; set; }

        public string Size { get; set; }
        public double Qty { get; set; }
        //GST Implementation    Version 1.0
        //TODO: GST implementation should use Taxes Class
        //public double HSNCode { get; set; }
        //public int PreGST { get; set; }
        //public double SGST { get; set; }
        //public double CGST { get; set; }
        //public double IGST { get; set; }
    }
}