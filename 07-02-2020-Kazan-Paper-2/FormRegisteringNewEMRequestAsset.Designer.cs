namespace _07_02_2020_Kazan_Paper_2
{
    partial class FormRegisteringNewEMRequestAsset
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
            this.submitBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.assetSNLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.assetNameLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.departmentLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.emergencyDesTb = new System.Windows.Forms.TextBox();
            this.otherConsiderationsTB = new System.Windows.Forms.TextBox();
            this.priorityCB = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.departmentLbl);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.assetNameLbl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.assetSNLbl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Asset";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.priorityCB);
            this.groupBox2.Controls.Add(this.otherConsiderationsTB);
            this.groupBox2.Controls.Add(this.emergencyDesTb);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(13, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(775, 276);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request Report";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(110, 414);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(186, 23);
            this.submitBtn.TabIndex = 2;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(596, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset SN:";
            // 
            // assetSNLbl
            // 
            this.assetSNLbl.AutoSize = true;
            this.assetSNLbl.Location = new System.Drawing.Point(126, 45);
            this.assetSNLbl.Name = "assetSNLbl";
            this.assetSNLbl.Size = new System.Drawing.Size(71, 17);
            this.assetSNLbl.TabIndex = 1;
            this.assetSNLbl.Text = "(assetSN)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Asset Name:";
            // 
            // assetNameLbl
            // 
            this.assetNameLbl.AutoSize = true;
            this.assetNameLbl.Location = new System.Drawing.Point(334, 45);
            this.assetNameLbl.Name = "assetNameLbl";
            this.assetNameLbl.Size = new System.Drawing.Size(90, 17);
            this.assetNameLbl.TabIndex = 3;
            this.assetNameLbl.Text = "(AssetName)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(488, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Department:";
            // 
            // departmentLbl
            // 
            this.departmentLbl.AutoSize = true;
            this.departmentLbl.Location = new System.Drawing.Point(585, 45);
            this.departmentLbl.Name = "departmentLbl";
            this.departmentLbl.Size = new System.Drawing.Size(129, 17);
            this.departmentLbl.TabIndex = 5;
            this.departmentLbl.Text = "(DepartmentName)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Priority:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Description of Emergency:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Other Considerations:";
            // 
            // emergencyDesTb
            // 
            this.emergencyDesTb.Location = new System.Drawing.Point(97, 113);
            this.emergencyDesTb.Multiline = true;
            this.emergencyDesTb.Name = "emergencyDesTb";
            this.emergencyDesTb.Size = new System.Drawing.Size(672, 59);
            this.emergencyDesTb.TabIndex = 3;
            // 
            // otherConsiderationsTB
            // 
            this.otherConsiderationsTB.Location = new System.Drawing.Point(97, 203);
            this.otherConsiderationsTB.Multiline = true;
            this.otherConsiderationsTB.Name = "otherConsiderationsTB";
            this.otherConsiderationsTB.Size = new System.Drawing.Size(672, 67);
            this.otherConsiderationsTB.TabIndex = 4;
            // 
            // priorityCB
            // 
            this.priorityCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityCB.FormattingEnabled = true;
            this.priorityCB.Location = new System.Drawing.Point(97, 34);
            this.priorityCB.Name = "priorityCB";
            this.priorityCB.Size = new System.Drawing.Size(368, 24);
            this.priorityCB.TabIndex = 5;
            // 
            // FormRegisteringNewEMRequestAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormRegisteringNewEMRequestAsset";
            this.Text = "FormRegisteringNewEMRequestAsset";
            this.Load += new System.EventHandler(this.FormRegisteringNewEMRequestAsset_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label departmentLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label assetNameLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label assetSNLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox priorityCB;
        private System.Windows.Forms.TextBox otherConsiderationsTB;
        private System.Windows.Forms.TextBox emergencyDesTb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}