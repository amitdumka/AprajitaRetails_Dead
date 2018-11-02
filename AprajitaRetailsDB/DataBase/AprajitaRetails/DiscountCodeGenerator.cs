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
    public class DiscountCodeGenerator
    {

        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int DiscountCodeGeneratorID { set; get; }
        public string DiscountCode { set; get; }
        public DateTime GenDate { set; get; }
        //TODO: Implement with full secure
    }


}

