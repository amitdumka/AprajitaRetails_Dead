using AprajitaRetailsDataBase.Client;
//using AprajitaRetailsDataBase.SqlDataBase.Data;
//using AprajitaRetailsDataBase.SqlDataBase.ViewModel;
using AprajitaRetailsDB.DataBase.AprajitaRetails;
using AprajitaRetailsViewModels.EF6;
using CyberN.Utility;
using System;
using System.Windows.Forms;

namespace AprajitaRetails.Forms
{
    public partial class DayClosingForm : Form
    {
        private int vTotalCount = 0;
        private int vTotalAmount = 0;
       // private DayClosingVM DCVm;
        private DayClosingViewModel DCVm;

        public DayClosingForm( )
        {
            InitializeComponent();
            //DCVm = new DayClosingVM();
            DCVm=new DayClosingViewModel();
        }

        private void CalculateTotalAmount( )
        {
            // (TextBox)this.Controls.Find("T"+
        }

        private void TextChangedUpdate( object sender, EventArgs e )
        {
            TextBox t = (TextBox)sender;
            if (!Basic.IsNumeric(t.Text))
                t.Text = "0";
            string lab = t.Name;
            int count = Int32.Parse(t.Text.Trim());
            int iValue = Int32.Parse(lab.Trim().Substring(1));
            int iTotal = iValue * count;
            vTotalAmount = vTotalAmount + iTotal;
            vTotalCount = vTotalCount + count;

            if (lab.StartsWith("T"))
            {
                ((TextBox)this.Controls.Find("T" + lab, true)[0]).Text = "" + iTotal;
            }
            else if (lab.StartsWith("C"))
            {
                ((TextBox)this.Controls.Find("T" + lab, true)[0]).Text = "" + iTotal;
            }
            LBTotalAmount.Text = "" + vTotalAmount;
            LBTotalCount.Text = "" + vTotalCount;
        }

        private void TT10_TextChanged( object sender, EventArgs e )
        {
            //TODO: verify this one very throughly

        }

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

        private void PerformAdd( )
        {
            BTNAdd.Text = "Save";
        }

        private void PerformSave( )
        {
            if (ValidateFields())
            {
                if (DCVm.SaveData(ReadFields()) > 0)
                {
                    BTNAdd.Text = "Add";
                    MessageBox.Show("Your Record got Saved", "DayClosing");
                    LBTotalAmount.Text = "0"; LBTotalCount.Text = "0";
                    vTotalCount = vTotalAmount = 0;
                }
                else
                {
                    MessageBox.Show("Some error occured while saving data, Kindly recheck and try again", "DayClosing");
                }
            }
        }

        private bool ValidateFields( )
        {
            return Basic.ValidateFormUI(TLPCashDetails);
        }

        private DayClosing ReadFields( )
        {
            DayClosing cDs = new DayClosing()
            {
                C10 = Basic.ToInt(T10.Text.Trim()),
                C100 = Basic.ToInt(T100.Text.Trim()),
                C1000 = Basic.ToInt(T1000.Text.Trim()),
                C20 = Basic.ToInt(T20.Text.Trim()),
                C2000 = Basic.ToInt(T2000.Text.Trim()),
                C200 = Basic.ToInt(T200.Text.Trim()),

                C5 = Basic.ToInt(T5.Text.Trim()),
                C50 = Basic.ToInt(T50.Text.Trim()),
                C500 = Basic.ToInt(T500.Text.Trim()),
                Coin1 = Basic.ToInt(C1.Text.Trim()),
                Coin10 = Basic.ToInt(C10.Text.Trim()),
                Coin2 = Basic.ToInt(C2.Text.Trim()),
                Coin5 = Basic.ToInt(C5.Text.Trim()),
                DayClosingID = -1,
                TotalAmount = vTotalAmount,
                OnDate = DateTime.Now, 
                StoreCode=CurrentClient.LoggedClient.ClientCode
               
            };
            return cDs;
        }
    }
}