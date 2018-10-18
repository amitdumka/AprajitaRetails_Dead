using System.Collections.Generic;
using System.Data.SqlClient;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class SalesmanDB : DataOps<Salesman>
    {
        public void SampleData( )
        {
            InsertData(new Salesman { ID = -1, SalesmanName = "Sanjeev", SMCode = "SM001" });
            InsertData(new Salesman { ID = -1, SalesmanName = "Mukesh", SMCode = "SM002" });
            InsertData(new Salesman { ID = -1, SalesmanName = "Santosh", SMCode = "SM003" });
        }

        public override int InsertData( Salesman obj )
        {
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = InsertSqlQuery
            };
            cmd.Parameters.AddWithValue("@SalesmanName", obj.SalesmanName);
            cmd.Parameters.AddWithValue("@SMCode", obj.SMCode);
            return Db.Insert(cmd);
        }

        public override Salesman ResultToObject( List<Salesman> data, int index )
        {
            return data[index];
        }

        public override Salesman ResultToObject( SortedDictionary<string, string> data )
        {
            Salesman salesman = new Salesman
            {
                ID = int.Parse(data["ID"]),
                SalesmanName = data["SalesmanName"],
                SMCode = data["SMCode"]
            };
            return salesman;
        }

        public override List<Salesman> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            List<Salesman> list = new List<Salesman>();
            foreach (var data in dataList)
            {
                Salesman salesman = new Salesman
                {
                    ID = int.Parse(data["ID"]),
                    SalesmanName = data["SalesmanName"],
                    SMCode = data["SMCode"]
                };
                list.Add(salesman);
            }
            return list;
        }
    }
}