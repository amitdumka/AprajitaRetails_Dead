namespace AprajitaRetailsDB.Migrations.HRMDB
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AprajitaRetailsDB.DataBase.AprajitaRetails.HRM;

    internal sealed class HRMConfiguration : DbMigrationsConfiguration<AprajitaRetailsDB.DataBase.AprajitaRetails.HRM.AprajitaRetailsHRMDB>
    {
        public HRMConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AprajitaRetailsDB.DataBase.AprajitaRetails.HRM.AprajitaRetailsHRMDB context)
        {
            //  This method will be called after migrating to the latest version.
           // IList<EmpType> list = new List<EmpType>();
           // context.EmpTypes.AddOrUpdate( list );

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //base.Seed( context );
        }
    }
}
