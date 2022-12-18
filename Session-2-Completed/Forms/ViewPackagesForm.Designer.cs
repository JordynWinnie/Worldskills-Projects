namespace Session2_JordanKhong.Forms
{
    partial class ViewPackagesForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.defaultRadio = new System.Windows.Forms.RadioButton();
            this.qtyRadio = new System.Windows.Forms.RadioButton();
            this.valueRadio = new System.Windows.Forms.RadioButton();
            this.nameRadio = new System.Windows.Forms.RadioButton();
            this.tierRadio = new System.Windows.Forms.RadioButton();
            this.packagesDGV = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packagesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(219, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(349, 34);
            this.label6.TabIndex = 10;
            this.label6.Text = "View Sponsor Packages";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 34);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sort By:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.defaultRadio);
            this.groupBox1.Controls.Add(this.qtyRadio);
            this.groupBox1.Controls.Add(this.valueRadio);
            this.groupBox1.Controls.Add(this.nameRadio);
            this.groupBox1.Controls.Add(this.tierRadio);
            this.groupBox1.Location = new System.Drawing.Point(174, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 63);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // defaultRadio
            // 
            this.defaultRadio.AutoSize = true;
            this.defaultRadio.Checked = true;
            this.defaultRadio.Location = new System.Drawing.Point(22, 21);
            this.defaultRadio.Name = "defaultRadio";
            this.defaultRadio.Size = new System.Drawing.Size(74, 21);
            this.defaultRadio.TabIndex = 4;
            this.defaultRadio.TabStop = true;
            this.defaultRadio.Text = "Default";
            this.defaultRadio.UseVisualStyleBackColor = true;
            this.defaultRadio.CheckedChanged += new System.EventHandler(this.defaultRadio_CheckedChanged);
            // 
            // qtyRadio
            // 
            this.qtyRadio.AutoSize = true;
            this.qtyRadio.Location = new System.Drawing.Point(431, 21);
            this.qtyRadio.Name = "qtyRadio";
            this.qtyRadio.Size = new System.Drawing.Size(128, 21);
            this.qtyRadio.TabIndex = 3;
            this.qtyRadio.Text = "Quantity (Desc)";
            this.qtyRadio.UseVisualStyleBackColor = true;
            this.qtyRadio.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // valueRadio
            // 
            this.valueRadio.AutoSize = true;
            this.valueRadio.Location = new System.Drawing.Point(272, 21);
            this.valueRadio.Name = "valueRadio";
            this.valueRadio.Size = new System.Drawing.Size(106, 21);
            this.valueRadio.TabIndex = 2;
            this.valueRadio.Text = "Value (ASC)";
            this.valueRadio.UseVisualStyleBackColor = true;
            this.valueRadio.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // nameRadio
            // 
            this.nameRadio.AutoSize = true;
            this.nameRadio.Location = new System.Drawing.Point(187, 21);
            this.nameRadio.Name = "nameRadio";
            this.nameRadio.Size = new System.Drawing.Size(66, 21);
            this.nameRadio.TabIndex = 1;
            this.nameRadio.Text = "Name";
            this.nameRadio.UseVisualStyleBackColor = true;
            this.nameRadio.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // tierRadio
            // 
            this.tierRadio.AutoSize = true;
            this.tierRadio.Location = new System.Drawing.Point(103, 21);
            this.tierRadio.Name = "tierRadio";
            this.tierRadio.Size = new System.Drawing.Size(54, 21);
            this.tierRadio.TabIndex = 0;
            this.tierRadio.Text = "Tier";
            this.tierRadio.UseVisualStyleBackColor = true;
            this.tierRadio.CheckedChanged += new System.EventHandler(this.tierRadio_CheckedChanged);
            // 
            // packagesDGV
            // 
            this.packagesDGV.AllowUserToAddRows = false;
            this.packagesDGV.AllowUserToDeleteRows = false;
            this.packagesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packagesDGV.Location = new System.Drawing.Point(18, 235);
            this.packagesDGV.Name = "packagesDGV";
            this.packagesDGV.RowHeadersWidth = 51;
            this.packagesDGV.RowTemplate.Height = 24;
            this.packagesDGV.Size = new System.Drawing.Size(770, 277);
            this.packagesDGV.TabIndex = 13;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(-6, 537);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(808, 62);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(501, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 34);
            this.label1.TabIndex = 16;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(22, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 51);
            this.button1.TabIndex = 15;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(-6, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(808, 83);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // ViewPackagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 601);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.packagesDGV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Name = "ViewPackagesForm";
            this.Text = "ViewPackagesForm";
            this.Load += new System.EventHandler(this.ViewPackagesForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packagesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton qtyRadio;
        private System.Windows.Forms.RadioButton valueRadio;
        private System.Windows.Forms.RadioButton nameRadio;
        private System.Windows.Forms.RadioButton tierRadio;
        private System.Windows.Forms.DataGridView packagesDGV;
        private System.Windows.Forms.RadioButton defaultRadio;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}