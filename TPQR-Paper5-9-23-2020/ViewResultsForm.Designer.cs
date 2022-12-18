namespace TPQR_Paper5_9_23_2020
{
    partial class ViewResultsForm
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
            this.competitorDGV = new System.Windows.Forms.DataGridView();
            this.completedSessionsLbl = new System.Windows.Forms.Label();
            this.totalNumberOfSessionsLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.goldFlag1 = new System.Windows.Forms.PictureBox();
            this.goldFlag2 = new System.Windows.Forms.PictureBox();
            this.silverFlag2 = new System.Windows.Forms.PictureBox();
            this.silverFlag1 = new System.Windows.Forms.PictureBox();
            this.bronzeFlag2 = new System.Windows.Forms.PictureBox();
            this.bronzeFlag1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.competitorDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goldFlag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goldFlag2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.silverFlag2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.silverFlag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bronzeFlag2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bronzeFlag1)).BeginInit();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(25, 19);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(89, 36);
            this.backBtn.TabIndex = 50;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(468, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 32);
            this.label2.TabIndex = 49;
            this.label2.Text = "View Results";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(404, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 36);
            this.label1.TabIndex = 48;
            this.label1.Text = "ASEAN Skills 2020";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 615);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1132, 50);
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1132, 80);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(333, 158);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(475, 24);
            this.skillCb.TabIndex = 53;
            this.skillCb.SelectedIndexChanged += new System.EventHandler(this.skillCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(273, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 25);
            this.label3.TabIndex = 52;
            this.label3.Text = "Skill:";
            // 
            // competitorDGV
            // 
            this.competitorDGV.AllowUserToAddRows = false;
            this.competitorDGV.AllowUserToDeleteRows = false;
            this.competitorDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.competitorDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.competitorDGV.Location = new System.Drawing.Point(37, 238);
            this.competitorDGV.Name = "competitorDGV";
            this.competitorDGV.RowHeadersWidth = 51;
            this.competitorDGV.RowTemplate.Height = 24;
            this.competitorDGV.Size = new System.Drawing.Size(543, 371);
            this.competitorDGV.TabIndex = 54;
            // 
            // completedSessionsLbl
            // 
            this.completedSessionsLbl.AutoSize = true;
            this.completedSessionsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completedSessionsLbl.Location = new System.Drawing.Point(661, 204);
            this.completedSessionsLbl.Name = "completedSessionsLbl";
            this.completedSessionsLbl.Size = new System.Drawing.Size(271, 25);
            this.completedSessionsLbl.TabIndex = 56;
            this.completedSessionsLbl.Text = "No Of Completed Sessions: 0";
            // 
            // totalNumberOfSessionsLbl
            // 
            this.totalNumberOfSessionsLbl.AutoSize = true;
            this.totalNumberOfSessionsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalNumberOfSessionsLbl.Location = new System.Drawing.Point(146, 204);
            this.totalNumberOfSessionsLbl.Name = "totalNumberOfSessionsLbl";
            this.totalNumberOfSessionsLbl.Size = new System.Drawing.Size(259, 25);
            this.totalNumberOfSessionsLbl.TabIndex = 55;
            this.totalNumberOfSessionsLbl.Text = "Total Number of Sessions: 0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(780, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 25);
            this.label4.TabIndex = 57;
            this.label4.Text = "Gold:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(780, 380);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 58;
            this.label5.Text = "Silver:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(780, 499);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 25);
            this.label6.TabIndex = 59;
            this.label6.Text = "Bronze:";
            // 
            // goldFlag1
            // 
            this.goldFlag1.Location = new System.Drawing.Point(655, 292);
            this.goldFlag1.Name = "goldFlag1";
            this.goldFlag1.Size = new System.Drawing.Size(128, 75);
            this.goldFlag1.TabIndex = 60;
            this.goldFlag1.TabStop = false;
            // 
            // goldFlag2
            // 
            this.goldFlag2.Location = new System.Drawing.Point(846, 292);
            this.goldFlag2.Name = "goldFlag2";
            this.goldFlag2.Size = new System.Drawing.Size(128, 75);
            this.goldFlag2.TabIndex = 61;
            this.goldFlag2.TabStop = false;
            // 
            // silverFlag2
            // 
            this.silverFlag2.Location = new System.Drawing.Point(846, 421);
            this.silverFlag2.Name = "silverFlag2";
            this.silverFlag2.Size = new System.Drawing.Size(128, 75);
            this.silverFlag2.TabIndex = 63;
            this.silverFlag2.TabStop = false;
            // 
            // silverFlag1
            // 
            this.silverFlag1.Location = new System.Drawing.Point(655, 421);
            this.silverFlag1.Name = "silverFlag1";
            this.silverFlag1.Size = new System.Drawing.Size(128, 75);
            this.silverFlag1.TabIndex = 62;
            this.silverFlag1.TabStop = false;
            // 
            // bronzeFlag2
            // 
            this.bronzeFlag2.Location = new System.Drawing.Point(846, 527);
            this.bronzeFlag2.Name = "bronzeFlag2";
            this.bronzeFlag2.Size = new System.Drawing.Size(128, 75);
            this.bronzeFlag2.TabIndex = 65;
            this.bronzeFlag2.TabStop = false;
            // 
            // bronzeFlag1
            // 
            this.bronzeFlag1.Location = new System.Drawing.Point(655, 527);
            this.bronzeFlag1.Name = "bronzeFlag1";
            this.bronzeFlag1.Size = new System.Drawing.Size(128, 75);
            this.bronzeFlag1.TabIndex = 64;
            this.bronzeFlag1.TabStop = false;
            // 
            // ViewResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 665);
            this.Controls.Add(this.bronzeFlag2);
            this.Controls.Add(this.bronzeFlag1);
            this.Controls.Add(this.silverFlag2);
            this.Controls.Add(this.silverFlag1);
            this.Controls.Add(this.goldFlag2);
            this.Controls.Add(this.goldFlag1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.completedSessionsLbl);
            this.Controls.Add(this.totalNumberOfSessionsLbl);
            this.Controls.Add(this.competitorDGV);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ViewResultsForm";
            this.Text = "ViewResultsForm";
            this.Load += new System.EventHandler(this.ViewResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.competitorDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goldFlag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goldFlag2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.silverFlag2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.silverFlag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bronzeFlag2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bronzeFlag1)).EndInit();
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
        private System.Windows.Forms.DataGridView competitorDGV;
        private System.Windows.Forms.Label completedSessionsLbl;
        private System.Windows.Forms.Label totalNumberOfSessionsLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox goldFlag1;
        private System.Windows.Forms.PictureBox goldFlag2;
        private System.Windows.Forms.PictureBox silverFlag2;
        private System.Windows.Forms.PictureBox silverFlag1;
        private System.Windows.Forms.PictureBox bronzeFlag2;
        private System.Windows.Forms.PictureBox bronzeFlag1;
    }
}