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
    [Table( "DuesPayment" )]
    public class DuesPayment
    {

        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int DuesPaymentID { get; set; }
        public int EmpID { get; set; }
        public string EmpCode { get; set; }

        public int AdvanceID { get; set; }

        public double Amount { get; set; }
        public int ReciptNo { get; set; }

        public DateTime DateOfRecipt { get; set; }
    }


}

