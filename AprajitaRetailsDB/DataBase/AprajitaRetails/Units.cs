namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Unit")]
    public partial class Unit
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
        public Unit( )
        {
            PurchaseItems=new HashSet<PurchaseItem>();
            SaleItems=new HashSet<SaleItem>();
            StockSales=new HashSet<StockSale>();
            Stocks=new HashSet<Stock>();
        }

        
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int UnitID { get; set; }
        [Key]
        [StringLength( 50 )]
        public string UnitName { get; set; }
        

        [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
        public virtual ICollection<SaleItem> SaleItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
        public virtual ICollection<StockSale> StockSales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
