using System;

//TODO: Modularity needed
namespace AprajitaRetailsDB.Models.Data
{
    public class DayClosing
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
}