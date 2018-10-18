using System;

namespace AprajitaRetailsDataBase.SqlDataBase.Data
{
    internal class Advances
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string EmpCode { get; set; }
        public DateTime DateOfAdvance { get; set; }
        public double Amount { get; set; }
        public string Reason { get; set; }
    }
}