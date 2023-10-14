namespace SchoolSystemUI
{
    public partial class SchoolSystemMain : Form
    {
        public SchoolSystemMain()
        {
            InitializeComponent();
            SchoolSystemLogin Loginpopup = new SchoolSystemLogin();
            Loginpopup.TopLevel = false;
            Loginpopup.AutoScroll = true;
            this.Controls.Add(Loginpopup);
            Loginpopup.Show();   
        }

        private void SchoolSystemMain_Load(object sender, EventArgs e)
        {

        }
    }
}