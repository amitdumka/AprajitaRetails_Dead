using System;
using System.Collections.Generic;
using System.Reflection;

namespace AprajitaRetails.Data
{
    /// <summary>
    /// Table Name: ExpensesForm
    /// </summary>
    public class Expenses
    {
        public int ID { get; set; }
        public int ExpensesCategoryID { get; set; }
        public string ExpensesReason { get; set; }
        public string ApprovedBy { get; set; }
        public int PaymentModeID { get; set; }
        public double Amount { get; set; }
        public int BankDetailsID { get; set; }
        //TODO: Future: Scope of update in future based on Usage
    }

    /// <summary>
    /// TableName : Bank
    /// </summary>
    internal class Bank
    {
        /// <summary>
        /// Account Type Constants
        /// </summary>
        public enum AccountTypes
        {
            Saving = 1, Current = 2, OverDraft = 3, Other = 4
        }

        public int ID { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public int AccountType { get; set; }
        public string IFSCCode { get; set; }
        public string Branch { get; set; }
        public string BranchCity { get; set; }
    }

    /// <summary>
    /// Transcation Type
    /// </summary>
    internal class TranscationType
    {
        public static readonly int Cash = 7;
        public static readonly int Cheque = 1;
        public static readonly int RTGS = 2;
        public static readonly int NEFT = 3;
        public static readonly int IMPS = 4;
        public static readonly int UPI = 5;
        public static readonly int PaymentAPP = 6;
        public static readonly int BankTransfer = 8;
        public static readonly int Others = 9;

        public static List<string> ToList( )
        {
            List<string> list = new List<string>();
            Type t = typeof(TranscationType);

            foreach (FieldInfo p in t.GetFields())
            {
                list.Add(p.Name);
            }
            return list;
        }
    }

    /// <summary>
    ///  TableName : BankDetails
    /// </summary>
    internal class BankDetails
    {
        public int ID { get; set; }
        public string RefID { set; get; }
        public int BankID { get; set; }
        public int TranscationType { get; set; }
        public string BankRef { get; set; }
        public string TranscationRef { get; set; }
    }

    /// <summary>
    /// TableName: PaymentMode
    /// </summary>
    internal class PaymentMode
    {
        public int ID { get; set; }
        public string PayMode { get; set; }

        public override string ToString( )
        {
            return PayMode;
        }

        public static string GetPayModeName( int id )
        {
            string sMode = "Cash";
            switch (id)
            {
                case 7:
                    sMode = "Cash";
                    break;

                case 1:
                    sMode = "Cheque";
                    break;

                case 2:
                    sMode = "RTGS";
                    break;

                case 3:
                    sMode = "NEFT";
                    break;

                case 4:
                    sMode = "IMPS";
                    break;

                case 5:
                    sMode = "UPI";
                    break;

                case 6:
                    sMode = "PaymentApp";
                    break;

                case 8:
                    sMode = "BankTransfer";
                    break;

                case 9:
                    sMode = "Others";
                    break;

                default:
                    sMode = "Cash";
                    break;
            }
            return sMode;
        }

        public static int GetPayModeId( string name )
        {
            int sMode = 7;
            switch (name)
            {
                case "Cash":
                    sMode = 7;
                    break;

                case "Cheque":
                    sMode = 1;
                    break;

                case "RTGS":
                    sMode = 2;
                    break;

                case "NEFT":
                    sMode = 3;
                    break;

                case "IMPS":
                    sMode = 4;
                    break;

                case "UPI":
                    sMode = 5;
                    break;

                case "PaymentApp":
                    sMode = 6;
                    break;

                case "BankTransfer":
                    sMode = 8;
                    break;

                case "Others":
                    sMode = 9;
                    break;

                default:
                    sMode = 7;
                    break;
            }
            return sMode;
        }
    }

    /// <summary>
    /// TableName: ExpensesCategory
    /// </summary>
    internal class ExpensesCategory
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public int Level { get; set; }
    }

    /// <summary>
    /// ExpensesForm Level
    /// </summary>
    internal class ExpensesLevel
    {
        public static readonly int General = 1;
        public static readonly int Low = 2;
        public static readonly int Medium = 3;
        public static readonly int High = 4;
        public static readonly int VeryHigh = 5;
        public static readonly int Other = 6;

        public static int ExpensesLevelID( string level )
        {
            int id = 1;
            switch (level)
            {
                case "Other":
                    id = 6;
                    break;

                case "VeryHigh":
                    id = 5;
                    break;

                case "High":
                    id = 4;
                    break;

                case "General":
                    id = 1;
                    break;

                case "Low":
                    id = 2;
                    break;

                case "Medium":
                    id = 3;
                    break;

                default:
                    id = 1;
                    break;
            }

            return id;
        }

        public static string ExpensesLevelName( int id )
        {
            string name = "General";
            switch (id)
            {
                case 6:
                    name = "Other";
                    break;

                case 5:
                    name = "VeryHigh";
                    break;

                case 4:
                    name = "High";
                    break;

                case 1:
                    name = "General";
                    break;

                case 2:
                    name = "Low";
                    break;

                case 3:
                    name = "Medium";

                    break;

                default:
                    name = "General";
                    break;
            }
            return name;
        }
    }
}