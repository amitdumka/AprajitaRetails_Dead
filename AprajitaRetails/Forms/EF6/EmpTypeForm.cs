using AprajitaRetailsDB.DataBase.AprajitaRetails.HRM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace AprajitaRetails.Forms.EF6
{
    public partial class EmpTypeForm : Form
    {
        private AprajitaRetailsHRMDB dbHRM = new AprajitaRetailsDB.DataBase.AprajitaRetails.HRM.AprajitaRetailsHRMDB();

        public EmpTypeForm( )
        {
            InitializeComponent();
        }

        private void empTypeBindingNavigatorSaveItem_Click( object sender, EventArgs e )
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
