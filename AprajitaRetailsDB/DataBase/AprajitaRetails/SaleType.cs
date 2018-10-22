namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaleType")]
    public partial class SaleType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SaleType()
        {
            SaleInvoices = new HashSet<SaleInvoice>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SaleTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string SaleTypeName { get; set; }

        public int ISVoyger { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleInvoice> SaleInvoices { get; set; }
    }
}
