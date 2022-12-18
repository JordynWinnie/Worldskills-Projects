namespace TPQR2020_S2_10062022_Windows_NetFramework
{
    partial class BookPackage
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.benefitsCheckList = new System.Windows.Forms.CheckedListBox();
            this.filterByBudget = new System.Windows.Forms.NumericUpDown();
            this.tierCb = new System.Windows.Forms.ComboBox();
            this.packageDGV = new System.Windows.Forms.DataGridView();
            this.desiredQty = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterByBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packageDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.desiredQty)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 33);
            this.button1.TabIndex = 29;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(258, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 25);
            this.label2.TabIndex = 28;
            this.label2.Text = "Book Sponsorship Packages";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(497, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 37);
            this.label1.TabIndex = 27;
            this.label1.Text = "ASEAN Skills 2020";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox2.Location = new System.Drawing.Point(0, 671);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(801, 50);
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(801, 57);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Filter By Tier:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(81, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Filter By Budget:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(81, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Filter By Benefit:";
            // 
            // benefitsCheckList
            // 
            this.benefitsCheckList.FormattingEnabled = true;
            this.benefitsCheckList.Location = new System.Drawing.Point(212, 190);
            this.benefitsCheckList.Name = "benefitsCheckList";
            this.benefitsCheckList.Size = new System.Drawing.Size(384, 94);
            this.benefitsCheckList.TabIndex = 33;
            this.benefitsCheckList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.benefitsCheckList_ItemCheck);
            this.benefitsCheckList.Click += new System.EventHandler(this.benefitsCheckList_Click);
            this.benefitsCheckList.SelectedIndexChanged += new System.EventHandler(this.benefitsCheckList_SelectedIndexChanged);
            this.benefitsCheckList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.benefitsCheckList_MouseUp);
            // 
            // filterByBudget
            // 
            this.filterByBudget.Location = new System.Drawing.Point(212, 150);
            this.filterByBudget.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.filterByBudget.Name = "filterByBudget";
            this.filterByBudget.Size = new System.Drawing.Size(384, 20);
            this.filterByBudget.TabIndex = 34;
            this.filterByBudget.ValueChanged += new System.EventHandler(this.filterByBudget_ValueChanged);
            // 
            // tierCb
            // 
            this.tierCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tierCb.FormattingEnabled = true;
            this.tierCb.Location = new System.Drawing.Point(212, 111);
            this.tierCb.Name = "tierCb";
            this.tierCb.Size = new System.Drawing.Size(384, 21);
            this.tierCb.TabIndex = 35;
            this.tierCb.SelectedIndexChanged += new System.EventHandler(this.tierCb_SelectedIndexChanged);
            // 
            // packageDGV
            // 
            this.packageDGV.AllowUserToAddRows = false;
            this.packageDGV.AllowUserToDeleteRows = false;
            this.packageDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.packageDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packageDGV.Location = new System.Drawing.Point(12, 300);
            this.packageDGV.Name = "packageDGV";
            this.packageDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.packageDGV.Size = new System.Drawing.Size(776, 323);
            this.packageDGV.TabIndex = 36;
            this.packageDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.packageDGV_CellClick);
            this.packageDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.packageDGV_CellContentClick);
            // 
            // desiredQty
            // 
            this.desiredQty.Location = new System.Drawing.Point(149, 634);
            this.desiredQty.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.desiredQty.Name = "desiredQty";
            this.desiredQty.Size = new System.Drawing.Size(252, 20);
            this.desiredQty.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 634);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "Desired Quantity:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(659, 629);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 33);
            this.button2.TabIndex = 39;
            this.button2.Text = "Book";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BookPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 719);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.desiredQty);
            this.Controls.Add(this.packageDGV);
            this.Controls.Add(this.tierCb);
            this.Controls.Add(this.filterByBudget);
            this.Controls.Add(this.benefitsCheckList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "BookPackage";
            this.Text = "BookPackage";
            this.Load += new System.EventHandler(this.BookPackage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterByBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packageDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.desiredQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox benefitsCheckList;
        private System.Windows.Forms.NumericUpDown filterByBudget;
        private System.Windows.Forms.ComboBox tierCb;
        private System.Windows.Forms.DataGridView packageDGV;
        private System.Windows.Forms.NumericUpDown desiredQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
    }
}