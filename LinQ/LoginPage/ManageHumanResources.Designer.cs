namespace LoginPage
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
            this.components = new System.ComponentModel.Container();
            this.adventureWorks2017DataSet = new LoginPage.AdventureWorks2017DataSet();
            this.vEmployeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vEmployeeTableAdapter = new LoginPage.AdventureWorks2017DataSetTableAdapters.vEmployeeTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.employeeList = new System.Windows.Forms.DataGridView();
            this.manageStaffBtn = new System.Windows.Forms.Button();
            this.addNewStaffBtn = new System.Windows.Forms.Button();
            this.viewExitedStaffBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks2017DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEmployeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeList)).BeginInit();
            this.SuspendLayout();
            // 
            // adventureWorks2017DataSet
            // 
            this.adventureWorks2017DataSet.DataSetName = "AdventureWorks2017DataSet";
            this.adventureWorks2017DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vEmployeeBindingSource
            // 
            this.vEmployeeBindingSource.DataMember = "vEmployee";
            this.vEmployeeBindingSource.DataSource = this.adventureWorks2017DataSet;
            // 
            // vEmployeeTableAdapter
            // 
            this.vEmployeeTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Employee List:";
            // 
            // employeeList
            // 
            this.employeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeList.Location = new System.Drawing.Point(9, 29);
            this.employeeList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.employeeList.Name = "employeeList";
            this.employeeList.RowHeadersWidth = 51;
            this.employeeList.RowTemplate.Height = 24;
            this.employeeList.Size = new System.Drawing.Size(928, 465);
            this.employeeList.TabIndex = 3;
            this.employeeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employeeList_CellClick);
            // 
            // manageStaffBtn
            // 
            this.manageStaffBtn.Location = new System.Drawing.Point(9, 498);
            this.manageStaffBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.manageStaffBtn.Name = "manageStaffBtn";
            this.manageStaffBtn.Size = new System.Drawing.Size(130, 39);
            this.manageStaffBtn.TabIndex = 4;
            this.manageStaffBtn.Text = "Manage Staff";
            this.manageStaffBtn.UseVisualStyleBackColor = true;
            this.manageStaffBtn.Click += new System.EventHandler(this.manageStaffBtn_Click);
            // 
            // addNewStaffBtn
            // 
            this.addNewStaffBtn.Location = new System.Drawing.Point(143, 498);
            this.addNewStaffBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addNewStaffBtn.Name = "addNewStaffBtn";
            this.addNewStaffBtn.Size = new System.Drawing.Size(130, 39);
            this.addNewStaffBtn.TabIndex = 5;
            this.addNewStaffBtn.Text = "Add New Staff";
            this.addNewStaffBtn.UseVisualStyleBackColor = true;
            this.addNewStaffBtn.Visible = false;
            this.addNewStaffBtn.Click += new System.EventHandler(this.addNewStaffBtn_Click);
            // 
            // viewExitedStaffBtn
            // 
            this.viewExitedStaffBtn.Location = new System.Drawing.Point(278, 498);
            this.viewExitedStaffBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.viewExitedStaffBtn.Name = "viewExitedStaffBtn";
            this.viewExitedStaffBtn.Size = new System.Drawing.Size(130, 39);
            this.viewExitedStaffBtn.TabIndex = 6;
            this.viewExitedStaffBtn.Text = "View Exited Staff";
            this.viewExitedStaffBtn.UseVisualStyleBackColor = true;
            this.viewExitedStaffBtn.Visible = false;
            this.viewExitedStaffBtn.Click += new System.EventHandler(this.viewExitedStaffBtn_Click);
            // 
            // ManageHumanResources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 547);
            this.Controls.Add(this.viewExitedStaffBtn);
            this.Controls.Add(this.addNewStaffBtn);
            this.Controls.Add(this.manageStaffBtn);
            this.Controls.Add(this.employeeList);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ManageHumanResources";
            this.Text = "Human Resource";
            this.Load += new System.EventHandler(this.ManageHumanResources_Load);
            ((System.ComponentModel.ISupportInitialize)(this.adventureWorks2017DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vEmployeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AdventureWorks2017DataSet adventureWorks2017DataSet;
        private System.Windows.Forms.BindingSource vEmployeeBindingSource;
        private AdventureWorks2017DataSetTableAdapters.vEmployeeTableAdapter vEmployeeTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView employeeList;
        private System.Windows.Forms.Button manageStaffBtn;
        private System.Windows.Forms.Button addNewStaffBtn;
        private System.Windows.Forms.Button viewExitedStaffBtn;
    }
}