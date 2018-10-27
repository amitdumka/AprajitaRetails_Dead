using AprajitaRetailsDataBase.SqlDataBase.Data;
using System.Collections.Generic;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    public class CustomerVM
    {
        public CustomerVM( )
        {
            DB=new CustomerDB();
        }

        public void AddData( )
        {
        }

        public Customer GetCustomer( string mob )
        {
            return DB.GetCustomer( mob );
        }

        public Customer GetCustomerByName( string name )
        {
            return DB.GetCustomerByName( name );
        }

        public List<Customer> GetCustomersByName( string name )
        {
            return DB.GetCustomersByName( name );
        }

        public List<string> GetMobileList( )
        {
            return DB.GetMobileList();
        }

        public int SaveData( Customer cust )
        {
            return DB.InsertData( cust );
        }

        private CustomerDB DB;
    }
}