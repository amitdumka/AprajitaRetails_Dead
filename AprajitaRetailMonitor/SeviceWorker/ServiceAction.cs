using AprajitaRetails.Voy;
using System.Threading.Tasks;

namespace AprajitaRetailMonitor.SeviceWorker
{
    /// <summary>
    /// This class is used to take action based on singal
    /// </summary>
    public class ServiceAction
    {
        private static Task t = null;

        public static void InsertInvoiceXML( string filename )
        {
            //TODO: write action
            t = Task.Run(( ) => ProcessInvoiceXML(filename));
            //TODO:Make Changes as said Below
            /*
             * first all readyvoyBillXML need to bifurcate
             * first file will rear xml file into dataset
             * second function will convert dataset to vouBill object
             * third function verify and process
             * third:A  will insert Customer data
             * third:B will line items
             * third:C will enter voy bill table
             * third:c will payment details after checking payment mode CA CR MW else
             */
        }

        private static void ProcessInvoiceXML( string invoiceXMLFile )
        {
            VoygerBill voygerBill = VoygerXMLReader.ReadInvoiceXML(invoiceXMLFile);
            if (voygerBill != null)
            {
            }
            else
            {
                //TODO: Raise Event  and store in database for futher intervention.
            }
        }

        public static void InsertTabletBillXML( )
        {
            //TODO: write action
        }

        public static void InsertTailroingHUB( )
        {
            //TODO: write action
        }
    }
}