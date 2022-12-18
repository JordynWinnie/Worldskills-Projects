namespace NTUPracticeMock2
{
    partial class ManageHumanResources
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
            this.label1 = new System.Windows.Forms.Label();
            this.employeeGrid = new System.Windows.Forms.DataGridView();
            this.ManageStaffBtn = new System.Windows.Forms.Button();
            this.AddNewStaffBtn = new System.Windows.Forms.Button();
            this.ViewExitedStaffBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.employeeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee List";
            // 
            // employeeGrid
            // 
            this.employeeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeGrid.Location = new System.Drawing.Point(16, 34);
            this.employeeGrid.Name = "employeeGrid";
            this.employeeGrid.RowHeadersWidth = 51;
            this.employeeGrid.RowTemplate.Height = 24;
            this.employeeGrid.Size = new System.Drawing.Size(1162, 404);
            this.employeeGrid.TabIndex = 1;
            this.employeeGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employeeGrid_CellClick);
            // 
            // ManageStaffBtn
            // 
            this.ManageStaffBtn.Location = new System.Drawing.Point(17, 459);
            this.ManageStaffBtn.Name = "ManageStaffBtn";
            this.ManageStaffBtn.Size = new System.Drawing.Size(148, 42);
            this.ManageStaffBtn.TabIndex = 2;
            this.ManageStaffBtn.Text = "Manage Staff";
            this.ManageStaffBtn.UseVisualStyleBackColor = true;
            this.ManageStaffBtn.Click += new System.EventHandler(this.ManageStaffBtn_Click);
            // 
            // AddNewStaffBtn
            // 
            this.AddNewStaffBtn.Location = new System.Drawing.Point(171, 459);
            this.AddNewStaffBtn.Name = "AddNewStaffBtn";
            this.AddNewStaffBtn.Size = new System.Drawing.Size(154, 42);
            this.AddNewStaffBtn.TabIndex = 3;
            this.AddNewStaffBtn.Text = "Add New Staff";
            this.AddNewStaffBtn.UseVisualStyleBackColor = true;
            this.AddNewStaffBtn.Visible = false;
            this.AddNewStaffBtn.Click += new System.EventHandler(this.AddNewStaffBtn_Click);
            // 
            // ViewExitedStaffBtn
            // 
            this.ViewExitedStaffBtn.Location = new System.Drawing.Point(331, 459);
            this.ViewExitedStaffBtn.Name = "ViewExitedStaffBtn";
            this.ViewExitedStaffBtn.Size = new System.Drawing.Size(166, 42);
            this.ViewExitedStaffBtn.TabIndex = 4;
            this.ViewExitedStaffBtn.Text = "View Exited Staff";
            this.ViewExitedStaffBtn.UseVisualStyleBackColor = true;
            this.ViewExitedStaffBtn.Visible = false;
            this.ViewExitedStaffBtn.Click += new System.EventHandler(this.ViewExitedStaffBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(604, 472);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // ManageHumanResources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 526);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ViewExitedStaffBtn);
            this.Controls.Add(this.AddNewStaffBtn);
            this.Controls.Add(this.ManageStaffBtn);
            this.Controls.Add(this.employeeGrid);
            this.Controls.Add(this.label1);
            this.Name = "ManageHumanResources";
            this.Text = "ManageHumanResources";
            this.Load += new System.EventHandler(this.ManageHumanResources_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeeGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView employeeGrid;
        private System.Windows.Forms.Button ManageStaffBtn;
        private System.Windows.Forms.Button AddNewStaffBtn;
        private System.Windows.Forms.Button ViewExitedStaffBtn;
        private System.Windows.Forms.Label label2;
    }
}