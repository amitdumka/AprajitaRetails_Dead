using AprajitaRetailsDB.DataBase.AprajitaRetails;
using AprajitaRetailsDB.DataBase.AprajitaRetails.HRM;
using AprajitaRetailsDB.DataTypes;
using CyberN.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace AprajitaRetailsViewModels.EF6
{
    public class ExpenseViewModel : IDisposable
    {
        private AprajitaRetailsMainDB mainDB;

        #region Decalrations

        public ExpenseViewModel( )
        {
            mainDB=new AprajitaRetailsMainDB();
        }

        public void Dispose( )
        {
            ((IDisposable)mainDB).Dispose();
        }

        #endregion Decalrations

        public BankDetail GetBankDetails( int bankDetailsID )
        {
            mainDB.BankDetails.Load();
            return mainDB.BankDetails.Local.Where( s => s.BankDetailsID==bankDetailsID ).FirstOrDefault();
            //return eDB.GetBankDetails( bankDetailsID );
        }

        public int GetBankDetailsID( string text )
        {
            string[] bankD = text.Split( ' ' );
            return Basic.ToInt( bankD[0].Trim() );
        }

        public int GetExpenseCategoryId( string category )
        {
            mainDB.ExpensesCategories.Load();
            return mainDB.ExpensesCategories.Local.Where( s => s.Category==category ).Select( s => s.ExpensesCategoryID ).FirstOrDefault();
        }

        //End of load section
        public List<ExpensesCategory> GetExpenseCategoryList( )
        {
            mainDB.ExpensesCategories.Load();
            return mainDB.ExpensesCategories.Local.Select( s => s ).ToList();
        }

        public List<string> GetExpenseCategoryNameList( )
        {
            mainDB.ExpensesCategories.Load();
            return mainDB.ExpensesCategories.Local.Select( s => s.Category ).ToList();
        }

        public void GetPaymentMode( )
        {
            throw new NotImplementedException();
        }

        public void GetTranscationType( )
        {
            throw new NotImplementedException();
        }

        public List<Bank> GetAllBankAccounts( )
        {
            mainDB.Banks.Load();
            return mainDB.Banks.Local.Select( s => s ).ToList();
        }

        //Load Section
        public void LoadAccounts( ComboBox cb )
        {
            //List<SortedDictionary<string, string>> list = GetAllBankAccounts();
            mainDB.Banks.Load();
            var list = mainDB.Banks.Local.Select( s => new { s.BankID, s.BankName, s.AccountNo } ).ToList();
            foreach (var item in list)
            {
                cb.Items.Add( item.BankID+" "+item.BankName+" "+item.AccountNo );
            }
        }

        public void LoadApprovedBy( ComboBox cBApprovedBy )
        {
            using (AprajitaRetailsHRMDB hrmDB = new AprajitaRetailsHRMDB())
            {
                List<string> list;
                hrmDB.Employees.Load();

                list=hrmDB.Employees.Local.Where( s => s.EmpTypeID==1||s.EmpTypeID==2||s.EmpTypeID==6 ).Select( s => s.FirstName ).ToList();
                foreach (string item in list)
                {
                    cBApprovedBy.Items.Add( item );
                }
            }
        }

        public void LoadCategory( ComboBox cb )
        {
            List<ExpensesCategory> list = GetExpenseCategoryList();

            foreach (ExpensesCategory item in list)
            {
                cb.Items.Add( item.Category );
            }
        }

        public void LoadPayMode( ComboBox cb )
        {
            List<string> collection = TranscationType.ToList();
            foreach (string item in collection)
            {
                cb.Items.Add( item );
                Console.WriteLine( "item={0}", item );
            }
            Console.WriteLine( "CB={0}, List={1}", cb.Items.Count, collection.Count );
        }

        public void LoadTransType( ComboBox cb )
        {
            List<string> collection = TranscationType.ToList();
            foreach (string item in collection)
            {
                cb.Items.Add( item );
            }
        }

        public int SaveData( Expenses exp, BankDetail bd )
        {
            Console.WriteLine( "Calling Save Data" );
            exp.BankDetail=bd;
            mainDB.Expenses.Add( exp );
            return mainDB.SaveChanges();
        }

        public int SaveData( Expenses exp )
        {
            Console.WriteLine( "Calling Save Data" );

            mainDB.Expenses.Add( exp );
            return mainDB.SaveChanges();
        }

        public int GetPayModeId( string mode )
        {
            mainDB.PaymentModes.Load();
            return mainDB.PaymentModes.Local.Where( s => s.PayMode==mode ).FirstOrDefault().PaymentModeID;
        }
    }
}