namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class GST : Taxes
    {
        // public int ID { set; get; }
        public double CGSTRate { set; get; }

        public double SGSTRate { set; get; }
        public double IGSTRate { set; get; }

        public double IGSTAmount { set; get; }
        public double CGSTAmount { set; get; }
        public double SGSTAmount { set; get; }

        public override Taxes TaxAmount( TaxType type, double BillAmount, double rate )
        {   //TODO: Check and verify for GST Tax Calculation.
            if (type == TaxType.Gst)
            {
                CGSTRate = rate / 2;
                SGSTRate = rate / 2;
                TotalTaxAmount = BillAmount - ((BillAmount * rate) / 100);
                CGSTAmount = TotalTaxAmount / 2;
                SGSTAmount = CGSTAmount;
                return this;
            }
            else if (type == TaxType.SGST || type == TaxType.CGST)
            {
                CGSTRate = rate / 2;
                SGSTRate = rate / 2;
                TotalTaxAmount = BillAmount - ((BillAmount * rate) / 100);
                CGSTAmount = TotalTaxAmount / 2;
                SGSTAmount = CGSTAmount;
                return this;
            }
            else if (type == TaxType.IGST)
            {
                TotalTaxAmount = BillAmount - ((BillAmount * rate) / 100);
                return this;
            }
            else
            {
                return null;
            }
        }
    }
}