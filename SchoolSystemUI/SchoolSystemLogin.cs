using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using SchoolSystemLibary.Login;
using SchoolSystemLibary.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace SchoolSystemUI
{

    public partial class SchoolSystemLogin : Form
    {
        private bool ExitbuttonClicked = false;

        public SchoolSystemLogin()
        {
            InitializeComponent();
            // Set the form to always stay on top.
        }
        private void SchoolSystemLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Make user unable to close the form. The only way to exit is thru the exit button or to enter credentials
            if (!ExitbuttonClicked)
            {
                e.Cancel = true;
            }
        }

        private void SchoolSystemLoginExitButton_Click(object sender, EventArgs e)
        {
            ExitbuttonClicked = true;
            Application.Exit();
        }

        private void SchoolSystemLoginButton_Click(object sender, EventArgs e)
        {
            string loginName = SchoolSystemLoginUserTextBox.Text;
            string pw = SchoolSystemLoginPasswordTextBox.Text;

            if (loginName.Length > 0 && pw.Length > 0)
            {
                LoginManager loginManager = new LoginManager();
                UserModel authenticatedUser = loginManager.AuthenticateUser(loginName, pw);

                if (authenticatedUser != null)
                {
                    ExitbuttonClicked = true;

                    this.Hide();
                    SchoolSystemMain schoolSystemMain = new SchoolSystemMain();
                    schoolSystemMain.Show();
                }
                else
                    MessageBox.Show("Felaktiga uppgifter!");
            }
            else
                MessageBox.Show("Vänligen se över inloggningsuppgifter");
        }
        private void SchoolSystemLoginPasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Prevent the "ding" sound
                SchoolSystemLoginButton.PerformClick(); // Simulate a button click
            }
        }

        private void DebugButton_Click(object sender, EventArgs e)
        {
            string loginName = "sonek";
            string pw = SchoolSystemLoginPasswordTextBox.Text;

            if (1==1)
            {
                LoginManager loginManager = new LoginManager();
                UserModel authenticatedUser = loginManager.AuthenticateUser(loginName, pw);

                if (authenticatedUser != null)
                {
                    ExitbuttonClicked = true;

                    this.Hide();
                    SchoolSystemMain schoolSystemMain = new SchoolSystemMain();
                    schoolSystemMain.Show();
                }
                else
                    MessageBox.Show("Felaktiga uppgifter!");
            }
            else
                MessageBox.Show("Vänligen se över inloggningsuppgifter");
        }
    }
}
