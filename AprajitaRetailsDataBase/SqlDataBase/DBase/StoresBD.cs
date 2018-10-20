using AprajitaRetailsDataBase.SqlDataBase.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class StoresBD : DataOps<Stores>
    {
        public override int InsertData( Stores obj )
        {
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = InsertSqlQuery
            };
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@City", obj.City);
            return Db.Insert(cmd);
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