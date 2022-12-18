namespace TPQR_Session5_9_4_2020
{
    partial class CalculateBonus
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
            this.skillCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.competitorNameCb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.moneyDGV = new System.Windows.Forms.DataGridView();
            this.totalBonusLbl = new System.Windows.Forms.Label();
            this.totalAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(284, 139);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(489, 21);
            this.skillCb.TabIndex = 42;
            this.skillCb.SelectedIndexChanged += new System.EventHandler(this.skillCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(220, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 41;
            this.label3.Text = "Skill:";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(13, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(192, 47);
            this.backBtn.TabIndex = 40;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(305, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 25);
            this.label2.TabIndex = 39;
            this.label2.Text = "Calculate Bonus";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(579, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 50);
            this.label1.TabIndex = 38;
            this.label1.Text = "ASEAN Skills 2020\r\n26 - 28 Jul 2020\r\n";
            // 
            // competitorNameCb
            // 
            this.competitorNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.competitorNameCb.FormattingEnabled = true;
            this.competitorNameCb.Location = new System.Drawing.Point(284, 186);
            this.competitorNameCb.Name = "competitorNameCb";
            this.competitorNameCb.Size = new System.Drawing.Size(489, 21);
            this.competitorNameCb.TabIndex = 44;
            this.competitorNameCb.SelectedIndexChanged += new System.EventHandler(this.competitorNameCb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(94, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 25);
            this.label4.TabIndex = 43;
            this.label4.Text = "Competitor Name:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(4, 616);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(795, 36);
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(4, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(795, 80);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // moneyDGV
            // 
            this.moneyDGV.AllowUserToAddRows = false;
            this.moneyDGV.AllowUserToDeleteRows = false;
            this.moneyDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.moneyDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moneyDGV.Location = new System.Drawing.Point(22, 228);
            this.moneyDGV.Name = "moneyDGV";
            this.moneyDGV.Size = new System.Drawing.Size(751, 317);
            this.moneyDGV.TabIndex = 45;
            // 
            // totalBonusLbl
            // 
            this.totalBonusLbl.AutoSize = true;
            this.totalBonusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBonusLbl.Location = new System.Drawing.Point(54, 564);
            this.totalBonusLbl.Name = "totalBonusLbl";
            this.totalBonusLbl.Size = new System.Drawing.Size(133, 25);
            this.totalBonusLbl.TabIndex = 46;
            this.totalBonusLbl.Text = "Total Bonus:";
            // 
            // totalAmount
            // 
            this.totalAmount.AutoSize = true;
            this.totalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAmount.Location = new System.Drawing.Point(392, 564);
            this.totalAmount.Name = "totalAmount";
            this.totalAmount.Size = new System.Drawing.Size(241, 25);
            this.totalAmount.TabIndex = 47;
            this.totalAmount.Text = "Total Amount Recieved:";
            // 
            // CalculateBonus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 652);
            this.Controls.Add(this.totalAmount);
            this.Controls.Add(this.totalBonusLbl);
            this.Controls.Add(this.moneyDGV);
            this.Controls.Add(this.competitorNameCb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CalculateBonus";
            this.Text = "CalculateBonus";
            this.Load += new System.EventHandler(this.CalculateBonus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox skillCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox competitorNameCb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView moneyDGV;
        private System.Windows.Forms.Label totalBonusLbl;
        private System.Windows.Forms.Label totalAmount;
    }
}