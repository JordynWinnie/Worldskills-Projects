namespace TPQR_Session4_9_8_2020
{
    partial class UpdateExpertTrainingForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progress = new System.Windows.Forms.RadioButton();
            this.nameRadio = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.trainingDGV = new System.Windows.Forms.DataGridView();
            this.competitorNameCb = new System.Windows.Forms.ComboBox();
            this.skillCb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trainingDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progress);
            this.groupBox1.Controls.Add(this.nameRadio);
            this.groupBox1.Location = new System.Drawing.Point(258, 255);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 43);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            // 
            // progress
            // 
            this.progress.AutoSize = true;
            this.progress.Location = new System.Drawing.Point(187, 16);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(86, 21);
            this.progress.TabIndex = 1;
            this.progress.Text = "Progress";
            this.progress.UseVisualStyleBackColor = true;
            this.progress.CheckedChanged += new System.EventHandler(this.progress_CheckedChanged);
            // 
            // nameRadio
            // 
            this.nameRadio.AutoSize = true;
            this.nameRadio.Checked = true;
            this.nameRadio.Location = new System.Drawing.Point(28, 16);
            this.nameRadio.Name = "nameRadio";
            this.nameRadio.Size = new System.Drawing.Size(66, 21);
            this.nameRadio.TabIndex = 0;
            this.nameRadio.TabStop = true;
            this.nameRadio.Text = "Name";
            this.nameRadio.UseVisualStyleBackColor = true;
            this.nameRadio.CheckedChanged += new System.EventHandler(this.nameRadio_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(172, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 29);
            this.label7.TabIndex = 71;
            this.label7.Text = "Sort:";
            // 
            // trainingDGV
            // 
            this.trainingDGV.AllowUserToAddRows = false;
            this.trainingDGV.AllowUserToDeleteRows = false;
            this.trainingDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.trainingDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trainingDGV.Location = new System.Drawing.Point(31, 344);
            this.trainingDGV.Name = "trainingDGV";
            this.trainingDGV.RowHeadersWidth = 51;
            this.trainingDGV.RowTemplate.Height = 24;
            this.trainingDGV.Size = new System.Drawing.Size(754, 245);
            this.trainingDGV.TabIndex = 70;
            this.trainingDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.trainingDGV_CellClick);
            this.trainingDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.trainingDGV_CellEndEdit);
            // 
            // competitorNameCb
            // 
            this.competitorNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.competitorNameCb.FormattingEnabled = true;
            this.competitorNameCb.Location = new System.Drawing.Point(258, 201);
            this.competitorNameCb.Name = "competitorNameCb";
            this.competitorNameCb.Size = new System.Drawing.Size(492, 24);
            this.competitorNameCb.TabIndex = 69;
            this.competitorNameCb.SelectedIndexChanged += new System.EventHandler(this.competitorNameCb_SelectedIndexChanged);
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(258, 152);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(492, 24);
            this.skillCb.TabIndex = 68;
            this.skillCb.SelectedIndexChanged += new System.EventHandler(this.skillCb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 29);
            this.label4.TabIndex = 67;
            this.label4.Text = "Expert\'s Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(167, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 29);
            this.label3.TabIndex = 66;
            this.label3.Text = "Skill:";
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(7, 22);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(192, 31);
            this.closeBtn.TabIndex = 65;
            this.closeBtn.Text = "Back";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // uploadBtn
            // 
            this.uploadBtn.Location = new System.Drawing.Point(516, 606);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(269, 31);
            this.uploadBtn.TabIndex = 64;
            this.uploadBtn.Text = "Update";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(194, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(358, 29);
            this.label2.TabIndex = 63;
            this.label2.Text = "Update Expert Training Records";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(540, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 32);
            this.label1.TabIndex = 62;
            this.label1.Text = "ASEAN Skill 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(-6, 643);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(803, 93);
            this.pictureBox2.TabIndex = 61;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(-6, -5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(803, 79);
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            // 
            // UpdateExpertTrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 741);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.trainingDGV);
            this.Controls.Add(this.competitorNameCb);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UpdateExpertTrainingForm";
            this.Text = "UpdateExpertTrainingForm";
            this.Load += new System.EventHandler(this.UpdateExpertTrainingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trainingDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton progress;
        private System.Windows.Forms.RadioButton nameRadio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView trainingDGV;
        private System.Windows.Forms.ComboBox competitorNameCb;
        private System.Windows.Forms.ComboBox skillCb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}