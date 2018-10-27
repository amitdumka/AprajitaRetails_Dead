using AprajitaRetailsDB.DataBase.AprajitaRetails;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Customer = AprajitaRetailsDB.DataBase.AprajitaRetails.Customer;

namespace AprajitaRetailsViewModels.EF6
{
    public class CustomerViewModel : IDisposable
    {
        #region Decalrations

        private AprajitaRetailsMainDB mainDB;

        public void Dispose( )
        {
            ((IDisposable)mainDB).Dispose();
        }

        public CustomerViewModel( )
        {
            mainDB=new AprajitaRetailsMainDB();
        }

        #endregion Decalrations

        #region Get Functions

        /// <summary>
        ///  Return list of Mobile no of customers
        /// </summary>
        /// <returns></returns>
        public List<string> GetMobileList( )
        {
            mainDB.Customers.Load();
            return mainDB.Customers.Local.Select( s => s.MobileNo ).ToList();
        }

        public Customer GetCustomer( string mob )
        {
            mainDB.Customers.Load();
            return mainDB.Customers.Local.Where( s => s.MobileNo==mob ).FirstOrDefault();
        }

        public Customer GetCustomerByName( string name )
        {
            mainDB.Customers.Load();
            return mainDB.Customers.Local.Where( s => s.FirstName==name ).FirstOrDefault();
        }

        public List<Customer> GetCustomersByName( string name )
        {
            mainDB.Customers.Load();
            return mainDB.Customers.Local.Where( s => s.FirstName==name ).ToList();
        }

        #endregion Get Functions

        #region Save

        public int SaveData( Customer cust )
        {
            mainDB.Customers.Add( cust );
            return mainDB.SaveChanges();
        }

        #endregion Save
    }
}