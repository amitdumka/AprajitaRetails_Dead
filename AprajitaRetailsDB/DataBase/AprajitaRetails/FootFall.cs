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
    [Table( "FootFall" )]
    public class FootFall
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int FootFallID { set; get; }

        public DateTime OnDate { set; get; }
        //TODO: Date should be created for today date and automaticly calculate total .
       // [DatabaseGenerated( DatabaseGeneratedOption.Computed )]
        public int Total { set; get; }
        public int T9_10 { set; get; }
        public int T10_11 { set; get; }
        public int T11_12 { set; get; }
        public int T12_1 { set; get; }
        public int T1_2 { set; get; }
        public int T2_3 { set; get; }
        public int T3_4 { set; get; }
        public int T4_5 { set; get; }
        public int T5_6 { set; get; }
        public int T6_7 { set; get; }
        public int T7_8 { set; get; }
        public int T8_9 { set; get; }
        [StringLength( 20 )]
        public string StoreCode { get; set; }
    }


}

