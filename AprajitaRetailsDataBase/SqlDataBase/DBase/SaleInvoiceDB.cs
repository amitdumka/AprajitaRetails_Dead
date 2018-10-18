using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class SaleInvoiceDB : DataOps<SaleInvoice>
    {
        /// <summary>
        /// Get Item Details Based on BarCode
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public List<SortedDictionary<string, string>> GetItemDetails( string barcode )
        { //TODO: VerifY Uses.
            string sql = "select * from ProductItem where BarCode=@barcode ";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            cmd.Parameters.AddWithValue("@barcode", barcode);
            return DataBase.GetSqlStoreProcedureString(cmd);
        }

        /// <summary>
        /// Get Last Invoice No
        /// </summary>
        /// <returns></returns>
        public string GetLastInvoiceNo( )
        {
            string sql = "select ISNULL( Max(ID),0) from  " + Tablename;
            string inv = "";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            int ids = (int)cmd.ExecuteScalar();

            if (ids > 0)
            {
                sql = "select InvoiceNo from " + Tablename + " where ID=" + ids;
                cmd.CommandText = sql;
                inv = (string)cmd.ExecuteScalar();
            }
            else
            {
                inv = "0";
            }
            return inv;
        }

        /// <summary>
        /// Get Customer Mobile List
        /// </summary>
        /// <returns>Its return list of Mobile no of Customer</returns>
        public List<string> GetCustomerMobileList( )
        {
            string sql = "select MobileNo from Customer";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            return DataBase.GetQueryString(cmd, "MobileNo");
        }

        /// <summary>
        /// Get Customer Infomarion based on MobileNo or ID  Based on search mode
        /// </summary>
        /// <param name="id">CustomerID</param>
        /// <param name="mobileno">MobileNo</param>
        /// <param name="searchMode">Search Mode ID/Mobile</param>
        /// <returns></returns>
        public SortedDictionary<string, string> GetCustomerInfo( int id, string mobileno, int searchMode )
        {
            string sql = "select ID, FirstName, LastName, MobileNo from Customer where ";
            if (searchMode == 1)
            {
                sql = sql + " ID=" + id;
            }
            else if (searchMode == 2)
            {
                sql = sql + "MobileNo='" + mobileno + "'";
            }
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            SortedDictionary<string, string> result = DataBase.GetSqlStoreProcedureString(cmd)[0];
            return result;
        }

        /// <summary>
        /// Get Invoice List
        /// </summary>
        /// <returns>returns List of Invoice</returns>
        public List<string> GetInvoiceList( )
        {
            string sql = "select InvoiceNo from SaleInvoice";
            //TODO: Urgent where OnDate=Year(2017)
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            return DataBase.GetQueryString(cmd, "InvoiceNo");
        }

        public override int InsertData( SaleInvoice obj )
        {
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = InsertSqlQuery
            };
            cmd.Parameters.AddWithValue("@CustomerId", obj.CustomerId);
            cmd.Parameters.AddWithValue("@InvoiceNo", obj.InvoiceNo);
            cmd.Parameters.AddWithValue("@OnDate", obj.OnDate);
            cmd.Parameters.AddWithValue("@RoundOffAmount", obj.RoundOffAmount);
            cmd.Parameters.AddWithValue("@TotalBillAmount", obj.TotalBillAmount);
            cmd.Parameters.AddWithValue("@TotalDiscountAmount", obj.TotalDiscountAmount);
            cmd.Parameters.AddWithValue("@TotalItems", obj.TotalItems);
            cmd.Parameters.AddWithValue("@TotalQty", obj.TotalQty);
            cmd.Parameters.AddWithValue("@TotalTaxAmount", obj.TotalTaxAmount);
            return Db.Insert(cmd);
            // throw new NotImplementedException ();
        }

        public override SaleInvoice ResultToObject( List<SaleInvoice> data, int index )
        {
            throw new NotImplementedException();
        }

        public override SaleInvoice ResultToObject( SortedDictionary<string, string> data )
        {
            throw new NotImplementedException();
        }

        public override List<SaleInvoice> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            throw new NotImplementedException();
        }
    }
}