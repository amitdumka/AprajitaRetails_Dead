namespace AprajitaRetailsDB.Migrations.MainDB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class MainDBConfiguration : DbMigrationsConfiguration<AprajitaRetailsDB.DataBase.AprajitaRetails.AprajitaRetailsMainDB>
    {
        public MainDBConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed=true;
            ContextKey = "AprajitaRetailsDB.DataBase.AprajitaRetails.AprajitaRetailsMainDB";
        }

        protected override void Seed(AprajitaRetailsDB.DataBase.AprajitaRetails.AprajitaRetailsMainDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //TODO: Basic Data Need to Addhere
            //DataBase.AprajitaRetails.AprajitaRetailsMainDBSeeder dBSeeder = new DataBase.AprajitaRetails.AprajitaRetailsMainDBSeeder();
            //dBSeeder.InitializeDatabase(context);

            //TODO: update this section for Update version or db change happens in future upgrades
            
        }
    }
}
