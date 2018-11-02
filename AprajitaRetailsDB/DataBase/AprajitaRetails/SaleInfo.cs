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
    public class SaleInfo
    {//TODO: Data /Datamodel or model / data type / data helper
        public string TodaySale { get; set; }
        public string MonthlySale { get; set; }
        public string YearlySale { get; set; }
    }


}

