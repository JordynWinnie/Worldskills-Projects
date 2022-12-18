namespace WSC2019Kazan_S4_05242022_Windows
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.purchaseOrderManagement = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSeparator();
            this.warehouseManagement = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.inventoryReport = new System.Windows.Forms.ToolStripButton();
            this.dataDGV = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseOrderManagement,
            this.toolStripButton2,
            this.warehouseManagement,
            this.toolStripButton1,
            this.inventoryReport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(1193, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // purchaseOrderManagement
            // 
            this.purchaseOrderManagement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.purchaseOrderManagement.Image = ((System.Drawing.Image)(resources.GetObject("purchaseOrderManagement.Image")));
            this.purchaseOrderManagement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.purchaseOrderManagement.Name = "purchaseOrderManagement";
            this.purchaseOrderManagement.Size = new System.Drawing.Size(166, 22);
            this.purchaseOrderManagement.Text = "Purchase Order Management";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(6, 25);
            // 
            // warehouseManagement
            // 
            this.warehouseManagement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.warehouseManagement.Image = ((System.Drawing.Image)(resources.GetObject("warehouseManagement.Image")));
            this.warehouseManagement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.warehouseManagement.Name = "warehouseManagement";
            this.warehouseManagement.Size = new System.Drawing.Size(144, 22);
            this.warehouseManagement.Text = "Warehouse Management";
            this.warehouseManagement.Click += new System.EventHandler(this.warehouseManagement_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // inventoryReport
            // 
            this.inventoryReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.inventoryReport.Image = ((System.Drawing.Image)(resources.GetObject("inventoryReport.Image")));
            this.inventoryReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.inventoryReport.Name = "inventoryReport";
            this.inventoryReport.Size = new System.Drawing.Size(99, 22);
            this.inventoryReport.Text = "Inventory Report";
            this.inventoryReport.Click += new System.EventHandler(this.inventoryReport_Click);
            // 
            // dataDGV
            // 
            this.dataDGV.AllowUserToAddRows = false;
            this.dataDGV.AllowUserToDeleteRows = false;
            this.dataDGV.AllowUserToOrderColumns = true;
            this.dataDGV.AllowUserToResizeColumns = false;
            this.dataDGV.AllowUserToResizeRows = false;
            this.dataDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataDGV.Location = new System.Drawing.Point(12, 28);
            this.dataDGV.Name = "dataDGV";
            this.dataDGV.RowTemplate.Height = 25;
            this.dataDGV.Size = new System.Drawing.Size(1169, 667);
            this.dataDGV.TabIndex = 1;
            this.dataDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataDGV_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 707);
            this.Controls.Add(this.dataDGV);
            this.Controls.Add(this.toolStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton purchaseOrderManagement;
        private ToolStripButton warehouseManagement;
        private ToolStripSeparator toolStripButton2;
        private ToolStripSeparator toolStripButton1;
        private ToolStripButton inventoryReport;
        private DataGridView dataDGV;
    }
}