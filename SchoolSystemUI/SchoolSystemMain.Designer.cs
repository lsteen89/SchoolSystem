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
            this.SuspendLayout();
            // 
            // MainWelcomeLabel
            // 
            this.MainWelcomeLabel.AutoSize = true;
            this.MainWelcomeLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.MainWelcomeLabel.Location = new System.Drawing.Point(44, 67);
            this.MainWelcomeLabel.Name = "MainWelcomeLabel";
            this.MainWelcomeLabel.Size = new System.Drawing.Size(101, 25);
            this.MainWelcomeLabel.TabIndex = 0;
            this.MainWelcomeLabel.Text = "Welcome";
            // 
            // SchoolSystemMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1371, 750);
            this.Controls.Add(this.MainWelcomeLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SchoolSystemMain";
            this.Text = "School system ©";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label MainWelcomeLabel;
    }
}