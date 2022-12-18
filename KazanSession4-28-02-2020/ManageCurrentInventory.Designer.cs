namespace KazanSession4_28_02_2020
{
    partial class ManageCurrentInventory
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.orderDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.orderDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Purchase Order Management";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(215, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Warehouse Management";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(441, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(235, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Inventory Report";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // orderDGV
            // 
            this.orderDGV.AllowUserToAddRows = false;
            this.orderDGV.AllowUserToDeleteRows = false;
            this.orderDGV.AllowUserToOrderColumns = true;
            this.orderDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDGV.Location = new System.Drawing.Point(13, 42);
            this.orderDGV.Name = "orderDGV";
            this.orderDGV.RowHeadersWidth = 51;
            this.orderDGV.RowTemplate.Height = 24;
            this.orderDGV.Size = new System.Drawing.Size(1051, 396);
            this.orderDGV.TabIndex = 3;
            this.orderDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderDGV_CellClick);
            // 
            // ManageCurrentInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 450);
            this.Controls.Add(this.orderDGV);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ManageCurrentInventory";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ManageCurrentInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.orderDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView orderDGV;
    }
}

