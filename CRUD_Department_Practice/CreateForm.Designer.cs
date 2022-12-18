namespace CRUD_Department_Practice
{
    partial class CreateForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.BtnCreate = new System.Windows.Forms.Button();
            this.lbl3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDepartmentID = new System.Windows.Forms.Label();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.tbDepartmentName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 38);
            this.button2.TabIndex = 14;
            this.button2.Text = "Close Form";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // BtnCreate
            // 
            this.BtnCreate.Location = new System.Drawing.Point(16, 156);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(124, 38);
            this.BtnCreate.TabIndex = 13;
            this.BtnCreate.Text = "Create Entry";
            this.BtnCreate.UseVisualStyleBackColor = true;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(13, 112);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(171, 17);
            this.lbl3.TabIndex = 12;
            this.lbl3.Text = "Department Group Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Department Name:";
            // 
            // lblDepartmentID
            // 
            this.lblDepartmentID.AutoSize = true;
            this.lblDepartmentID.Location = new System.Drawing.Point(13, 21);
            this.lblDepartmentID.Name = "lblDepartmentID";
            this.lblDepartmentID.Size = new System.Drawing.Size(103, 17);
            this.lblDepartmentID.TabIndex = 10;
            this.lblDepartmentID.Text = "Department ID:";
            // 
            // tbGroupName
            // 
            this.tbGroupName.Location = new System.Drawing.Point(190, 107);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(598, 22);
            this.tbGroupName.TabIndex = 9;
            // 
            // tbDepartmentName
            // 
            this.tbDepartmentName.Location = new System.Drawing.Point(190, 63);
            this.tbDepartmentName.Name = "tbDepartmentName";
            this.tbDepartmentName.Size = new System.Drawing.Size(598, 22);
            this.tbDepartmentName.TabIndex = 8;
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 203);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtnCreate);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDepartmentID);
            this.Controls.Add(this.tbGroupName);
            this.Controls.Add(this.tbDepartmentName);
            this.Name = "CreateForm";
            this.Text = "CreateForm";
            this.Load += new System.EventHandler(this.CreateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnCreate;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDepartmentID;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.TextBox tbDepartmentName;
    }
}