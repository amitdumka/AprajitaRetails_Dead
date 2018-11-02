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
    [Table("ProductType")]
    public class ProductType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }
        public int? IsFrieghtCharged { get; set; }
        public decimal? RateOfFrieghtCharged { set; get; }
        public virtual ICollection<PurchaseInward> PurchaseInwards { get; set; }
        public ProductType( )
        {
            PurchaseInwards=new HashSet<PurchaseInward>();
        }

    }
}
