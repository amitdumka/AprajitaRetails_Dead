using System;

namespace AprajitaRetailsDataBase.SqlDataBase
{
    /// <summary>
    /// Table Name: Sales
    /// Updateing GST Features
    /// </summary>
    public class SaleItemWise
    {
        public string Barcode { get; set; }
        public double BasicRate { get; set; }
        public double BillAmnt { get; set; }
        public string BrandName { get; set; }
        public double CGST { get; set; }
        public double Discount { get; set; }
        public string HSNCode { get; set; }
        public int ID { get; set; }
        public string InvDate { get; set; }
        public string InvoiceNo { get; set; }
        public string InvType { get; set; }
        public string ItemDesc { get; set; }
        public double LineTotal { get; set; }
        public string LP { get; set; }
        public double MRP { get; set; }
        public string PaymentType { get; set; }
        public string ProductName { get; set; }
        public int QTY { get; set; }
        public double RoundOff { get; set; }
        public string Saleman { get; set; }
        public double SGST { get; set; }
        public string StyleCode { get; set; }
        public double Tax { get; set; } // Can be use for IGST
        public DateTime ImportTime { get; set; } // Date of Import
        public string IsDataConsumed { get; set; }// is data imported to relevent table

        public SaleItemWise( )
        {
            HSNCode = "";
            CGST = SGST = Tax = 0.00;
            LineTotal = 0.00;
            PaymentType = "";
            IsDataConsumed = "NO";
            ImportTime = DateTime.Now;
        }
    }
}