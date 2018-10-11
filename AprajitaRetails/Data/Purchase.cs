using System;

namespace AprajitaRetails
{
    /// <summary>
    /// TableName: Purchase 
    /// GST Impemented
    /// </summary>
    public class Purchase
    {
        public string GRNNo { get; set; }
        public DateTime GRNDate { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string SupplierName { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public string StyleCode { get; set; }
        public string ItemDesc { get; set; }
        public double Quantity { get; set; }
        public double MRP { get; set; }
        public double MRPValue { get; set; }
        public double Cost { get; set; }
        public double CostValue { get; set; }
        public double TaxAmt { get; set; }
        public double IGSTAmt { get; set; }
        public double CSGTAmt { get; set; }
        public double SGSTAmt { get; set; }




    }
}
/*
 
 GRNNo	GRNDate	Invoice No	Invoice Date	Supplier Name	Barcode	Product Name	Style Code	Item Desc	Quantity	MRP	MRP Value	Cost	Cost Value	TaxAmt	ExmillCost	Excise1	Excise2	Excise3
C33GR500001	16/02/2016	DTE5000523	25/01/2016	TAS RMG Warehouse - Bangalore	8907259107264	Apparel/Mens Formal/Shirts	USSH3887L	Shirts-FS-Red	2.00	2199.00	4398.00	1416.60	2833.20	0.00				
   		
 


 * 
 * 
 */
