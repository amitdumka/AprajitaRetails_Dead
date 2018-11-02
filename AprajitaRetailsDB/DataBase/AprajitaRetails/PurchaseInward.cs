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

    [Table( "PurchaseInward" )]
    public class PurchaseInward
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseInwardID { get; set; }
        [StringLength( 50 )]
        public string GRNNo { get; set; }

        [Column( TypeName = "date" )]
        public DateTime GRNDate { get; set; }

        [StringLength( 50 )]
        public string InvoiceNo { get; set; }

        [Column( TypeName = "date" )]
        public DateTime InvoiceDate { get; set; }

       
        public int ProductTypeID { get; set; }

       

        [Column( TypeName = "money" )]
        public decimal? TotalAmount { get; set; }

        [Column( TypeName = "money" )]
        public decimal? TaxAmount { get; set; }

        [Column( TypeName = "money" )]
        public decimal? FrieghtCharge { get; set; }

        [Column( TypeName = "money" )]
        public decimal? GrandTotal { get; set; }
        public decimal TotalQty { get; set; }

        public int? IsStockOk { get; set; }
        public int? IsPaid { get; set; }
        [StringLength( 20 )]
        public string StoreCode { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
    //TODO: implement fk key concept with purchase inward and other table
    //Add Seeder data also
}
