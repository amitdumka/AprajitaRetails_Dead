using AprajitaRetailsDB.DataBase.AprajitaRetails;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;

namespace AprajitaRetails.Forms.EF6
{
    public partial class UnitForm : Form
    {
        public UnitForm( )
        {
            InitializeComponent();
        }
        AprajitaRetailsMainDB dbAprajitaRetails;
        private void unitsBindingNavigatorSaveItem_Click( object sender, EventArgs e )
        {
            this.Validate();
            dbAprajitaRetails.SaveChanges();
            unitsDataGridView.Refresh();
        }


        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );
            dbAprajitaRetails=new AprajitaRetailsMainDB();
            dbAprajitaRetails.Units.Load();
            this.unitsBindingSource.DataSource=dbAprajitaRetails.Units.Local.ToBindingList();

        }


        protected override void OnClosing( CancelEventArgs e )
        {
            base.OnClosing( e );
            this.dbAprajitaRetails.Dispose();
        }
    }
}
