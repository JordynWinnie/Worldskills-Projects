namespace Session1_JordanKhong.Forms
{
    partial class AddNewResourceForm
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
            this.menuLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.addResourceBtn = new System.Windows.Forms.Button();
            this.resourceNametb = new System.Windows.Forms.TextBox();
            this.quantityTb = new System.Windows.Forms.TextBox();
            this.resourceTypeCb = new System.Windows.Forms.ComboBox();
            this.skillNameCheckList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuLbl
            // 
            this.menuLbl.AutoSize = true;
            this.menuLbl.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuLbl.Location = new System.Drawing.Point(243, 137);
            this.menuLbl.Name = "menuLbl";
            this.menuLbl.Size = new System.Drawing.Size(291, 34);
            this.menuLbl.TabIndex = 1;
            this.menuLbl.Text = "Add New Resource:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Resource Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Available Quantity:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Resource Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Allocated Skills:";
            // 
            // addResourceBtn
            // 
            this.addResourceBtn.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addResourceBtn.Location = new System.Drawing.Point(249, 505);
            this.addResourceBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addResourceBtn.Name = "addResourceBtn";
            this.addResourceBtn.Size = new System.Drawing.Size(293, 46);
            this.addResourceBtn.TabIndex = 6;
            this.addResourceBtn.Text = "Add Resource";
            this.addResourceBtn.UseVisualStyleBackColor = true;
            this.addResourceBtn.Click += new System.EventHandler(this.addResourceBtn_Click);
            // 
            // resourceNametb
            // 
            this.resourceNametb.Location = new System.Drawing.Point(181, 177);
            this.resourceNametb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resourceNametb.Name = "resourceNametb";
            this.resourceNametb.Size = new System.Drawing.Size(564, 22);
            this.resourceNametb.TabIndex = 7;
            // 
            // quantityTb
            // 
            this.quantityTb.Location = new System.Drawing.Point(181, 265);
            this.quantityTb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.quantityTb.Name = "quantityTb";
            this.quantityTb.Size = new System.Drawing.Size(564, 22);
            this.quantityTb.TabIndex = 9;
            this.quantityTb.Text = "0";
            // 
            // resourceTypeCb
            // 
            this.resourceTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resourceTypeCb.FormattingEnabled = true;
            this.resourceTypeCb.Location = new System.Drawing.Point(181, 219);
            this.resourceTypeCb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resourceTypeCb.Name = "resourceTypeCb";
            this.resourceTypeCb.Size = new System.Drawing.Size(564, 24);
            this.resourceTypeCb.TabIndex = 14;
            // 
            // skillNameCheckList
            // 
            this.skillNameCheckList.FormattingEnabled = true;
            this.skillNameCheckList.Location = new System.Drawing.Point(181, 314);
            this.skillNameCheckList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skillNameCheckList.Name = "skillNameCheckList";
            this.skillNameCheckList.Size = new System.Drawing.Size(564, 123);
            this.skillNameCheckList.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(497, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 34);
            this.label1.TabIndex = 19;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(-16, 556);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(801, 50);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(24, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 33);
            this.button1.TabIndex = 16;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(0, -14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(801, 100);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // AddNewResourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 606);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.skillNameCheckList);
            this.Controls.Add(this.resourceTypeCb);
            this.Controls.Add(this.quantityTb);
            this.Controls.Add(this.resourceNametb);
            this.Controls.Add(this.addResourceBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuLbl);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddNewResourceForm";
            this.Text = "AddNewResourceForm";
            this.Load += new System.EventHandler(this.AddNewResourceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label menuLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addResourceBtn;
        private System.Windows.Forms.TextBox resourceNametb;
        private System.Windows.Forms.TextBox quantityTb;
        private System.Windows.Forms.ComboBox resourceTypeCb;
        private System.Windows.Forms.CheckedListBox skillNameCheckList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}