using System;

/// <summary>
/// It is Version 2.
/// <!-- A Modular Approch-->
/// </summary>
namespace AprajitaRetailsDataBase.SqlDataBase.Data
{
    /// <summary>
    /// It is used to record Attendence
    /// </summary>
    public class Attendence
    {
        public int ID { set; get; }
        public string EMPCode { get; set; }
        public DateTime OnDate { get; set; }
        public double AttendenceNo { get; set; }
        public int IsAbesent { get; set; }
        public int IsPaidLeave { set; get; }
    }
}