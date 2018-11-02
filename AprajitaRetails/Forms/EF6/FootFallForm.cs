using AprajitaRetailsDB.DataBase.AprajitaRetails;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AprajitaRetails.Forms.EF6
{
    public partial class FootFallForm : Form
    {
        public FootFallForm( )
        {
            InitializeComponent();
        }

        private void FootFallForm_Load( object sender, EventArgs e )
        {
            //TODO: need to update total foot fall col and current date in ondate col

        }
        AprajitaRetailsMainDB dbAprajitaRetails;

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );
            dbAprajitaRetails=new AprajitaRetailsMainDB();
            dbAprajitaRetails.FootFalls.Load();
            this.footFallBindingSource.DataSource=dbAprajitaRetails.FootFalls.Local.ToBindingList();
            
        }

        private void footFallBindingNavigatorSaveItem_Click( object sender, EventArgs e )
        {
            this.Validate();
            dbAprajitaRetails.SaveChanges();
            footFallDataGridView.Refresh();
        }
        protected override void OnClosing( CancelEventArgs e )
        {
            base.OnClosing( e );
            this.dbAprajitaRetails.Dispose();
        }

        private void bindingNavigatorAddNewItem_Click( object sender, EventArgs e )
        {
            
        }
    }
}
