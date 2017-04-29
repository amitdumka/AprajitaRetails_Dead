using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AprajitaRetails
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent ();
            Logs.LogMe ("Login Form Loaded..");
            int x = Setups.IsUserTableExit ();
            Logs.LogMe ("Check User Table Exist or not: x="+x);
            if ( x < 0 )
            {
                Logs.LogMe ("Creating AuthTable");
                AuthUser.CreateAuthUserTable (x);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Logs.LogMe ("loginForm onLoad...");

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ( txtPassword.Text != "" && txtUserName.Text != "" )
                if ( AuthUser.DoLogin (txtUserName.Text, txtPassword.Text) == 1 )
                {
                    new MainMDI ().Show ();
                    this.Hide ();
                }
                else
                {
                    MessageBox.Show ("Username or password is incorrect!");
                }
            else
            { MessageBox.Show ("Kindly Enter Username and Password"); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           DialogResult result= MessageBox.Show ("Are Your sure to exit", "Aprajita Retails", MessageBoxButtons.YesNo);
            if ( result == DialogResult.Yes )
            {
                this.Close ();
                Application.Exit ();
               
            } else if ( result == DialogResult.No )
            {
                txtPassword.Text = ""; txtUserName.Text = "";
            }
        }
    }
}
