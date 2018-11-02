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
    [Table("Salary")]
    public class Salary
    {//TODO:HRM 
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int SalaryID { get; set; }
        public double BasicSalary { get; set; }
        public double ExtraSalary { get; set; }
        public Incentive IncentiveID { get; set; }
    }


}

