using System;

namespace AprajitaRetailsDataBase.SqlDataBase.Data
{
    public class Employee
    {
        public int ID { get; set; }
        public string EMPCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int EmpType { get; set; }
        public int AttendenceId { set; get; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime DateOfLeaving { get; set; }
        public string MobileNo { set; get; }
        public string Status { get; set; }
    }
}