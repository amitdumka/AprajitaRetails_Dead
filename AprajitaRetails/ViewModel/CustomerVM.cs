using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AprajitaRetails.Data;

namespace AprajitaRetails.ViewModel
{
    public class CustomerVM
    {
        public void AddData()
        {

        }
        public int SaveData(Customer cust)
        {
            return DB.InsertData (cust);
        }
        CustomerDB DB;
        public CustomerVM()
        {
            DB = new CustomerDB ();
        }
        public List<string> GetMobileList()
        {
            return DB.GetMobileList ();
        }
        public Customer GetCustomer(string mob)
        {
            return DB.GetCustomer (mob);
        }
        public Customer GetCustomerByName(string name)
        {
            return DB.GetCustomerByName (name);
        }
        public List<Customer> GetCustomersByName(string name)
        {
            return DB.GetCustomersByName (name);
        }
    }
}
