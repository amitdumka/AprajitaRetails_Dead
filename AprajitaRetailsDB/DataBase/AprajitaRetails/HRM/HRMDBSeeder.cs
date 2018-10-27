using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetailsDB.DataBase.AprajitaRetails.HRM
{
    class HRMDBSeeder : DropCreateDatabaseAlways<AprajitaRetailsHRMDB>
    {
        protected override void Seed( AprajitaRetailsHRMDB context )
        {
            IList<EmpType> defaultEmpType = new List<EmpType>();

            defaultEmpType.Add( new EmpType() { EmpTypeID=1,EmpTypeName="Owner" } );
            defaultEmpType.Add( new EmpType() { EmpTypeID=2, EmpTypeName="Store Manager" } );
            defaultEmpType.Add( new EmpType() { EmpTypeID=3, EmpTypeName="Assistance Manager" } );
            defaultEmpType.Add( new EmpType() { EmpTypeID=4, EmpTypeName="Salesman" } );
            defaultEmpType.Add( new EmpType() { EmpTypeID=5, EmpTypeName="Housekeeping" } );
            defaultEmpType.Add( new EmpType() { EmpTypeID=6, EmpTypeName="Accountant" } );
            defaultEmpType.Add( new EmpType() { EmpTypeID=7, EmpTypeName="Others" } );
            
            context.EmpTypes.AddRange( defaultEmpType );

            base.Seed( context );
        }
    }
}