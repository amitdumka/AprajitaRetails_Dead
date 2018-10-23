//using AprajitaRetailsDataBase.Client;

namespace AprajitaRetailMonitor.SeviceWorker.Common
{
    //public class VoygerXMLToLinqDB
    //{
    //    private readonly DataTable vbTable;
    //    //private static readonly Clients client = CurrentClient.LoggedClient;

    //    public VoygerXMLToLinqDB( )
    //    {
    //        vbTable=new DataTable( "VoyBill" );
    //    }
    //}

    public class VoyTable
    {
        public const string T_Bill = "bill";
        public const string T_LineItem = "line_item";
        public const string T_Customer = "customer";
        public const string T_Payments = "payment";
    }
}