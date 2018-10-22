namespace AprajitaRetailsDB.Models.Voyger

{
    public class LineItem
    {
        public int LineItemID { get; set; }

        public int VoyBillID { get; set; }

        public string LineType { get; set; }

        public int Serial { get; set; }

        public string ItemCode { get; set; }

        public double Qty { get; set; }

        public double Rate { get; set; }

        public double Value { get; set; }

        public double DiscountValue { get; set; }

        public double Amount { get; set; }

        public string Description { get; set; }
        public virtual VoyBill VoyBill { get; set; }
    }
}