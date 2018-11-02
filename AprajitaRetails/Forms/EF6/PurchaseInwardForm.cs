using AprajitaRetailsDataBase.Client;
using AprajitaRetailsDB.DataBase.AprajitaRetails;
using AprajitaRetailsViewModels.EF6;
using CyberN.Utility;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AprajitaRetails.Forms
{
    public partial class PurchaseInwardForm : Form
    {
        PuchaseInwardViewModel viewModel;
        public PurchaseInwardForm( )
        {
            InitializeComponent();
           
        }
        private bool ValidateFields( )
        {
            return Basic.ValidateFormUI( TLPPurchaseInward );
        }

        private void BTNAdd_Click( object sender, EventArgs e )
        {
            if (BTNAdd.Text=="Add")
            {
                PerformAdd();
               

            }
            else if (BTNAdd.Text=="Save")
            {

                PerformSave();


            }
        }

        private void PurchaseInvoiceForm_Load( object sender, EventArgs e )
        {
            viewModel=new PuchaseInwardViewModel();
            LoadUI();
        }
        private void LoadUI( )
        {
            LoadProductType();
            LoadGRNList();
        }
        private void LoadProductType( )
        {
            List<string> pType = viewModel.GetProductTypeNameList();
            CBProductType.Items.AddRange(pType.ToArray());
        }
        private void LoadGRNList( )
        {
            List<string> grnList = viewModel.GetGRNNoList();
            if(grnList!=null &&grnList.Count>0)
            {
                CBGRNo.Items.AddRange( grnList.ToArray() );
            }
        }
       
        private void PerformAdd( )
        {
            BTNAdd.Text="Save";
            Basic.ClearUIFields( TLPPurchaseInward );

        }
        private void PerformSave( )
        {
           
            if (Validate())
            {
                if (viewModel.Save( ReadUI() )>0)
                {
                    MessageBox.Show( "Purchase Inward details is save." );
                    
                    BTNAdd.Text="Add";
                    Basic.ClearUIFields( TLPPurchaseInward );
                }
                else
                {
                    MessageBox.Show( "Error Occured while saving, check field and try again" );
                }
            }
           
            
        }
        private PurchaseInward ReadUI( )
        {
            PurchaseInward pi = new PurchaseInward()
            {
                FrieghtCharge=viewModel.CalculateFrieghtCharge(viewModel.GetFrieghtCharge(CBProductType.Text),decimal.Parse( TXTTotalQty.Text.Trim())),
                GrandTotal=decimal.Parse(TXTGrandTotal.Text.Trim()),
                GRNDate=DTPGRNDate.Value,GRNNo=CBGRNo.Text, InvoiceDate=DTPInvoiceDate.Value,
                InvoiceNo=TXTInvoiceNo.Text , StoreCode=CurrentClient.LoggedClient.ClientCode,
                IsStockOk=Basic.ReadChechBox(CKStockOk), IsPaid=Basic.ReadChechBox(CKStockOk),
                TaxAmount=decimal.Parse(TXTTaxAmount.Text.Trim()),
                TotalAmount=decimal.Parse( TXTTotalAmount.Text.Trim() ),
                TotalQty=decimal.Parse( TXTTotalQty.Text.Trim() ),
                ProductTypeID=CBProductType.SelectedIndex // or get it from database
              
            };

            return pi;
        }

        public void DisplayPurchaseInward(PurchaseInward inward )
        {
            TXTGrandTotal.Text=inward.GrandTotal.ToString();
            TXTInvoiceNo.Text=inward.InvoiceNo;
            TXTTaxAmount.Text=inward.TaxAmount.ToString();
            TXTTotalAmount.Text=inward.TotalAmount.ToString();
            TXTTotalQty.Text=inward.TotalQty.ToString();
            CBProductType.Text=viewModel.GetProductType(inward.ProductTypeID);// try to use navigation properties
            Basic.SetCheckBox( CKStockOk, inward.IsStockOk??0 );
            Basic.SetCheckBox( CKPaid, inward.IsPaid??0 );
            DTPGRNDate.Value=inward.GRNDate;
            DTPInvoiceDate.Value=inward.InvoiceDate;



        }

        private void CBGRNo_SelectedIndexChanged( object sender, EventArgs e )
        {
            if(BTNAdd.Text=="Add" && BTNUpdate.Text=="Update")
             DisplayPurchaseInward( viewModel.GetPurchaseInwardDetails( CBGRNo.Text ) );
        }

        private void Cancel_Click( object sender, EventArgs e )
        {
            ResetUI();
        }
        private void ResetUI( )
        {
            BTNAdd.Text="Add";
            BTNUpdate.Text="Update";
        }
    }
}