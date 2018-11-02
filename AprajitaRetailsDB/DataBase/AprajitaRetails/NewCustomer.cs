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
    public class NewCustomer
    {//TODO: Be part of CRM in future
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int NewCustomerID { set; get; }
        public int CustomerID { set; get; }
        public string InvoiceNo { set; get; }
        public DateTime OnDate { set; get; }
        public string CustomerFullName { get; set; }
    }


}

