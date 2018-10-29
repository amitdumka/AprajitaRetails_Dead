namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BankDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BankDetail()
        {
            Expenses = new HashSet<Expenses>();
        }

        [Key]
        public int BankDetailsID { get; set; }

        public DateTime OnDate { get; set; }
        [StringLength(100)]
        public string RefID { get; set; }

        public int BankID { get; set; }

        public int? TranscationType { get; set; }

        [StringLength(100)]
        public string BankRef { get; set; }

        [StringLength(100)]
        public string TranscationRef { get; set; }

        public virtual Bank Bank { get; set; }
        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expenses> Expenses { get; set; }
    }
}
