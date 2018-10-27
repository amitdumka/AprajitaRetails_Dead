namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Client
    {
        [Key]
        public int ClinetsID { get; set; }

        [Required]
        [StringLength(100)]
        public string ClientName { get; set; }

        [StringLength(100)]
        public string ClientAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string ClientCity { get; set; }

        [Required]
        [StringLength(20)]
        public string ClientCode { get; set; }

        [StringLength(100)]
        public string ClientPhoneNo { get; set; }

        [StringLength(100)]
        public string ClientGSTNo { get; set; }

        [StringLength(100)]
        public string ClientVatNo { get; set; }
    }
}
