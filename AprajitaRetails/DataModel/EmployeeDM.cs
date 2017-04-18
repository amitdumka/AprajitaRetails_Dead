using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AprajitaRetails.Data;

namespace AprajitaRetails.DataModel
{
    public class EmployeeDM
    {
        public int ID { get; set; }
        public string EMPCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime DateOfLeaving { get; set; }
        public string Status { get; set; }
        public int EmpType { get; set; }
        public int AttendenceId { set; get; }

        public EmployeeDM()
        {


        }

    }
   
}
