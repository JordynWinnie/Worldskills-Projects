namespace TP_QR_Paper2_5_29_2020
{
    partial class BookPackages
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tierComboBox = new System.Windows.Forms.ComboBox();
            this.onlineCheckBox = new System.Windows.Forms.CheckBox();
            this.flyerCheckBox = new System.Windows.Forms.CheckBox();
            this.bannerCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.packageDGV = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.quantityTb = new System.Windows.Forms.TextBox();
            this.bookBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packageDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(531, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 20;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(2, 514);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1085, 53);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(2, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1085, 92);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Book Sponsorship Packages:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Filter by Tier:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Filter by Budget:";
            // 
            // tierComboBox
            // 
            this.tierComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tierComboBox.FormattingEnabled = true;
            this.tierComboBox.Location = new System.Drawing.Point(149, 165);
            this.tierComboBox.Name = "tierComboBox";
            this.tierComboBox.Size = new System.Drawing.Size(545, 24);
            this.tierComboBox.TabIndex = 25;
            this.tierComboBox.SelectedIndexChanged += new System.EventHandler(this.tierComboBox_SelectedIndexChanged);
            // 
            // onlineCheckBox
            // 
            this.onlineCheckBox.AutoSize = true;
            this.onlineCheckBox.Location = new System.Drawing.Point(149, 255);
            this.onlineCheckBox.Name = "onlineCheckBox";
            this.onlineCheckBox.Size = new System.Drawing.Size(71, 21);
            this.onlineCheckBox.TabIndex = 27;
            this.onlineCheckBox.Text = "Online";
            this.onlineCheckBox.UseVisualStyleBackColor = true;
            this.onlineCheckBox.CheckedChanged += new System.EventHandler(this.onlineCheckBox_CheckedChanged);
            // 
            // flyerCheckBox
            // 
            this.flyerCheckBox.AutoSize = true;
            this.flyerCheckBox.Location = new System.Drawing.Point(272, 255);
            this.flyerCheckBox.Name = "flyerCheckBox";
            this.flyerCheckBox.Size = new System.Drawing.Size(68, 21);
            this.flyerCheckBox.TabIndex = 28;
            this.flyerCheckBox.Text = "Flyers";
            this.flyerCheckBox.UseVisualStyleBackColor = true;
            this.flyerCheckBox.CheckedChanged += new System.EventHandler(this.flyerCheckBox_CheckedChanged);
            // 
            // bannerCheckBox
            // 
            this.bannerCheckBox.AutoSize = true;
            this.bannerCheckBox.Location = new System.Drawing.Point(392, 255);
            this.bannerCheckBox.Name = "bannerCheckBox";
            this.bannerCheckBox.Size = new System.Drawing.Size(76, 21);
            this.bannerCheckBox.TabIndex = 29;
            this.bannerCheckBox.Text = "Banner";
            this.bannerCheckBox.UseVisualStyleBackColor = true;
            this.bannerCheckBox.CheckedChanged += new System.EventHandler(this.bannerCheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "Filter by Benefit:";
            // 
            // packageDGV
            // 
            this.packageDGV.AllowUserToAddRows = false;
            this.packageDGV.AllowUserToDeleteRows = false;
            this.packageDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.packageDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packageDGV.Location = new System.Drawing.Point(27, 295);
            this.packageDGV.Name = "packageDGV";
            this.packageDGV.RowHeadersWidth = 51;
            this.packageDGV.RowTemplate.Height = 24;
            this.packageDGV.Size = new System.Drawing.Size(1051, 150);
            this.packageDGV.TabIndex = 31;
            this.packageDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.packageDGV_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 475);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 32;
            this.label6.Text = "Desired Quantity:";
            // 
            // quantityTb
            // 
            this.quantityTb.Location = new System.Drawing.Point(152, 475);
            this.quantityTb.Name = "quantityTb";
            this.quantityTb.Size = new System.Drawing.Size(204, 22);
            this.quantityTb.TabIndex = 33;
            // 
            // bookBtn
            // 
            this.bookBtn.Location = new System.Drawing.Point(904, 474);
            this.bookBtn.Name = "bookBtn";
            this.bookBtn.Size = new System.Drawing.Size(174, 23);
            this.bookBtn.TabIndex = 34;
            this.bookBtn.Text = "Book";
            this.bookBtn.UseVisualStyleBackColor = true;
            this.bookBtn.Click += new System.EventHandler(this.bookBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 199);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(545, 22);
            this.textBox1.TabIndex = 35;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BookPackages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 569);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bookBtn);
            this.Controls.Add(this.quantityTb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.packageDGV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bannerCheckBox);
            this.Controls.Add(this.flyerCheckBox);
            this.Controls.Add(this.onlineCheckBox);
            this.Controls.Add(this.tierComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "BookPackages";
            this.Text = "BookPackages";
            this.Load += new System.EventHandler(this.BookPackages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packageDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox tierComboBox;
        private System.Windows.Forms.CheckBox onlineCheckBox;
        private System.Windows.Forms.CheckBox flyerCheckBox;
        private System.Windows.Forms.CheckBox bannerCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView packageDGV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox quantityTb;
        private System.Windows.Forms.Button bookBtn;
        private System.Windows.Forms.TextBox textBox1;
    }
}