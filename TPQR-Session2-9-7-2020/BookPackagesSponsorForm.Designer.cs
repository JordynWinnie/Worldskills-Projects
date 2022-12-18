namespace TPQR_Session2_9_7_2020
{
    partial class BookPackagesSponsorForm
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
            this.backBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tierCb = new System.Windows.Forms.ComboBox();
            this.budgetNUD = new System.Windows.Forms.NumericUpDown();
            this.onlineCheck = new System.Windows.Forms.CheckBox();
            this.flyerCheck = new System.Windows.Forms.CheckBox();
            this.bannerCheck = new System.Windows.Forms.CheckBox();
            this.packagesDGV = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.desiredQtyNUD = new System.Windows.Forms.NumericUpDown();
            this.bookBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.budgetNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packagesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.desiredQtyNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(145, 38);
            this.backBtn.TabIndex = 36;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(221, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 29);
            this.label2.TabIndex = 35;
            this.label2.Text = "Book Sponsorship Packages";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(531, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 34;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(2, 537);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(796, 77);
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(796, 62);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 25);
            this.label3.TabIndex = 37;
            this.label3.Text = "Filter By Tier:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 25);
            this.label4.TabIndex = 38;
            this.label4.Text = "Filter Budget:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 25);
            this.label5.TabIndex = 39;
            this.label5.Text = "Filter By Benefit:";
            // 
            // tierCb
            // 
            this.tierCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tierCb.FormattingEnabled = true;
            this.tierCb.Location = new System.Drawing.Point(199, 133);
            this.tierCb.Name = "tierCb";
            this.tierCb.Size = new System.Drawing.Size(549, 24);
            this.tierCb.TabIndex = 40;
            this.tierCb.SelectedIndexChanged += new System.EventHandler(this.tierCb_SelectedIndexChanged);
            // 
            // budgetNUD
            // 
            this.budgetNUD.Location = new System.Drawing.Point(199, 182);
            this.budgetNUD.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.budgetNUD.Name = "budgetNUD";
            this.budgetNUD.Size = new System.Drawing.Size(549, 22);
            this.budgetNUD.TabIndex = 41;
            this.budgetNUD.ValueChanged += new System.EventHandler(this.budgetNUD_ValueChanged);
            // 
            // onlineCheck
            // 
            this.onlineCheck.AutoSize = true;
            this.onlineCheck.Location = new System.Drawing.Point(199, 228);
            this.onlineCheck.Name = "onlineCheck";
            this.onlineCheck.Size = new System.Drawing.Size(71, 21);
            this.onlineCheck.TabIndex = 42;
            this.onlineCheck.Text = "Online";
            this.onlineCheck.UseVisualStyleBackColor = true;
            this.onlineCheck.CheckedChanged += new System.EventHandler(this.onlineCheck_CheckedChanged);
            // 
            // flyerCheck
            // 
            this.flyerCheck.AutoSize = true;
            this.flyerCheck.Location = new System.Drawing.Point(357, 231);
            this.flyerCheck.Name = "flyerCheck";
            this.flyerCheck.Size = new System.Drawing.Size(68, 21);
            this.flyerCheck.TabIndex = 43;
            this.flyerCheck.Text = "Flyers";
            this.flyerCheck.UseVisualStyleBackColor = true;
            this.flyerCheck.CheckedChanged += new System.EventHandler(this.flyerCheck_CheckedChanged);
            // 
            // bannerCheck
            // 
            this.bannerCheck.AutoSize = true;
            this.bannerCheck.Location = new System.Drawing.Point(495, 231);
            this.bannerCheck.Name = "bannerCheck";
            this.bannerCheck.Size = new System.Drawing.Size(76, 21);
            this.bannerCheck.TabIndex = 44;
            this.bannerCheck.Text = "Banner";
            this.bannerCheck.UseVisualStyleBackColor = true;
            this.bannerCheck.CheckedChanged += new System.EventHandler(this.bannerCheck_CheckedChanged);
            // 
            // packagesDGV
            // 
            this.packagesDGV.AllowUserToAddRows = false;
            this.packagesDGV.AllowUserToDeleteRows = false;
            this.packagesDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.packagesDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.packagesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packagesDGV.Location = new System.Drawing.Point(12, 269);
            this.packagesDGV.Name = "packagesDGV";
            this.packagesDGV.RowHeadersWidth = 51;
            this.packagesDGV.RowTemplate.Height = 24;
            this.packagesDGV.Size = new System.Drawing.Size(776, 188);
            this.packagesDGV.TabIndex = 45;
            this.packagesDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.packagesDGV_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 484);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 25);
            this.label6.TabIndex = 46;
            this.label6.Text = "Desired Quantity:";
            // 
            // desiredQtyNUD
            // 
            this.desiredQtyNUD.Location = new System.Drawing.Point(198, 484);
            this.desiredQtyNUD.Name = "desiredQtyNUD";
            this.desiredQtyNUD.Size = new System.Drawing.Size(238, 22);
            this.desiredQtyNUD.TabIndex = 47;
            // 
            // bookBtn
            // 
            this.bookBtn.Location = new System.Drawing.Point(617, 480);
            this.bookBtn.Name = "bookBtn";
            this.bookBtn.Size = new System.Drawing.Size(145, 38);
            this.bookBtn.TabIndex = 48;
            this.bookBtn.Text = "Book";
            this.bookBtn.UseVisualStyleBackColor = true;
            this.bookBtn.Click += new System.EventHandler(this.bookBtn_Click);
            // 
            // BookPackagesSponsorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 613);
            this.Controls.Add(this.bookBtn);
            this.Controls.Add(this.desiredQtyNUD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.packagesDGV);
            this.Controls.Add(this.bannerCheck);
            this.Controls.Add(this.flyerCheck);
            this.Controls.Add(this.onlineCheck);
            this.Controls.Add(this.budgetNUD);
            this.Controls.Add(this.tierCb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "BookPackagesSponsorForm";
            this.Text = "BookPackagesSponsorForm";
            this.Load += new System.EventHandler(this.BookPackagesSponsorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.budgetNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packagesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.desiredQtyNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox tierCb;
        private System.Windows.Forms.NumericUpDown budgetNUD;
        private System.Windows.Forms.CheckBox onlineCheck;
        private System.Windows.Forms.CheckBox flyerCheck;
        private System.Windows.Forms.CheckBox bannerCheck;
        private System.Windows.Forms.DataGridView packagesDGV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown desiredQtyNUD;
        private System.Windows.Forms.Button bookBtn;
    }
}