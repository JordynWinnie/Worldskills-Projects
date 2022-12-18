namespace TPQR_Paper5_9_23_2020
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
            this.backBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.skillCb = new System.Windows.Forms.ComboBox();
            this.assignedLbl = new System.Windows.Forms.Label();
            this.unassignedLbl = new System.Windows.Forms.Label();
            this.seatAssignmentDGV = new System.Windows.Forms.DataGridView();
            this.unassignedList = new System.Windows.Forms.ListBox();
            this.RandomAsgn = new System.Windows.Forms.Button();
            this.manualAssign = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.swapSeatBtn = new System.Windows.Forms.Button();
            this.shadowDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seatAssignmentDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shadowDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(22, 25);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(89, 36);
            this.backBtn.TabIndex = 25;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(397, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 32);
            this.label2.TabIndex = 24;
            this.label2.Text = "Assign Seating";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(274, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 36);
            this.label1.TabIndex = 23;
            this.label1.Text = "ASEAN Skills 2020";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 550);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1005, 50);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1005, 80);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(252, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Skill:";
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(312, 142);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(475, 24);
            this.skillCb.TabIndex = 27;
            // 
            // assignedLbl
            // 
            this.assignedLbl.AutoSize = true;
            this.assignedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignedLbl.Location = new System.Drawing.Point(105, 200);
            this.assignedLbl.Name = "assignedLbl";
            this.assignedLbl.Size = new System.Drawing.Size(226, 25);
            this.assignedLbl.TabIndex = 28;
            this.assignedLbl.Text = "Assigned Competitors: 0";
            // 
            // unassignedLbl
            // 
            this.unassignedLbl.AutoSize = true;
            this.unassignedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unassignedLbl.Location = new System.Drawing.Point(620, 200);
            this.unassignedLbl.Name = "unassignedLbl";
            this.unassignedLbl.Size = new System.Drawing.Size(248, 25);
            this.unassignedLbl.TabIndex = 29;
            this.unassignedLbl.Text = "Unassigned Competitors: 0";
            // 
            // seatAssignmentDGV
            // 
            this.seatAssignmentDGV.AllowUserToAddRows = false;
            this.seatAssignmentDGV.AllowUserToDeleteRows = false;
            this.seatAssignmentDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.seatAssignmentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.seatAssignmentDGV.Location = new System.Drawing.Point(65, 228);
            this.seatAssignmentDGV.Name = "seatAssignmentDGV";
            this.seatAssignmentDGV.RowHeadersWidth = 51;
            this.seatAssignmentDGV.RowTemplate.Height = 24;
            this.seatAssignmentDGV.Size = new System.Drawing.Size(419, 304);
            this.seatAssignmentDGV.TabIndex = 30;
            // 
            // unassignedList
            // 
            this.unassignedList.FormattingEnabled = true;
            this.unassignedList.ItemHeight = 16;
            this.unassignedList.Location = new System.Drawing.Point(541, 228);
            this.unassignedList.Name = "unassignedList";
            this.unassignedList.Size = new System.Drawing.Size(403, 180);
            this.unassignedList.TabIndex = 31;
            // 
            // RandomAsgn
            // 
            this.RandomAsgn.Location = new System.Drawing.Point(625, 427);
            this.RandomAsgn.Name = "RandomAsgn";
            this.RandomAsgn.Size = new System.Drawing.Size(114, 48);
            this.RandomAsgn.TabIndex = 32;
            this.RandomAsgn.Text = "Randomly Assign";
            this.RandomAsgn.UseVisualStyleBackColor = true;
            this.RandomAsgn.Click += new System.EventHandler(this.RandomAsgn_Click);
            // 
            // manualAssign
            // 
            this.manualAssign.Location = new System.Drawing.Point(745, 427);
            this.manualAssign.Name = "manualAssign";
            this.manualAssign.Size = new System.Drawing.Size(123, 48);
            this.manualAssign.TabIndex = 35;
            this.manualAssign.Text = "Manually Assign";
            this.manualAssign.UseVisualStyleBackColor = true;
            this.manualAssign.Click += new System.EventHandler(this.manualAssign_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(745, 481);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(123, 51);
            this.confirmBtn.TabIndex = 37;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // swapSeatBtn
            // 
            this.swapSeatBtn.Location = new System.Drawing.Point(625, 481);
            this.swapSeatBtn.Name = "swapSeatBtn";
            this.swapSeatBtn.Size = new System.Drawing.Size(114, 51);
            this.swapSeatBtn.TabIndex = 36;
            this.swapSeatBtn.Text = "Swap Seats";
            this.swapSeatBtn.UseVisualStyleBackColor = true;
            this.swapSeatBtn.Click += new System.EventHandler(this.swapSeatBtn_Click);
            // 
            // shadowDGV
            // 
            this.shadowDGV.AllowUserToAddRows = false;
            this.shadowDGV.AllowUserToDeleteRows = false;
            this.shadowDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.shadowDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shadowDGV.Location = new System.Drawing.Point(874, 427);
            this.shadowDGV.Name = "shadowDGV";
            this.shadowDGV.RowHeadersWidth = 51;
            this.shadowDGV.RowTemplate.Height = 24;
            this.shadowDGV.Size = new System.Drawing.Size(70, 92);
            this.shadowDGV.TabIndex = 38;
            // 
            // AssignSeating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 600);
            this.Controls.Add(this.shadowDGV);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.swapSeatBtn);
            this.Controls.Add(this.manualAssign);
            this.Controls.Add(this.RandomAsgn);
            this.Controls.Add(this.unassignedList);
            this.Controls.Add(this.seatAssignmentDGV);
            this.Controls.Add(this.unassignedLbl);
            this.Controls.Add(this.assignedLbl);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AssignSeating";
            this.Text = "AssignSeating";
            this.Load += new System.EventHandler(this.AssignSeating_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seatAssignmentDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shadowDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox skillCb;
        private System.Windows.Forms.Label assignedLbl;
        private System.Windows.Forms.Label unassignedLbl;
        private System.Windows.Forms.DataGridView seatAssignmentDGV;
        private System.Windows.Forms.ListBox unassignedList;
        private System.Windows.Forms.Button RandomAsgn;
        private System.Windows.Forms.Button manualAssign;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button swapSeatBtn;
        private System.Windows.Forms.DataGridView shadowDGV;
    }
}