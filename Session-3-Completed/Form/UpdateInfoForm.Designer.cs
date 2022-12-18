namespace Session3_Jordan_Khong
{
    partial class UpdateInfoForm
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
            this.components = new System.ComponentModel.Container();
            this.doubleRoomErrorLbl = new System.Windows.Forms.Label();
            this.singleRoomErrorLbl = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            this.totalValueLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.roomInfoDGV = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.timerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numberOfDeleTb = new System.Windows.Forms.TextBox();
            this.numberOfCompetitorsTb = new System.Windows.Forms.TextBox();
            this.numberOfHODTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.delegateHODErrorLbl = new System.Windows.Forms.Label();
            this.competitorErrorLbl = new System.Windows.Forms.Label();
            this.delegateErrorLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHotelName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.roomInfoDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // doubleRoomErrorLbl
            // 
            this.doubleRoomErrorLbl.AutoSize = true;
            this.doubleRoomErrorLbl.BackColor = System.Drawing.Color.Red;
            this.doubleRoomErrorLbl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doubleRoomErrorLbl.Location = new System.Drawing.Point(18, 624);
            this.doubleRoomErrorLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.doubleRoomErrorLbl.Name = "doubleRoomErrorLbl";
            this.doubleRoomErrorLbl.Size = new System.Drawing.Size(45, 14);
            this.doubleRoomErrorLbl.TabIndex = 75;
            this.doubleRoomErrorLbl.Text = "label5";
            this.doubleRoomErrorLbl.Visible = false;
            // 
            // singleRoomErrorLbl
            // 
            this.singleRoomErrorLbl.AutoSize = true;
            this.singleRoomErrorLbl.BackColor = System.Drawing.Color.Red;
            this.singleRoomErrorLbl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleRoomErrorLbl.Location = new System.Drawing.Point(18, 591);
            this.singleRoomErrorLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.singleRoomErrorLbl.Name = "singleRoomErrorLbl";
            this.singleRoomErrorLbl.Size = new System.Drawing.Size(45, 14);
            this.singleRoomErrorLbl.TabIndex = 74;
            this.singleRoomErrorLbl.Text = "label5";
            this.singleRoomErrorLbl.Visible = false;
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(592, 647);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(2);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(121, 37);
            this.updateBtn.TabIndex = 73;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // totalValueLbl
            // 
            this.totalValueLbl.AutoSize = true;
            this.totalValueLbl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.totalValueLbl.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalValueLbl.ForeColor = System.Drawing.Color.Black;
            this.totalValueLbl.Location = new System.Drawing.Point(589, 617);
            this.totalValueLbl.Name = "totalValueLbl";
            this.totalValueLbl.Size = new System.Drawing.Size(126, 23);
            this.totalValueLbl.TabIndex = 72;
            this.totalValueLbl.Text = "(TotalValue)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(523, 617);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 23);
            this.label8.TabIndex = 71;
            this.label8.Text = "Total:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // roomInfoDGV
            // 
            this.roomInfoDGV.AllowUserToAddRows = false;
            this.roomInfoDGV.AllowUserToDeleteRows = false;
            this.roomInfoDGV.AllowUserToOrderColumns = true;
            this.roomInfoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomInfoDGV.Location = new System.Drawing.Point(20, 301);
            this.roomInfoDGV.Margin = new System.Windows.Forms.Padding(2);
            this.roomInfoDGV.Name = "roomInfoDGV";
            this.roomInfoDGV.RowHeadersWidth = 51;
            this.roomInfoDGV.RowTemplate.Height = 24;
            this.roomInfoDGV.Size = new System.Drawing.Size(688, 155);
            this.roomInfoDGV.TabIndex = 70;
            this.roomInfoDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomInfoDGV_CellEndEdit);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(406, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 23);
            this.label7.TabIndex = 69;
            this.label7.Text = "Competitors";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(406, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(277, 23);
            this.label6.TabIndex = 68;
            this.label6.Text = "Delegates (Excluding Head)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(38, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 23);
            this.label4.TabIndex = 64;
            this.label4.Text = "No. Of Pax:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(267, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 26);
            this.label2.TabIndex = 62;
            this.label2.Text = "Update Form";
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.Location = new System.Drawing.Point(20, 24);
            this.backBtn.Margin = new System.Windows.Forms.Padding(2);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(121, 37);
            this.backBtn.TabIndex = 61;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.BackColor = System.Drawing.Color.Red;
            this.timerLabel.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(533, 708);
            this.timerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(48, 17);
            this.timerLabel.TabIndex = 60;
            this.timerLabel.Text = "label5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(496, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 59;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(-2, 690);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(725, 52);
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(725, 80);
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // numberOfDeleTb
            // 
            this.numberOfDeleTb.Location = new System.Drawing.Point(188, 207);
            this.numberOfDeleTb.Margin = new System.Windows.Forms.Padding(2);
            this.numberOfDeleTb.Name = "numberOfDeleTb";
            this.numberOfDeleTb.Size = new System.Drawing.Size(213, 20);
            this.numberOfDeleTb.TabIndex = 76;
            this.numberOfDeleTb.TextChanged += new System.EventHandler(this.delegatesTb_TextChanged);
            // 
            // numberOfCompetitorsTb
            // 
            this.numberOfCompetitorsTb.Location = new System.Drawing.Point(188, 252);
            this.numberOfCompetitorsTb.Margin = new System.Windows.Forms.Padding(2);
            this.numberOfCompetitorsTb.Name = "numberOfCompetitorsTb";
            this.numberOfCompetitorsTb.Size = new System.Drawing.Size(213, 20);
            this.numberOfCompetitorsTb.TabIndex = 77;
            this.numberOfCompetitorsTb.TextChanged += new System.EventHandler(this.competitorsTb_TextChanged);
            // 
            // numberOfHODTb
            // 
            this.numberOfHODTb.Location = new System.Drawing.Point(188, 167);
            this.numberOfHODTb.Margin = new System.Windows.Forms.Padding(2);
            this.numberOfHODTb.Name = "numberOfHODTb";
            this.numberOfHODTb.Size = new System.Drawing.Size(213, 20);
            this.numberOfHODTb.TabIndex = 79;
            this.numberOfHODTb.TextChanged += new System.EventHandler(this.headOfDelegatesTb_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(406, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 23);
            this.label5.TabIndex = 78;
            this.label5.Text = "Head of Delegates";
            // 
            // delegateHODErrorLbl
            // 
            this.delegateHODErrorLbl.AutoSize = true;
            this.delegateHODErrorLbl.BackColor = System.Drawing.Color.Red;
            this.delegateHODErrorLbl.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delegateHODErrorLbl.Location = new System.Drawing.Point(17, 483);
            this.delegateHODErrorLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.delegateHODErrorLbl.Name = "delegateHODErrorLbl";
            this.delegateHODErrorLbl.Size = new System.Drawing.Size(425, 17);
            this.delegateHODErrorLbl.TabIndex = 82;
            this.delegateHODErrorLbl.Text = "Number of Head Of Delegation not recognised. Assuming 0";
            this.delegateHODErrorLbl.Visible = false;
            // 
            // competitorErrorLbl
            // 
            this.competitorErrorLbl.AutoSize = true;
            this.competitorErrorLbl.BackColor = System.Drawing.Color.Red;
            this.competitorErrorLbl.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.competitorErrorLbl.Location = new System.Drawing.Point(17, 550);
            this.competitorErrorLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.competitorErrorLbl.Name = "competitorErrorLbl";
            this.competitorErrorLbl.Size = new System.Drawing.Size(374, 17);
            this.competitorErrorLbl.TabIndex = 81;
            this.competitorErrorLbl.Text = "Number of competitors not recognised. Assuming 0";
            this.competitorErrorLbl.Visible = false;
            // 
            // delegateErrorLbl
            // 
            this.delegateErrorLbl.AutoSize = true;
            this.delegateErrorLbl.BackColor = System.Drawing.Color.Red;
            this.delegateErrorLbl.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delegateErrorLbl.Location = new System.Drawing.Point(17, 515);
            this.delegateErrorLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.delegateErrorLbl.Name = "delegateErrorLbl";
            this.delegateErrorLbl.Size = new System.Drawing.Size(357, 17);
            this.delegateErrorLbl.TabIndex = 80;
            this.delegateErrorLbl.Text = "Number of delegates not recognised. Assuming 0";
            this.delegateErrorLbl.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(26, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 23);
            this.label3.TabIndex = 63;
            this.label3.Text = "Hotel Name:";
            // 
            // lblHotelName
            // 
            this.lblHotelName.AutoSize = true;
            this.lblHotelName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblHotelName.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHotelName.ForeColor = System.Drawing.Color.Black;
            this.lblHotelName.Location = new System.Drawing.Point(186, 131);
            this.lblHotelName.Name = "lblHotelName";
            this.lblHotelName.Size = new System.Drawing.Size(132, 23);
            this.lblHotelName.TabIndex = 65;
            this.lblHotelName.Text = "(HotelName)";
            // 
            // UpdateInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 742);
            this.Controls.Add(this.delegateHODErrorLbl);
            this.Controls.Add(this.competitorErrorLbl);
            this.Controls.Add(this.delegateErrorLbl);
            this.Controls.Add(this.numberOfHODTb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numberOfCompetitorsTb);
            this.Controls.Add(this.numberOfDeleTb);
            this.Controls.Add(this.doubleRoomErrorLbl);
            this.Controls.Add(this.singleRoomErrorLbl);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.totalValueLbl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.roomInfoDGV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblHotelName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UpdateInfoForm";
            this.Text = "Update Info";
            this.Load += new System.EventHandler(this.UpdateInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomInfoDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label doubleRoomErrorLbl;
        private System.Windows.Forms.Label singleRoomErrorLbl;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Label totalValueLbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView roomInfoDGV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox numberOfDeleTb;
        private System.Windows.Forms.TextBox numberOfCompetitorsTb;
        private System.Windows.Forms.TextBox numberOfHODTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label delegateHODErrorLbl;
        private System.Windows.Forms.Label competitorErrorLbl;
        private System.Windows.Forms.Label delegateErrorLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHotelName;
    }
}