namespace TPQR_Session4_9_8_2020
{
    partial class UpdateCompetitorTrainingRecordsForm
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
            this.trainingDGV = new System.Windows.Forms.DataGridView();
            this.progressCb = new System.Windows.Forms.ComboBox();
            this.competitorNameCb = new System.Windows.Forms.ComboBox();
            this.skillCb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.searchModuleTb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nameRadio = new System.Windows.Forms.RadioButton();
            this.endDateRadio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.trainingDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trainingDGV
            // 
            this.trainingDGV.AllowUserToAddRows = false;
            this.trainingDGV.AllowUserToDeleteRows = false;
            this.trainingDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.trainingDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trainingDGV.Location = new System.Drawing.Point(34, 405);
            this.trainingDGV.Name = "trainingDGV";
            this.trainingDGV.RowHeadersWidth = 51;
            this.trainingDGV.RowTemplate.Height = 24;
            this.trainingDGV.Size = new System.Drawing.Size(754, 187);
            this.trainingDGV.TabIndex = 55;
            this.trainingDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.trainingDGV_CellClick);
            this.trainingDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.trainingDGV_CellEndEdit);
            // 
            // progressCb
            // 
            this.progressCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.progressCb.FormattingEnabled = true;
            this.progressCb.Location = new System.Drawing.Point(264, 347);
            this.progressCb.Name = "progressCb";
            this.progressCb.Size = new System.Drawing.Size(492, 24);
            this.progressCb.TabIndex = 54;
            this.progressCb.SelectedIndexChanged += new System.EventHandler(this.progressCb_SelectedIndexChanged);
            // 
            // competitorNameCb
            // 
            this.competitorNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.competitorNameCb.FormattingEnabled = true;
            this.competitorNameCb.Location = new System.Drawing.Point(261, 204);
            this.competitorNameCb.Name = "competitorNameCb";
            this.competitorNameCb.Size = new System.Drawing.Size(492, 24);
            this.competitorNameCb.TabIndex = 53;
            this.competitorNameCb.SelectedIndexChanged += new System.EventHandler(this.competitorNameCb_SelectedIndexChanged);
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(261, 155);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(492, 24);
            this.skillCb.TabIndex = 52;
            this.skillCb.SelectedIndexChanged += new System.EventHandler(this.skillCb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(121, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 29);
            this.label5.TabIndex = 51;
            this.label5.Text = "Progress:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 29);
            this.label4.TabIndex = 50;
            this.label4.Text = "Competitor Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(170, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 29);
            this.label3.TabIndex = 49;
            this.label3.Text = "Skill:";
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(10, 25);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(192, 31);
            this.closeBtn.TabIndex = 48;
            this.closeBtn.Text = "Back";
            this.closeBtn.UseVisualStyleBackColor = true;
            // 
            // uploadBtn
            // 
            this.uploadBtn.Location = new System.Drawing.Point(519, 609);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(269, 31);
            this.uploadBtn.TabIndex = 47;
            this.uploadBtn.Text = "Update";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(408, 29);
            this.label2.TabIndex = 46;
            this.label2.Text = "Update Competitor Training Records";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(543, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 32);
            this.label1.TabIndex = 45;
            this.label1.Text = "ASEAN Skill 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(-3, 646);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(803, 93);
            this.pictureBox2.TabIndex = 44;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(-3, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(803, 79);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 29);
            this.label6.TabIndex = 56;
            this.label6.Text = "Search Module Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(175, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 29);
            this.label7.TabIndex = 57;
            this.label7.Text = "Sort:";
            // 
            // searchModuleTb
            // 
            this.searchModuleTb.Location = new System.Drawing.Point(264, 307);
            this.searchModuleTb.Name = "searchModuleTb";
            this.searchModuleTb.Size = new System.Drawing.Size(492, 22);
            this.searchModuleTb.TabIndex = 58;
            this.searchModuleTb.TextChanged += new System.EventHandler(this.searchModuleTb_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.endDateRadio);
            this.groupBox1.Controls.Add(this.nameRadio);
            this.groupBox1.Location = new System.Drawing.Point(261, 258);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 43);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
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
            // endDateRadio
            // 
            this.endDateRadio.AutoSize = true;
            this.endDateRadio.Location = new System.Drawing.Point(187, 16);
            this.endDateRadio.Name = "endDateRadio";
            this.endDateRadio.Size = new System.Drawing.Size(88, 21);
            this.endDateRadio.TabIndex = 1;
            this.endDateRadio.Text = "End Date";
            this.endDateRadio.UseVisualStyleBackColor = true;
            this.endDateRadio.CheckedChanged += new System.EventHandler(this.endDateRadio_CheckedChanged);
            // 
            // UpdateCompetitorTrainingRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 736);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.searchModuleTb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trainingDGV);
            this.Controls.Add(this.progressCb);
            this.Controls.Add(this.competitorNameCb);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UpdateCompetitorTrainingRecordsForm";
            this.Text = "UpdateCompetitorTrainingRecordsForm";
            this.Load += new System.EventHandler(this.UpdateCompetitorTrainingRecordsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trainingDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView trainingDGV;
        private System.Windows.Forms.ComboBox progressCb;
        private System.Windows.Forms.ComboBox competitorNameCb;
        private System.Windows.Forms.ComboBox skillCb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox searchModuleTb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton endDateRadio;
        private System.Windows.Forms.RadioButton nameRadio;
    }
}