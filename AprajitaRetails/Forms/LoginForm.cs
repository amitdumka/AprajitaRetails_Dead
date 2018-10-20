﻿using AprajitaRetailsDataBase.Client;
using CyberN.Utility;
using System;
using System.Windows.Forms;

namespace AprajitaRetails
{
    public partial class LoginForm : Form
    {
        private Clients clients = null;

        public LoginForm( )
        {
            InitializeComponent();
            Logs.LogMe("Login Form Loaded..");
            int x = Setups.IsUserTableExit();
            Logs.LogMe("Check User Table Exist or not: x=" + x);
            if (x < 0)
            {
                Logs.LogMe("Creating AuthTable");
                AuthUser.CreateAuthUserTable(x);
            }
            if (Client.IsClientExist())
            {
                clients = Client.GetClientDetails();
                Logs.LogMe("Cleint Details Exist");
            }
            else
            {
                //TODO: Need to Implement to ask detials for client and create client then procced futher
                Logs.LogMe("Creating Client Details");
                if (Client.DefaultClient())
                    clients = Client.GetClientDetails();
            }
            UpdateUiWithClientInfo();
        }

        private void UpdateUiWithClientInfo( )
        {
            if (clients != null)
            {
                LBStoreName.Text = clients.ClientName;
                LBStoreCity.Text = "The Arvind Store, " + clients.ClientCity + "(" + clients.ClientCode + ")";
                Logs.LogMe("Client Details Updated");
            }
        }

        private void LoginForm_Load( object sender, EventArgs e )
        {
            Logs.LogMe("loginForm onLoad...");
        }

        private void btnLogin_Click( object sender, EventArgs e )
        {
            if (txtPassword.Text != "" && txtUserName.Text != "")
                if (AuthUser.DoLogin(txtUserName.Text, txtPassword.Text) == 1)
                {
                    new MainMDI().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect!");
                }
            else
            { MessageBox.Show("Kindly Enter Username and Password"); }
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            DialogResult result = MessageBox.Show("Are Your sure to exit", "Aprajita Retails", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                txtPassword.Text = "";
                txtUserName.Text = "";
            }
        }

        private void GBLogin_Enter( object sender, EventArgs e )
        {
        }
    }
}