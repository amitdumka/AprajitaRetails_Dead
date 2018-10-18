using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class SaleItemsDB : DataOps<SaleItem>
    {
        public int InsertData( DataTable dt )
        {
            int ctr = 0;
            foreach (DataRow dr in dt.Rows)
            {
                SqlCommand cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);
                cmd.Parameters.AddWithValue("@InvoiceNo", dr["InvoiceNo"]);
                cmd.Parameters.AddWithValue("@BarCode", dr["BarCode"]);
                cmd.Parameters.AddWithValue("@Qty", dr["Qty"]);
                cmd.Parameters.AddWithValue("@MRP", dr["MRP"]);
                cmd.Parameters.AddWithValue("@BasicAmount", dr["MRP"]);
                //TODO:urgent basic amount cal
                cmd.Parameters.AddWithValue("@Discount", dr["Discount"]);
                cmd.Parameters.AddWithValue("@Tax", dr["Tax"]);
                cmd.Parameters.AddWithValue("@BillAmount", dr["Amount"]);
                cmd.Parameters.AddWithValue("@SalesmanID", "001");
                //TODO: saleman need to add up

                if (cmd.ExecuteNonQuery() > 0)
                    ctr++;
            }
            return ctr;
        }

        public override int InsertData( SaleItem dr )
        {
            SqlCommand cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);

            cmd.Parameters.AddWithValue("@InvoiceNo", dr.InvoiceNo);
            cmd.Parameters.AddWithValue("@BarCode", dr.BarCode);
            cmd.Parameters.AddWithValue("@Qty", dr.Qty);
            cmd.Parameters.AddWithValue("@MRP", dr.MRP);
            cmd.Parameters.AddWithValue("@BasicAmount", dr.BasicAmount);
            cmd.Parameters.AddWithValue("@Discount", dr.Discount);
            cmd.Parameters.AddWithValue("@Tax", dr.Tax);
            cmd.Parameters.AddWithValue("@BillAmount", dr.BillAmount);
            cmd.Parameters.AddWithValue("@SalesmanID", dr.SalesmanID);
            return cmd.ExecuteNonQuery();
        }

        public override SaleItem ResultToObject( List<SaleItem> data, int index )
        {
            throw new NotImplementedException();
        }

        public override SaleItem ResultToObject( SortedDictionary<string, string> data )
        {
            throw new NotImplementedException();
        }

        public override List<SaleItem> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            throw new NotImplementedException();
        }
    }
}