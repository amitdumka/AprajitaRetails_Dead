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
            Employee employee = new Employee() {
                AddressLine1="Bhagalpur Road, Dumka",Age=36, AttendenceDeviceId=1,
                City="Dumka",Country="India",DateOfBirth=DateTime.Parse("24/07/1982"),
                DateOfJoining=DateTime.Parse("17/02/2016"),EMPCode="MD20160001",FirstName="Amit",
                LastName="Kumar",MobileNo="7779997556",State="Jharkhand",Status="Active",
                StoreCode="JH006",EmpTypeID=1,Gender=1
            };
            context.Employees.Add( employee );

            base.Seed( context );
        }
    }
}