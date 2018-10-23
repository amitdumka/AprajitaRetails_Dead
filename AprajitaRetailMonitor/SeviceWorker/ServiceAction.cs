//using AprajitaRetailsDB.DataTypes;
using System.Threading.Tasks;

namespace AprajitaRetailMonitor.SeviceWorker
{
    /// <summary>
    /// This class is used to take action based on singal
    /// </summary>
    public class ServiceAction
    {
        private static Task t = null;

        public static void InsertInvoiceXML( string filename, int DBType )
        {
            LogEvent.WriteEvent( "insertinvoicexml" );
            t=Task.Run( ( ) => ProcessInvoiceXML( filename, DBType ) );
        }

        public static void InsertTabletBillXML( )
        {
            //TODO: write action
        }

        public static void InsertTailroingHUB( )
        {
            //TODO: write action
        }

        private static void ProcessInvoiceXML( string invoiceXMLFile, int DBType )
        {
            if (DBType==1)
            {
                LogEvent.WriteEvent( "processinvoicexml" );
                Linq.VoygerBillWithLinq voygerBill = Linq.VoygerXMLReader.ReadInvoiceXML( invoiceXMLFile );
                LogEvent.WriteEvent( "voygerBill Readed" );

                if (voygerBill!=null)
                {
                    LogEvent.WriteEvent( "voygerBill Readed and have data" );
                    Linq.InsertData.InsertBillData( voygerBill );
                }
                else
                {
                    LogEvent.WriteEvent( "voygerBill Readed, and it is empty" );
                    //TODO: Raise Event  and store in database for futher intervention.
                }
            }
            else
            {
                LogEvent.WriteEvent( "processinvoicexml" );
                AprajitaRetailsDB.DataTypes.VoygerBill voygerBill = EF.VoygerXMLReader.ReadInvoiceXML( invoiceXMLFile );
                LogEvent.WriteEvent( "voygerBill Readed" );

                if (voygerBill!=null)
                {
                    LogEvent.WriteEvent( "voygerBill Readed and have data" );
                    EF.InsertData.InsertBillData( voygerBill );
                }
                else
                {
                    LogEvent.WriteEvent( "voygerBill Readed, and it is empty" );
                    //TODO: Raise Event  and store in database for futher intervention.
                }
            }

            LogEvent.WriteEvent( "ProcessInvoiceXml is ened.#"+Watcher.NoOfEvent );
            Watcher.NoOfEvent--;
            LogEvent.WriteEvent( "NoofEvent:"+Watcher.NoOfEvent );
        }
    }
}