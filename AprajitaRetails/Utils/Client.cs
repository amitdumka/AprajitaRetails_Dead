using AprajitaRetails.ViewModel;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AprajitaRetails.Utils
{
    public class Clients
    {
        public int ID { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string ClientCity { get; set; }
        public string ClientCode { get; set; }
        public string ClientPhoneNo { get; set; }
        public string ClientGSTNo { get; set; }
        public string ClientVatNo { get; set; }
    }

    internal class Client
    {
        private static ClientDB cDB = new ClientDB();

        public static bool DefaultClient( )
        {
            Clients client = new Clients()
            {
                ClientAddress = "Bhagalpur Raod Dumka",
                ClientCity = "Dumka",
                ClientCode = "JH006",
                ClientGSTNo = "AJHPA7396P1ZV",
                ClientName = "Aprajita Retails",
                ClientPhoneNo = "06434-224461",
                ClientVatNo = "123123",
                ID = -1
            };
            if (cDB.InsertData(client) > 0)
                return true;
            else
                return false;
        }

        public static bool IsClientExist( )
        {
            if (cDB.GetNoOfRecord() > 0)
                return true;
            else
                return false;
        }

        public static int CreateClient( Clients obj )
        {
            return cDB.InsertData(obj);
        }

        public static Clients GetClientDetails( )
        {
            Clients clients = cDB.GetAllRecord()[0];
            return clients;
        }
    }

    public class CurrentClient
    {
        public static Clients LoggedClient = Client.GetClientDetails();
    }

    internal class ClientDB : DataOps<Clients>
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