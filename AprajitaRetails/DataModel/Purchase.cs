using System;

namespace AprajitaRetails
{
    /// <summary>
    /// TableName: Purchase
    /// </summary>
    public class Purchase
    {
        string grnno; DateTime grndate; string invoiceno; DateTime invdate;
        string suppliername; string barcode; string productname;
        string stylecode; string itemdesc; double qty; double mrp; double mrpvalue;
        double cost; double costvalue; double taxamt;

        public string Grnno { get => grnno; set => grnno = value; }
        public DateTime Grndate { get => grndate; set => grndate = value; }
        public string Invoiceno { get => invoiceno; set => invoiceno = value; }
        public DateTime Invdate { get => invdate; set => invdate = value; }
        public string Suppliername { get => suppliername; set => suppliername = value; }
        public string Barcode { get => barcode; set => barcode = value; }
        public string Productname { get => productname; set => productname = value; }
        public string Stylecode { get => stylecode; set => stylecode = value; }
        public string Itemdesc { get => itemdesc; set => itemdesc = value; }
        public double Qty { get => qty; set => qty = value; }
        public double Mrp { get => mrp; set => mrp = value; }
        public double Mrpvalue { get => mrpvalue; set => mrpvalue = value; }
        public double Cost { get => cost; set => cost = value; }
        public double Costvalue { get => costvalue; set => costvalue = value; }
        public double Taxamt { get => taxamt; set => taxamt = value; }
    }
}
/*
 GRNNo	GRNDate	Invoice No	Invoice Date	Supplier Name	Barcode	Product Name	Style Code
 Item Desc	Quantity	MRP	MRP Value	Cost	Cost Value	TaxAmt
C33GR500001	16/02/2016	DTE5000523	25/01/2016	TAS RMG Warehouse - Bangalore	8907259105888
Apparel/Mens Formal/Shirts	USSH3877XL	Shirts-FS-Black	1.00	1999.00	1999.00	1287.76	1287.76	0.00
 */
