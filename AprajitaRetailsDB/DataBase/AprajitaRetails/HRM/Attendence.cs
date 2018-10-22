namespace AprajitaRetailsDB.DataBase.AprajitaRetails.HRM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attendence")]
    public partial class Attendence
    {
        public int AttendenceID { get; set; }

        public int EMPID { get; set; }

        [Required]
        [StringLength(100)]
        public string EMPCode { get; set; }

        public DateTime? OnDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? AttendenceNo { get; set; }

        public int? IsAbesent { get; set; }

        public int? IsPaidLeave { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
