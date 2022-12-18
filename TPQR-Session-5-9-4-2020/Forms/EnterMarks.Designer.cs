namespace TPQR_Session5_9_4_2020
{
    partial class EnterMarks
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
            this.skillCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sessionCb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.competitorNameCb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.marksDGV = new System.Windows.Forms.DataGridView();
            this.totalMarksLbl = new System.Windows.Forms.Label();
            this.clearForm = new System.Windows.Forms.Button();
            this.submitBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marksDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(14, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(192, 47);
            this.backBtn.TabIndex = 19;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(306, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Enter Marks";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(580, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 50);
            this.label1.TabIndex = 17;
            this.label1.Text = "ASEAN Skills 2020\r\n26 - 28 Jul 2020\r\n";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(5, 584);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(795, 68);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(5, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(795, 80);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(212, 139);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(562, 21);
            this.skillCb.TabIndex = 21;
            this.skillCb.SelectedIndexChanged += new System.EventHandler(this.skillCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(148, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 20;
            this.label3.Text = "Skill:";
            // 
            // sessionCb
            // 
            this.sessionCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionCb.FormattingEnabled = true;
            this.sessionCb.Location = new System.Drawing.Point(212, 179);
            this.sessionCb.Name = "sessionCb";
            this.sessionCb.Size = new System.Drawing.Size(562, 21);
            this.sessionCb.TabIndex = 23;
            this.sessionCb.SelectedIndexChanged += new System.EventHandler(this.sessionCb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(111, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "Session:";
            // 
            // competitorNameCb
            // 
            this.competitorNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.competitorNameCb.FormattingEnabled = true;
            this.competitorNameCb.Location = new System.Drawing.Point(212, 227);
            this.competitorNameCb.Name = "competitorNameCb";
            this.competitorNameCb.Size = new System.Drawing.Size(562, 21);
            this.competitorNameCb.TabIndex = 25;
            this.competitorNameCb.SelectedIndexChanged += new System.EventHandler(this.competitorNameCb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "Competitor Name:";
            // 
            // marksDGV
            // 
            this.marksDGV.AllowUserToAddRows = false;
            this.marksDGV.AllowUserToDeleteRows = false;
            this.marksDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.marksDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.marksDGV.Location = new System.Drawing.Point(27, 276);
            this.marksDGV.Name = "marksDGV";
            this.marksDGV.Size = new System.Drawing.Size(747, 225);
            this.marksDGV.TabIndex = 26;
            this.marksDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.marksDGV_CellEndEdit);
            // 
            // totalMarksLbl
            // 
            this.totalMarksLbl.AutoSize = true;
            this.totalMarksLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalMarksLbl.Location = new System.Drawing.Point(148, 525);
            this.totalMarksLbl.Name = "totalMarksLbl";
            this.totalMarksLbl.Size = new System.Drawing.Size(131, 25);
            this.totalMarksLbl.TabIndex = 27;
            this.totalMarksLbl.Text = "Total Marks:";
            // 
            // clearForm
            // 
            this.clearForm.Location = new System.Drawing.Point(441, 526);
            this.clearForm.Name = "clearForm";
            this.clearForm.Size = new System.Drawing.Size(144, 52);
            this.clearForm.TabIndex = 28;
            this.clearForm.Text = "Clear Form";
            this.clearForm.UseVisualStyleBackColor = true;
            this.clearForm.Click += new System.EventHandler(this.clearForm_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(636, 526);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(138, 52);
            this.submitBtn.TabIndex = 29;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // EnterMarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 645);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.clearForm);
            this.Controls.Add(this.totalMarksLbl);
            this.Controls.Add(this.marksDGV);
            this.Controls.Add(this.competitorNameCb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sessionCb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "EnterMarks";
            this.Text = "EnterMarks";
            this.Load += new System.EventHandler(this.EnterMarks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marksDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox skillCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox sessionCb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox competitorNameCb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView marksDGV;
        private System.Windows.Forms.Label totalMarksLbl;
        private System.Windows.Forms.Button clearForm;
        private System.Windows.Forms.Button submitBtn;
    }
}