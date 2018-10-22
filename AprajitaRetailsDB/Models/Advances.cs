using System;

namespace AprajitaRetailsDB.Models
{
    public class Advances
    {
        public int AdvancesID { get; set; }
        public int EmpID { get; set; }
        public string EmpCode { get; set; }
        public DateTime DateOfAdvance { get; set; }
        public double Amount { get; set; }
        public string Reason { get; set; }
    }
}