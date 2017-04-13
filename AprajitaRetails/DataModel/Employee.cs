using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetails.DataModel
{
    public class Employee
    {
        public int ID { get; set; }
        public string EMPCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime DateOfLeaving { get; set; }
        public string Status { get; set; }
        public EmployeeType Category { get; set; }
        public Employee()
        {


        }

    }
   public  class EmployeeType
    {
        public static readonly int Owner = 1;
        public static readonly int StoreManager = 2;
        public static readonly int AssistanceManager = 3;
        public static readonly int SalesMan = 4;
        public static readonly int HouseKeeping = 5;
        public static readonly int Accountant = 6;
        public static readonly int Others = 7;
        public enum EmpType
        {
            Owner = 1, StoreManger = 2, AssistanceManager = 3, SalesMan = 4, Housekeeping = 5,
            Accountant = 6, Other = 7

        }

    }
}
