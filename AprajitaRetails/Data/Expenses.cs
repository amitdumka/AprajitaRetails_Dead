using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetails.Data
{
    /// <summary>
    /// Table Name: ExpensesForm
    /// </summary>
    class Expenses
    {
        public int ID { get; set; }
        public int ExpensesCategoryID { get; set; }
        public string ExpensesReason { get; set; }
        public string ApprovedBy { get; set; }
        public int PaymentModeID { get; set; }
        public double Amount { get; set; }
        public int BankDetailsID { get; set; }
        //TODO: Scope of update in future based on Usage

    }
    /// <summary>
    /// TableName : Bank
    /// </summary>
    class Bank
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
    class TranscationType
    {
        public static readonly int Cheque = 1;
        public static readonly int RTGS = 2;
        public static readonly int NEFT = 3;
        public static readonly int IMPS = 4;
        public static readonly int UPI = 5;
        public static readonly int PaymentAPP = 6;
        public static readonly int Cash = 7;
        public static readonly int BankTransfer = 8;
        public static readonly int Others = 9;


    }
    /// <summary>
    ///  TableName : BankDetails
    /// </summary>
    class BankDetails
    {
        public int ID { get; set; }
        public int BankID { get; set; }
        public int TranscationType { get; set; }
        public string BankRef { get; set; }
        public string TranscationRef { get; set; }

    }
    /// <summary>
    /// TableName: PaymentMode
    /// </summary>
    class PaymentMode
    {
        public int ID { get; set; }
        public string PayMode { get; set; }
        public override string ToString() { return PayMode; }
    }

    /// <summary>
    /// TableName: ExpensesCategory
    /// </summary>
    class ExpensesCategory
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public int Level { get; set; }
    }
    /// <summary>
    /// ExpensesForm Level
    /// </summary>
    class ExpensesLevel
    {
        public static readonly int General = 1;
        public static readonly int Low = 2;
        public static readonly int Medium = 3;
        public static readonly int High = 4;
        public static readonly int VeryHigh = 5;
        public static readonly int Other = 6;
    }
}
