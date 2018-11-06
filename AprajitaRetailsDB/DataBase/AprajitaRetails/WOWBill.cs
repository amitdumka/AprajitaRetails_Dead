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

namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    [Table("WOWBill")]
   public partial class WOWBill
    {
        public int WOWBillID { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime BillDate { get; set; }
        public decimal BillAmount { get; set; }
        public int SalesmanID { get; set; }
    }
    //TODO: Implement relationship with other tables
    [Table("LastPiece")]
    public partial class LastPiece
    {
        public int LastPieceID { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime BillDate { get; set; }
        public decimal Amount { get; set; }
        public int SalesmanID { get; set; }
        public String BarCode { get; set; }
        public decimal BillQty { get; set; }
        public decimal CurrentStock { get; set; }
        public decimal MRP { get; set; }
        public decimal IncentiveAmount { get; set; }
        public decimal IncentiveRate { get; set; }
        public int IncentiveID { get; set; }
    }
}
