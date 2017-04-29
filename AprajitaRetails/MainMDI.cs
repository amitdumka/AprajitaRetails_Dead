using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AprajitaRetails.Forms;

namespace AprajitaRetails
{
    public partial class MainMDI : Form
    {
        private int childFormNumber = 0;

        public MainMDI()
        {
            InitializeComponent ();
        }

        private void ShowNewForm(Form childForm)
        {
            // Form childForm = new Form ();
            childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            childFormNumber++;
            childForm.Show ();
        }
        /*
         private void OpenFile(object sender, EventArgs e)
         {
             OpenFileDialog openFileDialog = new OpenFileDialog ();
             openFileDialog.InitialDirectory = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
             openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
             if ( openFileDialog.ShowDialog (this) == DialogResult.OK )
             {
                 string FileName = openFileDialog.FileName;
             }
         }

         private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
         {
             SaveFileDialog saveFileDialog = new SaveFileDialog ();
             saveFileDialog.InitialDirectory = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
             saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
             if ( saveFileDialog.ShowDialog (this) == DialogResult.OK )
             {
                 string FileName = saveFileDialog.FileName;
             }
         }
          */
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close ();
            Application.Exit ();
        }


        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi (MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi (MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi (MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi (MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach ( Form childForm in MdiChildren )
            {
                childForm.Close ();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowNewForm (new DailySaleForm ());
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ShowNewForm (new DayClosingForm ());
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ShowNewForm (new FootFallForm ());
        }

        private void uploadSaleRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewForm (new Form1 ());
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewForm (new FormTest ());
        }

        private void customersDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewForm (new CustomersForm ());
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ShowNewForm (new SaleInvoiceForm ());
        }

        private void salaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewForm (new SalaryForm ());
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ShowNewForm (new ExpensesForm ());
        }

        private void employeeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewForm (new EmployeeForm ());
        }

        private void attendenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewForm (new AttendenceForm ());
        }

        private void updateEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewForm (new EmployeeForm ());
        }

        private void TSMIExpenses_Click(object sender, EventArgs e)
        {
            ShowNewForm (new ExpensesForm ());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewForm (new AboutBox1 ());
        }



        private void TSBDailySale_Click(object sender, EventArgs e)
        {
            ShowNewForm (new DailySaleForm ());
        }

        private void TSBDayClosing_Click(object sender, EventArgs e)
        {
            ShowNewForm (new DayClosingForm ());
        }

        private void TSBExpenses_Click(object sender, EventArgs e)
        {
            ShowNewForm (new ExpensesForm ());
        }

        private void TSBAttendence_Click(object sender, EventArgs e)
        {
            ShowNewForm (new AttendenceForm ());
        }

        private void uploadVoygerDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNewForm (new UploaderForm (0));
        }
    }
}
