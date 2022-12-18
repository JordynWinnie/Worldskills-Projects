namespace TPQR2020_S1_08062022_Windows_NetFramework
{
    partial class AddResource
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.allocatedSkillsCLB = new System.Windows.Forms.CheckedListBox();
            this.availableQtyNUD = new System.Windows.Forms.NumericUpDown();
            this.resourceNameTb = new System.Windows.Forms.TextBox();
            this.resourceTypeCb = new System.Windows.Forms.ComboBox();
            this.addResourceBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableQtyNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(593, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "ASEAN Skills 2020\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(805, 44);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 25);
            this.label2.TabIndex = 30;
            this.label2.Text = "Add New Resource";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 18);
            this.label4.TabIndex = 32;
            this.label4.Text = "Resource Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "Resource Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 18);
            this.label5.TabIndex = 33;
            this.label5.Text = "Available Quantity:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 18);
            this.label6.TabIndex = 34;
            this.label6.Text = "Allocated Skills:";
            // 
            // allocatedSkillsCLB
            // 
            this.allocatedSkillsCLB.FormattingEnabled = true;
            this.allocatedSkillsCLB.Location = new System.Drawing.Point(139, 211);
            this.allocatedSkillsCLB.Name = "allocatedSkillsCLB";
            this.allocatedSkillsCLB.Size = new System.Drawing.Size(648, 94);
            this.allocatedSkillsCLB.TabIndex = 35;
            // 
            // availableQtyNUD
            // 
            this.availableQtyNUD.Location = new System.Drawing.Point(139, 179);
            this.availableQtyNUD.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.availableQtyNUD.Name = "availableQtyNUD";
            this.availableQtyNUD.Size = new System.Drawing.Size(648, 20);
            this.availableQtyNUD.TabIndex = 36;
            // 
            // resourceNameTb
            // 
            this.resourceNameTb.Location = new System.Drawing.Point(139, 105);
            this.resourceNameTb.Name = "resourceNameTb";
            this.resourceNameTb.Size = new System.Drawing.Size(648, 20);
            this.resourceNameTb.TabIndex = 37;
            // 
            // resourceTypeCb
            // 
            this.resourceTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resourceTypeCb.FormattingEnabled = true;
            this.resourceTypeCb.Location = new System.Drawing.Point(139, 138);
            this.resourceTypeCb.Name = "resourceTypeCb";
            this.resourceTypeCb.Size = new System.Drawing.Size(648, 21);
            this.resourceTypeCb.TabIndex = 38;
            // 
            // addResourceBtn
            // 
            this.addResourceBtn.Location = new System.Drawing.Point(15, 325);
            this.addResourceBtn.Name = "addResourceBtn";
            this.addResourceBtn.Size = new System.Drawing.Size(772, 66);
            this.addResourceBtn.TabIndex = 39;
            this.addResourceBtn.Text = "Add Resource";
            this.addResourceBtn.UseVisualStyleBackColor = true;
            this.addResourceBtn.Click += new System.EventHandler(this.addResourceBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox2.Location = new System.Drawing.Point(-3, 409);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(805, 44);
            this.pictureBox2.TabIndex = 40;
            this.pictureBox2.TabStop = false;
            // 
            // AddResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.addResourceBtn);
            this.Controls.Add(this.resourceTypeCb);
            this.Controls.Add(this.resourceNameTb);
            this.Controls.Add(this.availableQtyNUD);
            this.Controls.Add(this.allocatedSkillsCLB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AddResource";
            this.Text = "AddResource";
            this.Load += new System.EventHandler(this.AddResource_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableQtyNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox allocatedSkillsCLB;
        private System.Windows.Forms.NumericUpDown availableQtyNUD;
        private System.Windows.Forms.TextBox resourceNameTb;
        private System.Windows.Forms.ComboBox resourceTypeCb;
        private System.Windows.Forms.Button addResourceBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}