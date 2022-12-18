namespace Session5
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.allocatedDGV = new System.Windows.Forms.DataGridView();
            this.skillCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.assignedCompLbl = new System.Windows.Forms.Label();
            this.unassignedCompLbl = new System.Windows.Forms.Label();
            this.randomlyAssignedBtn = new System.Windows.Forms.Button();
            this.manuallyAssignedBtn = new System.Windows.Forms.Button();
            this.swapSeatsBtn = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.unassignedCompetitorList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allocatedDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 25);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 37);
            this.button1.TabIndex = 28;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 27;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(1, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(599, 80);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(16, -231);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 37);
            this.button2.TabIndex = 32;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Red;
            this.label2.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(380, -231);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 26);
            this.label2.TabIndex = 31;
            this.label2.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(1, 552);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(599, 43);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Red;
            this.pictureBox3.Location = new System.Drawing.Point(1, -257);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(599, 80);
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // allocatedDGV
            // 
            this.allocatedDGV.AllowUserToAddRows = false;
            this.allocatedDGV.AllowUserToDeleteRows = false;
            this.allocatedDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.allocatedDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.allocatedDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allocatedDGV.Location = new System.Drawing.Point(51, 267);
            this.allocatedDGV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.allocatedDGV.Name = "allocatedDGV";
            this.allocatedDGV.RowHeadersWidth = 51;
            this.allocatedDGV.RowTemplate.Height = 24;
            this.allocatedDGV.Size = new System.Drawing.Size(272, 241);
            this.allocatedDGV.TabIndex = 33;
            this.allocatedDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.allocatedDGV_CellClick);
            this.allocatedDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.allocatedDGV_CellContentClick);
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(104, 138);
            this.skillCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(446, 21);
            this.skillCb.TabIndex = 34;
            this.skillCb.SelectedIndexChanged += new System.EventHandler(this.skillCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Skill:";
            // 
            // assignedCompLbl
            // 
            this.assignedCompLbl.AutoSize = true;
            this.assignedCompLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignedCompLbl.Location = new System.Drawing.Point(47, 214);
            this.assignedCompLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.assignedCompLbl.Name = "assignedCompLbl";
            this.assignedCompLbl.Size = new System.Drawing.Size(151, 20);
            this.assignedCompLbl.TabIndex = 36;
            this.assignedCompLbl.Text = "Assign Competitors:";
            // 
            // unassignedCompLbl
            // 
            this.unassignedCompLbl.AutoSize = true;
            this.unassignedCompLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unassignedCompLbl.Location = new System.Drawing.Point(338, 214);
            this.unassignedCompLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.unassignedCompLbl.Name = "unassignedCompLbl";
            this.unassignedCompLbl.Size = new System.Drawing.Size(188, 20);
            this.unassignedCompLbl.TabIndex = 37;
            this.unassignedCompLbl.Text = "Unassigned Competitors:";
            // 
            // randomlyAssignedBtn
            // 
            this.randomlyAssignedBtn.Location = new System.Drawing.Point(342, 479);
            this.randomlyAssignedBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.randomlyAssignedBtn.Name = "randomlyAssignedBtn";
            this.randomlyAssignedBtn.Size = new System.Drawing.Size(100, 29);
            this.randomlyAssignedBtn.TabIndex = 39;
            this.randomlyAssignedBtn.Text = "Randomly Assign";
            this.randomlyAssignedBtn.UseVisualStyleBackColor = true;
            this.randomlyAssignedBtn.Click += new System.EventHandler(this.randomlyAssignedBtn_Click);
            // 
            // manuallyAssignedBtn
            // 
            this.manuallyAssignedBtn.Location = new System.Drawing.Point(447, 479);
            this.manuallyAssignedBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.manuallyAssignedBtn.Name = "manuallyAssignedBtn";
            this.manuallyAssignedBtn.Size = new System.Drawing.Size(103, 29);
            this.manuallyAssignedBtn.TabIndex = 40;
            this.manuallyAssignedBtn.Text = "Manually Assigned";
            this.manuallyAssignedBtn.UseVisualStyleBackColor = true;
            this.manuallyAssignedBtn.Click += new System.EventHandler(this.manuallyAssignedBtn_Click);
            // 
            // swapSeatsBtn
            // 
            this.swapSeatsBtn.Location = new System.Drawing.Point(342, 514);
            this.swapSeatsBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.swapSeatsBtn.Name = "swapSeatsBtn";
            this.swapSeatsBtn.Size = new System.Drawing.Size(100, 34);
            this.swapSeatsBtn.TabIndex = 41;
            this.swapSeatsBtn.Text = "Swap Seats";
            this.swapSeatsBtn.UseVisualStyleBackColor = true;
            this.swapSeatsBtn.Click += new System.EventHandler(this.swapSeatsBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(447, 514);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(103, 34);
            this.confirmBtn.TabIndex = 42;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // unassignedCompetitorList
            // 
            this.unassignedCompetitorList.FormattingEnabled = true;
            this.unassignedCompetitorList.Location = new System.Drawing.Point(342, 267);
            this.unassignedCompetitorList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.unassignedCompetitorList.Name = "unassignedCompetitorList";
            this.unassignedCompetitorList.Size = new System.Drawing.Size(220, 199);
            this.unassignedCompetitorList.TabIndex = 43;
            this.unassignedCompetitorList.SelectedIndexChanged += new System.EventHandler(this.unassignedCompetitorList_SelectedIndexChanged);
            // 
            // AssignSeatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 596);
            this.Controls.Add(this.unassignedCompetitorList);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.swapSeatsBtn);
            this.Controls.Add(this.manuallyAssignedBtn);
            this.Controls.Add(this.randomlyAssignedBtn);
            this.Controls.Add(this.unassignedCompLbl);
            this.Controls.Add(this.assignedCompLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.allocatedDGV);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AssignSeatingForm";
            this.Text = "AssignSeatingForm";
            this.Load += new System.EventHandler(this.AssignSeatingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allocatedDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView allocatedDGV;
        private System.Windows.Forms.ComboBox skillCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label assignedCompLbl;
        private System.Windows.Forms.Label unassignedCompLbl;
        private System.Windows.Forms.Button randomlyAssignedBtn;
        private System.Windows.Forms.Button manuallyAssignedBtn;
        private System.Windows.Forms.Button swapSeatsBtn;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.ListBox unassignedCompetitorList;
    }
}