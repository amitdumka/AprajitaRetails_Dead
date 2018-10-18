using System;
using System.Collections.Generic;
using AprajitaRetailsDataBase.SqlDataBase.Data;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class StoresBD : DataOps<Stores>
    {
        public override int InsertData( Stores obj )
        {
            throw new NotImplementedException();
        }

        public override Stores ResultToObject( List<Stores> data, int index )
        {
            throw new NotImplementedException();
        }

        public override Stores ResultToObject( SortedDictionary<string, string> data )
        {
            throw new NotImplementedException();
        }

        public override List<Stores> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            throw new NotImplementedException();
        }
    }
}