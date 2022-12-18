namespace WSC2017_Paper1_29_10_2020
{
    partial class AddUserForm
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
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.emailTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.firstNameTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lastnameTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.officeCb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.birthdayDTP = new System.Windows.Forms.DateTimePicker();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.userRadio = new System.Windows.Forms.RadioButton();
            this.adminRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordTb
            // 
            this.passwordTb.Location = new System.Drawing.Point(104, 65);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.PasswordChar = '*';
            this.passwordTb.Size = new System.Drawing.Size(631, 20);
            this.passwordTb.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // emailTb
            // 
            this.emailTb.Location = new System.Drawing.Point(120, 38);
            this.emailTb.Name = "emailTb";
            this.emailTb.Size = new System.Drawing.Size(631, 20);
            this.emailTb.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Email Address:";
            // 
            // firstNameTb
            // 
            this.firstNameTb.Location = new System.Drawing.Point(120, 78);
            this.firstNameTb.Name = "firstNameTb";
            this.firstNameTb.Size = new System.Drawing.Size(631, 20);
            this.firstNameTb.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "First Name:";
            // 
            // lastnameTb
            // 
            this.lastnameTb.Location = new System.Drawing.Point(120, 116);
            this.lastnameTb.Name = "lastnameTb";
            this.lastnameTb.Size = new System.Drawing.Size(631, 20);
            this.lastnameTb.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Last Name:";
            // 
            // officeCb
            // 
            this.officeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.officeCb.FormattingEnabled = true;
            this.officeCb.Location = new System.Drawing.Point(120, 153);
            this.officeCb.Name = "officeCb";
            this.officeCb.Size = new System.Drawing.Size(631, 21);
            this.officeCb.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Offices:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Birthday:";
            // 
            // birthdayDTP
            // 
            this.birthdayDTP.Location = new System.Drawing.Point(104, 28);
            this.birthdayDTP.Name = "birthdayDTP";
            this.birthdayDTP.Size = new System.Drawing.Size(631, 20);
            this.birthdayDTP.TabIndex = 15;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(39, 355);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(263, 36);
            this.saveBtn.TabIndex = 16;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(485, 355);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(263, 36);
            this.cancelBtn.TabIndex = 17;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.birthdayDTP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.passwordTb);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 88);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.adminRadio);
            this.groupBox2.Controls.Add(this.userRadio);
            this.groupBox2.Location = new System.Drawing.Point(32, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(719, 51);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Role";
            // 
            // userRadio
            // 
            this.userRadio.AutoSize = true;
            this.userRadio.Location = new System.Drawing.Point(88, 20);
            this.userRadio.Name = "userRadio";
            this.userRadio.Size = new System.Drawing.Size(47, 17);
            this.userRadio.TabIndex = 0;
            this.userRadio.TabStop = true;
            this.userRadio.Text = "User";
            this.userRadio.UseVisualStyleBackColor = true;
            // 
            // adminRadio
            // 
            this.adminRadio.AutoSize = true;
            this.adminRadio.Location = new System.Drawing.Point(156, 20);
            this.adminRadio.Name = "adminRadio";
            this.adminRadio.Size = new System.Drawing.Size(54, 17);
            this.adminRadio.TabIndex = 1;
            this.adminRadio.TabStop = true;
            this.adminRadio.Text = "Admin";
            this.adminRadio.UseVisualStyleBackColor = true;
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 403);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.officeCb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lastnameTb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.firstNameTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.emailTb);
            this.Controls.Add(this.label1);
            this.Name = "AddUserForm";
            this.Text = "AddUserForm";
            this.Load += new System.EventHandler(this.AddUserForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emailTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstNameTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lastnameTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox officeCb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker birthdayDTP;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton adminRadio;
        private System.Windows.Forms.RadioButton userRadio;
    }
}