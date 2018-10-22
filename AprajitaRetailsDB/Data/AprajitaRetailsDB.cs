using AprajitaRetailsDB.Models;
using System.Data.Entity;

namespace AprajitaRetailsDB.Data
{
    public class AprajitaRetailsDB : DbContext
    {
        private DbSet<Advances> Advances { get; set; }
        private DbSet<Attendence> Attendences { get; set; }
        private DbSet<AuthUsers> AuthUsers { get; set; } 
    }
}