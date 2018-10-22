using AprajitaRetailsDB.Models.Voyger;
using System.Data.Entity;

namespace AprajitaRetailsDB.Data
{
    public class VoygerDB : DbContext
    {
        public DbSet<VoyBill> VoyBill { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<VPaymentMode> VPaymentModes { get; set; }
        public DbSet<InsertDataLog> InsertDataLogs { get; set; }
    }
}