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
    public partial class CustomersForm : Form
    {
        CustomerVM cVm;
        public string CustomerMobileNo;
        public string CustomerFirstName;
        public string CustomerLastName;
        public bool IsDailog = false;
        public int CustomeID;
        public CustomersForm()
        {
            InitializeComponent ();

            cVm = new CustomerVM ();
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
            else if(BTNAdd.Text== "Save && Return")
            {
                PerformSave ();
            }
        }
        void PerformAdd()
        {
            if ( IsDailog )
                BTNAdd.Text = "Save && Return";

            else
                BTNAdd.Text = "Save";
            // Basic.ClearUIFields (tlpPersonal);
        }
        void PerformSave()
        {
            if ( ValidateFields () )
            {
                if ( cVm.SaveData (ReadFields ()) > 0 )
                {
                    BTNAdd.Text = "Add";
                    MessageBox.Show ("Your Record got saved!", "Cusotmer Save");

                    if ( IsDailog )
                    {
                        CustomerMobileNo = txtMobileNo.Text;
                        CustomerFirstName = txtFirstName.Text;
                        CustomerLastName = txtLastname.Text;
                        this.Close ();
                        DialogResult = DialogResult.OK;
                    }
                }
            }

        }

        Customer ReadFields()
        {
            Customer cust = new Customer ()
            {
                City = CBCity.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastname.Text,
                Age = Int32.Parse (txtAge.Text.Trim ()),
                ID = -1,
                MobileNo = txtMobileNo.Text,
                NoOfBills = 0,
                TotalAmount = 0.00,
                Gender = Gender.GetGenderId (cbGender.Text)

            };
            return cust;
        }
        bool ValidateFields()
        {
            return Basic.ValidateFormUI (tlpPersonal);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Basic.ClearUIFields (tlpPersonal);
            BTNAdd.Text = "Add";
            BTNUpdate.Text = "Update";
        }
    }
}
