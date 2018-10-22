namespace AprajitaRetailsDB.Models.Voyger

{
    public class VPaymentMode
    {
        public int VPaymentModeID { get; set; }

        public int VoyBillID { get; set; }

        public string PaymentMode { get; set; }

        public string PaymentValue { get; set; }

        public string Notes { get; set; }
        public virtual VoyBill VoyBill { get; set; }
    }
}