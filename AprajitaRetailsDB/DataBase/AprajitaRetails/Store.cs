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
    [Table("Store")]
    public class Store
    {

        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int StoreID { get; set; }
        [StringLength(100)]
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string PhoneNo { get; set; }
        public string StoreManagerName { get; set; }
        public string StoreManagerPhoneNo { get; set; }
        public string GSTNO { get; set; }
        public int NoOfEmployees { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Status { get; set; }
    }


}

