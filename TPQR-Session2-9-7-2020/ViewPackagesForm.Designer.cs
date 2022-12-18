namespace TPQR_Session2_9_7_2020
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
            this.packagesDGV = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.noneRadio = new System.Windows.Forms.RadioButton();
            this.tierRadio = new System.Windows.Forms.RadioButton();
            this.nameRadio = new System.Windows.Forms.RadioButton();
            this.valueRadio = new System.Windows.Forms.RadioButton();
            this.qtyRadio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.packagesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // packagesDGV
            // 
            this.packagesDGV.AllowUserToAddRows = false;
            this.packagesDGV.AllowUserToDeleteRows = false;
            this.packagesDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.packagesDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.packagesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packagesDGV.Location = new System.Drawing.Point(12, 240);
            this.packagesDGV.Name = "packagesDGV";
            this.packagesDGV.RowHeadersWidth = 51;
            this.packagesDGV.RowTemplate.Height = 24;
            this.packagesDGV.Size = new System.Drawing.Size(776, 263);
            this.packagesDGV.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 25);
            this.label5.TabIndex = 51;
            this.label5.Text = "Sort By:";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 7);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(145, 38);
            this.backBtn.TabIndex = 50;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(221, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 29);
            this.label2.TabIndex = 49;
            this.label2.Text = "View Sponsorship Packages";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(531, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 48;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(2, 532);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(796, 77);
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(2, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(796, 62);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.qtyRadio);
            this.groupBox1.Controls.Add(this.valueRadio);
            this.groupBox1.Controls.Add(this.nameRadio);
            this.groupBox1.Controls.Add(this.tierRadio);
            this.groupBox1.Controls.Add(this.noneRadio);
            this.groupBox1.Location = new System.Drawing.Point(131, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 69);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            // 
            // noneRadio
            // 
            this.noneRadio.AutoSize = true;
            this.noneRadio.Checked = true;
            this.noneRadio.Location = new System.Drawing.Point(23, 32);
            this.noneRadio.Name = "noneRadio";
            this.noneRadio.Size = new System.Drawing.Size(63, 21);
            this.noneRadio.TabIndex = 0;
            this.noneRadio.TabStop = true;
            this.noneRadio.Text = "None";
            this.noneRadio.UseVisualStyleBackColor = true;
            this.noneRadio.CheckedChanged += new System.EventHandler(this.noneRadio_CheckedChanged);
            // 
            // tierRadio
            // 
            this.tierRadio.AutoSize = true;
            this.tierRadio.Location = new System.Drawing.Point(154, 32);
            this.tierRadio.Name = "tierRadio";
            this.tierRadio.Size = new System.Drawing.Size(54, 21);
            this.tierRadio.TabIndex = 1;
            this.tierRadio.Text = "Tier";
            this.tierRadio.UseVisualStyleBackColor = true;
            this.tierRadio.CheckedChanged += new System.EventHandler(this.tierRadio_CheckedChanged);
            // 
            // nameRadio
            // 
            this.nameRadio.AutoSize = true;
            this.nameRadio.Location = new System.Drawing.Point(281, 32);
            this.nameRadio.Name = "nameRadio";
            this.nameRadio.Size = new System.Drawing.Size(66, 21);
            this.nameRadio.TabIndex = 2;
            this.nameRadio.Text = "Name";
            this.nameRadio.UseVisualStyleBackColor = true;
            this.nameRadio.CheckedChanged += new System.EventHandler(this.nameRadio_CheckedChanged);
            // 
            // valueRadio
            // 
            this.valueRadio.AutoSize = true;
            this.valueRadio.Location = new System.Drawing.Point(385, 33);
            this.valueRadio.Name = "valueRadio";
            this.valueRadio.Size = new System.Drawing.Size(102, 21);
            this.valueRadio.TabIndex = 3;
            this.valueRadio.Text = "Value (Asc)";
            this.valueRadio.UseVisualStyleBackColor = true;
            this.valueRadio.CheckedChanged += new System.EventHandler(this.valueRadio_CheckedChanged);
            // 
            // qtyRadio
            // 
            this.qtyRadio.AutoSize = true;
            this.qtyRadio.Location = new System.Drawing.Point(516, 33);
            this.qtyRadio.Name = "qtyRadio";
            this.qtyRadio.Size = new System.Drawing.Size(121, 21);
            this.qtyRadio.TabIndex = 4;
            this.qtyRadio.Text = "Quantity (Dec)";
            this.qtyRadio.UseVisualStyleBackColor = true;
            this.qtyRadio.CheckedChanged += new System.EventHandler(this.qtyRadio_CheckedChanged);
            // 
            // ViewPackagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 608);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.packagesDGV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ViewPackagesForm";
            this.Text = "ViewPackagesForm";
            this.Load += new System.EventHandler(this.ViewPackagesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.packagesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView packagesDGV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton qtyRadio;
        private System.Windows.Forms.RadioButton valueRadio;
        private System.Windows.Forms.RadioButton nameRadio;
        private System.Windows.Forms.RadioButton tierRadio;
        private System.Windows.Forms.RadioButton noneRadio;
    }
}