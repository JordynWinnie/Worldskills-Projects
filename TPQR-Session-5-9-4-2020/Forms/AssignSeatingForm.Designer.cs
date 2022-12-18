namespace TPQR_Session5_9_4_2020
{
    partial class AssignSeatingForm
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
            this.seatingDGV = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.skillCb = new System.Windows.Forms.ComboBox();
            this.assignedLbl = new System.Windows.Forms.Label();
            this.unassignedLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.unassignedListBox = new System.Windows.Forms.ListBox();
            this.randomAssign = new System.Windows.Forms.Button();
            this.manualAssignBtn = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.swapSeatBtn = new System.Windows.Forms.Button();
            this.shadowTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seatingDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shadowTable)).BeginInit();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 11);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(192, 47);
            this.backBtn.TabIndex = 14;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Assign Seating";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(578, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 50);
            this.label1.TabIndex = 12;
            this.label1.Text = "ASEAN Skills 2020\r\n26 - 28 Jul 2020\r\n";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(3, 583);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(795, 68);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(3, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(795, 80);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // seatingDGV
            // 
            this.seatingDGV.AllowUserToAddRows = false;
            this.seatingDGV.AllowUserToDeleteRows = false;
            this.seatingDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.seatingDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.seatingDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.seatingDGV.Location = new System.Drawing.Point(27, 212);
            this.seatingDGV.Name = "seatingDGV";
            this.seatingDGV.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.seatingDGV.Size = new System.Drawing.Size(351, 351);
            this.seatingDGV.TabIndex = 15;
            this.seatingDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seatingDGV_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(109, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Skill:";
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(174, 142);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(533, 21);
            this.skillCb.TabIndex = 17;
            this.skillCb.SelectedIndexChanged += new System.EventHandler(this.skillCb_SelectedIndexChanged);
            // 
            // assignedLbl
            // 
            this.assignedLbl.AutoSize = true;
            this.assignedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignedLbl.Location = new System.Drawing.Point(99, 184);
            this.assignedLbl.Name = "assignedLbl";
            this.assignedLbl.Size = new System.Drawing.Size(228, 25);
            this.assignedLbl.TabIndex = 18;
            this.assignedLbl.Text = "Assigned Competitors:";
            // 
            // unassignedLbl
            // 
            this.unassignedLbl.AutoSize = true;
            this.unassignedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unassignedLbl.Location = new System.Drawing.Point(435, 184);
            this.unassignedLbl.Name = "unassignedLbl";
            this.unassignedLbl.Size = new System.Drawing.Size(253, 25);
            this.unassignedLbl.TabIndex = 19;
            this.unassignedLbl.Text = "Unassigned Competitors:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(436, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Unassigned:";
            // 
            // unassignedListBox
            // 
            this.unassignedListBox.FormattingEnabled = true;
            this.unassignedListBox.Location = new System.Drawing.Point(440, 281);
            this.unassignedListBox.Name = "unassignedListBox";
            this.unassignedListBox.Size = new System.Drawing.Size(332, 95);
            this.unassignedListBox.TabIndex = 21;
            // 
            // randomAssign
            // 
            this.randomAssign.Location = new System.Drawing.Point(440, 404);
            this.randomAssign.Name = "randomAssign";
            this.randomAssign.Size = new System.Drawing.Size(111, 56);
            this.randomAssign.TabIndex = 22;
            this.randomAssign.Text = "Randomly Assign";
            this.randomAssign.UseVisualStyleBackColor = true;
            this.randomAssign.Click += new System.EventHandler(this.randomAssign_Click);
            // 
            // manualAssignBtn
            // 
            this.manualAssignBtn.Location = new System.Drawing.Point(555, 404);
            this.manualAssignBtn.Name = "manualAssignBtn";
            this.manualAssignBtn.Size = new System.Drawing.Size(111, 56);
            this.manualAssignBtn.TabIndex = 23;
            this.manualAssignBtn.Text = "Manually Assign";
            this.manualAssignBtn.UseVisualStyleBackColor = true;
            this.manualAssignBtn.Click += new System.EventHandler(this.manualAssignBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(555, 472);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(111, 56);
            this.confirmBtn.TabIndex = 24;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // swapSeatBtn
            // 
            this.swapSeatBtn.Location = new System.Drawing.Point(440, 472);
            this.swapSeatBtn.Name = "swapSeatBtn";
            this.swapSeatBtn.Size = new System.Drawing.Size(111, 56);
            this.swapSeatBtn.TabIndex = 25;
            this.swapSeatBtn.Text = "Swap Seats";
            this.swapSeatBtn.UseVisualStyleBackColor = true;
            this.swapSeatBtn.Click += new System.EventHandler(this.swapSeatBtn_Click);
            // 
            // shadowTable
            // 
            this.shadowTable.AllowUserToAddRows = false;
            this.shadowTable.AllowUserToDeleteRows = false;
            this.shadowTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.shadowTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.shadowTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shadowTable.Location = new System.Drawing.Point(859, 151);
            this.shadowTable.Name = "shadowTable";
            this.shadowTable.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.shadowTable.Size = new System.Drawing.Size(333, 388);
            this.shadowTable.TabIndex = 26;
            // 
            // AssignSeatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 653);
            this.Controls.Add(this.shadowTable);
            this.Controls.Add(this.swapSeatBtn);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.manualAssignBtn);
            this.Controls.Add(this.randomAssign);
            this.Controls.Add(this.unassignedListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.unassignedLbl);
            this.Controls.Add(this.assignedLbl);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.seatingDGV);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AssignSeatingForm";
            this.Text = "AssignSeatingForm";
            this.Load += new System.EventHandler(this.AssignSeatingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seatingDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shadowTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView seatingDGV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox skillCb;
        private System.Windows.Forms.Label assignedLbl;
        private System.Windows.Forms.Label unassignedLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox unassignedListBox;
        private System.Windows.Forms.Button randomAssign;
        private System.Windows.Forms.Button manualAssignBtn;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button swapSeatBtn;
        private System.Windows.Forms.DataGridView shadowTable;
    }
}