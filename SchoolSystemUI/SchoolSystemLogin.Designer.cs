namespace SchoolSystemUI
{
    partial class SchoolSystemLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchoolSystemLogin));
            this.SchoolSystemLoginLabel = new System.Windows.Forms.Label();
            this.SchoolSystemLoginNameLabel = new System.Windows.Forms.Label();
            this.SchoolSystemLoginPasswordLabel = new System.Windows.Forms.Label();
            this.SchoolSystemLoginForgotPWLinkedLabel = new System.Windows.Forms.LinkLabel();
            this.SchoolSystemLoginUserTextBox = new System.Windows.Forms.TextBox();
            this.SchoolSystemLoginPasswordTextBox = new System.Windows.Forms.TextBox();
            this.SchoolSystemLoginButton = new System.Windows.Forms.Button();
            this.SchoolSystemLoginExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SchoolSystemLoginLabel
            // 
            this.SchoolSystemLoginLabel.AutoSize = true;
            this.SchoolSystemLoginLabel.Location = new System.Drawing.Point(49, 58);
            this.SchoolSystemLoginLabel.Name = "SchoolSystemLoginLabel";
            this.SchoolSystemLoginLabel.Size = new System.Drawing.Size(350, 25);
            this.SchoolSystemLoginLabel.TabIndex = 0;
            this.SchoolSystemLoginLabel.Text = "Vänligen ange inloggningsuppgifter";
            // 
            // SchoolSystemLoginNameLabel
            // 
            this.SchoolSystemLoginNameLabel.AutoSize = true;
            this.SchoolSystemLoginNameLabel.Location = new System.Drawing.Point(49, 130);
            this.SchoolSystemLoginNameLabel.Name = "SchoolSystemLoginNameLabel";
            this.SchoolSystemLoginNameLabel.Size = new System.Drawing.Size(169, 25);
            this.SchoolSystemLoginNameLabel.TabIndex = 1;
            this.SchoolSystemLoginNameLabel.Text = "Användarenamn";
            // 
            // SchoolSystemLoginPasswordLabel
            // 
            this.SchoolSystemLoginPasswordLabel.AutoSize = true;
            this.SchoolSystemLoginPasswordLabel.Location = new System.Drawing.Point(49, 178);
            this.SchoolSystemLoginPasswordLabel.Name = "SchoolSystemLoginPasswordLabel";
            this.SchoolSystemLoginPasswordLabel.Size = new System.Drawing.Size(102, 25);
            this.SchoolSystemLoginPasswordLabel.TabIndex = 2;
            this.SchoolSystemLoginPasswordLabel.Text = "Lösenord";
            // 
            // SchoolSystemLoginForgotPWLinkedLabel
            // 
            this.SchoolSystemLoginForgotPWLinkedLabel.AutoSize = true;
            this.SchoolSystemLoginForgotPWLinkedLabel.Location = new System.Drawing.Point(242, 268);
            this.SchoolSystemLoginForgotPWLinkedLabel.Name = "SchoolSystemLoginForgotPWLinkedLabel";
            this.SchoolSystemLoginForgotPWLinkedLabel.Size = new System.Drawing.Size(169, 25);
            this.SchoolSystemLoginForgotPWLinkedLabel.TabIndex = 3;
            this.SchoolSystemLoginForgotPWLinkedLabel.TabStop = true;
            this.SchoolSystemLoginForgotPWLinkedLabel.Text = "Glömt lösenord?";
            // 
            // SchoolSystemLoginUserTextBox
            // 
            this.SchoolSystemLoginUserTextBox.Location = new System.Drawing.Point(242, 130);
            this.SchoolSystemLoginUserTextBox.Name = "SchoolSystemLoginUserTextBox";
            this.SchoolSystemLoginUserTextBox.Size = new System.Drawing.Size(324, 31);
            this.SchoolSystemLoginUserTextBox.TabIndex = 4;
            // 
            // SchoolSystemLoginPasswordTextBox
            // 
            this.SchoolSystemLoginPasswordTextBox.Location = new System.Drawing.Point(242, 178);
            this.SchoolSystemLoginPasswordTextBox.Name = "SchoolSystemLoginPasswordTextBox";
            this.SchoolSystemLoginPasswordTextBox.PasswordChar = '*';
            this.SchoolSystemLoginPasswordTextBox.Size = new System.Drawing.Size(324, 31);
            this.SchoolSystemLoginPasswordTextBox.TabIndex = 5;
            this.SchoolSystemLoginPasswordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SchoolSystemLoginPasswordTextBox_KeyPress);
            // 
            // SchoolSystemLoginButton
            // 
            this.SchoolSystemLoginButton.Location = new System.Drawing.Point(242, 223);
            this.SchoolSystemLoginButton.Name = "SchoolSystemLoginButton";
            this.SchoolSystemLoginButton.Size = new System.Drawing.Size(129, 42);
            this.SchoolSystemLoginButton.TabIndex = 6;
            this.SchoolSystemLoginButton.Text = "Logga in";
            this.SchoolSystemLoginButton.UseVisualStyleBackColor = true;
            this.SchoolSystemLoginButton.Click += new System.EventHandler(this.SchoolSystemLoginButton_Click);
            // 
            // SchoolSystemLoginExitButton
            // 
            this.SchoolSystemLoginExitButton.Location = new System.Drawing.Point(377, 223);
            this.SchoolSystemLoginExitButton.Name = "SchoolSystemLoginExitButton";
            this.SchoolSystemLoginExitButton.Size = new System.Drawing.Size(129, 42);
            this.SchoolSystemLoginExitButton.TabIndex = 7;
            this.SchoolSystemLoginExitButton.Text = "Avbryt";
            this.SchoolSystemLoginExitButton.UseVisualStyleBackColor = true;
            this.SchoolSystemLoginExitButton.Click += new System.EventHandler(this.SchoolSystemLoginExitButton_Click);
            // 
            // SchoolSystemLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(905, 458);
            this.Controls.Add(this.SchoolSystemLoginExitButton);
            this.Controls.Add(this.SchoolSystemLoginButton);
            this.Controls.Add(this.SchoolSystemLoginPasswordTextBox);
            this.Controls.Add(this.SchoolSystemLoginUserTextBox);
            this.Controls.Add(this.SchoolSystemLoginForgotPWLinkedLabel);
            this.Controls.Add(this.SchoolSystemLoginPasswordLabel);
            this.Controls.Add(this.SchoolSystemLoginNameLabel);
            this.Controls.Add(this.SchoolSystemLoginLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SchoolSystemLogin";
            this.Text = "SchoolSystemLogin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SchoolSystemLogin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label SchoolSystemLoginLabel;
        private Label SchoolSystemLoginNameLabel;
        private Label SchoolSystemLoginPasswordLabel;
        private LinkLabel SchoolSystemLoginForgotPWLinkedLabel;
        private TextBox SchoolSystemLoginUserTextBox;
        private TextBox SchoolSystemLoginPasswordTextBox;
        private Button SchoolSystemLoginButton;
        private Button SchoolSystemLoginExitButton;
    }
}