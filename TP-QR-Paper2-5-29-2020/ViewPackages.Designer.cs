namespace TP_QR_Paper2_5_29_2020
{
    partial class ViewPackages
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.quantityRadio = new System.Windows.Forms.RadioButton();
            this.valueRadio = new System.Windows.Forms.RadioButton();
            this.nameRadio = new System.Windows.Forms.RadioButton();
            this.tierRadio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.packageDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.packageDGV.Location = new System.Drawing.Point(19, 295);
            this.packageDGV.Name = "packageDGV";
            this.packageDGV.RowHeadersWidth = 51;
            this.packageDGV.RowTemplate.Height = 24;
            this.packageDGV.Size = new System.Drawing.Size(1051, 203);
            this.packageDGV.TabIndex = 36;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(800, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 34;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(-2, 517);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1085, 53);
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1085, 92);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "View Sponsorship Packages:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.quantityRadio);
            this.groupBox1.Controls.Add(this.valueRadio);
            this.groupBox1.Controls.Add(this.nameRadio);
            this.groupBox1.Controls.Add(this.tierRadio);
            this.groupBox1.Location = new System.Drawing.Point(23, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1034, 71);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort by:";
            // 
            // quantityRadio
            // 
            this.quantityRadio.AutoSize = true;
            this.quantityRadio.Location = new System.Drawing.Point(401, 33);
            this.quantityRadio.Name = "quantityRadio";
            this.quantityRadio.Size = new System.Drawing.Size(124, 21);
            this.quantityRadio.TabIndex = 3;
            this.quantityRadio.Text = "Quantity (DEC)";
            this.quantityRadio.UseVisualStyleBackColor = true;
            this.quantityRadio.CheckedChanged += new System.EventHandler(this.quantityRadio_CheckedChanged);
            // 
            // valueRadio
            // 
            this.valueRadio.AutoSize = true;
            this.valueRadio.Location = new System.Drawing.Point(271, 33);
            this.valueRadio.Name = "valueRadio";
            this.valueRadio.Size = new System.Drawing.Size(106, 21);
            this.valueRadio.TabIndex = 2;
            this.valueRadio.Text = "Value (ASC)";
            this.valueRadio.UseVisualStyleBackColor = true;
            this.valueRadio.CheckedChanged += new System.EventHandler(this.valueRadio_CheckedChanged);
            // 
            // nameRadio
            // 
            this.nameRadio.AutoSize = true;
            this.nameRadio.Location = new System.Drawing.Point(139, 33);
            this.nameRadio.Name = "nameRadio";
            this.nameRadio.Size = new System.Drawing.Size(66, 21);
            this.nameRadio.TabIndex = 1;
            this.nameRadio.Text = "Name";
            this.nameRadio.UseVisualStyleBackColor = true;
            this.nameRadio.CheckedChanged += new System.EventHandler(this.nameRadio_CheckedChanged);
            // 
            // tierRadio
            // 
            this.tierRadio.AutoSize = true;
            this.tierRadio.Checked = true;
            this.tierRadio.Location = new System.Drawing.Point(23, 33);
            this.tierRadio.Name = "tierRadio";
            this.tierRadio.Size = new System.Drawing.Size(54, 21);
            this.tierRadio.TabIndex = 0;
            this.tierRadio.TabStop = true;
            this.tierRadio.Text = "Tier";
            this.tierRadio.UseVisualStyleBackColor = true;
            this.tierRadio.CheckedChanged += new System.EventHandler(this.tierRadio_CheckedChanged);
            // 
            // ViewPackages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 569);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.packageDGV);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ViewPackages";
            this.Text = "ViewPackages";
            this.Load += new System.EventHandler(this.ViewPackages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.packageDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView packageDGV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton quantityRadio;
        private System.Windows.Forms.RadioButton valueRadio;
        private System.Windows.Forms.RadioButton nameRadio;
        private System.Windows.Forms.RadioButton tierRadio;
    }
}