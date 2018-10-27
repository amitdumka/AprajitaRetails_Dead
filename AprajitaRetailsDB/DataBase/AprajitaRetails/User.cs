namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int UserId { get; set; }

        [Key]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(20)]
        public string passwd { get; set; }

        public int role { get; set; }
        [StringLength( 20 )]
        public string StoreCode { get; set; }

    }
}
