using System;

namespace AprajitaRetails.Data
{
    internal class Attendence
    {
        public int ID { set; get; }
        public string EMPCode { get; set; }
        public DateTime OnDate { get; set; }
        public double AttendenceNo { get; set; }
        public int IsAbesent { get; set; }
        public int IsPaidLeave { set; get; }
    }
}