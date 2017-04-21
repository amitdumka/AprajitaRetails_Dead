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
using AprajitaRetails.DataModel;
using AprajitaRetails.ViewModel;

namespace AprajitaRetails.Forms
{
    public partial class EmployeeForm : Form
    {
        EmployeeVM eVM = new EmployeeVM ();

        public EmployeeForm()
        {
            InitializeComponent ();
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
        private void PerformAdd()
        {
            BTNAdd.Text = "Save";
            // Basic.ClearUIFields (TLPEmployeeDetails);

        }
        private void PerformSave()
        {
            if ( ValidateFields () )
            {
                if ( eVM.SaveData (ReadFields ()) > 0 )
                {
                    BTNAdd.Text = "Add";
                    MessageBox.Show ("Your Record got Saved", "Employee");
                }
                else
                {
                    MessageBox.Show ("Some error occured while saving data, Kindly recheck and try again", "Employee");
                }
            }

        }
        private bool ValidateFields()
        {
            return Basic.ValidateFormUI (TLPEmployeeDetails);

        }

        private EmployeeDM ReadFields()
        {
            EmployeeDM eDM = new EmployeeDM ()
            {
                ID = -1,
                Age = Basic.ToInt (txtAge.Text.Trim ()),
                AddressLine1 = txtAddress.Text,
                City = CBCity.Text,
                Country = CBCountry.Text,
                Status = "Normal",
                LastName = TXTLastName.Text,
                FirstName = TXTFirstName.Text,
                State = cbState.Text,
                AttendenceId = Basic.ToInt (TXTAttendenceID.Text.Trim ()),
                DateOfBirth = DTPBirthDate.Value,
                DateOfJoining = DTPJoiningDate.Value,
                EmpType = EmpCode.GetCategory (CBEmpType.Text),
                DateOfLeaving = DTPJoiningDate.Value,
                EMPCode = EmpCode.GenerateEmpCode (EmpCode.GetCategory (CBEmpType.Text))

            };
            return eDM;

        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            int x = eVM.GetEmployeeTypeList (CBEmpType);
            Console.WriteLine ("Emptye list count={0}", x);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            BTNAdd.Text = "Add";
            BTNUpdate.Text = "Update";
            Basic.ClearUIFields (TLPEmployeeDetails);
        }
    }
}
