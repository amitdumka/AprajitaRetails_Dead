namespace AprajitaRetailsDataBase.Client
{
    /// <summary>
    /// It deal with Client part of Aprajita retails or any other The Arvind Store
    /// It create An Arvind Store
    /// </summary>
    public class Client
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
}