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
            //LogEvent.WriteEvent( "insertinvoicexml" );
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
            else if (DBType==2)           
            {
                //LogEvent.WriteEvent( "processinvoicexml _with_EF6" );
                AprajitaRetailsDB.DataTypes.VoygerBill voygerBill = EF.VoygerXMLReader.ReadInvoiceXML( invoiceXMLFile );
                //LogEvent.WriteEvent( "voygerBill Readed _with_EF6" );

                if (voygerBill!=null)
                {
                    //LogEvent.WriteEvent( "voygerBill Readed and have data _with_EF6" );
                    EF.InsertData.InsertBillData( voygerBill );
                }
                else
                {
                    LogEvent.WriteEvent( "voygerBill Readed, and it is empty" );
                    //TODO: Raise Event  and store in database for futher intervention.
                }
            }

            LogEvent.WriteEvent( "ProcessInvoiceXml is ended.#"+Watcher.NoOfEvent );
            Watcher.NoOfEvent=0;
            LogEvent.WriteEvent( "NoofEvent:"+Watcher.NoOfEvent );
        }
    }
}