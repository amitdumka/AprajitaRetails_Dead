//using AprajitaRetailsDataBase.SqlDataBase.Data;
//using AprajitaRetailsDataBase.SqlDataBase.ViewModel;
using AprajitaRetailsDataBase.Client;
using AprajitaRetailsDB.DataBase.AprajitaRetails.HRM;
using AprajitaRetailsDB.Models.Data;
using AprajitaRetailsViewModels.EF6;
using CyberN.Utility;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

//TODO: Bug EmpType on Load Emp Details .Check

namespace AprajitaRetails.Forms
{
    public partial class EmployeeForm : Form
    {
        //        private EmployeeVM eVM = new EmployeeVM();
        private EmployeeViewModel eVM;
        private Employee emp;

        public EmployeeForm( )
        {
            InitializeComponent();
            eVM=new EmployeeViewModel();
        }

        private void BTNAdd_Click( object sender, EventArgs e )
        {
            if (BTNAdd.Text == "Add")
            {
                PerformAdd();
            }
            else if (BTNAdd.Text == "Save")
            {
                PerformSave();
            }
        }

        private void PerformAdd( )
        {
            BTNAdd.Text = "Save";
            //TODO: removecoment Basic.ClearUIFields (TLPEmployeeDetails);
        }

        private void PerformSave( )
        {
            if (ValidateFields())
            {
                if (eVM.SaveData(ReadFields()) > 0)
                {
                    BTNAdd.Text = "Add";
                    MessageBox.Show("Your Employee details is saved!", "Employee");
                    LoadEmpCode();
                    Basic.ClearUIFields(TLPEmployeeDetails);
                }
                else
                {
                    MessageBox.Show("Some error occured while saving data, Kindly recheck and try again", "Employee");
                }
            }
        }

        private bool ValidateFields( )
        {
            return Basic.ValidateFormUI(TLPEmployeeDetails);
        }

        private Employee ReadFields( )
        {
            Employee eDM = new Employee()
            {
                EMPID = -1,
                Age = Basic.ToInt(txtAge.Text.Trim()),
                AddressLine1 = txtAddress.Text,
                Gender = Gender.GetGenderId(cbGender.Text),
                MobileNo = txtMobileNo.Text,
                City = CBCity.Text,
                Country = CBCountry.Text,
                Status = "Normal",
                LastName = TXTLastName.Text,
                FirstName = TXTFirstName.Text,
                State = cbState.Text,
                AttendenceDeviceId = Basic.ToInt(TXTAttendenceID.Text.Trim()),
                DateOfBirth = DTPBirthDate.Value,
                DateOfJoining = DTPJoiningDate.Value,
                EmpTypeID = EmpCode.GetCategory(CBEmpType.Text),
                DateOfLeaving = DTPJoiningDate.Value,
                EMPCode = eVM.GenerateEmpCode(EmpCode.GetCategory(CBEmpType.Text)),
                StoreCode=CurrentClient.LoggedClient.ClientCode            };
            return eDM;
        }

        private void EmployeeForm_Load( object sender, EventArgs e )
        {
            
            int x = eVM.GetEmployeeTypeList(CBEmpType);
            LoadUiItems();
        }

        private void LoadUiItems( )
        {
            LoadEmpCode();
            eVM.SetGenderList(cbGender);
        }

        private void Cancel_Click( object sender, EventArgs e )
        {
            BTNAdd.Text = "Add";
            BTNUpdate.Text = "Update";
            Basic.ClearUIFields(TLPEmployeeDetails);
        }


        private void LoadEmpCode( )
        {
            List<string> ecodes = eVM.GetAllEmpCodes();
            CBEmpCode.Items.Clear();
            foreach (string item in ecodes)
            {
                CBEmpCode.Items.Add(item);
            }
        }

        private void OnEmpCodeChange( int index )
        {
            emp = eVM.GetEmployeeDetails(CBEmpCode.Items[index].ToString());
            DisplayEmployeeData();
        }
        //TODO: emptype use db  load and update from there Bug 

        private void DisplayEmployeeData( )
        {
            if (emp != null)
            {
                TXTFirstName.Text = emp.FirstName;
                TXTLastName.Text = emp.LastName;
                txtMobileNo.Text = emp.MobileNo;
                CBCity.Text = emp.City;
                CBCountry.Text = emp.Country;
                cbState.Text = emp.State;
                CBEmpCode.Text = emp.EMPCode;
                txtAddress.Text = emp.AddressLine1;
                txtAge.Text = "" + emp.Age;
                TXTAttendenceID.Text = "" + emp.AttendenceDeviceId;
                DTPBirthDate.Value =emp.DateOfBirth;
                DTPJoiningDate.Value = emp.DateOfJoining;
                cbGender.Text = Gender.GetGender(emp.Gender);
                CBEmpType.Text = EmpCode.EmpTypeToCategory(emp.EmpTypeID);
            }
        }

        private void CBEmpCode_SelectedIndexChanged( object sender, EventArgs e )
        {
            int idx = ((ComboBox)sender).SelectedIndex;
            OnEmpCodeChange(idx);
        }

        private void BTNFind_Click( object sender, EventArgs e )
        {
        }

        private void BTNUpdate_Click( object sender, EventArgs e )
        {

        }
    }
}