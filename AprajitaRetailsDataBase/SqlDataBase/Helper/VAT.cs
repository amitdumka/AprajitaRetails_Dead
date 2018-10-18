namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class VAT : Taxes
    {
        //public int ID { set; get; }
        public double VatRate { set; get; }

        public double VatAmount { set; get; }

        public override Taxes TaxAmount( TaxType type, double BillAmount, double rate )
        {
            if (type == TaxType.Vat)
            {
                VatRate = rate;
                VatAmount = BillAmount - ((BillAmount * rate) / 100);
                TotalTaxAmount = VatAmount;
                return this;
            }
            else
            { return null; }
        }
    }
}