namespace Session_4_12_18_2019
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OutofStockRadio = new System.Windows.Forms.RadioButton();
            this.ReceivedStockRadio = new System.Windows.Forms.RadioButton();
            this.currentStockRadio = new System.Windows.Forms.RadioButton();
            this.resultDGV = new System.Windows.Forms.DataGridView();
            this.warehouseCb = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Warehouse:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Result:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OutofStockRadio);
            this.groupBox1.Controls.Add(this.ReceivedStockRadio);
            this.groupBox1.Controls.Add(this.currentStockRadio);
            this.groupBox1.Location = new System.Drawing.Point(307, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 50);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inventory Type";
            // 
            // OutofStockRadio
            // 
            this.OutofStockRadio.AutoSize = true;
            this.OutofStockRadio.Location = new System.Drawing.Point(263, 21);
            this.OutofStockRadio.Name = "OutofStockRadio";
            this.OutofStockRadio.Size = new System.Drawing.Size(95, 19);
            this.OutofStockRadio.TabIndex = 2;
            this.OutofStockRadio.TabStop = true;
            this.OutofStockRadio.Text = "Out Of Stock";
            this.OutofStockRadio.UseVisualStyleBackColor = true;
            this.OutofStockRadio.CheckedChanged += new System.EventHandler(this.OutofStockRadio_CheckedChanged);
            // 
            // ReceivedStockRadio
            // 
            this.ReceivedStockRadio.AutoSize = true;
            this.ReceivedStockRadio.Location = new System.Drawing.Point(135, 21);
            this.ReceivedStockRadio.Name = "ReceivedStockRadio";
            this.ReceivedStockRadio.Size = new System.Drawing.Size(112, 19);
            this.ReceivedStockRadio.TabIndex = 1;
            this.ReceivedStockRadio.TabStop = true;
            this.ReceivedStockRadio.Text = "Received Stock";
            this.ReceivedStockRadio.UseVisualStyleBackColor = true;
            this.ReceivedStockRadio.CheckedChanged += new System.EventHandler(this.ReceivedStockRadio_CheckedChanged);
            // 
            // currentStockRadio
            // 
            this.currentStockRadio.AutoSize = true;
            this.currentStockRadio.Location = new System.Drawing.Point(15, 21);
            this.currentStockRadio.Name = "currentStockRadio";
            this.currentStockRadio.Size = new System.Drawing.Size(101, 19);
            this.currentStockRadio.TabIndex = 0;
            this.currentStockRadio.TabStop = true;
            this.currentStockRadio.Text = "Current Stock";
            this.currentStockRadio.UseVisualStyleBackColor = true;
            this.currentStockRadio.CheckedChanged += new System.EventHandler(this.currentStockRadio_CheckedChanged);
            // 
            // resultDGV
            // 
            this.resultDGV.AllowUserToAddRows = false;
            this.resultDGV.AllowUserToDeleteRows = false;
            this.resultDGV.AllowUserToOrderColumns = true;
            this.resultDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDGV.Location = new System.Drawing.Point(12, 108);
            this.resultDGV.Name = "resultDGV";
            this.resultDGV.RowHeadersWidth = 51;
            this.resultDGV.Size = new System.Drawing.Size(777, 300);
            this.resultDGV.TabIndex = 3;
            this.resultDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultDGV_CellClick);
            // 
            // warehouseCb
            // 
            this.warehouseCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warehouseCb.FormattingEnabled = true;
            this.warehouseCb.Location = new System.Drawing.Point(15, 29);
            this.warehouseCb.Name = "warehouseCb";
            this.warehouseCb.Size = new System.Drawing.Size(252, 21);
            this.warehouseCb.TabIndex = 4;
            this.warehouseCb.SelectedIndexChanged += new System.EventHandler(this.warehouseCb_SelectedIndexChanged);
            // 
            // InventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.warehouseCb);
            this.Controls.Add(this.resultDGV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InventoryReport";
            this.Text = "InventoryReport";
            this.Load += new System.EventHandler(this.InventoryReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton OutofStockRadio;
        private System.Windows.Forms.RadioButton ReceivedStockRadio;
        private System.Windows.Forms.RadioButton currentStockRadio;
        private System.Windows.Forms.DataGridView resultDGV;
        private System.Windows.Forms.ComboBox warehouseCb;
    }
}