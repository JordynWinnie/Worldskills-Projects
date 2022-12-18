namespace TPQR_Session1_9_7_2020
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
            this.addBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.resourceTypeCb = new System.Windows.Forms.ComboBox();
            this.title = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.resourceNameTb = new System.Windows.Forms.TextBox();
            this.dsa = new System.Windows.Forms.Label();
            this.quantityNUD = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.allocatedSkills = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(253, 456);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(279, 47);
            this.addBtn.TabIndex = 42;
            this.addBtn.Text = "Add Resource";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(46, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 25);
            this.label7.TabIndex = 41;
            this.label7.Text = "Resource Type:";
            // 
            // resourceTypeCb
            // 
            this.resourceTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resourceTypeCb.FormattingEnabled = true;
            this.resourceTypeCb.Location = new System.Drawing.Point(230, 185);
            this.resourceTypeCb.Name = "resourceTypeCb";
            this.resourceTypeCb.Size = new System.Drawing.Size(514, 24);
            this.resourceTypeCb.TabIndex = 40;
            this.resourceTypeCb.SelectedIndexChanged += new System.EventHandler(this.typeFilterCb_SelectedIndexChanged);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(266, 82);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(228, 29);
            this.title.TabIndex = 39;
            this.title.Text = "Add New Resource:";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(16, 13);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(154, 42);
            this.backBtn.TabIndex = 38;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(526, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 37;
            this.label1.Text = "ASEAN Skills 2020\r\n";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(-6, 509);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(802, 65);
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(-6, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(802, 75);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // resourceNameTb
            // 
            this.resourceNameTb.Location = new System.Drawing.Point(230, 137);
            this.resourceNameTb.Name = "resourceNameTb";
            this.resourceNameTb.Size = new System.Drawing.Size(514, 22);
            this.resourceNameTb.TabIndex = 44;
            // 
            // dsa
            // 
            this.dsa.AutoSize = true;
            this.dsa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dsa.Location = new System.Drawing.Point(46, 133);
            this.dsa.Name = "dsa";
            this.dsa.Size = new System.Drawing.Size(158, 25);
            this.dsa.TabIndex = 43;
            this.dsa.Text = "Resource Name:";
            // 
            // quantityNUD
            // 
            this.quantityNUD.Location = new System.Drawing.Point(230, 240);
            this.quantityNUD.Name = "quantityNUD";
            this.quantityNUD.Size = new System.Drawing.Size(514, 22);
            this.quantityNUD.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 25);
            this.label4.TabIndex = 46;
            this.label4.Text = "Available Qty:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 25);
            this.label5.TabIndex = 47;
            this.label5.Text = "Allocated Skills:";
            // 
            // allocatedSkills
            // 
            this.allocatedSkills.FormattingEnabled = true;
            this.allocatedSkills.Location = new System.Drawing.Point(230, 306);
            this.allocatedSkills.Name = "allocatedSkills";
            this.allocatedSkills.Size = new System.Drawing.Size(501, 123);
            this.allocatedSkills.TabIndex = 48;
            // 
            // AddResourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 578);
            this.Controls.Add(this.allocatedSkills);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.quantityNUD);
            this.Controls.Add(this.resourceNameTb);
            this.Controls.Add(this.dsa);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.resourceTypeCb);
            this.Controls.Add(this.title);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AddResourceForm";
            this.Text = "AddResourceForm";
            this.Load += new System.EventHandler(this.AddResourceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox resourceTypeCb;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox resourceNameTb;
        private System.Windows.Forms.Label dsa;
        private System.Windows.Forms.NumericUpDown quantityNUD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox allocatedSkills;
    }
}