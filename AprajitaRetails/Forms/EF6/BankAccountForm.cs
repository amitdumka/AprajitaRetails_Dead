using System.Windows.Forms;
using System.Data;
using System.Linq;
using AprajitaRetailsDB.DataBase.AprajitaRetails;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AprajitaRetails.Forms
{
    public partial class BankAccountForm : Form
    {
        public BankAccountForm( )
        {
            InitializeComponent();
        }

       
        AprajitaRetailsMainDB dbAprajitaRetails;

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );
            dbAprajitaRetails=new AprajitaRetailsMainDB();
            dbAprajitaRetails.Banks.Load();
            this.bankBindingSource.DataSource=dbAprajitaRetails.Banks.Local.ToBindingList();

        }

        private void bankBindingNavigatorSaveItem_Click( object sender, EventArgs e )
        {
            this.Validate();
            dbAprajitaRetails.SaveChanges();
            bankDataGridView.Refresh();
        }
        protected override void OnClosing( CancelEventArgs e )
        {
            base.OnClosing( e );
            this.dbAprajitaRetails.Dispose();
        }

        
    }
}