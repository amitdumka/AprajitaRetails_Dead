using System;

namespace AprajitaRetailsDB.Models.Data
{
    public class DayEndDetails
    {
        public int ID { set; get; }
        public int DayClosingID { set; get; }
        public DateTime OnDate { set; get; }

        public double TotalSale { set; get; }

        public double CreditCardSale { get; set; }
        public double DebitCardSale { get; set; }

        public double TotalRMZSale { set; get; }
        public double TotalFabricSale { set; get; }
        public double TotalRMZNo { set; get; }
        public double TotalFabricNo { set; get; }

        public double TailoringSale { get; set; }
        public int TotalTailorDeliveryNo { get; set; }
        public double TotalTailoringBookingAmount { set; get; }
        public int TotalTailoringBookingNo { set; get; }

        public double TotalBankDeposit { set; get; }
        public double TotalBankPayment { set; get; }
        public double TotalCashPayment { set; get; }

        public double TotalExpenses { set; get; }

        public double TotalAccessicorySale { get; set; }
        public int TotalAccessicoryNo { get; set; }
    }
}