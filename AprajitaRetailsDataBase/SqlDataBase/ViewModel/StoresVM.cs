using AprajitaRetailsDataBase.SqlDataBase.Data;
using System;
using System.Collections.Generic;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class StoresVM
    {
        private StoresBD sDB;

        public StoresVM( )
        {
            sDB = new StoresBD();
        }

        public List<Stores> GetStores( )
        {
            throw new NotImplementedException();
        }

        public int GetStoresId( )
        {
            throw new NotImplementedException();
        }

        public int GetStoresId( string city )
        {
            throw new NotImplementedException();
        }

        public Stores GetStores( int id )
        {
            throw new NotImplementedException();
        }

        public Stores GetStores( string storename, string City )
        {
            throw new NotImplementedException();
        }

        public Stores GetStores( string City )
        {
            throw new NotImplementedException();
        }

        public int AddStores( Stores store )
        {
            return sDB.InsertData(store);
        }

        public int DelStores( int id )
        {
            //TODO: in Larger prospective
            throw new NotImplementedException();
        }

        public int UpdateStores( int id, Stores store )
        {
            throw new NotImplementedException();
        }
    }
}