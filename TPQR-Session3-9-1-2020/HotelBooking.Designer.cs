namespace TPQR_Session3_9_1_2020
{
    partial class HotelBooking
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
            this.seater19Lbl = new System.Windows.Forms.Label();
            this.hotelNameLbl = new System.Windows.Forms.Label();
            this.numberOfDeleLbl = new System.Windows.Forms.Label();
            this.numberOfCompLBl = new System.Windows.Forms.Label();
            this.roomDGV = new System.Windows.Forms.DataGridView();
            this.totalValueLbl = new System.Windows.Forms.Label();
            this.bookBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.roomDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(22, 19);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(116, 30);
            this.backBtn.TabIndex = 13;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(322, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Hotel Booking";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(521, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // seater19Lbl
            // 
            this.seater19Lbl.AutoSize = true;
            this.seater19Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seater19Lbl.Location = new System.Drawing.Point(62, 166);
            this.seater19Lbl.Name = "seater19Lbl";
            this.seater19Lbl.Size = new System.Drawing.Size(108, 25);
            this.seater19Lbl.TabIndex = 31;
            this.seater19Lbl.Text = "No Of Pax:";
            // 
            // hotelNameLbl
            // 
            this.hotelNameLbl.AutoSize = true;
            this.hotelNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotelNameLbl.Location = new System.Drawing.Point(62, 130);
            this.hotelNameLbl.Name = "hotelNameLbl";
            this.hotelNameLbl.Size = new System.Drawing.Size(246, 25);
            this.hotelNameLbl.TabIndex = 30;
            this.hotelNameLbl.Text = "Hotel Name: <HotelName>";
            // 
            // numberOfDeleLbl
            // 
            this.numberOfDeleLbl.AutoSize = true;
            this.numberOfDeleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfDeleLbl.Location = new System.Drawing.Point(176, 166);
            this.numberOfDeleLbl.Name = "numberOfDeleLbl";
            this.numberOfDeleLbl.Size = new System.Drawing.Size(198, 25);
            this.numberOfDeleLbl.TabIndex = 33;
            this.numberOfDeleLbl.Text = "<Number> Delegates";
            // 
            // numberOfCompLBl
            // 
            this.numberOfCompLBl.AutoSize = true;
            this.numberOfCompLBl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfCompLBl.Location = new System.Drawing.Point(176, 212);
            this.numberOfCompLBl.Name = "numberOfCompLBl";
            this.numberOfCompLBl.Size = new System.Drawing.Size(215, 25);
            this.numberOfCompLBl.TabIndex = 34;
            this.numberOfCompLBl.Text = "<Number> Competitors";
            // 
            // roomDGV
            // 
            this.roomDGV.AllowUserToAddRows = false;
            this.roomDGV.AllowUserToDeleteRows = false;
            this.roomDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.roomDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.roomDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomDGV.Location = new System.Drawing.Point(12, 257);
            this.roomDGV.Name = "roomDGV";
            this.roomDGV.RowHeadersWidth = 51;
            this.roomDGV.RowTemplate.Height = 24;
            this.roomDGV.Size = new System.Drawing.Size(776, 163);
            this.roomDGV.TabIndex = 35;
            this.roomDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomDGV_CellEndEdit);
            // 
            // totalValueLbl
            // 
            this.totalValueLbl.AutoSize = true;
            this.totalValueLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalValueLbl.Location = new System.Drawing.Point(533, 476);
            this.totalValueLbl.Name = "totalValueLbl";
            this.totalValueLbl.Size = new System.Drawing.Size(186, 25);
            this.totalValueLbl.TabIndex = 36;
            this.totalValueLbl.Text = "Total: <TotalValue>";
            // 
            // bookBtn
            // 
            this.bookBtn.Location = new System.Drawing.Point(527, 525);
            this.bookBtn.Name = "bookBtn";
            this.bookBtn.Size = new System.Drawing.Size(251, 35);
            this.bookBtn.TabIndex = 37;
            this.bookBtn.Text = "Book";
            this.bookBtn.UseVisualStyleBackColor = true;
            this.bookBtn.Click += new System.EventHandler(this.bookBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(2, 585);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(797, 78);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(2, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(797, 71);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // HotelBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 666);
            this.Controls.Add(this.bookBtn);
            this.Controls.Add(this.totalValueLbl);
            this.Controls.Add(this.roomDGV);
            this.Controls.Add(this.numberOfCompLBl);
            this.Controls.Add(this.numberOfDeleLbl);
            this.Controls.Add(this.seater19Lbl);
            this.Controls.Add(this.hotelNameLbl);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "HotelBooking";
            this.Text = "HotelBooking";
            this.Load += new System.EventHandler(this.HotelBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label seater19Lbl;
        private System.Windows.Forms.Label hotelNameLbl;
        private System.Windows.Forms.Label numberOfDeleLbl;
        private System.Windows.Forms.Label numberOfCompLBl;
        private System.Windows.Forms.DataGridView roomDGV;
        private System.Windows.Forms.Label totalValueLbl;
        private System.Windows.Forms.Button bookBtn;
    }
}