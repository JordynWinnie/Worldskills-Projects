namespace Session5
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.skillCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.totalNoOfSessionsLbl = new System.Windows.Forms.Label();
            this.numberOfCompletedSessions = new System.Windows.Forms.Label();
            this.marksDGV = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bronzeFlag2 = new System.Windows.Forms.PictureBox();
            this.bronzeFlag1 = new System.Windows.Forms.PictureBox();
            this.silverFlag2 = new System.Windows.Forms.PictureBox();
            this.silverFlag1 = new System.Windows.Forms.PictureBox();
            this.goldFlag2 = new System.Windows.Forms.PictureBox();
            this.goldFlag1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.goldFinalistsButton = new System.Windows.Forms.Button();
            this.silverFinalistsBtn = new System.Windows.Forms.Button();
            this.bronzeFinalistsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.marksDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bronzeFlag2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bronzeFlag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.silverFlag2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.silverFlag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goldFlag2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goldFlag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 25);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 37);
            this.button1.TabIndex = 13;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(478, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(94, 136);
            this.skillCb.Margin = new System.Windows.Forms.Padding(2);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(596, 21);
            this.skillCb.TabIndex = 21;
            this.skillCb.SelectedIndexChanged += new System.EventHandler(this.skillCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 26);
            this.label3.TabIndex = 20;
            this.label3.Text = "Skill:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(300, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 26);
            this.label4.TabIndex = 19;
            this.label4.Text = "View Results";
            // 
            // totalNoOfSessionsLbl
            // 
            this.totalNoOfSessionsLbl.AutoSize = true;
            this.totalNoOfSessionsLbl.BackColor = System.Drawing.SystemColors.Control;
            this.totalNoOfSessionsLbl.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalNoOfSessionsLbl.Location = new System.Drawing.Point(22, 186);
            this.totalNoOfSessionsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalNoOfSessionsLbl.Name = "totalNoOfSessionsLbl";
            this.totalNoOfSessionsLbl.Size = new System.Drawing.Size(255, 26);
            this.totalNoOfSessionsLbl.TabIndex = 22;
            this.totalNoOfSessionsLbl.Text = "Total No. Of Sessions:";
            // 
            // numberOfCompletedSessions
            // 
            this.numberOfCompletedSessions.AutoSize = true;
            this.numberOfCompletedSessions.BackColor = System.Drawing.SystemColors.Control;
            this.numberOfCompletedSessions.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfCompletedSessions.Location = new System.Drawing.Point(329, 186);
            this.numberOfCompletedSessions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numberOfCompletedSessions.Name = "numberOfCompletedSessions";
            this.numberOfCompletedSessions.Size = new System.Drawing.Size(308, 26);
            this.numberOfCompletedSessions.TabIndex = 23;
            this.numberOfCompletedSessions.Text = "No of Completed Sessions:";
            // 
            // marksDGV
            // 
            this.marksDGV.AllowUserToAddRows = false;
            this.marksDGV.AllowUserToDeleteRows = false;
            this.marksDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.marksDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.marksDGV.Location = new System.Drawing.Point(26, 244);
            this.marksDGV.Margin = new System.Windows.Forms.Padding(2);
            this.marksDGV.Name = "marksDGV";
            this.marksDGV.RowHeadersWidth = 51;
            this.marksDGV.RowTemplate.Height = 24;
            this.marksDGV.Size = new System.Drawing.Size(369, 278);
            this.marksDGV.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(425, 244);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Gold:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(425, 326);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Silver:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(425, 407);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Bronze:";
            // 
            // bronzeFlag2
            // 
            this.bronzeFlag2.Location = new System.Drawing.Point(564, 423);
            this.bronzeFlag2.Name = "bronzeFlag2";
            this.bronzeFlag2.Size = new System.Drawing.Size(100, 50);
            this.bronzeFlag2.TabIndex = 33;
            this.bronzeFlag2.TabStop = false;
            // 
            // bronzeFlag1
            // 
            this.bronzeFlag1.Location = new System.Drawing.Point(428, 423);
            this.bronzeFlag1.Name = "bronzeFlag1";
            this.bronzeFlag1.Size = new System.Drawing.Size(100, 50);
            this.bronzeFlag1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bronzeFlag1.TabIndex = 32;
            this.bronzeFlag1.TabStop = false;
            // 
            // silverFlag2
            // 
            this.silverFlag2.Location = new System.Drawing.Point(564, 342);
            this.silverFlag2.Name = "silverFlag2";
            this.silverFlag2.Size = new System.Drawing.Size(100, 50);
            this.silverFlag2.TabIndex = 31;
            this.silverFlag2.TabStop = false;
            // 
            // silverFlag1
            // 
            this.silverFlag1.Location = new System.Drawing.Point(428, 342);
            this.silverFlag1.Name = "silverFlag1";
            this.silverFlag1.Size = new System.Drawing.Size(100, 50);
            this.silverFlag1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.silverFlag1.TabIndex = 30;
            this.silverFlag1.TabStop = false;
            // 
            // goldFlag2
            // 
            this.goldFlag2.Location = new System.Drawing.Point(564, 260);
            this.goldFlag2.Name = "goldFlag2";
            this.goldFlag2.Size = new System.Drawing.Size(100, 50);
            this.goldFlag2.TabIndex = 29;
            this.goldFlag2.TabStop = false;
            // 
            // goldFlag1
            // 
            this.goldFlag1.Location = new System.Drawing.Point(428, 260);
            this.goldFlag1.Name = "goldFlag1";
            this.goldFlag1.Size = new System.Drawing.Size(100, 50);
            this.goldFlag1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.goldFlag1.TabIndex = 28;
            this.goldFlag1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(1, 538);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(698, 43);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(1, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(698, 80);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // goldFinalistsButton
            // 
            this.goldFinalistsButton.Location = new System.Drawing.Point(453, 272);
            this.goldFinalistsButton.Name = "goldFinalistsButton";
            this.goldFinalistsButton.Size = new System.Drawing.Size(184, 23);
            this.goldFinalistsButton.TabIndex = 34;
            this.goldFinalistsButton.Text = "See Gold Finalists";
            this.goldFinalistsButton.UseVisualStyleBackColor = true;
            this.goldFinalistsButton.Visible = false;
            this.goldFinalistsButton.Click += new System.EventHandler(this.goldFinalistsButton_Click);
            // 
            // silverFinalistsBtn
            // 
            this.silverFinalistsBtn.Location = new System.Drawing.Point(453, 357);
            this.silverFinalistsBtn.Name = "silverFinalistsBtn";
            this.silverFinalistsBtn.Size = new System.Drawing.Size(184, 23);
            this.silverFinalistsBtn.TabIndex = 35;
            this.silverFinalistsBtn.Text = "See Silver Finalists";
            this.silverFinalistsBtn.UseVisualStyleBackColor = true;
            this.silverFinalistsBtn.Visible = false;
            this.silverFinalistsBtn.Click += new System.EventHandler(this.silverFinalistsBtn_Click);
            // 
            // bronzeFinalistsButton
            // 
            this.bronzeFinalistsButton.Location = new System.Drawing.Point(453, 438);
            this.bronzeFinalistsButton.Name = "bronzeFinalistsButton";
            this.bronzeFinalistsButton.Size = new System.Drawing.Size(184, 23);
            this.bronzeFinalistsButton.TabIndex = 36;
            this.bronzeFinalistsButton.Text = "See BronzeFinalists";
            this.bronzeFinalistsButton.UseVisualStyleBackColor = true;
            this.bronzeFinalistsButton.Visible = false;
            this.bronzeFinalistsButton.Click += new System.EventHandler(this.bronzeFinalistsButton_Click);
            // 
            // ViewResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 582);
            this.Controls.Add(this.bronzeFinalistsButton);
            this.Controls.Add(this.silverFinalistsBtn);
            this.Controls.Add(this.goldFinalistsButton);
            this.Controls.Add(this.bronzeFlag2);
            this.Controls.Add(this.bronzeFlag1);
            this.Controls.Add(this.silverFlag2);
            this.Controls.Add(this.silverFlag1);
            this.Controls.Add(this.goldFlag2);
            this.Controls.Add(this.goldFlag1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.marksDGV);
            this.Controls.Add(this.numberOfCompletedSessions);
            this.Controls.Add(this.totalNoOfSessionsLbl);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewResultsForm";
            this.Text = "ViewResultsForm";
            this.Load += new System.EventHandler(this.ViewResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.marksDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bronzeFlag2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bronzeFlag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.silverFlag2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.silverFlag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goldFlag2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goldFlag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox skillCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label totalNoOfSessionsLbl;
        private System.Windows.Forms.Label numberOfCompletedSessions;
        private System.Windows.Forms.DataGridView marksDGV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox goldFlag1;
        private System.Windows.Forms.PictureBox goldFlag2;
        private System.Windows.Forms.PictureBox silverFlag2;
        private System.Windows.Forms.PictureBox silverFlag1;
        private System.Windows.Forms.PictureBox bronzeFlag2;
        private System.Windows.Forms.PictureBox bronzeFlag1;
        private System.Windows.Forms.Button goldFinalistsButton;
        private System.Windows.Forms.Button silverFinalistsBtn;
        private System.Windows.Forms.Button bronzeFinalistsButton;
    }
}