namespace Session5
{
    partial class CalculateBonusForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.competitorCb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bonusDGV = new System.Windows.Forms.DataGridView();
            this.BonusLbl = new System.Windows.Forms.Label();
            this.totalToReceiveLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(229, 153);
            this.skillCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(294, 21);
            this.skillCb.TabIndex = 28;
            this.skillCb.SelectedIndexChanged += new System.EventHandler(this.skillCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(118, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 26);
            this.label3.TabIndex = 27;
            this.label3.Text = "Skill:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(205, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 26);
            this.label4.TabIndex = 26;
            this.label4.Text = "Calculate Bonus";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 27);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 37);
            this.button1.TabIndex = 25;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 24;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(1, 588);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(599, 43);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(599, 80);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // competitorCb
            // 
            this.competitorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.competitorCb.FormattingEnabled = true;
            this.competitorCb.Location = new System.Drawing.Point(229, 194);
            this.competitorCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.competitorCb.Name = "competitorCb";
            this.competitorCb.Size = new System.Drawing.Size(294, 21);
            this.competitorCb.TabIndex = 30;
            this.competitorCb.SelectedIndexChanged += new System.EventHandler(this.competitorCb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 186);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 26);
            this.label5.TabIndex = 29;
            this.label5.Text = "Competitor Name:";
            // 
            // bonusDGV
            // 
            this.bonusDGV.AllowUserToAddRows = false;
            this.bonusDGV.AllowUserToDeleteRows = false;
            this.bonusDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bonusDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.bonusDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bonusDGV.Location = new System.Drawing.Point(16, 238);
            this.bonusDGV.Name = "bonusDGV";
            this.bonusDGV.RowHeadersWidth = 51;
            this.bonusDGV.Size = new System.Drawing.Size(572, 294);
            this.bonusDGV.TabIndex = 31;
            // 
            // BonusLbl
            // 
            this.BonusLbl.AutoSize = true;
            this.BonusLbl.BackColor = System.Drawing.SystemColors.Control;
            this.BonusLbl.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BonusLbl.Location = new System.Drawing.Point(16, 550);
            this.BonusLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BonusLbl.Name = "BonusLbl";
            this.BonusLbl.Size = new System.Drawing.Size(89, 26);
            this.BonusLbl.TabIndex = 32;
            this.BonusLbl.Text = "Bonus:";
            // 
            // totalToReceiveLbl
            // 
            this.totalToReceiveLbl.AutoSize = true;
            this.totalToReceiveLbl.BackColor = System.Drawing.SystemColors.Control;
            this.totalToReceiveLbl.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalToReceiveLbl.Location = new System.Drawing.Point(224, 550);
            this.totalToReceiveLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalToReceiveLbl.Name = "totalToReceiveLbl";
            this.totalToReceiveLbl.Size = new System.Drawing.Size(274, 26);
            this.totalToReceiveLbl.TabIndex = 33;
            this.totalToReceiveLbl.Text = "Total Amount Received:";
            // 
            // CalculateBonusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 629);
            this.Controls.Add(this.totalToReceiveLbl);
            this.Controls.Add(this.BonusLbl);
            this.Controls.Add(this.bonusDGV);
            this.Controls.Add(this.competitorCb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CalculateBonusForm";
            this.Text = "CalculateBonusForm";
            this.Load += new System.EventHandler(this.CalculateBonusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox skillCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox competitorCb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView bonusDGV;
        private System.Windows.Forms.Label BonusLbl;
        private System.Windows.Forms.Label totalToReceiveLbl;
    }
}