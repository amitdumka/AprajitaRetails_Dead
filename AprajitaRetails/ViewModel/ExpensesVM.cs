using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AprajitaRetails.Data;
using CyberN.TableCreator;

namespace AprajitaRetails.ViewModel
{
    class BankAccountsDB : DataOps<Bank>
    {
        public BankAccountsDB()
        {
            //TODO: remove this in release data.
            CreateDeafultData ();
        }
        public void CreateDeafultData()
        {
            //TODO: Remove in realse version 

            SqlCommand cmd = new SqlCommand ("select count(ID) from " + Tablename, Db.DBCon);
            int x = (int) cmd.ExecuteScalar ();
            if ( x >= 2 )
                return;
            Bank b = new Bank ()
            {
                AccountNo = "123456",
                AccountType = (int) Bank.AccountTypes.Current,
                BankName = "ICICI",
                Branch = "Dumka",
                BranchCity = "Dumka",
                IFSCCode = "ICIC0000630",
                ID = -1
            };
            InsertData (b);
            b = new Bank ()
            {
                AccountNo = "654321",
                AccountType = (int) Bank.AccountTypes.Current,
                BankName = "HDFC",
                Branch = "Dumka",
                BranchCity = "Dumka",
                IFSCCode = "HDFC0001470",
                ID = -2
            };
            InsertData (b);

        }
        public List<SortedDictionary<string, string>> GetAllAccounts()
        {
            List<SortedDictionary<string, string>> list;
            string sql = "select AccountNo, BankName,ID  from Bank";
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            list = DataBase.GetSqlStoreProcedureString (cmd);
            return list;

        }

        public int GetBankID(string accountno)
        {
            string sql = "select ID from Bank where AccountNo=@accNo";

            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            cmd.Parameters.AddWithValue ("@accNo", accountno);
            return (int) cmd.ExecuteScalar ();

        }
        public override int InsertData(Bank obj)
        {
            SqlCommand cmd = new SqlCommand (InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue ("@AccountNo", obj.AccountNo);
            cmd.Parameters.AddWithValue ("@AccountType", obj.AccountType);
            cmd.Parameters.AddWithValue ("@BankName", obj.BankName);
            cmd.Parameters.AddWithValue ("@Branch", obj.Branch);
            cmd.Parameters.AddWithValue ("@BranchCity", obj.BranchCity);
            cmd.Parameters.AddWithValue ("@IFSCCode", obj.IFSCCode);

            return cmd.ExecuteNonQuery ();
        }

        public override Bank ResultToObject(List<Bank> data, int index)
        {
            return data [index];
        }

        public override Bank ResultToObject(SortedDictionary<string, string> data)
        {
            Bank bank = new Bank ()
            {
                AccountNo = data ["AccountNo"],
                IFSCCode = data ["IFSCCode"],
                AccountType = Basic.ToInt (data ["AccountType"]),
                BankName = data ["BankName"],
                Branch = data ["Branch"],
                BranchCity = data ["BranchCity"],
                ID = Basic.ToInt (data ["ID"])

            };
            return bank;

        }

        public override List<Bank> ResultToObject(List<SortedDictionary<string, string>> dataList)
        {
            List<Bank> bankList = new List<Bank> ();
            foreach ( var data in dataList )
            {
                Bank bank = new Bank ()
                {
                    AccountNo = data ["AccountNo"],
                    IFSCCode = data ["IFSCCode"],
                    AccountType = Basic.ToInt (data ["AccountType"]),
                    BankName = data ["BankName"],
                    Branch = data ["Branch"],
                    BranchCity = data ["BranchCity"],
                    ID = Basic.ToInt (data ["ID"])

                };
                bankList.Add (bank);
            }
            return bankList;
        }
    }

    class ExpensesCategoryDB : DataOps<ExpensesCategory>
    {
        public ExpensesCategoryDB()
        {
            //TODO: Remove in realse version 

            DefaultData ();
        }
        public int DefaultData()
        {
            //TODO: Remove in realse version 

            SqlCommand cmd = new SqlCommand ("select count(ID) from " + Tablename, Db.DBCon);

            int x = (int) cmd.ExecuteScalar ();
            if ( x >= 7 )
                return -1;



            cmd = new SqlCommand (InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue ("@Category", "Snacks");
            cmd.Parameters.AddWithValue ("@Level", ExpensesLevel.General);
            cmd.ExecuteNonQuery ();

            cmd.Parameters.Clear ();
            cmd.Parameters.AddWithValue ("@Level", ExpensesLevel.General);
            cmd.Parameters.AddWithValue ("@Category", "Printing");
            cmd.ExecuteNonQuery ();

            cmd.Parameters.Clear ();
            cmd.Parameters.AddWithValue ("@Level", ExpensesLevel.General);
            cmd.Parameters.AddWithValue ("@Category", "Puja Items");
            cmd.ExecuteNonQuery ();
            cmd.Parameters.Clear ();
            cmd.Parameters.AddWithValue ("@Level", ExpensesLevel.General);
            cmd.Parameters.AddWithValue ("@Category", "Postage");
            cmd.ExecuteNonQuery ();
            cmd.Parameters.Clear ();
            cmd.Parameters.AddWithValue ("@Level", ExpensesLevel.General);
            cmd.Parameters.AddWithValue ("@Category", "Ads");
            cmd.ExecuteNonQuery ();
            cmd.Parameters.Clear ();
            cmd.Parameters.AddWithValue ("@Level", ExpensesLevel.General);
            cmd.Parameters.AddWithValue ("@Category", "Statinonary");
            cmd.ExecuteNonQuery ();

            cmd.Parameters.Clear ();
            cmd.Parameters.AddWithValue ("@Level", ExpensesLevel.Other);
            cmd.Parameters.AddWithValue ("@Category", "Others");
            return cmd.ExecuteNonQuery ();

        }

        public override int InsertData(ExpensesCategory obj)
        {
            SqlCommand cmd = new SqlCommand (InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue ("@Category", obj.Category);
            cmd.Parameters.AddWithValue ("@Level", obj.Level);
            return cmd.ExecuteNonQuery ();
        }

        public override ExpensesCategory ResultToObject(List<ExpensesCategory> data, int index)
        {
            return data [index];
        }

        public override ExpensesCategory ResultToObject(SortedDictionary<string, string> data)
        {
            ExpensesCategory cat = new ExpensesCategory ()
            {
                Category = data ["Category"],
                ID = Basic.ToInt (data ["ID"]),
                Level = Basic.ToInt (data ["Level"])
            };
            return cat;
        }

        public override List<ExpensesCategory> ResultToObject(List<SortedDictionary<string, string>> dataList)
        {
            List<ExpensesCategory> list = new List<ExpensesCategory> ();
            foreach ( var data in dataList )
            {
                ExpensesCategory cat = new ExpensesCategory ()
                {
                    Category = data ["Category"],
                    ID = Basic.ToInt (data ["ID"]),
                    Level = Basic.ToInt (data ["Level"])
                };
                list.Add (cat);
            }
            return list;
        }
    }

    class ExpensesDB : DataOps<Expenses>
    {
        string DetailTableName = "BankDetails";

        string InsertDetailsSqlQuery = "";

        //Expesnes Details Section Addition 
        TableClass tableDetails;

        public ExpensesDB()
        {
            tableDetails = new TableClass (typeof (BankDetails));
            DetailTableName = tableDetails.ClassName;
            InsertDetailsSqlQuery = tableDetails.CreateInsertScript ();
            if ( !IsTableExist (DetailTableName) )
            {
                CreateTable (tableDetails.CreateTableScript ());
            }
        }

        public List<string> GetApprovedByList()
        {
            string sql = "select FirstName, LastName from Employee";
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            SqlDataReader reader = cmd.ExecuteReader ();

            if ( reader != null && reader.HasRows )
            {
                List<string> names = new List<string> ();
                while ( reader.Read () )
                {
                    names.Add (reader ["FirstName"] + " " + reader ["LastName"]);
                    Console.WriteLine ("name= {0}-{1}", reader ["FirstName"], reader ["LastName"]);
                }
                return names;

            }
            else
                return null;



        }
        
        public BankDetails GetBankDetails(int bankDetailsID)
        {
            string sql = "select * from BankDetails where ID=" + bankDetailsID;
            BankDetails bankDetails = null;
            SqlCommand cmd = new SqlCommand (sql, Db.DBCon);
            SqlDataReader reader = cmd.ExecuteReader ();
            if ( reader != null && reader.HasRows )
            {
                reader.Read ();
                bankDetails = new BankDetails ()
                {
                    BankID = (int) reader ["BankID"],
                    ID = (int) reader ["ID"],
                    RefID = (string) reader ["RefID"],
                    TranscationType = (int) reader ["TranscationType"],
                    BankRef = (string) reader ["BankRef"],
                    TranscationRef = (string) reader ["TranscationRef"]

                };
            }

            return bankDetails;
        }

        public int InsertBankDetails(BankDetails bankDetails)
        {
            SqlCommand cmd = new SqlCommand (InsertDetailsSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue ("@BankID", bankDetails.BankID);
            cmd.Parameters.AddWithValue ("@BankRef", bankDetails.BankRef);
            cmd.Parameters.AddWithValue ("@RefID", bankDetails.RefID);
            cmd.Parameters.AddWithValue ("@TranscationRef", bankDetails.TranscationRef);
            cmd.Parameters.AddWithValue ("@TranscationType", bankDetails.TranscationType);

            int count = cmd.ExecuteNonQuery ();
            if ( count > 0 )
            {
                cmd.CommandText = "select Max(ID) from " + DetailTableName;
                return (int) cmd.ExecuteScalar ();
            }
            else
                return -1;

        }
        // End of details section 

        public override int InsertData(Expenses obj)
        {
            SqlCommand cmd = new SqlCommand (InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue ("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue ("@ApprovedBy", obj.ApprovedBy);
            cmd.Parameters.AddWithValue ("@BankDetailsID", obj.BankDetailsID);
            cmd.Parameters.AddWithValue ("@ExpensesCategoryID", obj.ExpensesCategoryID);
            cmd.Parameters.AddWithValue ("@ExpensesReason", obj.ExpensesReason);
            cmd.Parameters.AddWithValue ("@PaymentModeID", obj.PaymentModeID);
            
            return cmd.ExecuteNonQuery ();
        }

        public override Expenses ResultToObject(List<Expenses> data, int index)
        {
            return data [index];
        }

        public override Expenses ResultToObject(SortedDictionary<string, string> data)
        {
            Expenses exp = new Expenses ()
            {
                Amount = double.Parse (data ["Amount"]),
                ApprovedBy = data ["ApprovedBy"],
                ExpensesReason = data ["ExpensesReason"],
                BankDetailsID = Basic.ToInt (data ["BankDetailsID"]),
                ID = Basic.ToInt (data ["ID"]),
                PaymentModeID = Basic.ToInt (data ["PaymentModeId"]),
                ExpensesCategoryID = Basic.ToInt (data ["ExpensesCategoryId"])
            };
            return exp;


        }

        public override List<Expenses> ResultToObject(List<SortedDictionary<string, string>> dataList)
        {
            List<Expenses> expList = new List<Expenses> ();
            foreach ( var data in dataList )
            {
                Expenses exp = new Expenses ()
                {
                    Amount = double.Parse (data ["Amount"]),
                    ApprovedBy = data ["ApprovedBy"],
                    ExpensesReason = data ["ExpensesReason"],
                    BankDetailsID = Basic.ToInt (data ["BankDetailsID"]),
                    ID = Basic.ToInt (data ["ID"]),
                    PaymentModeID = Basic.ToInt (data ["PaymentModeId"]),
                    ExpensesCategoryID = Basic.ToInt (data ["ExpensesCategoryId"])
                };
                expList.Add (exp);

            }
            return expList;
        }
    }

    class ExpensesVM
    {
        private BankAccountsDB bDB;
        private ExpensesCategoryDB cDB;
        private ExpensesDB eDB;
        public ExpensesVM()
        {
            eDB = new ExpensesDB ();
            bDB = new BankAccountsDB ();
            cDB = new ExpensesCategoryDB ();
        }


        public void GetBankAccount()
        {
        }


        public BankDetails GetBankDetails(int bankDetailsID)
        {
            return eDB.GetBankDetails (bankDetailsID);
        }

        public int GetBankDetailsID(string text)
        {
            string []bankD  = text.Split (' ');
            return Basic.ToInt (bankD [0].Trim ());

        }

        public int GetExpenseCategoryId(string category)
        {
            return cDB.GetID ("Category", category);
        }

        //End of load section
        public void GetExpenseCategoryList()
        {
            throw new NotImplementedException ();
        }

        public void GetPaymentMode()
        {
            throw new NotImplementedException ();
        }

        public void GetTranscationType()
        {
            throw new NotImplementedException ();
        }

        //Load Section
        public void LoadAccounts(ComboBox cb)
        {

            List<SortedDictionary<string, string>> list = bDB.GetAllAccounts ();
            foreach ( var item in list )
            {
                cb.Items.Add (item ["ID"] + " " + item ["BankName"] + " " + item ["AccountNo"]);

            }
        }

        public void LoadApprovedBy(ComboBox cBApprovedBy)
        {
            List<string> list = eDB.GetApprovedByList ();
            // cBApprovedBy.Items.Add (list);
            foreach ( string item in list )
            {
                cBApprovedBy.Items.Add (item);
                Console.WriteLine ("app {0}", item);
            }
        }

        public void LoadCategory(ComboBox cb)
        {
            List<ExpensesCategory> list = cDB.GetAllRecord ();

            foreach ( ExpensesCategory item in list )
            {
                cb.Items.Add (item.Category);
            }
        }

        public void LoadPayMode(ComboBox cb)
        {
            List<string> collection = TranscationType.ToList ();
            foreach ( string item in collection )
            {
                cb.Items.Add (item);
                Console.WriteLine ("item={0}", item);
            }
            Console.WriteLine ("CB={0}, List={1}", cb.Items.Count, collection.Count);
        }
        public void LoadTransType(ComboBox cb)
        {
            List<string> collection = TranscationType.ToList ();
            foreach ( string item in collection )
            {
                cb.Items.Add (item);
            }
        }
        public int SaveBankDetails(BankDetails bd)
        {
            return eDB.InsertBankDetails (bd);
        }

        public int SaveData(Expenses exp)
        {
            Console.WriteLine ("Calling Save Data");
            return eDB.InsertData (exp);
        }
    }
}
