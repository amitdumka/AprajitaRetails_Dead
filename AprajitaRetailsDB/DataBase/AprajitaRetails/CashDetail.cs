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
    [Table("CashDetail")]
    public class CashDetail{
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int CashDetailID { set; get; }

        public int TotalAmount { set; get; }
        public int C2000 { set; get; }
        public int C1000 { set; get; }
        public int C500 { set; get; }
        public int C100 { set; get; }
        public int C50 { set; get; }
        public int C20 { set; get; }
        public int C10 { set; get; }
        public int C5 { set; get; }
        public int Coin10 { set; get; }
        public int Coin5 { set; get; }
        public int Coin2 { set; get; }
        public int Coin1 { set; get; }
        [StringLength( 20 )]
        public string StoreCode { get; set; }
    }


}

