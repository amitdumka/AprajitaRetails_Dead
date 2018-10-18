namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal abstract class Taxes
    {
        public int ID { set; get; }
        public TaxType TaxType { set; get; }
        public double TotalTaxAmount { set; get; }

        public abstract Taxes TaxAmount( TaxType type, double BillAmount, double rate );
    }
}