namespace CRUD_Department_Practice
{
    partial class ReadForm
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
            this.DepartmentData = new System.Windows.Forms.DataGridView();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.departmentCb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentData)).BeginInit();
            this.SuspendLayout();
            // 
            // DepartmentData
            // 
            this.DepartmentData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DepartmentData.Location = new System.Drawing.Point(13, 13);
            this.DepartmentData.Name = "DepartmentData";
            this.DepartmentData.RowHeadersWidth = 51;
            this.DepartmentData.RowTemplate.Height = 24;
            this.DepartmentData.Size = new System.Drawing.Size(775, 374);
            this.DepartmentData.TabIndex = 0;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(13, 415);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(158, 23);
            this.BtnUpdate.TabIndex = 1;
            this.BtnUpdate.Text = "Refresh";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(190, 415);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(158, 23);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "Close Form";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // departmentCb
            // 
            this.departmentCb.FormattingEnabled = true;
            this.departmentCb.Location = new System.Drawing.Point(809, 42);
            this.departmentCb.Name = "departmentCb";
            this.departmentCb.Size = new System.Drawing.Size(461, 24);
            this.departmentCb.TabIndex = 3;
            // 
            // ReadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 450);
            this.Controls.Add(this.departmentCb);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.DepartmentData);
            this.Name = "ReadForm";
            this.Text = "ReadForm";
            this.Load += new System.EventHandler(this.ReadForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DepartmentData;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.ComboBox departmentCb;
    }
}