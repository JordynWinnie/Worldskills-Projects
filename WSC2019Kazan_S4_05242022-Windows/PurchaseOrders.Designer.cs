namespace WSC2019Kazan_S4_05242022_Windows
{
    partial class PurchaseOrders
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
            this.supplierCb = new System.Windows.Forms.ComboBox();
            this.warehouseCb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.purchaseDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.batchNumber = new System.Windows.Forms.TextBox();
            this.partsCb = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.amountUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.submitBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // supplierCb
            // 
            this.supplierCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supplierCb.FormattingEnabled = true;
            this.supplierCb.Location = new System.Drawing.Point(12, 27);
            this.supplierCb.Name = "supplierCb";
            this.supplierCb.Size = new System.Drawing.Size(322, 23);
            this.supplierCb.TabIndex = 0;
            this.supplierCb.SelectedIndexChanged += new System.EventHandler(this.supplierCb_SelectedIndexChanged);
            // 
            // warehouseCb
            // 
            this.warehouseCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warehouseCb.FormattingEnabled = true;
            this.warehouseCb.Location = new System.Drawing.Point(415, 27);
            this.warehouseCb.Name = "warehouseCb";
            this.warehouseCb.Size = new System.Drawing.Size(322, 23);
            this.warehouseCb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Suppliers:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Warehouse:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date:";
            // 
            // purchaseDate
            // 
            this.purchaseDate.Location = new System.Drawing.Point(76, 74);
            this.purchaseDate.Name = "purchaseDate";
            this.purchaseDate.Size = new System.Drawing.Size(258, 23);
            this.purchaseDate.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.batchNumber);
            this.groupBox1.Controls.Add(this.partsCb);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.amountUpDown);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(789, 257);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parts List";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(777, 181);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // batchNumber
            // 
            this.batchNumber.Location = new System.Drawing.Point(403, 28);
            this.batchNumber.Name = "batchNumber";
            this.batchNumber.Size = new System.Drawing.Size(148, 23);
            this.batchNumber.TabIndex = 13;
            // 
            // partsCb
            // 
            this.partsCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partsCb.FormattingEnabled = true;
            this.partsCb.Location = new System.Drawing.Point(78, 29);
            this.partsCb.Name = "partsCb";
            this.partsCb.Size = new System.Drawing.Size(226, 23);
            this.partsCb.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(688, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Add To List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // amountUpDown
            // 
            this.amountUpDown.Location = new System.Drawing.Point(617, 28);
            this.amountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.amountUpDown.Name = "amountUpDown";
            this.amountUpDown.Size = new System.Drawing.Size(65, 23);
            this.amountUpDown.TabIndex = 10;
            this.amountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(557, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Amount:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(310, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Batch Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Part Name:";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(700, 375);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(95, 23);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(599, 375);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(95, 23);
            this.submitBtn.TabIndex = 9;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // PurchaseOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 416);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.purchaseDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.warehouseCb);
            this.Controls.Add(this.supplierCb);
            this.Name = "PurchaseOrders";
            this.Text = "PurchaseOrders";
            this.Load += new System.EventHandler(this.PurchaseOrders_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox supplierCb;
        private ComboBox warehouseCb;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker purchaseDate;
        private GroupBox groupBox1;
        private Button button1;
        private NumericUpDown amountUpDown;
        private Label label6;
        private Label label5;
        private Label label4;
        private DataGridView dataGridView1;
        private TextBox batchNumber;
        private ComboBox partsCb;
        private Button cancelBtn;
        private Button submitBtn;
    }
}