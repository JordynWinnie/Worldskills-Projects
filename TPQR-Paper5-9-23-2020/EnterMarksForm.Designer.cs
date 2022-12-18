namespace TPQR_Paper5_9_23_2020
{
    partial class EnterMarksForm
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
            this.submitBtn = new System.Windows.Forms.Button();
            this.skillCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sessionNoCb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.competitorNameCb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.marksDGV = new System.Windows.Forms.DataGridView();
            this.clearForm = new System.Windows.Forms.Button();
            this.totalMarksLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marksDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(851, 498);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(123, 51);
            this.submitBtn.TabIndex = 45;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(313, 141);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(475, 24);
            this.skillCb.TabIndex = 44;
            this.skillCb.SelectedIndexChanged += new System.EventHandler(this.skillCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(240, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 25);
            this.label3.TabIndex = 43;
            this.label3.Text = "Skill:";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(21, 22);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(89, 36);
            this.backBtn.TabIndex = 42;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(386, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 32);
            this.label2.TabIndex = 41;
            this.label2.Text = "Enter Marks";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(370, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 36);
            this.label1.TabIndex = 40;
            this.label1.Text = "ASEAN Skills 2020";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 574);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1036, 50);
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1036, 80);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // sessionNoCb
            // 
            this.sessionNoCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionNoCb.FormattingEnabled = true;
            this.sessionNoCb.Location = new System.Drawing.Point(313, 188);
            this.sessionNoCb.Name = "sessionNoCb";
            this.sessionNoCb.Size = new System.Drawing.Size(475, 24);
            this.sessionNoCb.TabIndex = 47;
            this.sessionNoCb.SelectedIndexChanged += new System.EventHandler(this.sessionNoCb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(175, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 25);
            this.label4.TabIndex = 46;
            this.label4.Text = "Session No:";
            // 
            // competitorNameCb
            // 
            this.competitorNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.competitorNameCb.FormattingEnabled = true;
            this.competitorNameCb.Location = new System.Drawing.Point(313, 234);
            this.competitorNameCb.Name = "competitorNameCb";
            this.competitorNameCb.Size = new System.Drawing.Size(475, 24);
            this.competitorNameCb.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(124, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 25);
            this.label5.TabIndex = 48;
            this.label5.Text = "Competitor Name:";
            // 
            // marksDGV
            // 
            this.marksDGV.AllowUserToAddRows = false;
            this.marksDGV.AllowUserToDeleteRows = false;
            this.marksDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.marksDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.marksDGV.Location = new System.Drawing.Point(21, 287);
            this.marksDGV.Name = "marksDGV";
            this.marksDGV.RowHeadersWidth = 51;
            this.marksDGV.RowTemplate.Height = 24;
            this.marksDGV.Size = new System.Drawing.Size(767, 262);
            this.marksDGV.TabIndex = 50;
            this.marksDGV.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.marksDGV_CellBeginEdit);
            this.marksDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.marksDGV_CellClick);
            this.marksDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.marksDGV_CellEndEdit);
            // 
            // clearForm
            // 
            this.clearForm.Location = new System.Drawing.Point(851, 441);
            this.clearForm.Name = "clearForm";
            this.clearForm.Size = new System.Drawing.Size(123, 51);
            this.clearForm.TabIndex = 51;
            this.clearForm.Text = "Clear Form";
            this.clearForm.UseVisualStyleBackColor = true;
            this.clearForm.Click += new System.EventHandler(this.clearForm_Click);
            // 
            // totalMarksLbl
            // 
            this.totalMarksLbl.AutoSize = true;
            this.totalMarksLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalMarksLbl.Location = new System.Drawing.Point(806, 401);
            this.totalMarksLbl.Name = "totalMarksLbl";
            this.totalMarksLbl.Size = new System.Drawing.Size(121, 25);
            this.totalMarksLbl.TabIndex = 52;
            this.totalMarksLbl.Text = "Total Marks:";
            // 
            // EnterMarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 624);
            this.Controls.Add(this.totalMarksLbl);
            this.Controls.Add(this.clearForm);
            this.Controls.Add(this.marksDGV);
            this.Controls.Add(this.competitorNameCb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sessionNoCb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "EnterMarksForm";
            this.Text = "EnterMarksForm";
            this.Load += new System.EventHandler(this.EnterMarksForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marksDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.ComboBox skillCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox sessionNoCb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox competitorNameCb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView marksDGV;
        private System.Windows.Forms.Button clearForm;
        private System.Windows.Forms.Label totalMarksLbl;
    }
}