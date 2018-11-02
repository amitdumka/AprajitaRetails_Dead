using AprajitaRetailsDB.DataBase.AprajitaRetails.HRM;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;

namespace AprajitaRetails.Forms.EF6
{
    public partial class EmpTypeForm : Form
    {
        private AprajitaRetailsHRMDB dbHRM = new AprajitaRetailsDB.DataBase.AprajitaRetails.HRM.AprajitaRetailsHRMDB();

        public EmpTypeForm( )
        {
            InitializeComponent();
        }

        private void EmpTypeBindingNavigatorSaveItem_Click( object sender, EventArgs e )
        {
            this.Validate();
            dbHRM.SaveChanges();
            empTypeDataGridView.Refresh();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );
            dbHRM=new AprajitaRetailsHRMDB();
            dbHRM.EmpTypes.Load();
            this.empTypeBindingSource.DataSource=dbHRM.EmpTypes.Local.ToBindingList();
        }

        protected override void OnClosing( CancelEventArgs e )
        {
            base.OnClosing( e );
            this.dbHRM.Dispose();
        }
    }
}