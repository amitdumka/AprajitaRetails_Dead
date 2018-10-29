using AprajitaRetailsDB.DataBase.AprajitaRetails;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;

namespace AprajitaRetails.Forms.EF6
{
    public partial class ExpensesCategoryForm : Form
    {
        private AprajitaRetailsMainDB dbAprajitaRetails;

        public ExpensesCategoryForm( )
        {
            InitializeComponent();
        }

        private void expensesCategoryBindingNavigatorSaveItem_Click( object sender, EventArgs e )
        {
            this.Validate();
            dbAprajitaRetails.SaveChanges();
            expensesCategoryDataGridView.Refresh();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );
            dbAprajitaRetails=new AprajitaRetailsMainDB();
            dbAprajitaRetails.ExpensesCategories.Load();
            this.expensesCategoryBindingSource.DataSource=dbAprajitaRetails.ExpensesCategories.Local.ToBindingList();
        }

        protected override void OnClosing( CancelEventArgs e )
        {
            base.OnClosing( e );
            this.dbAprajitaRetails.Dispose();
        }
    }
}