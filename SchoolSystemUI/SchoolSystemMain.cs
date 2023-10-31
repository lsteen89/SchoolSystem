using Microsoft.VisualBasic.ApplicationServices;
using SchoolSystemLibary;
using SchoolSystemLibary.DataAccess;
using SchoolSystemLibary.Login;
using SchoolSystemLibary.Models;
using System.Security;

namespace SchoolSystemUI
{
    public partial class SchoolSystemMain : Form
    {
        private string LoginName { get; }
        private List<string> Roles { get; }
        private string Persoid { get; }


        public SchoolSystemMain()
        {

            InitializeComponent();

            // Fetch all details from the user session
            LoginName = UserSessionManager.Instance.CurrentUserSession.Username;
            Roles = UserSessionManager.Instance.CurrentUserSession.RoleList;
            Persoid = UserSessionManager.Instance.CurrentUserSession.Persoid;


            // Prepare SQL exectuors
            SqlExecutor sqlExecutor = new SqlExecutor(GlobalConfig.GetConnection().ConnectionString); // Create an instance of SqlExecutor with the connection string


            // Welcome message to everyone feels welcome :-)
            DateTime currentTime = DateTime.Now;
            TimeSpan startTime = new TimeSpan(5, 0, 0); // 05:00 AM
            TimeSpan endTime = new TimeSpan(11, 59, 59); // 11:59 AM
            if (currentTime.TimeOfDay >= startTime && currentTime.TimeOfDay <= endTime)
                MainWelcomeLabel.Text = " God förmiddag " + LoginName;
            else
                MainWelcomeLabel.Text = " God eftermiddag " + LoginName;

            //Fill the comboBox of avaible classes
            List<string> yearGrades = sqlExecutor.GetAvailableYearGrades(Persoid).ToList();
            for (int i = 0; i < yearGrades.Count; i++)
                MainUIClassSelectorComboBox.Items.Add(yearGrades[i]);


            /*
            //Lärare
            if (Roles.Contains("1"))
            {
                
                //var students = sqlExecutor.GetStudentInfo(Persoid);
                foreach(var student in studentModels)
                    MainUIStudentListBox.Items.Add(student.FirstName);
            }
            */
            /*
            SchoolSystemLogin Loginpopup = new SchoolSystemLogin();
            Loginpopup.TopLevel = false;
            Loginpopup.AutoScroll = true;
            this.Controls.Add(Loginpopup);
            Loginpopup.Show();
            */

        }

        private void SchoolSystemMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Application.Exit();
        }

        private void MainUIClassSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the selected class or year grade from the combo box
            string selectedClass = MainUIClassSelectorComboBox.SelectedItem.ToString();

            // Query the database to get students for the selected class
            SqlExecutor sqlExecutor = new SqlExecutor(GlobalConfig.GetConnection().ConnectionString);

            List<StudentModel> studentModels = sqlExecutor.GetStudentInfo(Persoid, selectedClass);
            List<DisplayStudent> displayStudents = studentModels
                .Select(student => new DisplayStudent(student.FirstName, student.LastName))
                .ToList();
            MainUIStudentListBox.DataSource = displayStudents;
            MainUIStudentListBox.DisplayMember = "FullName";
        }
    }
}