using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestHourCalc
{
    
    public partial class frmUserLogin : Form
    {
        DBAccessLayer dbLayer = new DBAccessLayer();

        public String strUserName;
        public string strPswd;
        public frmUserLogin()
        {
            InitializeComponent();
        }
        private void Authenticate()
        {
            String strRole = dbLayer.AuthenticateUser(txtUserName.Text, txtPassword.Text);
            if (strRole == null)
            {
                MessageBox.Show("Invalid Username/Password. Try Again!");
            }
            else
            {
                    frmShipMain objMainScreen = new frmShipMain(txtUserName.Text ,strRole );
                    objMainScreen.AccessControl();    
                    objMainScreen.Show();
                    this.Visible = false;
             }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String strUserName = txtUserName.Text.ToString();
            Authenticate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtUserName.Clear();
            this.Close();
        }

        private void btnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                Authenticate();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                Authenticate();
            }
        }

            
    }
}