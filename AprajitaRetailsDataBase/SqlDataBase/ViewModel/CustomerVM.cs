using AprajitaRetailsDataBase.SqlDataBase.Data;
using System.Collections.Generic;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    public class CustomerVM
    {
        public void AddData( )
        {
        }

        public int SaveData( Customer cust )
        {
            return DB.InsertData(cust);
        }

        private CustomerDB DB;

        public CustomerVM( )
        {
            DB = new CustomerDB();
        }

        public List<string> GetMobileList( )
        {
            return DB.GetMobileList();
        }

        public Customer GetCustomer( string mob )
        {
            return DB.GetCustomer(mob);
        }

        public Customer GetCustomerByName( string name )
        {
            return DB.GetCustomerByName(name);
        }

        public List<Customer> GetCustomersByName( string name )
        {
            return DB.GetCustomersByName(name);
        }
    }
}