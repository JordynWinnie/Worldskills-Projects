namespace WSC2017_Paper1_29_10_2020
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userIdtb = new System.Windows.Forms.TextBox();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.loginLbl = new System.Windows.Forms.Label();
            this.loginGroup = new System.Windows.Forms.GroupBox();
            this.loginGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // userIdtb
            // 
            this.userIdtb.Location = new System.Drawing.Point(113, 22);
            this.userIdtb.Name = "userIdtb";
            this.userIdtb.Size = new System.Drawing.Size(631, 20);
            this.userIdtb.TabIndex = 2;
            // 
            // passwordTb
            // 
            this.passwordTb.Location = new System.Drawing.Point(113, 59);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.PasswordChar = '*';
            this.passwordTb.Size = new System.Drawing.Size(631, 20);
            this.passwordTb.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(215, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(358, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // loginLbl
            // 
            this.loginLbl.AutoSize = true;
            this.loginLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLbl.Location = new System.Drawing.Point(21, 26);
            this.loginLbl.Name = "loginLbl";
            this.loginLbl.Size = new System.Drawing.Size(62, 24);
            this.loginLbl.TabIndex = 6;
            this.loginLbl.Text = "Login";
            // 
            // loginGroup
            // 
            this.loginGroup.Controls.Add(this.button1);
            this.loginGroup.Controls.Add(this.passwordTb);
            this.loginGroup.Controls.Add(this.button2);
            this.loginGroup.Controls.Add(this.label2);
            this.loginGroup.Controls.Add(this.userIdtb);
            this.loginGroup.Controls.Add(this.label1);
            this.loginGroup.Location = new System.Drawing.Point(25, 68);
            this.loginGroup.Name = "loginGroup";
            this.loginGroup.Size = new System.Drawing.Size(744, 133);
            this.loginGroup.TabIndex = 7;
            this.loginGroup.TabStop = false;
            this.loginGroup.Text = "groupBox1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 222);
            this.Controls.Add(this.loginLbl);
            this.Controls.Add(this.loginGroup);
            this.Name = "Form1";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.loginGroup.ResumeLayout(false);
            this.loginGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userIdtb;
        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label loginLbl;
        private System.Windows.Forms.GroupBox loginGroup;
    }
}

