namespace Session4_12_10_2019
{
    partial class Form1
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
            this.btnPurOrdMag = new System.Windows.Forms.Button();
            this.btnWareHouseMng = new System.Windows.Forms.Button();
            this.btnInventRep = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inventoryDGV = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDGV)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPurOrdMag
            // 
            this.btnPurOrdMag.Location = new System.Drawing.Point(436, 9);
            this.btnPurOrdMag.Name = "btnPurOrdMag";
            this.btnPurOrdMag.Size = new System.Drawing.Size(210, 23);
            this.btnPurOrdMag.TabIndex = 0;
            this.btnPurOrdMag.Text = "Purchase Order Management";
            this.btnPurOrdMag.UseVisualStyleBackColor = true;
            this.btnPurOrdMag.Click += new System.EventHandler(this.btnPurOrdMag_Click);
            // 
            // btnWareHouseMng
            // 
            this.btnWareHouseMng.Location = new System.Drawing.Point(220, 9);
            this.btnWareHouseMng.Name = "btnWareHouseMng";
            this.btnWareHouseMng.Size = new System.Drawing.Size(210, 23);
            this.btnWareHouseMng.TabIndex = 1;
            this.btnWareHouseMng.Text = "Warehouse Management";
            this.btnWareHouseMng.UseVisualStyleBackColor = true;
            // 
            // btnInventRep
            // 
            this.btnInventRep.Location = new System.Drawing.Point(4, 9);
            this.btnInventRep.Name = "btnInventRep";
            this.btnInventRep.Size = new System.Drawing.Size(210, 23);
            this.btnInventRep.TabIndex = 2;
            this.btnInventRep.Text = "Inventory Report";
            this.btnInventRep.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.inventoryDGV);
            this.panel1.Location = new System.Drawing.Point(12, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1187, 395);
            this.panel1.TabIndex = 3;
            // 
            // inventoryDGV
            // 
            this.inventoryDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryDGV.Location = new System.Drawing.Point(0, 0);
            this.inventoryDGV.Name = "inventoryDGV";
            this.inventoryDGV.RowHeadersWidth = 51;
            this.inventoryDGV.RowTemplate.Height = 24;
            this.inventoryDGV.Size = new System.Drawing.Size(1187, 395);
            this.inventoryDGV.TabIndex = 0;
            this.inventoryDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inventoryDGV_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnInventRep);
            this.panel2.Controls.Add(this.btnWareHouseMng);
            this.panel2.Controls.Add(this.btnPurOrdMag);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1211, 38);
            this.panel2.TabIndex = 4;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(926, 492);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(138, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(1070, 492);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(129, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 575);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPurOrdMag;
        private System.Windows.Forms.Button btnWareHouseMng;
        private System.Windows.Forms.Button btnInventRep;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView inventoryDGV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
    }
}

