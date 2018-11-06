namespace AprajitaRetailsDB.DataBase.Voyager
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VoyagerDB : DbContext
    {
        //TODO: Database should have username and password. which can be used database. 
        //TODO: All database should be at Same Location. 
        //TODO: All Database should have update , backup and copy function .if any version is updated.
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
