using AprajitaRetailsDataBase;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AprajitaRetailMonitor.SeviceWorker
{
    public class InsertData
    {
        #region LinqSql

        public const string dbName = @".\TASVoyger.mdf";

        private TASVoyger voyDatabase;

        public bool ConnectLinqDataBase( )
        {
            if (voyDatabase == null)
                voyDatabase = new TASVoyger(dbName);
            if (voyDatabase.Connection.State == ConnectionState.Open)
                return true;
            else return false;
        }

        public void InsertBillData( VoygerBillWithLinq voygerBill )
        {
            VoyBill bill = voygerBill.bill;
            List<LineItems> lineItemList = voygerBill.lineItems;
            List<VPaymentMode> paymentList = voygerBill.payModes;
            ConnectLinqDataBase();
            voyDatabase.VoyBills.InsertOnSubmit(bill);
            // Get Last Inserted Row
            foreach (LineItems item in lineItemList)
            {
                item.VoyBillId = bill.ID;
                voyDatabase.LineItem.InsertOnSubmit(item);
            }
            foreach (VPaymentMode item in paymentList)
            {
                item.VoyBillId = bill.ID;
                voyDatabase.VPaymentModes.InsertOnSubmit(item);
            }
        }

        #endregion LinqSql

        //Below is Old Data . Add Any function for Linq Above else down

        #region SqlDataTable

        // Insert Bill Data and Customer Data to Table
        public void InsertBillData( DataTable table, SqlConnection con, string sqlQuery )
        {
            InsertDataTabletoSql(table, con, sqlQuery);
        }

        public void InsertLineItems( )
        {
        }

        public void InsertPaymentDetails( )
        {
        }

        public int InsertDataTabletoSql( DataTable table, SqlConnection con, string sqlQuery )
        {
            int status = -9999;
            if (con.State != ConnectionState.Open)
                con.Open();

            using (var adapter = new SqlDataAdapter(sqlQuery, con))
            using (var builder = new SqlCommandBuilder(adapter))
            {
                adapter.InsertCommand = builder.GetInsertCommand();
                status = adapter.Update(table);
                // adapter.Update(ds.Tables[0]); (Incase u have a data-set)
            }
            con.Close();
            return status;
        }

        #endregion SqlDataTable
    }
}