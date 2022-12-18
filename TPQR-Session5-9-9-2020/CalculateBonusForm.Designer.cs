namespace TPQR_Session5_9_9_2020
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
            this.backBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.skilCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.competitorNameCb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.marksDGV = new System.Windows.Forms.DataGridView();
            this.totalBonusLbl = new System.Windows.Forms.Label();
            this.amountRecievedLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marksDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(25, 17);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(186, 51);
            this.backBtn.TabIndex = 43;
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
            this.label1.Location = new System.Drawing.Point(759, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 42;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 689);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1043, 50);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1043, 83);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // skilCb
            // 
            this.skilCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skilCb.FormattingEnabled = true;
            this.skilCb.Location = new System.Drawing.Point(284, 148);
            this.skilCb.Name = "skilCb";
            this.skilCb.Size = new System.Drawing.Size(732, 24);
            this.skilCb.TabIndex = 45;
            this.skilCb.SelectedIndexChanged += new System.EventHandler(this.skilCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(223, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 25);
            this.label3.TabIndex = 44;
            this.label3.Text = "Skill:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(417, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 29);
            this.label2.TabIndex = 46;
            this.label2.Text = "Calculate Bonus:";
            // 
            // competitorNameCb
            // 
            this.competitorNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.competitorNameCb.FormattingEnabled = true;
            this.competitorNameCb.Location = new System.Drawing.Point(284, 194);
            this.competitorNameCb.Name = "competitorNameCb";
            this.competitorNameCb.Size = new System.Drawing.Size(732, 24);
            this.competitorNameCb.TabIndex = 48;
            this.competitorNameCb.SelectedIndexChanged += new System.EventHandler(this.competitorNameCb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(107, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 25);
            this.label5.TabIndex = 47;
            this.label5.Text = "Competitor Name:";
            // 
            // marksDGV
            // 
            this.marksDGV.AllowUserToAddRows = false;
            this.marksDGV.AllowUserToDeleteRows = false;
            this.marksDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.marksDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.marksDGV.Location = new System.Drawing.Point(25, 242);
            this.marksDGV.Name = "marksDGV";
            this.marksDGV.RowHeadersWidth = 51;
            this.marksDGV.RowTemplate.Height = 24;
            this.marksDGV.Size = new System.Drawing.Size(991, 362);
            this.marksDGV.TabIndex = 49;
            // 
            // totalBonusLbl
            // 
            this.totalBonusLbl.AutoSize = true;
            this.totalBonusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBonusLbl.Location = new System.Drawing.Point(20, 642);
            this.totalBonusLbl.Name = "totalBonusLbl";
            this.totalBonusLbl.Size = new System.Drawing.Size(203, 25);
            this.totalBonusLbl.TabIndex = 50;
            this.totalBonusLbl.Text = "Total Bonus: <Value>";
            // 
            // amountRecievedLbl
            // 
            this.amountRecievedLbl.AutoSize = true;
            this.amountRecievedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountRecievedLbl.Location = new System.Drawing.Point(686, 642);
            this.amountRecievedLbl.Name = "amountRecievedLbl";
            this.amountRecievedLbl.Size = new System.Drawing.Size(221, 25);
            this.amountRecievedLbl.TabIndex = 51;
            this.amountRecievedLbl.Text = "Total Amount Recieved:";
            // 
            // CalculateBonusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 739);
            this.Controls.Add(this.amountRecievedLbl);
            this.Controls.Add(this.totalBonusLbl);
            this.Controls.Add(this.marksDGV);
            this.Controls.Add(this.competitorNameCb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.skilCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CalculateBonusForm";
            this.Text = "CalculateBonusForm";
            this.Load += new System.EventHandler(this.CalculateBonusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marksDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox skilCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox competitorNameCb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView marksDGV;
        private System.Windows.Forms.Label totalBonusLbl;
        private System.Windows.Forms.Label amountRecievedLbl;
    }
}