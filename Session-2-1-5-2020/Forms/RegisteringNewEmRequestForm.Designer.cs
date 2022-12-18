namespace Session_2_1_5_2020.Forms
{
    partial class RegisteringNewEmRequestForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAssetSN = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAssetName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PriorityCb = new System.Windows.Forms.ComboBox();
            this.DescriptionOfEMTb = new System.Windows.Forms.TextBox();
            this.OtherConsiderationsTb = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDepartment);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblAssetName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblAssetSN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Asset";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OtherConsiderationsTb);
            this.groupBox2.Controls.Add(this.DescriptionOfEMTb);
            this.groupBox2.Controls.Add(this.PriorityCb);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 256);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request Report";
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(626, 415);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(75, 23);
            this.SubmitBtn.TabIndex = 2;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.ForeColor = System.Drawing.Color.Red;
            this.CloseBtn.Location = new System.Drawing.Point(707, 415);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 3;
            this.CloseBtn.Text = "Cancel";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset SN:";
            // 
            // lblAssetSN
            // 
            this.lblAssetSN.AutoSize = true;
            this.lblAssetSN.Location = new System.Drawing.Point(66, 44);
            this.lblAssetSN.Name = "lblAssetSN";
            this.lblAssetSN.Size = new System.Drawing.Size(35, 13);
            this.lblAssetSN.TabIndex = 1;
            this.lblAssetSN.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Asset Name:";
            // 
            // lblAssetName
            // 
            this.lblAssetName.AutoSize = true;
            this.lblAssetName.Location = new System.Drawing.Point(281, 44);
            this.lblAssetName.Name = "lblAssetName";
            this.lblAssetName.Size = new System.Drawing.Size(35, 13);
            this.lblAssetName.TabIndex = 3;
            this.lblAssetName.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(495, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Department:";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(566, 44);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(35, 13);
            this.lblDepartment.TabIndex = 5;
            this.lblDepartment.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Priority:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Description of Emergency:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Other Considerations:";
            // 
            // PriorityCb
            // 
            this.PriorityCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PriorityCb.FormattingEnabled = true;
            this.PriorityCb.Location = new System.Drawing.Point(47, 22);
            this.PriorityCb.Name = "PriorityCb";
            this.PriorityCb.Size = new System.Drawing.Size(723, 21);
            this.PriorityCb.TabIndex = 3;
            // 
            // DescriptionOfEMTb
            // 
            this.DescriptionOfEMTb.Location = new System.Drawing.Point(47, 89);
            this.DescriptionOfEMTb.Multiline = true;
            this.DescriptionOfEMTb.Name = "DescriptionOfEMTb";
            this.DescriptionOfEMTb.Size = new System.Drawing.Size(723, 56);
            this.DescriptionOfEMTb.TabIndex = 4;
            // 
            // OtherConsiderationsTb
            // 
            this.OtherConsiderationsTb.Location = new System.Drawing.Point(47, 184);
            this.OtherConsiderationsTb.Multiline = true;
            this.OtherConsiderationsTb.Name = "OtherConsiderationsTb";
            this.OtherConsiderationsTb.Size = new System.Drawing.Size(723, 56);
            this.OtherConsiderationsTb.TabIndex = 5;
            // 
            // RegisteringNewEmRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegisteringNewEmRequestForm";
            this.Text = "RegisteringNewEmRequestForm";
            this.Load += new System.EventHandler(this.RegisteringNewEmRequestForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAssetName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAssetSN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox OtherConsiderationsTb;
        private System.Windows.Forms.TextBox DescriptionOfEMTb;
        private System.Windows.Forms.ComboBox PriorityCb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Button CloseBtn;
    }
}