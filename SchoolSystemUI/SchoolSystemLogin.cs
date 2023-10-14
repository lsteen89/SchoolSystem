using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }
    }
}
