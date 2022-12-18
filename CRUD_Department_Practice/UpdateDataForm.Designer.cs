namespace CRUD_Department_Practice
{
    partial class UpdateDataForm
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
            this.tbDepartmentName = new System.Windows.Forms.TextBox();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.lblDepartmentID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDepartmentName
            // 
            this.tbDepartmentName.Location = new System.Drawing.Point(190, 95);
            this.tbDepartmentName.Name = "tbDepartmentName";
            this.tbDepartmentName.Size = new System.Drawing.Size(598, 22);
            this.tbDepartmentName.TabIndex = 1;
            // 
            // tbGroupName
            // 
            this.tbGroupName.Location = new System.Drawing.Point(190, 139);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(598, 22);
            this.tbGroupName.TabIndex = 2;
            // 
            // lblDepartmentID
            // 
            this.lblDepartmentID.AutoSize = true;
            this.lblDepartmentID.Location = new System.Drawing.Point(13, 41);
            this.lblDepartmentID.Name = "lblDepartmentID";
            this.lblDepartmentID.Size = new System.Drawing.Size(103, 17);
            this.lblDepartmentID.TabIndex = 3;
            this.lblDepartmentID.Text = "Department ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Department Name:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(13, 144);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(171, 17);
            this.lbl3.TabIndex = 5;
            this.lbl3.Text = "Department Group Name:";
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(16, 188);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(124, 38);
            this.BtnUpdate.TabIndex = 6;
            this.BtnUpdate.Text = "UpdateEntry";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 38);
            this.button2.TabIndex = 7;
            this.button2.Text = "Close Form";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UpdateDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 238);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDepartmentID);
            this.Controls.Add(this.tbGroupName);
            this.Controls.Add(this.tbDepartmentName);
            this.Name = "UpdateDataForm";
            this.Text = "UpdateDataForm";
            this.Load += new System.EventHandler(this.UpdateDataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDepartmentName;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.Label lblDepartmentID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button button2;
    }
}