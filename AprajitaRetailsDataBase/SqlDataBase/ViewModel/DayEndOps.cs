using AprajitaRetailsDataBase.SqlDataBase.Data;
using System.Data.SqlClient;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal sealed class DayEndOps : DayEndDetailsDB
    {
        private SqlConnection con;
        private DayEndDetails dayEnd;

        public DayEndOps( )
        {
            con = Db.DBCon;
            dayEnd = new DayEndDetails();
        }

        private void SaleData( )
        {
            // string totalSaleQuery = "select sum(BillAmount) from DailySale where SaleDate=@saledate";
            //string totalRMZ = "select Sum(RMZ),sum(Accessory), sum(Fabric), sum(Tailoring) from DailySale= where SaleDate=@saledate ";
            //string cardsale = "select sum(BillAmount) from DailySale where SaleDate=@saledate  groupby PayMode";
            //Total Sale, Total RMZ, Fabric, tailoring,
            //total card sale , debit card , credit card
            //total accessor sale
            //
        }

        private void TailoringData( )
        {
            //total tailoringg booking deliver no with amount
        }

        private void ExpensesAndBank( )
        {
        }

        private void CashDetails( )
        {
        }
    }
}