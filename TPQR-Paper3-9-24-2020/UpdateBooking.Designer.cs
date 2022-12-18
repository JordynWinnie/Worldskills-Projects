namespace TPQR_Paper3_9_24_2020
{
    partial class UpdateBooking
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
            this.update_Btn = new System.Windows.Forms.Button();
            this.totalVal_Lbl = new System.Windows.Forms.Label();
            this.roomDGV = new System.Windows.Forms.DataGridView();
            this.hotelNameLbl = new System.Windows.Forms.Label();
            this.noOfPaxLbl = new System.Windows.Forms.Label();
            this.competitors_Lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HOD_NUD = new System.Windows.Forms.NumericUpDown();
            this.delegate_NUD = new System.Windows.Forms.NumericUpDown();
            this.competitors_NUD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.roomDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOD_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delegate_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.competitors_NUD)).BeginInit();
            this.SuspendLayout();
            // 
            // update_Btn
            // 
            this.update_Btn.Location = new System.Drawing.Point(665, 516);
            this.update_Btn.Name = "update_Btn";
            this.update_Btn.Size = new System.Drawing.Size(123, 34);
            this.update_Btn.TabIndex = 68;
            this.update_Btn.Text = "Book";
            this.update_Btn.UseVisualStyleBackColor = true;
            this.update_Btn.Click += new System.EventHandler(this.update_Btn_Click);
            // 
            // totalVal_Lbl
            // 
            this.totalVal_Lbl.AutoSize = true;
            this.totalVal_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalVal_Lbl.Location = new System.Drawing.Point(599, 456);
            this.totalVal_Lbl.Name = "totalVal_Lbl";
            this.totalVal_Lbl.Size = new System.Drawing.Size(127, 25);
            this.totalVal_Lbl.TabIndex = 67;
            this.totalVal_Lbl.Text = "Total Value:";
            // 
            // roomDGV
            // 
            this.roomDGV.AllowUserToAddRows = false;
            this.roomDGV.AllowUserToDeleteRows = false;
            this.roomDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.roomDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomDGV.Location = new System.Drawing.Point(12, 276);
            this.roomDGV.Name = "roomDGV";
            this.roomDGV.Size = new System.Drawing.Size(776, 150);
            this.roomDGV.TabIndex = 66;
            this.roomDGV.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.roomDGV_CellBeginEdit);
            this.roomDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomDGV_CellEndEdit);
            // 
            // hotelNameLbl
            // 
            this.hotelNameLbl.AutoSize = true;
            this.hotelNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotelNameLbl.Location = new System.Drawing.Point(30, 142);
            this.hotelNameLbl.Name = "hotelNameLbl";
            this.hotelNameLbl.Size = new System.Drawing.Size(130, 25);
            this.hotelNameLbl.TabIndex = 65;
            this.hotelNameLbl.Text = "Arrival Date:";
            // 
            // noOfPaxLbl
            // 
            this.noOfPaxLbl.AutoSize = true;
            this.noOfPaxLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noOfPaxLbl.Location = new System.Drawing.Point(343, 142);
            this.noOfPaxLbl.Name = "noOfPaxLbl";
            this.noOfPaxLbl.Size = new System.Drawing.Size(193, 25);
            this.noOfPaxLbl.TabIndex = 64;
            this.noOfPaxLbl.Text = "Head of delegation";
            // 
            // competitors_Lbl
            // 
            this.competitors_Lbl.AutoSize = true;
            this.competitors_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.competitors_Lbl.Location = new System.Drawing.Point(343, 189);
            this.competitors_Lbl.Name = "competitors_Lbl";
            this.competitors_Lbl.Size = new System.Drawing.Size(106, 25);
            this.competitors_Lbl.TabIndex = 63;
            this.competitors_Lbl.Text = "delegates";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(273, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 25);
            this.label2.TabIndex = 62;
            this.label2.Text = "Update Info / Booking";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(35, 41);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 61;
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
            this.label1.Location = new System.Drawing.Point(273, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 29);
            this.label1.TabIndex = 60;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 556);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(800, 39);
            this.pictureBox2.TabIndex = 59;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 90);
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(343, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 25);
            this.label3.TabIndex = 69;
            this.label3.Text = "Competitors";
            // 
            // HOD_NUD
            // 
            this.HOD_NUD.Location = new System.Drawing.Point(167, 146);
            this.HOD_NUD.Name = "HOD_NUD";
            this.HOD_NUD.Size = new System.Drawing.Size(170, 20);
            this.HOD_NUD.TabIndex = 70;
            this.HOD_NUD.ValueChanged += new System.EventHandler(this.HOD_NUD_ValueChanged);
            // 
            // delegate_NUD
            // 
            this.delegate_NUD.Location = new System.Drawing.Point(167, 196);
            this.delegate_NUD.Name = "delegate_NUD";
            this.delegate_NUD.Size = new System.Drawing.Size(170, 20);
            this.delegate_NUD.TabIndex = 71;
            this.delegate_NUD.ValueChanged += new System.EventHandler(this.delegate_NUD_ValueChanged);
            // 
            // competitors_NUD
            // 
            this.competitors_NUD.Location = new System.Drawing.Point(167, 238);
            this.competitors_NUD.Name = "competitors_NUD";
            this.competitors_NUD.Size = new System.Drawing.Size(170, 20);
            this.competitors_NUD.TabIndex = 72;
            this.competitors_NUD.ValueChanged += new System.EventHandler(this.competitors_NUD_ValueChanged);
            // 
            // UpdateBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 595);
            this.Controls.Add(this.competitors_NUD);
            this.Controls.Add(this.delegate_NUD);
            this.Controls.Add(this.HOD_NUD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.update_Btn);
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
            this.Name = "UpdateBooking";
            this.Text = "UpdateBooking";
            this.Load += new System.EventHandler(this.UpdateBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOD_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delegate_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.competitors_NUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button update_Btn;
        private System.Windows.Forms.Label totalVal_Lbl;
        private System.Windows.Forms.DataGridView roomDGV;
        private System.Windows.Forms.Label hotelNameLbl;
        private System.Windows.Forms.Label noOfPaxLbl;
        private System.Windows.Forms.Label competitors_Lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown HOD_NUD;
        private System.Windows.Forms.NumericUpDown delegate_NUD;
        private System.Windows.Forms.NumericUpDown competitors_NUD;
    }
}