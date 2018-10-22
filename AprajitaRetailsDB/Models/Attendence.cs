using System;

namespace AprajitaRetailsDB.Models
{
    /// <summary>
    /// It is used to record Attendence
    /// </summary>
    public class Attendence
    {
        public int AttendenceID { set; get; }
        public string EMPCode { get; set; }
        public DateTime OnDate { get; set; }
        public double AttendenceNo { get; set; }
        public int IsAbesent { get; set; }
        public int IsPaidLeave { set; get; }
    }
}