using AprajitaRetailsDataBase.SqlDataBase.Data;
using AprajitaRetailsDataBase.SqlDataBase.ViewModel;
using CyberN.Utility;
using System;
using System.Windows.Forms;

namespace AprajitaRetails.Forms
{
    public partial class ExpensesForm : Form
    {
        private ExpensesVM eVM;

        private int vBankDetailsID = -1;

        private bool vIsBankDetails = false;

        private void ExpensesForm_Load( object sender, EventArgs e )
        {
            LoadUIDetails();
        }

        public ExpensesForm( )
        {
            InitializeComponent();
            eVM = new ExpensesVM();
        }

        /// <summary>
        /// Clear UI Fields
        /// </summary>
        protected void ClearUiFields( )
        {
            Basic.ClearUIFields(TLPExpenses);
        }

        /// <summary>
        /// Handel Add
        /// </summary>
        protected void PerformAdd( )
        {
            BTNAdd.Text = "Save";
            ClearUiFields();
        }

        /// <summary>
        /// Save Data
        /// </summary>
        protected void PerformSave( )
        {
            if (ValidateFields())
            {
                Console.WriteLine("Validation done");
                if (vIsBankDetails)
                {
                    Console.WriteLine("Getting bank details");
                    vBankDetailsID = eVM.SaveBankDetails(ReadBankDetails());
                    Console.WriteLine("Bank details id{0}", vBankDetailsID);
                }
                if (vIsBankDetails && vBankDetailsID <= 0)
                {
                    MessageBox.Show("An Error occured while saving Data, Kindly check and try again!");
                }
                else if (eVM.SaveData(ReadFields()) > 0)
                {
                    MessageBox.Show("Your record is save!");
                    BTNAdd.Text = "Add";
                    ClearUiFields();
                }
            }
        }

        /// <summary>
        /// Read Ui Fields from Forms and return in Expenses Object
        /// </summary>
        /// <returns></returns>
        protected Expenses ReadFields( )
        {
            Expenses exp = new Expenses()
            {
                Amount = double.Parse(TXTAmount.Text),
                ApprovedBy = CBApprovedBy.Text,
                ExpensesReason = TXTReason.Text,
                ID = -1,
                PaymentModeID = PaymentMode.GetPayModeId(CBPaymentMode.Text),
                BankDetailsID = vBankDetailsID,
                ExpensesCategoryID = eVM.GetExpenseCategoryId(CBCategory.Text)
            };
            return exp;
        }

        /// <summary>
        /// Do Validation
        /// </summary>
        /// <returns></returns>
        protected bool ValidateFields( )
        {
            return Basic.ValidateFormUI(TLPExpenses);
        }

        /// <summary>
        /// Add Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNAdd_Click( object sender, EventArgs e )
        {
            if (BTNAdd.Text == "Add")
            {
                PerformAdd();
            }
            else if (BTNAdd.Text == "Save")
            {
                PerformSave();
            }
        }

        /// <summary>
        /// Cancel Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click( object sender, EventArgs e )
        {
            ClearUiFields();
            BTNAdd.Text = "Add";
            BTNUpdate.Text = "Update";
        }

        private BankDetails ReadBankDetails( )
        {
            return new BankDetails()
            {
                ID = -1,
                TranscationType = PaymentMode.GetPayModeId(CBTranscationType.Text),
                TranscationRef = TXTTranscationRef.Text,
                BankRef = TXTBankRef.Text,
                RefID = "Expenses",
                BankID = eVM.GetBankDetailsID(CBBankAccount.Text),
            };
        }

        protected void LoadUIDetails( )
        {
            LoadAccounts(CBBankAccount);
            LoadApprovedBy(CBApprovedBy);
            LoadCategory(CBCategory);
            LoadPayMode(CBPaymentMode);
            LoadTransType(CBTranscationType);
        }

        private void LoadAccounts( ComboBox cBBankAccount )
        {
            eVM.LoadAccounts(cBBankAccount);
        }

        private void LoadApprovedBy( ComboBox cBApprovedBy )
        {
            eVM.LoadApprovedBy(cBApprovedBy);
        }

        protected void LoadPayMode( ComboBox cb )
        {
            eVM.LoadPayMode(cb);
        }

        protected void LoadTransType( ComboBox cb )
        {
            eVM.LoadTransType(cb);
        }

        protected void LoadCategory( ComboBox cb )
        {
            eVM.LoadCategory(cb);
        }

        private void CBPaymentMode_SelectedIndexChanged( object sender, EventArgs e )
        {
            //TODO: Implement based on selected Different Mode.
            if (CBPaymentMode.Text != "Cash")
            {
                EnableBankDetails(true);
            }
            else
                EnableBankDetails(false);
        }

        private void EnableBankDetails( bool enable )
        {
            //TODO: implement this 
            //TODO: Based on selected choice make visible element on context of
            //choice made
            //TODO:Change Lable name based on the selection Made.
            //TODO: disolve transcation type and use payment mode as trancation type
            LBBankAccount.Visible = enable;
            LBBankRef.Visible = enable;
            LBTrType.Visible = enable;
            LBTrRef.Visible = enable;
            TXTBankRef.Visible = enable;
            TXTTranscationRef.Visible = enable;
            CBTranscationType.Visible = enable;
            CBBankAccount.Visible = enable;
            vIsBankDetails = enable;

            if (enable)
            {
                CBTranscationType.Text = CBPaymentMode.Text;
                CBTranscationType.Enabled = false;
            }
            else
                CBTranscationType.Enabled = true;
        }

        private void BTNUpdate_Click( object sender, EventArgs e )
        {

        }
    }
}