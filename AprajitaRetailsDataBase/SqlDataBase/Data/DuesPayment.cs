using System;

namespace AprajitaRetailsDataBase.SqlDataBase.Data
{
    internal class DuesPayment
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string EmpCode { get; set; }
        public int AdvanceID { get; set; }
        public double Amount { get; set; }
        public int ReciptNo { get; set; }
        public DateTime DateOfRecipt { get; set; }
    }
}