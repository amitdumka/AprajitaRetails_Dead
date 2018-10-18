using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class PaymentDetailDB : DataOps<PaymentDetails>
    {
        public override int InsertData( PaymentDetails obj )
        {
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = InsertSqlQuery
            };
            cmd.Parameters.AddWithValue("@InvoiceNo", obj.InvoiceNo);
            cmd.Parameters.AddWithValue("@CardAmount", obj.CardAmount);
            cmd.Parameters.AddWithValue("@CardDetailsID", obj.CardDetailsID);
            cmd.Parameters.AddWithValue("@CashAmount", obj.CashAmount);
            cmd.Parameters.AddWithValue("@PayMode", obj.PayMode);
            return Db.Insert(cmd);
        }

        public override PaymentDetails ResultToObject( List<PaymentDetails> data, int index )
        {
            throw new NotImplementedException();
        }

        public override PaymentDetails ResultToObject( SortedDictionary<string, string> data )
        {
            throw new NotImplementedException();
        }

        public override List<PaymentDetails> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            throw new NotImplementedException();
        }
    }
}