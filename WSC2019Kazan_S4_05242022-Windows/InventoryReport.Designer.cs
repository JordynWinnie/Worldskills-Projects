namespace WSC2019Kazan_S4_05242022_Windows
{
    partial class InventoryReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.warehouseCb = new System.Windows.Forms.ComboBox();
            this.inventoryType = new System.Windows.Forms.GroupBox();
            this.outofstock = new System.Windows.Forms.RadioButton();
            this.recievedStock = new System.Windows.Forms.RadioButton();
            this.currentStock = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.inventoryType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Warehouse:";
            // 
            // warehouseCb
            // 
            this.warehouseCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warehouseCb.FormattingEnabled = true;
            this.warehouseCb.Location = new System.Drawing.Point(12, 27);
            this.warehouseCb.Name = "warehouseCb";
            this.warehouseCb.Size = new System.Drawing.Size(322, 23);
            this.warehouseCb.TabIndex = 3;
            this.warehouseCb.SelectedIndexChanged += new System.EventHandler(this.warehouseCb_SelectedIndexChanged);
            // 
            // inventoryType
            // 
            this.inventoryType.Controls.Add(this.outofstock);
            this.inventoryType.Controls.Add(this.recievedStock);
            this.inventoryType.Controls.Add(this.currentStock);
            this.inventoryType.Location = new System.Drawing.Point(350, 9);
            this.inventoryType.Name = "inventoryType";
            this.inventoryType.Size = new System.Drawing.Size(438, 68);
            this.inventoryType.TabIndex = 5;
            this.inventoryType.TabStop = false;
            this.inventoryType.Text = "Inventory Type:";
            // 
            // outofstock
            // 
            this.outofstock.AutoSize = true;
            this.outofstock.Location = new System.Drawing.Point(228, 22);
            this.outofstock.Name = "outofstock";
            this.outofstock.Size = new System.Drawing.Size(93, 19);
            this.outofstock.TabIndex = 2;
            this.outofstock.Text = "Out Of Stock";
            this.outofstock.UseVisualStyleBackColor = true;
            this.outofstock.CheckedChanged += new System.EventHandler(this.outofstock_CheckedChanged);
            // 
            // recievedStock
            // 
            this.recievedStock.AutoSize = true;
            this.recievedStock.Location = new System.Drawing.Point(118, 22);
            this.recievedStock.Name = "recievedStock";
            this.recievedStock.Size = new System.Drawing.Size(104, 19);
            this.recievedStock.TabIndex = 1;
            this.recievedStock.Text = "Recieved Stock";
            this.recievedStock.UseVisualStyleBackColor = true;
            this.recievedStock.CheckedChanged += new System.EventHandler(this.recievedStock_CheckedChanged);
            // 
            // currentStock
            // 
            this.currentStock.AutoSize = true;
            this.currentStock.Checked = true;
            this.currentStock.Location = new System.Drawing.Point(15, 22);
            this.currentStock.Name = "currentStock";
            this.currentStock.Size = new System.Drawing.Size(97, 19);
            this.currentStock.TabIndex = 0;
            this.currentStock.TabStop = true;
            this.currentStock.Text = "Current Stock";
            this.currentStock.UseVisualStyleBackColor = true;
            this.currentStock.CheckedChanged += new System.EventHandler(this.currentStock_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(776, 326);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // InventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.inventoryType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.warehouseCb);
            this.Name = "InventoryReport";
            this.Text = "InventoryReport";
            this.Load += new System.EventHandler(this.InventoryReport_Load);
            this.inventoryType.ResumeLayout(false);
            this.inventoryType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox warehouseCb;
        private GroupBox inventoryType;
        private RadioButton outofstock;
        private RadioButton recievedStock;
        private RadioButton currentStock;
        private DataGridView dataGridView1;
    }
}