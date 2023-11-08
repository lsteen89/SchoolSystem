namespace SchoolSystemUI
{
    partial class SchoolSystemMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchoolSystemMain));
            this.MainWelcomeLabel = new System.Windows.Forms.Label();
            this.MainUIStudentListBox = new System.Windows.Forms.ListBox();
            this.MainUIClassSelectorComboBox = new System.Windows.Forms.ComboBox();
            this.MainUIClassSelectorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MainWelcomeLabel
            // 
            this.MainWelcomeLabel.AutoSize = true;
            this.MainWelcomeLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.MainWelcomeLabel.Location = new System.Drawing.Point(44, 67);
            this.MainWelcomeLabel.Name = "MainWelcomeLabel";
            this.MainWelcomeLabel.Size = new System.Drawing.Size(126, 31);
            this.MainWelcomeLabel.TabIndex = 0;
            this.MainWelcomeLabel.Text = "Welcome";
            // 
            // MainUIStudentListBox
            // 
            this.MainUIStudentListBox.FormattingEnabled = true;
            this.MainUIStudentListBox.ItemHeight = 30;
            this.MainUIStudentListBox.Location = new System.Drawing.Point(689, 67);
            this.MainUIStudentListBox.Name = "MainUIStudentListBox";
            this.MainUIStudentListBox.Size = new System.Drawing.Size(629, 504);
            this.MainUIStudentListBox.TabIndex = 1;
            this.MainUIStudentListBox.SelectedIndexChanged += new System.EventHandler(this.MainUIStudentListBox_SelectedIndexChanged);
            // 
            // MainUIClassSelectorComboBox
            // 
            this.MainUIClassSelectorComboBox.FormattingEnabled = true;
            this.MainUIClassSelectorComboBox.Location = new System.Drawing.Point(689, 635);
            this.MainUIClassSelectorComboBox.Name = "MainUIClassSelectorComboBox";
            this.MainUIClassSelectorComboBox.Size = new System.Drawing.Size(335, 38);
            this.MainUIClassSelectorComboBox.TabIndex = 2;
            this.MainUIClassSelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.MainUIClassSelectorComboBox_SelectedIndexChanged);
            // 
            // MainUIClassSelectorLabel
            // 
            this.MainUIClassSelectorLabel.AutoSize = true;
            this.MainUIClassSelectorLabel.Location = new System.Drawing.Point(689, 599);
            this.MainUIClassSelectorLabel.Name = "MainUIClassSelectorLabel";
            this.MainUIClassSelectorLabel.Size = new System.Drawing.Size(156, 31);
            this.MainUIClassSelectorLabel.TabIndex = 3;
            this.MainUIClassSelectorLabel.Text = "Välj årskurs";
            // 
            // SchoolSystemMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1371, 750);
            this.Controls.Add(this.MainUIClassSelectorLabel);
            this.Controls.Add(this.MainUIClassSelectorComboBox);
            this.Controls.Add(this.MainUIStudentListBox);
            this.Controls.Add(this.MainWelcomeLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SchoolSystemMain";
            this.Text = "School system ©";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SchoolSystemMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label MainWelcomeLabel;
        private ListBox MainUIStudentListBox;
        private ComboBox MainUIClassSelectorComboBox;
        private Label MainUIClassSelectorLabel;
    }
}