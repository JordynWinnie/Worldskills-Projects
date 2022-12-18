namespace WSC2017_Paper1_29_10_2020
{
    partial class SecurityForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reasonTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.loginLbl = new System.Windows.Forms.Label();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.softwareCrashRadio = new System.Windows.Forms.RadioButton();
            this.systemCrashRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.systemCrashRadio);
            this.groupBox1.Controls.Add(this.softwareCrashRadio);
            this.groupBox1.Location = new System.Drawing.Point(15, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Crash Type:";
            // 
            // reasonTb
            // 
            this.reasonTb.Location = new System.Drawing.Point(15, 67);
            this.reasonTb.Multiline = true;
            this.reasonTb.Name = "reasonTb";
            this.reasonTb.Size = new System.Drawing.Size(534, 105);
            this.reasonTb.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reason:";
            // 
            // loginLbl
            // 
            this.loginLbl.AutoSize = true;
            this.loginLbl.Location = new System.Drawing.Point(15, 13);
            this.loginLbl.Name = "loginLbl";
            this.loginLbl.Size = new System.Drawing.Size(35, 13);
            this.loginLbl.TabIndex = 4;
            this.loginLbl.Text = "label3";
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(18, 282);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(531, 23);
            this.confirmBtn.TabIndex = 5;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // softwareCrashRadio
            // 
            this.softwareCrashRadio.AutoSize = true;
            this.softwareCrashRadio.Location = new System.Drawing.Point(6, 33);
            this.softwareCrashRadio.Name = "softwareCrashRadio";
            this.softwareCrashRadio.Size = new System.Drawing.Size(97, 17);
            this.softwareCrashRadio.TabIndex = 0;
            this.softwareCrashRadio.TabStop = true;
            this.softwareCrashRadio.Text = "Software Crash";
            this.softwareCrashRadio.UseVisualStyleBackColor = true;
            // 
            // systemCrashRadio
            // 
            this.systemCrashRadio.AutoSize = true;
            this.systemCrashRadio.Location = new System.Drawing.Point(109, 33);
            this.systemCrashRadio.Name = "systemCrashRadio";
            this.systemCrashRadio.Size = new System.Drawing.Size(89, 17);
            this.systemCrashRadio.TabIndex = 1;
            this.systemCrashRadio.TabStop = true;
            this.systemCrashRadio.Text = "System Crash";
            this.systemCrashRadio.UseVisualStyleBackColor = true;
            // 
            // SecurityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 450);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.loginLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reasonTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "SecurityForm";
            this.Text = "SecurityForm";
            this.Load += new System.EventHandler(this.SecurityForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton systemCrashRadio;
        private System.Windows.Forms.RadioButton softwareCrashRadio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox reasonTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label loginLbl;
        private System.Windows.Forms.Button confirmBtn;
    }
}