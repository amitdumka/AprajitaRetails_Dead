using AprajitaRetailsDataBase.SqlDataBase.Data;
using CyberN.Utility;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    public class ExpensesVM
    {
        private BankAccountsDB bDB;
        private ExpensesCategoryDB cDB;
        private ExpensesDB eDB;

        public ExpensesVM( )
        {
            eDB = new ExpensesDB();
            bDB = new BankAccountsDB();
            cDB = new ExpensesCategoryDB();
        }

        public void GetBankAccount( )
        {
        }

        public BankDetails GetBankDetails( int bankDetailsID )
        {
            return eDB.GetBankDetails(bankDetailsID);
        }

        public int GetBankDetailsID( string text )
        {
            string[] bankD = text.Split(' ');
            return Basic.ToInt(bankD[0].Trim());
        }

        public int GetExpenseCategoryId( string category )
        {
            return cDB.GetID("Category", category);
        }

        //End of load section
        public void GetExpenseCategoryList( )
        {
            throw new NotImplementedException();
        }

        public void GetPaymentMode( )
        {
            throw new NotImplementedException();
        }

        public void GetTranscationType( )
        {
            throw new NotImplementedException();
        }

        //Load Section
        public void LoadAccounts( ComboBox cb )
        {
            List<SortedDictionary<string, string>> list = bDB.GetAllAccounts();
            foreach (var item in list)
            {
                cb.Items.Add(item["ID"] + " " + item["BankName"] + " " + item["AccountNo"]);
            }
        }

        public void LoadApprovedBy( ComboBox cBApprovedBy )
        {
            List<string> list = eDB.GetApprovedByList();
            // cBApprovedBy.Items.Add (list);
            foreach (string item in list)
            {
                cBApprovedBy.Items.Add(item);
                Console.WriteLine("app {0}", item);
            }
        }

        public void LoadCategory( ComboBox cb )
        {
            List<ExpensesCategory> list = cDB.GetAllRecord();

            foreach (ExpensesCategory item in list)
            {
                cb.Items.Add(item.Category);
            }
        }

        public void LoadPayMode( ComboBox cb )
        {
            List<string> collection = TranscationType.ToList();
            foreach (string item in collection)
            {
                cb.Items.Add(item);
                Console.WriteLine("item={0}", item);
            }
            Console.WriteLine("CB={0}, List={1}", cb.Items.Count, collection.Count);
        }

        public void LoadTransType( ComboBox cb )
        {
            List<string> collection = TranscationType.ToList();
            foreach (string item in collection)
            {
                cb.Items.Add(item);
            }
        }

        public int SaveBankDetails( BankDetails bd )
        {
            return eDB.InsertBankDetails(bd);
        }

        public int SaveData( Expenses exp )
        {
            Console.WriteLine("Calling Save Data");
            return eDB.InsertData(exp);
        }
    }
}