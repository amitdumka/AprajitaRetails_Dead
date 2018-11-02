using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using AprajitaRetailsDB.DataBase.AprajitaRetails.HRM;

namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    [Table("Dues")]
    public class Dues
    {//TODO:HRM or payroll
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DuesID { get; set; }
        public int EmpID { get; set; }
        public string EMPCode { get; set; }
        public double DuesAmount { get; set; }
    }


}

