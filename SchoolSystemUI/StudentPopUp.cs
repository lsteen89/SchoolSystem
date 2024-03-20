using SchoolSystemLibary.Helper;
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
    public partial class StudentPopUp : Form
    {
        private StudentPopUpHelper studentHelp;
        public StudentPopUp()
    {
            InitializeComponent();
            studentHelp = new StudentPopUpHelper();
            string test = studentHelp.GetStudentPnumID();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(studentHelp.GetStudentPnumID());
        }
    }
}
