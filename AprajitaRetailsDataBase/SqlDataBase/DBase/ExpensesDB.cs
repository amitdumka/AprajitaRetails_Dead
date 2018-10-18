using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AprajitaRetailsDataBase.SqlDataBase.Data;
using AprajitaRetailsDataBase.TableCreator;
using CyberN.Utility;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class ExpensesDB : DataOps<Expenses>
    {
        private readonly string DetailTableName = "BankDetails";

        private string InsertDetailsSqlQuery = "";

        //Expesnes Details Section Addition
        private TableClass tableDetails;

        public ExpensesDB( )
        {
            tableDetails = new TableClass(typeof(BankDetails));
            DetailTableName = tableDetails.ClassName;
            InsertDetailsSqlQuery = tableDetails.CreateInsertScript();
            if (!IsTableExist(DetailTableName))
            {
                CreateTable(tableDetails.CreateTableScript());
            }
        }

        public List<string> GetApprovedByList( )
        {
            string sql = "select FirstName, LastName from Employee";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                List<string> names = new List<string>();
                while (reader.Read())
                {
                    names.Add(reader["FirstName"] + " " + reader["LastName"]);
                    Console.WriteLine("name= {0}-{1}", reader["FirstName"], reader["LastName"]);
                }
                return names;
            }
            else
                return null;
        }

        public BankDetails GetBankDetails( int bankDetailsID )
        {
            string sql = "select * from BankDetails where ID=" + bankDetailsID;
            BankDetails bankDetails = null;
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader != null && reader.HasRows)
            {
                reader.Read();
                bankDetails = new BankDetails()
                {
                    BankID = (int)reader["BankID"],
                    ID = (int)reader["ID"],
                    RefID = (string)reader["RefID"],
                    TranscationType = (int)reader["TranscationType"],
                    BankRef = (string)reader["BankRef"],
                    TranscationRef = (string)reader["TranscationRef"]
                };
            }

            return bankDetails;
        }

        public int InsertBankDetails( BankDetails bankDetails )
        {
            SqlCommand cmd = new SqlCommand(InsertDetailsSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue("@BankID", bankDetails.BankID);
            cmd.Parameters.AddWithValue("@BankRef", bankDetails.BankRef);
            cmd.Parameters.AddWithValue("@RefID", bankDetails.RefID);
            cmd.Parameters.AddWithValue("@TranscationRef", bankDetails.TranscationRef);
            cmd.Parameters.AddWithValue("@TranscationType", bankDetails.TranscationType);

            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                cmd.CommandText = "select Max(ID) from " + DetailTableName;
                return (int)cmd.ExecuteScalar();
            }
            else
                return -1;
        }

        // End of details section

        public override int InsertData( Expenses obj )
        {
            SqlCommand cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue("@ApprovedBy", obj.ApprovedBy);
            cmd.Parameters.AddWithValue("@BankDetailsID", obj.BankDetailsID);
            cmd.Parameters.AddWithValue("@ExpensesCategoryID", obj.ExpensesCategoryID);
            cmd.Parameters.AddWithValue("@ExpensesReason", obj.ExpensesReason);
            cmd.Parameters.AddWithValue("@PaymentModeID", obj.PaymentModeID);

            return cmd.ExecuteNonQuery();
        }

        public override Expenses ResultToObject( List<Expenses> data, int index )
        {
            return data[index];
        }

        public override Expenses ResultToObject( SortedDictionary<string, string> data )
        {
            Expenses exp = new Expenses()
            {
                Amount = double.Parse(data["Amount"]),
                ApprovedBy = data["ApprovedBy"],
                ExpensesReason = data["ExpensesReason"],
                BankDetailsID = Basic.ToInt(data["BankDetailsID"]),
                ID = Basic.ToInt(data["ID"]),
                PaymentModeID = Basic.ToInt(data["PaymentModeId"]),
                ExpensesCategoryID = Basic.ToInt(data["ExpensesCategoryId"])
            };
            return exp;
        }

        public override List<Expenses> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            List<Expenses> expList = new List<Expenses>();
            foreach (var data in dataList)
            {
                Expenses exp = new Expenses()
                {
                    Amount = double.Parse(data["Amount"]),
                    ApprovedBy = data["ApprovedBy"],
                    ExpensesReason = data["ExpensesReason"],
                    BankDetailsID = Basic.ToInt(data["BankDetailsID"]),
                    ID = Basic.ToInt(data["ID"]),
                    PaymentModeID = Basic.ToInt(data["PaymentModeId"]),
                    ExpensesCategoryID = Basic.ToInt(data["ExpensesCategoryId"])
                };
                expList.Add(exp);
            }
            return expList;
        }
    }
}