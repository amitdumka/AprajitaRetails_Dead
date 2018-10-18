using AprajitaRetailsDataBase.SqlDataBase.Data;
using AprajitaRetailsDataBase.SqlDataBase.ViewModel;
using CyberN.Utility;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

//TODO: Add Option to search based of name or phone or both or only one .
// now is first option is mobile then name
namespace AprajitaRetails.Forms
{
    public partial class CustomersForm : Form
    {
        private CustomerVM cVm;
        public string CustomerMobileNo;
        public string CustomerFirstName;
        public string CustomerLastName;
        public bool IsDailog = false;
        public int CustomeID;

        public CustomersForm( )
        {
            InitializeComponent();

            cVm = new CustomerVM();
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
            else if (BTNAdd.Text == "Save && Return")
            {
                PerformSave();
            }
        }

        private void PerformAdd( )
        {
            if (IsDailog)
                BTNAdd.Text = "Save && Return";
            else
                BTNAdd.Text = "Save";
            // Basic.ClearUIFields (tlpPersonal);
        }

        private void PerformSave( )
        {
            if (ValidateFields())
            {
                if (cVm.SaveData(ReadFields()) > 0)
                {
                    BTNAdd.Text = "Add";
                    MessageBox.Show("Your Record got saved!", "Cusotmer Save");

                    if (IsDailog)
                    {
                        CustomerMobileNo = txtMobileNo.Text;
                        CustomerFirstName = txtFirstName.Text;
                        CustomerLastName = txtLastname.Text;
                        this.Close();
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private Customer ReadFields( )
        {
            Customer cust = new Customer()
            {
                City = CBCity.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastname.Text,
                Age = Int32.Parse(txtAge.Text.Trim()),
                ID = -1,
                MobileNo = txtMobileNo.Text,
                NoOfBills = 0,
                TotalAmount = 0.00,
                Gender = Gender.GetGenderId(cbGender.Text)
            };
            return cust;
        }

        private bool ValidateFields( )
        {
            return Basic.ValidateFormUI(tlpPersonal);
        }

        private void Cancel_Click( object sender, EventArgs e )
        {
            Basic.ClearUIFields(tlpPersonal);
            BTNAdd.Text = "Add";
            BTNUpdate.Text = "Update";
        }

        private void CustomersForm_Load( object sender, EventArgs e )
        {
            LoadMobileNo();
        }

        private void LoadMobileNo( )
        {
            List<string> list = cVm.GetMobileList();
            for (int i = 0; i < list.Count; i++)
            {
                CBMobileNos.Items.Add(list[i]);
            }
        }

        private void CBMobileNos_SelectedIndexChanged( object sender, EventArgs e )
        {
            MoveTOUI(CBMobileNos.Text);
        }

        public void MoveTOUI( string mobileno )
        {
            Customer cust = cVm.GetCustomer(mobileno);
            if (cust != null)
            {
                txtAge.Text = "" + cust.Age;
                txtFirstName.Text = cust.FirstName;
                txtLastname.Text = cust.LastName;
                txtMobileNo.Text = cust.MobileNo;
                CBCity.Text = cust.City;
                cbGender.Text = Gender.GetGender(cust.Gender);
            }
        }

        private void BTNFind_Click( object sender, EventArgs e )
        {
            if (CBMobileNos.Text.Trim().Length >= 10)
            {  //TODO: Add for 91
                MoveTOUI(CBMobileNos.Text.Trim());
            }
            else if (CBNames.Text.Trim().Length > 0)
            {
                ShowCustomer(cVm.GetCustomersByName(CBNames.Text.Trim()));
            }
        }

        private List<Customer> CustLists;

        private void ShowCustomer( List<Customer> custs )
        {
            CustLists = custs;
            for (int i = 0; i < custs.Count; i++)
            {
                CBNames.Items.Add(custs[i].FirstName + " " + custs[i].LastName);
            }
            if (custs.Count > 0)
                CBNames.Text = (custs[0].FirstName + " " + custs[0].LastName);
        }

        private void CBNames_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (CBNames.SelectedIndex >= 0)
                MoveTO(CBNames.SelectedIndex);
            else
            {
                int index = CBNames.Items.IndexOf(CBNames.Text.Trim());
                Logs.LogMe("Index of Cnames " + CBNames.Text + " is " + index);
                MoveTO(CBNames.SelectedIndex);
            }
        }

        public void MoveTO( int i )
        {
            if (CustLists != null && CustLists.Count > 0 && i >= 0)
            {
                Customer cust = CustLists[i];
                if (cust != null)
                {
                    txtAge.Text = "" + cust.Age;
                    txtFirstName.Text = cust.FirstName;
                    txtLastname.Text = cust.LastName;
                    txtMobileNo.Text = cust.MobileNo;
                    CBCity.Text = cust.City;
                    cbGender.Text = Gender.GetGender(cust.Gender);
                }
            }
        }
    }
}