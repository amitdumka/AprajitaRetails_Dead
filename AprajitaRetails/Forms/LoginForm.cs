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
            int x = Setups.IsUserTableExit ();
            if ( x < 0 )
            {
                AuthUser.CreateAuthUserTable (x);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {


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
    }
}
