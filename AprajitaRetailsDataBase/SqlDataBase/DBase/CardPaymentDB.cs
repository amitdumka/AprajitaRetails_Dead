using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class CardPaymentDB : DataOps<CardPaymentDetails>
    {
        public override int InsertData( CardPaymentDetails obj )
        {
            SqlCommand cmd = new SqlCommand()
            {
                CommandText = InsertSqlQuery
            };
            cmd.Parameters.AddWithValue("@InvoiceNo", obj.InvoiceNo);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue("@AuthCode", obj.AuthCode);
            cmd.Parameters.AddWithValue("@CardType", obj.CardType);
            cmd.Parameters.AddWithValue("@LastDigit", obj.LastDigit);
            return Db.Insert(cmd);

            //throw new NotImplementedException ();
        }

        public override CardPaymentDetails ResultToObject( List<CardPaymentDetails> data, int index )
        {
            throw new NotImplementedException();
        }

        public override CardPaymentDetails ResultToObject( SortedDictionary<string, string> data )
        {
            throw new NotImplementedException();
        }

        public override List<CardPaymentDetails> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            throw new NotImplementedException();
        }
    }
}