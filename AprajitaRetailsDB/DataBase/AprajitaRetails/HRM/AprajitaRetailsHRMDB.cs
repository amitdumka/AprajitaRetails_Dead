namespace AprajitaRetailsDB.DataBase.AprajitaRetails.HRM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AprajitaRetailsHRMDB : DbContext
    {
        public AprajitaRetailsHRMDB( )
            : base( "AprajitaRetailsHRMDB" )
        {
            Database.SetInitializer( new HRMDBSeeder() );
        }

        public virtual DbSet<Attendence> Attendences { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmpType> EmpTypes { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Attendence>()
                .Property( e => e.EMPCode )
                .IsUnicode( false );

            modelBuilder.Entity<Attendence>()
                .Property( e => e.AttendenceDeviceID ); 
                

            modelBuilder.Entity<Employee>()
                .Property( e => e.EMPCode )
                .IsUnicode( false );

            modelBuilder.Entity<Employee>()
                .Property( e => e.FirstName )
                .IsUnicode( false );

            modelBuilder.Entity<Employee>()
                .Property( e => e.LastName )
                .IsUnicode( false );

            modelBuilder.Entity<Employee>()
                .Property( e => e.AddressLine1 )
                .IsUnicode( false );

            modelBuilder.Entity<Employee>()
                .Property( e => e.City )
                .IsUnicode( false );

            modelBuilder.Entity<Employee>()
                .Property( e => e.Country )
                .IsUnicode( false );

            modelBuilder.Entity<Employee>()
                .Property( e => e.State )
                .IsUnicode( false );

            modelBuilder.Entity<Employee>()
                .Property( e => e.MobileNo )
                .IsUnicode( false );

            modelBuilder.Entity<Employee>()
                .Property( e => e.Status )
                .IsUnicode( false );

            modelBuilder.Entity<Employee>()
                .HasMany( e => e.Attendences )
                .WithRequired( e => e.Employee )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<EmpType>()
                .Property( e => e.EmpTypeName )
                .IsUnicode( false );

            modelBuilder.Entity<EmpType>()
                .HasMany( e => e.Employees )
                .WithRequired( e => e.EmpType )
                .WillCascadeOnDelete( false );
        }
    }
}
