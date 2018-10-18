using System.Collections.Generic;
using System.Data.SqlClient;
using AprajitaRetailsDataBase.SqlDataBase.Data;
using CyberN.Utility;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class ExpensesCategoryDB : DataOps<ExpensesCategory>
    {
        public ExpensesCategoryDB( )
        {
            //TODO: Remove in realse version

            DefaultData();
        }

        public int DefaultData( )
        {
            //TODO: Remove in realse version

            SqlCommand cmd = new SqlCommand("select count(ID) from " + Tablename, Db.DBCon);

            int x = (int)cmd.ExecuteScalar();
            if (x >= 7)
                return -1;

            cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue("@Category", "Snacks");
            cmd.Parameters.AddWithValue("@Level", ExpensesLevel.General);
            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Level", ExpensesLevel.General);
            cmd.Parameters.AddWithValue("@Category", "Printing");
            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Level", ExpensesLevel.General);
            cmd.Parameters.AddWithValue("@Category", "Puja Items");
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Level", ExpensesLevel.General);
            cmd.Parameters.AddWithValue("@Category", "Postage");
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Level", ExpensesLevel.General);
            cmd.Parameters.AddWithValue("@Category", "Ads");
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Level", ExpensesLevel.General);
            cmd.Parameters.AddWithValue("@Category", "Statinonary");
            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Level", ExpensesLevel.Other);
            cmd.Parameters.AddWithValue("@Category", "Others");
            return cmd.ExecuteNonQuery();
        }

        public override int InsertData( ExpensesCategory obj )
        {
            SqlCommand cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue("@Category", obj.Category);
            cmd.Parameters.AddWithValue("@Level", obj.Level);
            return cmd.ExecuteNonQuery();
        }

        public override ExpensesCategory ResultToObject( List<ExpensesCategory> data, int index )
        {
            return data[index];
        }

        public override ExpensesCategory ResultToObject( SortedDictionary<string, string> data )
        {
            ExpensesCategory cat = new ExpensesCategory()
            {
                Category = data["Category"],
                ID = Basic.ToInt(data["ID"]),
                Level = Basic.ToInt(data["Level"])
            };
            return cat;
        }

        public override List<ExpensesCategory> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            List<ExpensesCategory> list = new List<ExpensesCategory>();
            foreach (var data in dataList)
            {
                ExpensesCategory cat = new ExpensesCategory()
                {
                    Category = data["Category"],
                    ID = Basic.ToInt(data["ID"]),
                    Level = Basic.ToInt(data["Level"])
                };
                list.Add(cat);
            }
            return list;
        }
    }
}