using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetails.Data
{
    /// <summary>
    /// TableName: Customer
    /// </summary>
    public class Customer
    {
        public int ID { set; get; }
        public int Age { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string City { set; get; }
        public string MobileNo { set; get; }
        public int Gender { set; get; }
        public int NoOfBills { set; get; }
        public double TotalAmount { set; get; }
    }

}
