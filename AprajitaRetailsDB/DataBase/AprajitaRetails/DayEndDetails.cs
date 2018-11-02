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
    [Table ( "DayEndDetails" )]
    public class DayEndDetails
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int DayEndDetailsID { set; get; }
        public int DayClosingID { set; get; }
        public DateTime OnDate { set; get; }

        public double TotalSale { set; get; }

        public double CreditCardSale { get; set; }
        public double DebitCardSale { get; set; }

        public double TotalRMZSale { set; get; }
        public double TotalFabricSale { set; get; }
        public double TotalRMZNo { set; get; }
        public double TotalFabricNo { set; get; }

        public double TailoringSale { get; set; }
        public int TotalTailorDeliveryNo { get; set; }
        public double TotalTailoringBookingAmount { set; get; }
        public int TotalTailoringBookingNo { set; get; }

        public double TotalBankDeposit { set; get; }
        public double TotalBankPayment { set; get; }
        public double TotalCashPayment { set; get; }

        public double TotalExpenses { set; get; }

        public double TotalAccessicorySale { get; set; }
        public int TotalAccessicoryNo { get; set; }
        [StringLength( 20 )]
        public string StoreCode { get; set; }
    }


}

