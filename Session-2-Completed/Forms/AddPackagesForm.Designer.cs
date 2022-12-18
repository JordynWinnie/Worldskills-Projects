namespace Session2_JordanKhong.Forms
{
    partial class AddPackagesForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.filePathTb = new System.Windows.Forms.TextBox();
            this.tierCb = new System.Windows.Forms.ComboBox();
            this.packageNameTb = new System.Windows.Forms.TextBox();
            this.valueTb = new System.Windows.Forms.TextBox();
            this.availQntyTb = new System.Windows.Forms.TextBox();
            this.clearFormBtn = new System.Windows.Forms.Button();
            this.addPackageBtn = new System.Windows.Forms.Button();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.benefitsCheckList = new System.Windows.Forms.CheckedListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(171, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(393, 34);
            this.label6.TabIndex = 13;
            this.label6.Text = "Add Sponsorship Packages";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(123, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tier:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Package Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(108, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Value:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(-3, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Available Quantity:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Filter by Benefit:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 524);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "File Path:";
            // 
            // filePathTb
            // 
            this.filePathTb.Location = new System.Drawing.Point(133, 525);
            this.filePathTb.Name = "filePathTb";
            this.filePathTb.Size = new System.Drawing.Size(437, 22);
            this.filePathTb.TabIndex = 20;
            this.filePathTb.Click += new System.EventHandler(this.textBox1_Click);
            this.filePathTb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tierCb
            // 
            this.tierCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tierCb.FormattingEnabled = true;
            this.tierCb.Location = new System.Drawing.Point(189, 141);
            this.tierCb.Name = "tierCb";
            this.tierCb.Size = new System.Drawing.Size(583, 24);
            this.tierCb.TabIndex = 21;
            // 
            // packageNameTb
            // 
            this.packageNameTb.Location = new System.Drawing.Point(189, 176);
            this.packageNameTb.Name = "packageNameTb";
            this.packageNameTb.Size = new System.Drawing.Size(583, 22);
            this.packageNameTb.TabIndex = 22;
            // 
            // valueTb
            // 
            this.valueTb.Location = new System.Drawing.Point(189, 213);
            this.valueTb.Name = "valueTb";
            this.valueTb.Size = new System.Drawing.Size(583, 22);
            this.valueTb.TabIndex = 23;
            // 
            // availQntyTb
            // 
            this.availQntyTb.Location = new System.Drawing.Point(189, 254);
            this.availQntyTb.Name = "availQntyTb";
            this.availQntyTb.Size = new System.Drawing.Size(583, 22);
            this.availQntyTb.TabIndex = 24;
            // 
            // clearFormBtn
            // 
            this.clearFormBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearFormBtn.Location = new System.Drawing.Point(220, 425);
            this.clearFormBtn.Name = "clearFormBtn";
            this.clearFormBtn.Size = new System.Drawing.Size(160, 51);
            this.clearFormBtn.TabIndex = 28;
            this.clearFormBtn.Text = "Clear Form";
            this.clearFormBtn.UseVisualStyleBackColor = true;
            this.clearFormBtn.Click += new System.EventHandler(this.clearFormBtn_Click);
            // 
            // addPackageBtn
            // 
            this.addPackageBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPackageBtn.Location = new System.Drawing.Point(436, 425);
            this.addPackageBtn.Name = "addPackageBtn";
            this.addPackageBtn.Size = new System.Drawing.Size(160, 51);
            this.addPackageBtn.TabIndex = 29;
            this.addPackageBtn.Text = "Add Package";
            this.addPackageBtn.UseVisualStyleBackColor = true;
            this.addPackageBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // uploadBtn
            // 
            this.uploadBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadBtn.Location = new System.Drawing.Point(606, 509);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(160, 51);
            this.uploadBtn.TabIndex = 30;
            this.uploadBtn.Text = "Upload File";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // benefitsCheckList
            // 
            this.benefitsCheckList.FormattingEnabled = true;
            this.benefitsCheckList.HorizontalScrollbar = true;
            this.benefitsCheckList.Location = new System.Drawing.Point(189, 295);
            this.benefitsCheckList.Name = "benefitsCheckList";
            this.benefitsCheckList.Size = new System.Drawing.Size(583, 89);
            this.benefitsCheckList.TabIndex = 31;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(-4, 591);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(808, 62);
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Red;
            this.label9.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(503, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(281, 34);
            this.label9.TabIndex = 33;
            this.label9.Text = "ASEAN Skills 2020";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(24, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 51);
            this.button2.TabIndex = 32;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(-4, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(808, 83);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // AddPackagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 647);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.benefitsCheckList);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.addPackageBtn);
            this.Controls.Add(this.clearFormBtn);
            this.Controls.Add(this.availQntyTb);
            this.Controls.Add(this.valueTb);
            this.Controls.Add(this.packageNameTb);
            this.Controls.Add(this.tierCb);
            this.Controls.Add(this.filePathTb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Name = "AddPackagesForm";
            this.Text = "AddPackagesForm";
            this.Load += new System.EventHandler(this.AddPackagesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox filePathTb;
        private System.Windows.Forms.ComboBox tierCb;
        private System.Windows.Forms.TextBox packageNameTb;
        private System.Windows.Forms.TextBox valueTb;
        private System.Windows.Forms.TextBox availQntyTb;
        private System.Windows.Forms.Button clearFormBtn;
        private System.Windows.Forms.Button addPackageBtn;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.CheckedListBox benefitsCheckList;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}