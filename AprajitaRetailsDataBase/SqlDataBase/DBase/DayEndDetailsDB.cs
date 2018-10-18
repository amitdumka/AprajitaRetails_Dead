using System;
using System.Collections.Generic;
using AprajitaRetailsDataBase.SqlDataBase.Data;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class DayEndDetailsDB : DataOps<DayEndDetails>
    {
        public override int InsertData( DayEndDetails obj )
        {
            throw new NotImplementedException();
        }

        public override DayEndDetails ResultToObject( List<DayEndDetails> data, int index )
        {
            throw new NotImplementedException();
        }

        public override DayEndDetails ResultToObject( SortedDictionary<string, string> data )
        {
            throw new NotImplementedException();
        }

        public override List<DayEndDetails> ResultToObject( List<SortedDictionary<string, string>> data )
        {
            throw new NotImplementedException();
        }
    }
}