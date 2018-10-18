using AprajitaRetailsDataBase.SqlDataBase.ViewModel;
using CyberN.Utility;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AprajitaRetailsDataBase.Client
{
    public class ClientDB : DataOps<Clients>
    {
        public int GetNoOfRecord( )
        {
            SqlCommand cmd = new SqlCommand("select  count(ID) as CTR from Clients", Db.DBCon);
            return (int)cmd.ExecuteScalar();
        }

        public override int InsertData( Clients obj )
        {
            SqlCommand cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue("@ClientCity", obj.ClientCity);
            cmd.Parameters.AddWithValue("@ClientCode", obj.ClientCode);
            cmd.Parameters.AddWithValue("@ClientGSTNo", obj.ClientGSTNo);
            cmd.Parameters.AddWithValue("@ClientName", obj.ClientName);
            cmd.Parameters.AddWithValue("@ClientPhoneNo", obj.ClientPhoneNo);
            cmd.Parameters.AddWithValue("@ClientVatNo", obj.ClientVatNo);
            cmd.Parameters.AddWithValue("@ClientAddress", obj.ClientAddress);
            return cmd.ExecuteNonQuery();

            //throw new NotImplementedException ();
        }

        public override Clients ResultToObject( List<Clients> data, int index )
        {
            return data[index];
        }

        public override Clients ResultToObject( SortedDictionary<string, string> data )
        {
            Clients clients = new Clients()
            {
                ID = Basic.ToInt(data["ID"]),
                ClientAddress = data["ClientAddress"],
                ClientCity = data["City"],
                ClientCode = data["ClientCode"],
                ClientGSTNo = data["ClientGSTNo"],
                ClientName = data["ClientName"],
                ClientPhoneNo = data["ClientPhoneNo"],
                ClientVatNo = data["ClientVatNo"]
            };
            return clients;
            // throw new NotImplementedException ();
        }

        public override List<Clients> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            List<Clients> listItem = new List<Clients>();
            foreach (var data in dataList)
            {
                Clients clients = new Clients()
                {
                    ID = Basic.ToInt(data["ID"]),
                    ClientAddress = data["ClientAddress"],
                    ClientCity = data["ClientCity"],
                    ClientCode = data["ClientCode"],
                    ClientGSTNo = data["ClientGSTNo"],
                    ClientName = data["ClientName"],
                    ClientPhoneNo = data["ClientPhoneNo"],
                    ClientVatNo = data["ClientVatNo"]
                };
                listItem.Add(clients);
            }
            return listItem;
        }
    }
}