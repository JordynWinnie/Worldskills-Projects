namespace Session2_JordanKhong.Forms
{
    partial class BookPackageForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.packagesDGV = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.BookBtn = new System.Windows.Forms.Button();
            this.tierCb = new System.Windows.Forms.ComboBox();
            this.budgetTb = new System.Windows.Forms.TextBox();
            this.quantityTb = new System.Windows.Forms.TextBox();
            this.onlineCheckBox = new System.Windows.Forms.CheckBox();
            this.flyersCheckBox = new System.Windows.Forms.CheckBox();
            this.bannerCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.packagesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(177, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(410, 34);
            this.label2.TabIndex = 14;
            this.label2.Text = "Book Sponsorship Packages";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Filter by Tier:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Filter by budget:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Filter by Benefit:";
            // 
            // packagesDGV
            // 
            this.packagesDGV.AllowUserToAddRows = false;
            this.packagesDGV.AllowUserToDeleteRows = false;
            this.packagesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packagesDGV.Location = new System.Drawing.Point(34, 275);
            this.packagesDGV.MultiSelect = false;
            this.packagesDGV.Name = "packagesDGV";
            this.packagesDGV.RowHeadersWidth = 51;
            this.packagesDGV.RowTemplate.Height = 24;
            this.packagesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.packagesDGV.Size = new System.Drawing.Size(738, 209);
            this.packagesDGV.TabIndex = 18;
            this.packagesDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.packagesDGV_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 522);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Desired Quantity:";
            // 
            // BookBtn
            // 
            this.BookBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookBtn.Location = new System.Drawing.Point(612, 507);
            this.BookBtn.Name = "BookBtn";
            this.BookBtn.Size = new System.Drawing.Size(160, 51);
            this.BookBtn.TabIndex = 20;
            this.BookBtn.Text = "Book";
            this.BookBtn.UseVisualStyleBackColor = true;
            this.BookBtn.Click += new System.EventHandler(this.BookBtn_Click);
            // 
            // tierCb
            // 
            this.tierCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tierCb.FormattingEnabled = true;
            this.tierCb.Location = new System.Drawing.Point(196, 139);
            this.tierCb.Name = "tierCb";
            this.tierCb.Size = new System.Drawing.Size(508, 24);
            this.tierCb.TabIndex = 21;
            this.tierCb.SelectedIndexChanged += new System.EventHandler(this.tierCb_SelectedIndexChanged);
            // 
            // budgetTb
            // 
            this.budgetTb.Location = new System.Drawing.Point(196, 186);
            this.budgetTb.Name = "budgetTb";
            this.budgetTb.Size = new System.Drawing.Size(508, 22);
            this.budgetTb.TabIndex = 22;
            this.budgetTb.TextChanged += new System.EventHandler(this.budgetTb_TextChanged);
            // 
            // quantityTb
            // 
            this.quantityTb.Location = new System.Drawing.Point(198, 523);
            this.quantityTb.Name = "quantityTb";
            this.quantityTb.Size = new System.Drawing.Size(206, 22);
            this.quantityTb.TabIndex = 23;
            // 
            // onlineCheckBox
            // 
            this.onlineCheckBox.AutoSize = true;
            this.onlineCheckBox.Location = new System.Drawing.Point(198, 233);
            this.onlineCheckBox.Name = "onlineCheckBox";
            this.onlineCheckBox.Size = new System.Drawing.Size(71, 21);
            this.onlineCheckBox.TabIndex = 24;
            this.onlineCheckBox.Text = "Online";
            this.onlineCheckBox.UseVisualStyleBackColor = true;
            this.onlineCheckBox.CheckedChanged += new System.EventHandler(this.onlineCheckBox_CheckedChanged);
            // 
            // flyersCheckBox
            // 
            this.flyersCheckBox.AutoSize = true;
            this.flyersCheckBox.Location = new System.Drawing.Point(336, 236);
            this.flyersCheckBox.Name = "flyersCheckBox";
            this.flyersCheckBox.Size = new System.Drawing.Size(68, 21);
            this.flyersCheckBox.TabIndex = 25;
            this.flyersCheckBox.Text = "Flyers";
            this.flyersCheckBox.UseVisualStyleBackColor = true;
            this.flyersCheckBox.CheckedChanged += new System.EventHandler(this.flyersCheckBox_CheckedChanged);
            // 
            // bannerCheckBox
            // 
            this.bannerCheckBox.AutoSize = true;
            this.bannerCheckBox.Location = new System.Drawing.Point(497, 236);
            this.bannerCheckBox.Name = "bannerCheckBox";
            this.bannerCheckBox.Size = new System.Drawing.Size(76, 21);
            this.bannerCheckBox.TabIndex = 26;
            this.bannerCheckBox.Text = "Banner";
            this.bannerCheckBox.UseVisualStyleBackColor = true;
            this.bannerCheckBox.CheckedChanged += new System.EventHandler(this.bannerCheckBox_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(-4, 589);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(808, 62);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(507, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 34);
            this.label1.TabIndex = 28;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(25, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 51);
            this.button1.TabIndex = 27;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(-4, -9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(808, 83);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // BookPackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 651);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bannerCheckBox);
            this.Controls.Add(this.flyersCheckBox);
            this.Controls.Add(this.onlineCheckBox);
            this.Controls.Add(this.quantityTb);
            this.Controls.Add(this.budgetTb);
            this.Controls.Add(this.tierCb);
            this.Controls.Add(this.BookBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.packagesDGV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "BookPackageForm";
            this.Text = " ";
            this.Load += new System.EventHandler(this.BookPackageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.packagesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView packagesDGV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BookBtn;
        private System.Windows.Forms.ComboBox tierCb;
        private System.Windows.Forms.TextBox budgetTb;
        private System.Windows.Forms.TextBox quantityTb;
        private System.Windows.Forms.CheckBox onlineCheckBox;
        private System.Windows.Forms.CheckBox flyersCheckBox;
        private System.Windows.Forms.CheckBox bannerCheckBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}