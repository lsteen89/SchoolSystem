using Microsoft.VisualBasic.ApplicationServices;
using SchoolSystemLibary.Login;
using System.Security;

namespace SchoolSystemUI
{
    public partial class SchoolSystemMain : Form
    {
        public SchoolSystemMain()
        {

            InitializeComponent();
            string LoginName = UserSessionManager.Instance.CurrentUserSession.Username;
            List<string> roles = UserSessionManager.Instance.CurrentUserSession.RoleList;

            DateTime currentTime = DateTime.Now;
            TimeSpan startTime = new TimeSpan(5, 0, 0); // 05:00 AM
            TimeSpan endTime = new TimeSpan(11, 59, 59); // 11:59 AM
            if (currentTime.TimeOfDay >= startTime && currentTime.TimeOfDay <= endTime)
            {
                MainWelcomeLabel.Text = " God förmiddag " + LoginName;
            }
            else
                MainWelcomeLabel.Text = " God eftermiddag " + LoginName;

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
    }
}