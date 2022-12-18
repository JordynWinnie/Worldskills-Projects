namespace TPQR_Session5_9_9_2020
{
    partial class AssignSeating
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
            this.label2 = new System.Windows.Forms.Label();
            this.skilCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.assignedCompLbl = new System.Windows.Forms.Label();
            this.unassignedLbl = new System.Windows.Forms.Label();
            this.assignedDGV = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.unassignedListBox = new System.Windows.Forms.ListBox();
            this.randomAssignBtn = new System.Windows.Forms.Button();
            this.swapSeatsBtn = new System.Windows.Forms.Button();
            this.manualAssignmentBtn = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.shadowTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.assignedDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shadowTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(309, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 29);
            this.label2.TabIndex = 53;
            this.label2.Text = "Calculate Bonus:";
            // 
            // skilCb
            // 
            this.skilCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skilCb.FormattingEnabled = true;
            this.skilCb.Location = new System.Drawing.Point(176, 148);
            this.skilCb.Name = "skilCb";
            this.skilCb.Size = new System.Drawing.Size(732, 24);
            this.skilCb.TabIndex = 52;
            this.skilCb.SelectedIndexChanged += new System.EventHandler(this.skilCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(115, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 25);
            this.label3.TabIndex = 51;
            this.label3.Text = "Skill:";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(25, 17);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(186, 51);
            this.backBtn.TabIndex = 50;
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
            this.label1.Location = new System.Drawing.Point(743, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 49;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // assignedCompLbl
            // 
            this.assignedCompLbl.AutoSize = true;
            this.assignedCompLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignedCompLbl.Location = new System.Drawing.Point(115, 219);
            this.assignedCompLbl.Name = "assignedCompLbl";
            this.assignedCompLbl.Size = new System.Drawing.Size(210, 25);
            this.assignedCompLbl.TabIndex = 54;
            this.assignedCompLbl.Text = "Assigned Competitors:";
            // 
            // unassignedLbl
            // 
            this.unassignedLbl.AutoSize = true;
            this.unassignedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unassignedLbl.Location = new System.Drawing.Point(608, 219);
            this.unassignedLbl.Name = "unassignedLbl";
            this.unassignedLbl.Size = new System.Drawing.Size(232, 25);
            this.unassignedLbl.TabIndex = 55;
            this.unassignedLbl.Text = "Unassigned Competitors:";
            // 
            // assignedDGV
            // 
            this.assignedDGV.AllowUserToAddRows = false;
            this.assignedDGV.AllowUserToDeleteRows = false;
            this.assignedDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.assignedDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assignedDGV.Location = new System.Drawing.Point(45, 291);
            this.assignedDGV.Name = "assignedDGV";
            this.assignedDGV.RowHeadersWidth = 51;
            this.assignedDGV.RowTemplate.Height = 24;
            this.assignedDGV.Size = new System.Drawing.Size(437, 357);
            this.assignedDGV.TabIndex = 56;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 670);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1029, 50);
            this.pictureBox2.TabIndex = 48;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1029, 83);
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(488, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 25);
            this.label6.TabIndex = 57;
            this.label6.Text = "Unassigned:";
            // 
            // unassignedListBox
            // 
            this.unassignedListBox.FormattingEnabled = true;
            this.unassignedListBox.ItemHeight = 16;
            this.unassignedListBox.Location = new System.Drawing.Point(488, 319);
            this.unassignedListBox.Name = "unassignedListBox";
            this.unassignedListBox.Size = new System.Drawing.Size(512, 196);
            this.unassignedListBox.TabIndex = 58;
            // 
            // randomAssignBtn
            // 
            this.randomAssignBtn.Location = new System.Drawing.Point(488, 521);
            this.randomAssignBtn.Name = "randomAssignBtn";
            this.randomAssignBtn.Size = new System.Drawing.Size(250, 51);
            this.randomAssignBtn.TabIndex = 59;
            this.randomAssignBtn.Text = "Random Assign";
            this.randomAssignBtn.UseVisualStyleBackColor = true;
            this.randomAssignBtn.Click += new System.EventHandler(this.randomAssignBtn_Click);
            // 
            // swapSeatsBtn
            // 
            this.swapSeatsBtn.Location = new System.Drawing.Point(489, 591);
            this.swapSeatsBtn.Name = "swapSeatsBtn";
            this.swapSeatsBtn.Size = new System.Drawing.Size(250, 51);
            this.swapSeatsBtn.TabIndex = 60;
            this.swapSeatsBtn.Text = "Swap Seats";
            this.swapSeatsBtn.UseVisualStyleBackColor = true;
            this.swapSeatsBtn.Click += new System.EventHandler(this.swapSeatsBtn_Click);
            // 
            // manualAssignmentBtn
            // 
            this.manualAssignmentBtn.Location = new System.Drawing.Point(749, 521);
            this.manualAssignmentBtn.Name = "manualAssignmentBtn";
            this.manualAssignmentBtn.Size = new System.Drawing.Size(251, 51);
            this.manualAssignmentBtn.TabIndex = 61;
            this.manualAssignmentBtn.Text = "Manual Assignment";
            this.manualAssignmentBtn.UseVisualStyleBackColor = true;
            this.manualAssignmentBtn.Click += new System.EventHandler(this.manualAssignmentBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(749, 591);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(251, 51);
            this.confirmBtn.TabIndex = 62;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // shadowTable
            // 
            this.shadowTable.AllowUserToAddRows = false;
            this.shadowTable.AllowUserToDeleteRows = false;
            this.shadowTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.shadowTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shadowTable.Location = new System.Drawing.Point(1068, 291);
            this.shadowTable.Name = "shadowTable";
            this.shadowTable.RowHeadersWidth = 51;
            this.shadowTable.RowTemplate.Height = 24;
            this.shadowTable.Size = new System.Drawing.Size(437, 357);
            this.shadowTable.TabIndex = 63;
            // 
            // AssignSeating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 720);
            this.Controls.Add(this.shadowTable);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.manualAssignmentBtn);
            this.Controls.Add(this.swapSeatsBtn);
            this.Controls.Add(this.randomAssignBtn);
            this.Controls.Add(this.unassignedListBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.assignedDGV);
            this.Controls.Add(this.unassignedLbl);
            this.Controls.Add(this.assignedCompLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.skilCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AssignSeating";
            this.Text = "AssignSeating";
            this.Load += new System.EventHandler(this.AssignSeating_Load);
            ((System.ComponentModel.ISupportInitialize)(this.assignedDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shadowTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox skilCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label assignedCompLbl;
        private System.Windows.Forms.Label unassignedLbl;
        private System.Windows.Forms.DataGridView assignedDGV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox unassignedListBox;
        private System.Windows.Forms.Button randomAssignBtn;
        private System.Windows.Forms.Button swapSeatsBtn;
        private System.Windows.Forms.Button manualAssignmentBtn;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.DataGridView shadowTable;
    }
}