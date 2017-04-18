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
        void PerformAdd()
        {
            BTNAdd.Text = "Save";

        }
        void PerformSave()
        {
            if ( ValidateFields () )
            {
                if ( eVM.SaveData (ReadFields ()) > 0 )
                {
                    BTNAdd.Text = "Save";
                    MessageBox.Show ("Your Record got Saved", "DayClosing");
                }
                else
                {
                    MessageBox.Show ("Some error occured while saving data, Kindly recheck and try again", "DayClosing");
                }
            }

        }
        bool ValidateFields()
        {
            return Basic.ValidateFormUI (TLPEmployeeDetails);

        }
        EmployeeDM ReadFields()
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
                EmpType = GetCategory (CBEmpType.Text)  ,DateOfLeaving=DateTime.MaxValue.Date,
                 //TODO: EMPCode


            };
            return eDM;

        }
        public int GetCategory(string category)
        {
            int res = 0;
            switch ( category )
            {
                case "Accountant":
                    res = EmployeeType.Accountant;
                    break;
                case "AssistanceManager":
                    res = EmployeeType.AssistanceManager;
                    break;
                case "HouseKeeping":
                    res = EmployeeType.HouseKeeping;
                    break;
                case "Others":
                    res = EmployeeType.Others;
                    break;
                case "Owner":
                    res = EmployeeType.Owner;
                    break;
                case "SalesMan":
                    res = EmployeeType.SalesMan;
                    break;
                case "StoreManager":
                    res = EmployeeType.StoreManager;
                    break;
                default:
                    res = EmployeeType.SalesMan;
                    break;
            }

            return EmployeeType.SalesMan;
        }


    }
}
