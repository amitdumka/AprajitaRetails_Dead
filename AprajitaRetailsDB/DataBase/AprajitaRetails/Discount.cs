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
    [Table("Discount")]
    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiscountID { set; get; }
        [StringLength(25)]
        public string DiscountCode { set; get; }
    }


}

