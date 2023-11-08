using Microsoft.VisualBasic.ApplicationServices;
using SchoolSystemLibary;
using SchoolSystemLibary.DataAccess;
using SchoolSystemLibary.Login;
using SchoolSystemLibary.Models;
using System.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SchoolSystemUI
{
    public partial class SchoolSystemMain : Form
    {
        private string LoginName { get; }
        private List<string> Roles { get; }
        private string Persoid { get; }
        private StudentModel studentModel;

        public SchoolSystemMain()
        {

            InitializeComponent();

            // Fetch all details from the user session
            LoginName = UserSessionManager.Instance.CurrentUserSession.Username;
            Roles = UserSessionManager.Instance.CurrentUserSession.RoleList;
            Persoid = UserSessionManager.Instance.CurrentUserSession.Persoid;


            // Prepare SQL exectuors
            SqlExecutor sqlExecutor = new SqlExecutor(GlobalConfig.GetConnection().ConnectionString); // Create an instance of SqlExecutor with the connection string

            // Welcome message so that everyone feels welcome :-)
            DateTime currentTime = DateTime.Now;
            TimeSpan startTime = new TimeSpan(5, 0, 0); // 05:00 AM
            TimeSpan endTime = new TimeSpan(11, 59, 59); // 11:59 AM
            if (currentTime.TimeOfDay >= startTime && currentTime.TimeOfDay <= endTime)
                MainWelcomeLabel.Text = " God förmiddag " + LoginName;
            else
                MainWelcomeLabel.Text = " God eftermiddag " + LoginName;
            
            if (Roles.Contains("1") || Roles.Contains("3"))
            {
                //Fill the comboBox of avaible classes
                List<string> yearGrades = sqlExecutor.GetAvailableYearGrades(Persoid).ToList();
                for (int i = 0; i < yearGrades.Count; i++)
                    MainUIClassSelectorComboBox.Items.Add(yearGrades[i]);   
            }
        }

        private void SchoolSystemMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Application.Exit();
        }

        private void MainUIClassSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainUIStudentListBox.Items.Clear();
            // Retrieve the selected class or year grade from the combo box
            string selectedClass = MainUIClassSelectorComboBox.SelectedItem.ToString();

            //Clear and header
            MainUIStudentListBox.Items.Clear();
            MainUIStudentListBox.Items.Add("Namn \t\t Personnummer");
            // Query the database to get students for the selected class
            // Write it out afterwards in ListBox

            SqlExecutor sqlExecutor = new SqlExecutor(GlobalConfig.GetConnection().ConnectionString);
            List<StudentModel> studentModels = sqlExecutor.GetStudentInfo(Persoid, selectedClass);
            foreach (var student in studentModels)
            {
                DisplayStudent displayStudent = new DisplayStudent(student.FirstName, student.LastName, student.DateOfBirth);
                MainUIStudentListBox.Items.Add(displayStudent);
            }
        }

        private void MainUIStudentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //First index is header, make is unselectable
            if (MainUIStudentListBox.SelectedIndex == 0)
                MainUIStudentListBox.SelectedIndex = 1;


            //Start StudentPopup to display selected student information
            StudentPopUp studentPopUp = new StudentPopUp();
            studentPopUp.ShowDialog();
            
        }
    }
}