using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetails.DataModel
{
    /// <summary>
    /// Table Name: ExpensesForm
    /// </summary>
    class ExpensesDM
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
    class BankDM
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
    ///  TableName : BankDetails
    /// </summary>
    class BankDetailsDM
    {
        public int ID { get; set; }
        public int BankID { get; set; }
        public int TranscationType { get; set; }
        public string BankRef { get; set; }
        public string TranscationRef { get; set; }

    }

    /// <summary>
    /// TableName: ExpensesCategory
    /// </summary>
    class ExpensesCategoryDM
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public int Level { get; set; }
    }

}
