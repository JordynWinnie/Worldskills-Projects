namespace TPQR_Session2_9_7_2020
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
            this.addPackage = new System.Windows.Forms.Button();
            this.valueNUD = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.tierCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.packageNameTb = new System.Windows.Forms.TextBox();
            this.qtyNUD = new System.Windows.Forms.NumericUpDown();
            this.dsa = new System.Windows.Forms.Label();
            this.bannerCheck = new System.Windows.Forms.CheckBox();
            this.flyerCheck = new System.Windows.Forms.CheckBox();
            this.onlineCheck = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.clearForm = new System.Windows.Forms.Button();
            this.filePathTb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.valueNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtyNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // addPackage
            // 
            this.addPackage.Location = new System.Drawing.Point(414, 396);
            this.addPackage.Name = "addPackage";
            this.addPackage.Size = new System.Drawing.Size(252, 38);
            this.addPackage.TabIndex = 58;
            this.addPackage.Text = "Add Package";
            this.addPackage.UseVisualStyleBackColor = true;
            this.addPackage.Click += new System.EventHandler(this.addPackage_Click);
            // 
            // valueNUD
            // 
            this.valueNUD.Location = new System.Drawing.Point(196, 238);
            this.valueNUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.valueNUD.Name = "valueNUD";
            this.valueNUD.Size = new System.Drawing.Size(238, 22);
            this.valueNUD.TabIndex = 57;
            this.valueNUD.ValueChanged += new System.EventHandler(this.desiredQtyNUD_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 25);
            this.label6.TabIndex = 56;
            this.label6.Text = "Value:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // tierCb
            // 
            this.tierCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tierCb.FormattingEnabled = true;
            this.tierCb.Location = new System.Drawing.Point(196, 133);
            this.tierCb.Name = "tierCb";
            this.tierCb.Size = new System.Drawing.Size(550, 24);
            this.tierCb.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 25);
            this.label3.TabIndex = 54;
            this.label3.Text = "Tier:";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(10, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(145, 38);
            this.backBtn.TabIndex = 53;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 29);
            this.label2.TabIndex = 52;
            this.label2.Text = "Add Packages";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(529, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 51;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(0, 537);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(796, 77);
            this.pictureBox2.TabIndex = 50;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(796, 62);
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 25);
            this.label4.TabIndex = 59;
            this.label4.Text = "Package Name:";
            // 
            // packageNameTb
            // 
            this.packageNameTb.Location = new System.Drawing.Point(196, 187);
            this.packageNameTb.Name = "packageNameTb";
            this.packageNameTb.Size = new System.Drawing.Size(550, 22);
            this.packageNameTb.TabIndex = 60;
            // 
            // qtyNUD
            // 
            this.qtyNUD.Location = new System.Drawing.Point(196, 284);
            this.qtyNUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.qtyNUD.Name = "qtyNUD";
            this.qtyNUD.Size = new System.Drawing.Size(238, 22);
            this.qtyNUD.TabIndex = 62;
            // 
            // dsa
            // 
            this.dsa.AutoSize = true;
            this.dsa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dsa.Location = new System.Drawing.Point(27, 284);
            this.dsa.Name = "dsa";
            this.dsa.Size = new System.Drawing.Size(91, 25);
            this.dsa.TabIndex = 61;
            this.dsa.Text = "Quantity:";
            // 
            // bannerCheck
            // 
            this.bannerCheck.AutoSize = true;
            this.bannerCheck.Location = new System.Drawing.Point(492, 328);
            this.bannerCheck.Name = "bannerCheck";
            this.bannerCheck.Size = new System.Drawing.Size(76, 21);
            this.bannerCheck.TabIndex = 66;
            this.bannerCheck.Text = "Banner";
            this.bannerCheck.UseVisualStyleBackColor = true;
            this.bannerCheck.CheckedChanged += new System.EventHandler(this.bannerCheck_CheckedChanged);
            // 
            // flyerCheck
            // 
            this.flyerCheck.AutoSize = true;
            this.flyerCheck.Location = new System.Drawing.Point(354, 328);
            this.flyerCheck.Name = "flyerCheck";
            this.flyerCheck.Size = new System.Drawing.Size(68, 21);
            this.flyerCheck.TabIndex = 65;
            this.flyerCheck.Text = "Flyers";
            this.flyerCheck.UseVisualStyleBackColor = true;
            this.flyerCheck.CheckedChanged += new System.EventHandler(this.flyerCheck_CheckedChanged);
            // 
            // onlineCheck
            // 
            this.onlineCheck.AutoSize = true;
            this.onlineCheck.Location = new System.Drawing.Point(196, 325);
            this.onlineCheck.Name = "onlineCheck";
            this.onlineCheck.Size = new System.Drawing.Size(71, 21);
            this.onlineCheck.TabIndex = 64;
            this.onlineCheck.Text = "Online";
            this.onlineCheck.UseVisualStyleBackColor = true;
            this.onlineCheck.CheckedChanged += new System.EventHandler(this.onlineCheck_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 25);
            this.label5.TabIndex = 63;
            this.label5.Text = "Filter By Benefit:";
            // 
            // clearForm
            // 
            this.clearForm.Location = new System.Drawing.Point(122, 396);
            this.clearForm.Name = "clearForm";
            this.clearForm.Size = new System.Drawing.Size(217, 38);
            this.clearForm.TabIndex = 67;
            this.clearForm.Text = "Clear Form";
            this.clearForm.UseVisualStyleBackColor = true;
            this.clearForm.Click += new System.EventHandler(this.clearForm_Click);
            // 
            // filePathTb
            // 
            this.filePathTb.Location = new System.Drawing.Point(137, 487);
            this.filePathTb.Name = "filePathTb";
            this.filePathTb.Size = new System.Drawing.Size(476, 22);
            this.filePathTb.TabIndex = 69;
            this.filePathTb.Click += new System.EventHandler(this.filePathTb_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 483);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 25);
            this.label7.TabIndex = 68;
            this.label7.Text = "File Path:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(637, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 38);
            this.button1.TabIndex = 70;
            this.button1.Text = "Upload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddPackagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 613);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filePathTb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.clearForm);
            this.Controls.Add(this.bannerCheck);
            this.Controls.Add(this.flyerCheck);
            this.Controls.Add(this.onlineCheck);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.qtyNUD);
            this.Controls.Add(this.dsa);
            this.Controls.Add(this.packageNameTb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addPackage);
            this.Controls.Add(this.valueNUD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tierCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AddPackagesForm";
            this.Text = "AddPackagesForm";
            this.Load += new System.EventHandler(this.AddPackagesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.valueNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtyNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addPackage;
        private System.Windows.Forms.NumericUpDown valueNUD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox tierCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox packageNameTb;
        private System.Windows.Forms.NumericUpDown qtyNUD;
        private System.Windows.Forms.Label dsa;
        private System.Windows.Forms.CheckBox bannerCheck;
        private System.Windows.Forms.CheckBox flyerCheck;
        private System.Windows.Forms.CheckBox onlineCheck;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button clearForm;
        private System.Windows.Forms.TextBox filePathTb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}