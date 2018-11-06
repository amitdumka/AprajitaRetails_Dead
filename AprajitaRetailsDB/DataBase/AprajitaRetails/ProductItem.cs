namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    //TODO: Add Produtype so Category can be checked
    [Table("ProductItem")]
    public partial class ProductItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductItem()
        {
            PurchaseItems = new HashSet<PurchaseItem>();
            SaleItems = new HashSet<SaleItem>();
            StockSales = new HashSet<StockSale>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductItemID { get; set; }

        [StringLength(100)]
        public string StyleCode { get; set; }

        [Key]
        [StringLength(100)]
        public string Barcode { get; set; }

        [StringLength(100)]
        public string SupplierId { get; set; }

        [StringLength(100)]
        public string BrandName { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(100)]
        public string ItemDesc { get; set; }

        [Column(TypeName = "money")]
        public decimal? MRP { get; set; }

        [Column(TypeName = "money")]
        public decimal? Tax { get; set; }

        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }

        [StringLength(100)]
        public string Size { get; set; }

        [Column(TypeName = "money")]
        public decimal? Qty { get; set; }

        [StringLength( 20 )]
        public string StoreCode { get; set; }


        public virtual Stock Stock { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleItem> SaleItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockSale> StockSales { get; set; }
    }
}
