using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AprajitaRetails.Data;

namespace AprajitaRetails.ViewModel
{
    class StoresVM
    {
        StoresBD sDB;
        public StoresVM()
        {
            sDB = new StoresBD ();
        }
        public List<Stores> GetStores()
        {
            throw new NotImplementedException ();
        }
        public int GetStoresId()
        {
            throw new NotImplementedException ();
        }
        public int GetStoresId(string city)
        {
            throw new NotImplementedException ();
        }
        public Stores GetStores(int id)
        {
            throw new NotImplementedException ();
        }
        public Stores GetStores (string storename,string City)
        {
            throw new NotImplementedException ();
        }
        public Stores GetStores(string City)
        {
            throw new NotImplementedException ();
        }

        public int AddStores(Stores store)
        {
            return sDB.InsertData (store);
        }
        public int DelStores(int id)
        {
            //TODO: in Larger prospective
            throw new NotImplementedException ();
        }
        public int UpdateStores(int id, Stores store)
        {
            throw new NotImplementedException ();
        }


    }
    class StoresBD : DataOps<Stores>
    {
        public override int InsertData(Stores obj)
        {
            throw new NotImplementedException ();
        }

        public override Stores ResultToObject(List<Stores> data, int index)
        {
            throw new NotImplementedException ();
        }

        public override Stores ResultToObject(SortedDictionary<string, string> data)
        {
            throw new NotImplementedException ();
        }

        public override List<Stores> ResultToObject(List<SortedDictionary<string, string>> dataList)
        {
            throw new NotImplementedException ();
        }
    }
}
