namespace TPQR_Session1_9_7_2020
{
    partial class ResourceManagementForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.typeFilterCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.skillFilterCb = new System.Windows.Forms.ComboBox();
            this.resourceDGV = new System.Windows.Forms.DataGridView();
            this.addBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourceDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(271, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 29);
            this.label2.TabIndex = 28;
            this.label2.Text = "Resource Management";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(21, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(154, 42);
            this.backBtn.TabIndex = 27;
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
            this.label1.Location = new System.Drawing.Point(531, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 26;
            this.label1.Text = "ASEAN Skills 2020\r\n";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(-1, 508);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(802, 65);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(802, 75);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(71, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 25);
            this.label7.TabIndex = 30;
            this.label7.Text = "Filter by Type:";
            // 
            // typeFilterCb
            // 
            this.typeFilterCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeFilterCb.FormattingEnabled = true;
            this.typeFilterCb.Location = new System.Drawing.Point(213, 135);
            this.typeFilterCb.Name = "typeFilterCb";
            this.typeFilterCb.Size = new System.Drawing.Size(529, 24);
            this.typeFilterCb.TabIndex = 29;
            this.typeFilterCb.SelectedIndexChanged += new System.EventHandler(this.typeFilterCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 25);
            this.label3.TabIndex = 32;
            this.label3.Text = "Filter by Skill:";
            // 
            // skillFilterCb
            // 
            this.skillFilterCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillFilterCb.FormattingEnabled = true;
            this.skillFilterCb.Location = new System.Drawing.Point(213, 180);
            this.skillFilterCb.Name = "skillFilterCb";
            this.skillFilterCb.Size = new System.Drawing.Size(529, 24);
            this.skillFilterCb.TabIndex = 31;
            this.skillFilterCb.SelectedIndexChanged += new System.EventHandler(this.skillFilterCb_SelectedIndexChanged);
            // 
            // resourceDGV
            // 
            this.resourceDGV.AllowUserToAddRows = false;
            this.resourceDGV.AllowUserToDeleteRows = false;
            this.resourceDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resourceDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resourceDGV.Location = new System.Drawing.Point(36, 227);
            this.resourceDGV.Name = "resourceDGV";
            this.resourceDGV.RowHeadersWidth = 51;
            this.resourceDGV.RowTemplate.Height = 24;
            this.resourceDGV.Size = new System.Drawing.Size(729, 222);
            this.resourceDGV.TabIndex = 33;
            this.resourceDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resourceDGV_CellClick);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(412, 455);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 47);
            this.addBtn.TabIndex = 34;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(517, 455);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(75, 47);
            this.UpdateBtn.TabIndex = 35;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(639, 455);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 47);
            this.deleteBtn.TabIndex = 36;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // ResourceManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 572);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.resourceDGV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.skillFilterCb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.typeFilterCb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ResourceManagementForm";
            this.Text = "ResourceManagementForm";
            this.Load += new System.EventHandler(this.ResourceManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourceDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox typeFilterCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox skillFilterCb;
        private System.Windows.Forms.DataGridView resourceDGV;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button deleteBtn;
    }
}