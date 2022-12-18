namespace TPQR_Paper3_9_24_2020
{
    partial class HotelBookingForm
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
            this.backBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hotelNameLbl = new System.Windows.Forms.Label();
            this.noOfPaxLbl = new System.Windows.Forms.Label();
            this.competitors_Lbl = new System.Windows.Forms.Label();
            this.roomDGV = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.totalVal_Lbl = new System.Windows.Forms.Label();
            this.book_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.roomDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 25);
            this.label2.TabIndex = 51;
            this.label2.Text = "Hotel Booking";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(31, 38);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 50;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(289, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 29);
            this.label1.TabIndex = 49;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // hotelNameLbl
            // 
            this.hotelNameLbl.AutoSize = true;
            this.hotelNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotelNameLbl.Location = new System.Drawing.Point(47, 145);
            this.hotelNameLbl.Name = "hotelNameLbl";
            this.hotelNameLbl.Size = new System.Drawing.Size(130, 25);
            this.hotelNameLbl.TabIndex = 54;
            this.hotelNameLbl.Text = "Arrival Date:";
            // 
            // noOfPaxLbl
            // 
            this.noOfPaxLbl.AutoSize = true;
            this.noOfPaxLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noOfPaxLbl.Location = new System.Drawing.Point(47, 191);
            this.noOfPaxLbl.Name = "noOfPaxLbl";
            this.noOfPaxLbl.Size = new System.Drawing.Size(132, 25);
            this.noOfPaxLbl.TabIndex = 53;
            this.noOfPaxLbl.Text = "Arrival Time:";
            // 
            // competitors_Lbl
            // 
            this.competitors_Lbl.AutoSize = true;
            this.competitors_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.competitors_Lbl.Location = new System.Drawing.Point(172, 241);
            this.competitors_Lbl.Name = "competitors_Lbl";
            this.competitors_Lbl.Size = new System.Drawing.Size(116, 25);
            this.competitors_Lbl.TabIndex = 52;
            this.competitors_Lbl.Text = "No Of Pax:";
            // 
            // roomDGV
            // 
            this.roomDGV.AllowUserToAddRows = false;
            this.roomDGV.AllowUserToDeleteRows = false;
            this.roomDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.roomDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomDGV.Location = new System.Drawing.Point(12, 289);
            this.roomDGV.Name = "roomDGV";
            this.roomDGV.Size = new System.Drawing.Size(776, 150);
            this.roomDGV.TabIndex = 55;
            this.roomDGV.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.roomDGV_CellBeginEdit);
            this.roomDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomDGV_CellEndEdit);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 566);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(800, 39);
            this.pictureBox2.TabIndex = 48;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 90);
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // totalVal_Lbl
            // 
            this.totalVal_Lbl.AutoSize = true;
            this.totalVal_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalVal_Lbl.Location = new System.Drawing.Point(598, 464);
            this.totalVal_Lbl.Name = "totalVal_Lbl";
            this.totalVal_Lbl.Size = new System.Drawing.Size(146, 25);
            this.totalVal_Lbl.TabIndex = 56;
            this.totalVal_Lbl.Text = "Hotel Booking";
            // 
            // book_Btn
            // 
            this.book_Btn.Location = new System.Drawing.Point(665, 516);
            this.book_Btn.Name = "book_Btn";
            this.book_Btn.Size = new System.Drawing.Size(123, 34);
            this.book_Btn.TabIndex = 57;
            this.book_Btn.Text = "Book";
            this.book_Btn.UseVisualStyleBackColor = true;
            this.book_Btn.Click += new System.EventHandler(this.book_Btn_Click);
            // 
            // HotelBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 605);
            this.Controls.Add(this.book_Btn);
            this.Controls.Add(this.totalVal_Lbl);
            this.Controls.Add(this.roomDGV);
            this.Controls.Add(this.hotelNameLbl);
            this.Controls.Add(this.noOfPaxLbl);
            this.Controls.Add(this.competitors_Lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "HotelBookingForm";
            this.Text = "HotelBookingForm";
            this.Load += new System.EventHandler(this.HotelBookingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label hotelNameLbl;
        private System.Windows.Forms.Label noOfPaxLbl;
        private System.Windows.Forms.Label competitors_Lbl;
        private System.Windows.Forms.DataGridView roomDGV;
        private System.Windows.Forms.Label totalVal_Lbl;
        private System.Windows.Forms.Button book_Btn;
    }
}