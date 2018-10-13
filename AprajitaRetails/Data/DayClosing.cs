using System;

namespace AprajitaRetails.Data
{
    internal class DayClosing
    {
        public int ID { set; get; }
        public DateTime OnDate { set; get; }
        public int TotalAmount { set; get; }
        public int C2000 { set; get; }
        public int C200 { get; set; }//TODO: Implement this
        public int C1000 { set; get; }
        public int C500 { set; get; }
        public int C100 { set; get; }
        public int C50 { set; get; }
        public int C20 { set; get; }
        public int C10 { set; get; }
        public int C5 { set; get; }
        public int Coin10 { set; get; }
        public int Coin5 { set; get; }
        public int Coin2 { set; get; }
        public int Coin1 { set; get; }
    }

    internal class DayEndDetails
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