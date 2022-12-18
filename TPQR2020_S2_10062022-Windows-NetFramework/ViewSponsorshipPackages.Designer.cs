namespace TPQR2020_S2_10062022_Windows_NetFramework
{
    partial class ViewSponsorshipPackages
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
            this.packageDGV = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tierChecked = new System.Windows.Forms.RadioButton();
            this.nameChecked = new System.Windows.Forms.RadioButton();
            this.valueChecked = new System.Windows.Forms.RadioButton();
            this.quantityChecked = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.packageDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // packageDGV
            // 
            this.packageDGV.AllowUserToAddRows = false;
            this.packageDGV.AllowUserToDeleteRows = false;
            this.packageDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.packageDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packageDGV.Location = new System.Drawing.Point(14, 204);
            this.packageDGV.Name = "packageDGV";
            this.packageDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.packageDGV.Size = new System.Drawing.Size(776, 390);
            this.packageDGV.TabIndex = 42;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 33);
            this.button1.TabIndex = 41;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(288, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 25);
            this.label2.TabIndex = 40;
            this.label2.Text = "View Sponsor Packages";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(499, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 37);
            this.label1.TabIndex = 39;
            this.label1.Text = "ASEAN Skills 2020";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox1.Location = new System.Drawing.Point(2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(801, 57);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.quantityChecked);
            this.groupBox1.Controls.Add(this.valueChecked);
            this.groupBox1.Controls.Add(this.nameChecked);
            this.groupBox1.Controls.Add(this.tierChecked);
            this.groupBox1.Location = new System.Drawing.Point(14, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 100);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort By:";
            // 
            // tierChecked
            // 
            this.tierChecked.AutoSize = true;
            this.tierChecked.Checked = true;
            this.tierChecked.Location = new System.Drawing.Point(20, 29);
            this.tierChecked.Name = "tierChecked";
            this.tierChecked.Size = new System.Drawing.Size(43, 17);
            this.tierChecked.TabIndex = 0;
            this.tierChecked.TabStop = true;
            this.tierChecked.Text = "Tier";
            this.tierChecked.UseVisualStyleBackColor = true;
            this.tierChecked.CheckedChanged += new System.EventHandler(this.tierChecked_CheckedChanged);
            // 
            // nameChecked
            // 
            this.nameChecked.AutoSize = true;
            this.nameChecked.Location = new System.Drawing.Point(20, 64);
            this.nameChecked.Name = "nameChecked";
            this.nameChecked.Size = new System.Drawing.Size(53, 17);
            this.nameChecked.TabIndex = 1;
            this.nameChecked.Text = "Name";
            this.nameChecked.UseVisualStyleBackColor = true;
            this.nameChecked.CheckedChanged += new System.EventHandler(this.nameChecked_CheckedChanged);
            // 
            // valueChecked
            // 
            this.valueChecked.AutoSize = true;
            this.valueChecked.Location = new System.Drawing.Point(115, 29);
            this.valueChecked.Name = "valueChecked";
            this.valueChecked.Size = new System.Drawing.Size(79, 17);
            this.valueChecked.TabIndex = 2;
            this.valueChecked.Text = "Value (Asc)";
            this.valueChecked.UseVisualStyleBackColor = true;
            this.valueChecked.CheckedChanged += new System.EventHandler(this.valueChecked_CheckedChanged);
            // 
            // quantityChecked
            // 
            this.quantityChecked.AutoSize = true;
            this.quantityChecked.Location = new System.Drawing.Point(115, 64);
            this.quantityChecked.Name = "quantityChecked";
            this.quantityChecked.Size = new System.Drawing.Size(93, 17);
            this.quantityChecked.TabIndex = 3;
            this.quantityChecked.Text = "Quantity (Dec)";
            this.quantityChecked.UseVisualStyleBackColor = true;
            this.quantityChecked.CheckedChanged += new System.EventHandler(this.quantityChecked_CheckedChanged);
            // 
            // ViewSponsorshipPackages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 606);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.packageDGV);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ViewSponsorshipPackages";
            this.Text = "ViewSponsorshipPackages";
            this.Load += new System.EventHandler(this.ViewSponsorshipPackages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.packageDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView packageDGV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton quantityChecked;
        private System.Windows.Forms.RadioButton valueChecked;
        private System.Windows.Forms.RadioButton nameChecked;
        private System.Windows.Forms.RadioButton tierChecked;
    }
}