using System.Collections.Generic;
using System.Data.SqlClient;
using AprajitaRetailsDataBase.SqlDataBase.Data;
using CyberN.Utility;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    internal class BankAccountsDB : DataOps<Bank>
    {
        public BankAccountsDB( )
        {
            //TODO: remove this in release data.
            CreateDeafultData();
        }

        public void CreateDeafultData( )
        {
            //TODO: Remove in realse version

            SqlCommand cmd = new SqlCommand("select count(ID) from " + Tablename, Db.DBCon);
            int x = (int)cmd.ExecuteScalar();
            if (x >= 2)
                return;
            Bank b = new Bank()
            {
                AccountNo = "123456",
                AccountType = (int)Bank.AccountTypes.Current,
                BankName = "ICICI",
                Branch = "Dumka",
                BranchCity = "Dumka",
                IFSCCode = "ICIC0000630",
                ID = -1
            };
            InsertData(b);
            b = new Bank()
            {
                AccountNo = "654321",
                AccountType = (int)Bank.AccountTypes.Current,
                BankName = "HDFC",
                Branch = "Dumka",
                BranchCity = "Dumka",
                IFSCCode = "HDFC0001470",
                ID = -2
            };
            InsertData(b);
        }

        public List<SortedDictionary<string, string>> GetAllAccounts( )
        {
            List<SortedDictionary<string, string>> list;
            string sql = "select AccountNo, BankName,ID  from Bank";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            list = DataBase.GetSqlStoreProcedureString(cmd);
            return list;
        }

        public int GetBankID( string accountno )
        {
            string sql = "select ID from Bank where AccountNo=@accNo";

            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            cmd.Parameters.AddWithValue("@accNo", accountno);
            return (int)cmd.ExecuteScalar();
        }

        public override int InsertData( Bank obj )
        {
            SqlCommand cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue("@AccountNo", obj.AccountNo);
            cmd.Parameters.AddWithValue("@AccountType", obj.AccountType);
            cmd.Parameters.AddWithValue("@BankName", obj.BankName);
            cmd.Parameters.AddWithValue("@Branch", obj.Branch);
            cmd.Parameters.AddWithValue("@BranchCity", obj.BranchCity);
            cmd.Parameters.AddWithValue("@IFSCCode", obj.IFSCCode);

            return cmd.ExecuteNonQuery();
        }

        public override Bank ResultToObject( List<Bank> data, int index )
        {
            return data[index];
        }

        public override Bank ResultToObject( SortedDictionary<string, string> data )
        {
            Bank bank = new Bank()
            {
                AccountNo = data["AccountNo"],
                IFSCCode = data["IFSCCode"],
                AccountType = Basic.ToInt(data["AccountType"]),
                BankName = data["BankName"],
                Branch = data["Branch"],
                BranchCity = data["BranchCity"],
                ID = Basic.ToInt(data["ID"])
            };
            return bank;
        }

        public override List<Bank> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            List<Bank> bankList = new List<Bank>();
            foreach (var data in dataList)
            {
                Bank bank = new Bank()
                {
                    AccountNo = data["AccountNo"],
                    IFSCCode = data["IFSCCode"],
                    AccountType = Basic.ToInt(data["AccountType"]),
                    BankName = data["BankName"],
                    Branch = data["Branch"],
                    BranchCity = data["BranchCity"],
                    ID = Basic.ToInt(data["ID"])
                };
                bankList.Add(bank);
            }
            return bankList;
        }
    }
}