namespace TPQR_Paper1_5_15_2020
{
    partial class AddResourceForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.allocatedSkills = new System.Windows.Forms.CheckedListBox();
            this.addResourceBtn = new System.Windows.Forms.Button();
            this.resourceNameTb = new System.Windows.Forms.TextBox();
            this.quantityTb = new System.Windows.Forms.TextBox();
            this.resourceTypeCombobox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 38);
            this.button1.TabIndex = 11;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(470, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "ASEAN Skills 2020 ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(801, 101);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Add New Resource";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Resource Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Resource Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Availible Quantity:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Allocated Skills:";
            // 
            // allocatedSkills
            // 
            this.allocatedSkills.FormattingEnabled = true;
            this.allocatedSkills.Location = new System.Drawing.Point(206, 286);
            this.allocatedSkills.Name = "allocatedSkills";
            this.allocatedSkills.Size = new System.Drawing.Size(456, 106);
            this.allocatedSkills.TabIndex = 18;
            // 
            // addResourceBtn
            // 
            this.addResourceBtn.Location = new System.Drawing.Point(347, 432);
            this.addResourceBtn.Name = "addResourceBtn";
            this.addResourceBtn.Size = new System.Drawing.Size(113, 38);
            this.addResourceBtn.TabIndex = 19;
            this.addResourceBtn.Text = "Add Resource";
            this.addResourceBtn.UseVisualStyleBackColor = true;
            this.addResourceBtn.Click += new System.EventHandler(this.addResourceBtn_Click);
            // 
            // resourceNameTb
            // 
            this.resourceNameTb.Location = new System.Drawing.Point(206, 193);
            this.resourceNameTb.Name = "resourceNameTb";
            this.resourceNameTb.Size = new System.Drawing.Size(456, 22);
            this.resourceNameTb.TabIndex = 20;
            // 
            // quantityTb
            // 
            this.quantityTb.Location = new System.Drawing.Point(206, 258);
            this.quantityTb.Name = "quantityTb";
            this.quantityTb.Size = new System.Drawing.Size(456, 22);
            this.quantityTb.TabIndex = 22;
            // 
            // resourceTypeCombobox
            // 
            this.resourceTypeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resourceTypeCombobox.FormattingEnabled = true;
            this.resourceTypeCombobox.Location = new System.Drawing.Point(206, 225);
            this.resourceTypeCombobox.Name = "resourceTypeCombobox";
            this.resourceTypeCombobox.Size = new System.Drawing.Size(456, 24);
            this.resourceTypeCombobox.TabIndex = 23;
            // 
            // AddResourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.resourceTypeCombobox);
            this.Controls.Add(this.quantityTb);
            this.Controls.Add(this.resourceNameTb);
            this.Controls.Add(this.addResourceBtn);
            this.Controls.Add(this.allocatedSkills);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AddResourceForm";
            this.Text = "AddResourceForm";
            this.Load += new System.EventHandler(this.AddResourceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox allocatedSkills;
        private System.Windows.Forms.Button addResourceBtn;
        private System.Windows.Forms.TextBox resourceNameTb;
        private System.Windows.Forms.TextBox quantityTb;
        private System.Windows.Forms.ComboBox resourceTypeCombobox;
    }
}