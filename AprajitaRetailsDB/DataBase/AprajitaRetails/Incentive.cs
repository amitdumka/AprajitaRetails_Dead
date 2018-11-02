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
    [Table( "Incentive")]
    public class Incentive
    {//TODO: Move To HRM DB
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int IncentiveID { get; set; }
        public double IncentivePercentage { get; set; }
        public double TargetAmount { get; set; }
    }


}

