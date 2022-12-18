namespace TPQR_Session3_9_8_2020
{
    partial class HotelSummaryForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hotelNameLbl = new System.Windows.Forms.Label();
            this.hotelCb = new System.Windows.Forms.ComboBox();
            this.hotelDGV = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(308, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 29);
            this.label4.TabIndex = 36;
            this.label4.Text = "Hotel Summary";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(151, 29);
            this.backBtn.TabIndex = 35;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(531, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 34;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // hotelNameLbl
            // 
            this.hotelNameLbl.AutoSize = true;
            this.hotelNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotelNameLbl.Location = new System.Drawing.Point(32, 118);
            this.hotelNameLbl.Name = "hotelNameLbl";
            this.hotelNameLbl.Size = new System.Drawing.Size(147, 29);
            this.hotelNameLbl.TabIndex = 37;
            this.hotelNameLbl.Text = "Hotel Name:";
            // 
            // hotelCb
            // 
            this.hotelCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hotelCb.FormattingEnabled = true;
            this.hotelCb.Location = new System.Drawing.Point(185, 118);
            this.hotelCb.Name = "hotelCb";
            this.hotelCb.Size = new System.Drawing.Size(603, 24);
            this.hotelCb.TabIndex = 38;
            this.hotelCb.SelectedIndexChanged += new System.EventHandler(this.hotelCb_SelectedIndexChanged);
            // 
            // hotelDGV
            // 
            this.hotelDGV.AllowUserToAddRows = false;
            this.hotelDGV.AllowUserToDeleteRows = false;
            this.hotelDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.hotelDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hotelDGV.Location = new System.Drawing.Point(37, 171);
            this.hotelDGV.Name = "hotelDGV";
            this.hotelDGV.RowHeadersWidth = 51;
            this.hotelDGV.RowTemplate.Height = 24;
            this.hotelDGV.Size = new System.Drawing.Size(751, 150);
            this.hotelDGV.TabIndex = 39;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(1, 367);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(798, 85);
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(1, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(798, 60);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // HotelSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hotelDGV);
            this.Controls.Add(this.hotelCb);
            this.Controls.Add(this.hotelNameLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "HotelSummaryForm";
            this.Text = "HotelSummaryForm";
            this.Load += new System.EventHandler(this.HotelSummaryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hotelDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label hotelNameLbl;
        private System.Windows.Forms.ComboBox hotelCb;
        private System.Windows.Forms.DataGridView hotelDGV;
    }
}