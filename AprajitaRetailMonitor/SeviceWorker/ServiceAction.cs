using System.Threading.Tasks;

namespace AprajitaRetailMonitor.SeviceWorker
{
    /// <summary>
    /// This class is used to take action based on singal
    /// </summary>
    public class ServiceAction
    {
        private static Task t = null;

        public static void InsertInvoiceXML( string filename, System.Diagnostics.EventLog eventLog )
        {
            t = Task.Run(( ) => ProcessInvoiceXML(filename));
        }

        public static void InsertInvoiceXML( string filename )
        {
            t = Task.Run(( ) => ProcessInvoiceXML(filename));
        }

        public static void InsertTabletBillXML( )
        {
            //TODO: write action
        }

        public static void InsertTailroingHUB( )
        {
            //TODO: write action
        }

        private static void ProcessInvoiceXML( string invoiceXMLFile )
        {
            VoygerBillWithLinq voygerBill = VoygerXMLReader.ReadInvoiceXML(invoiceXMLFile);

            if (voygerBill != null)
            {
                InsertData insertData = new InsertData();
                insertData.InsertBillData(voygerBill);
            }
            else
            {
                LogEvent.WriteEvent("voygerBill Readed, and it is empty");
                //TODO: Raise Event  and store in database for futher intervention.
            }
            LogEvent.WriteEvent("ProcessInvoiceXml is ened");
            Watcher.NoOfEvent--;
        }
    }
}