using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AprajitaRetails.Data;
using AprajitaRetails.ViewModel;

namespace AprajitaRetails.Forms
{
    public partial class AttendenceForm : Form
    {
        AttendenceVM aVM;
        public AttendenceForm()
        {
            InitializeComponent ();
            aVM = new AttendenceVM ();
        }

        private void AttendenceForm_Load(object sender, EventArgs e)
        {
            LoadUiItems ();
        }
        private void BTNAdd_Click(object sender, EventArgs e)
        {
            if ( BTNAdd.Text == "Add" )
            {

                PerformAdd ();
            }
            else if ( BTNAdd.Text == "Save" )
            {
                PerformSave ();
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Basic.ClearUIFields (TLPAttendence);
            BTNAdd.Text = "Add";
            BTNUpdate.Text = "Update";
        }

        private void CBEmpCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> eName = aVM.GetEmpName (CBEmpCode.Text);
            if ( eName.Count >= 2 )
            {
                TXTFirstName.Text = eName [0];
                TXTLastName.Text = eName [1];
            }
        }

        private void LoadEmpCode()
        {
            List<string> ecodes = aVM.GetAllEmpCodes ();
            foreach ( string item in ecodes )
            {
                CBEmpCode.Items.Add (item);
            }
        }

        private void LoadUiItems()
        {

            LBAttenceDate.Text = DateTime.Now.ToShortDateString ();
            LoadEmpCode ();

        }
        private void PerformAdd()
        {
            BTNAdd.Text = "Save";
            Basic.ClearUIFields (TLPAttendence);
        }

        private void PerformSave()
        {
            if ( ValidateFields () )
            {
                if ( aVM.SaveData (ReadFields ()) > 0 )
                {
                    MessageBox.Show ("Your record is save!");
                    BTNAdd.Text = "Add";
                    Basic.ClearUIFields (TLPAttendence);
                }
            }
        }

        private Attendence ReadFields()
        {
            Attendence att = new Attendence ()
            {
                EMPCode = CBEmpCode.Text,
                ID = -1,
                OnDate = DateTime.Now,
                AttendenceNo = Basic.ToInt (TXTAttendenceNo.Text),
                IsAbesent = Basic.ReadChechBox (CKAbesent),
                IsPaidLeave = Basic.ReadChechBox (CKPaidLeaves)
            };
            return att;

        }

        private bool ValidateFields()
        {
            return Basic.ValidateFormUI (TLPAttendence);
        }
    }
}
