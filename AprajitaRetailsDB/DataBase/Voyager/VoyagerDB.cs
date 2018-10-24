namespace AprajitaRetailsDB.DataBase.Voyager
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VoyagerDB : DbContext
    {
        public VoyagerDB( )
            : base( "VoyagerDB" )
        {
        }

        public virtual DbSet<InsertDataLog> InsertDataLogs { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<VoyBill> VoyBills { get; set; }
        public virtual DbSet<VPaymentMode> VPaymentModes { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<InsertDataLog>()
                .Property( e => e.CreatedDate )
                .IsFixedLength();
        }
    }
}
