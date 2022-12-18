namespace WSC2019Kazan_S4_05242022_Windows
{
    partial class WarehouseManagement
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
            this.sourceCb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.destinationCb = new System.Windows.Forms.ComboBox();
            this.purchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.partsDGV = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.batchCb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.partsCb = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.amountUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source Warehouse:";
            // 
            // sourceCb
            // 
            this.sourceCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceCb.FormattingEnabled = true;
            this.sourceCb.Location = new System.Drawing.Point(12, 27);
            this.sourceCb.Name = "sourceCb";
            this.sourceCb.Size = new System.Drawing.Size(322, 23);
            this.sourceCb.TabIndex = 3;
            this.sourceCb.SelectedIndexChanged += new System.EventHandler(this.sourceCb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Destination Warehouse:";
            // 
            // destinationCb
            // 
            this.destinationCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinationCb.FormattingEnabled = true;
            this.destinationCb.Location = new System.Drawing.Point(359, 27);
            this.destinationCb.Name = "destinationCb";
            this.destinationCb.Size = new System.Drawing.Size(322, 23);
            this.destinationCb.TabIndex = 5;
            // 
            // purchaseDate
            // 
            this.purchaseDate.Location = new System.Drawing.Point(76, 67);
            this.purchaseDate.Name = "purchaseDate";
            this.purchaseDate.Size = new System.Drawing.Size(258, 23);
            this.purchaseDate.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Date:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.partsDGV);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.batchCb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.partsCb);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 250);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parts List";
            // 
            // partsDGV
            // 
            this.partsDGV.AllowUserToAddRows = false;
            this.partsDGV.AllowUserToDeleteRows = false;
            this.partsDGV.AllowUserToOrderColumns = true;
            this.partsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.partsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsDGV.Location = new System.Drawing.Point(10, 47);
            this.partsDGV.Name = "partsDGV";
            this.partsDGV.RowTemplate.Height = 25;
            this.partsDGV.Size = new System.Drawing.Size(770, 181);
            this.partsDGV.TabIndex = 20;
            this.partsDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.partsDGV_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(310, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Batch Number;";
            // 
            // batchCb
            // 
            this.batchCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.batchCb.FormattingEnabled = true;
            this.batchCb.Location = new System.Drawing.Point(403, 17);
            this.batchCb.Name = "batchCb";
            this.batchCb.Size = new System.Drawing.Size(145, 23);
            this.batchCb.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Part Name:";
            // 
            // partsCb
            // 
            this.partsCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partsCb.FormattingEnabled = true;
            this.partsCb.Location = new System.Drawing.Point(78, 17);
            this.partsCb.Name = "partsCb";
            this.partsCb.Size = new System.Drawing.Size(226, 23);
            this.partsCb.TabIndex = 19;
            this.partsCb.SelectedIndexChanged += new System.EventHandler(this.partsCb_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(694, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Add To List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // amountUpDown
            // 
            this.amountUpDown.Location = new System.Drawing.Point(623, 114);
            this.amountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.amountUpDown.Name = "amountUpDown";
            this.amountUpDown.Size = new System.Drawing.Size(65, 23);
            this.amountUpDown.TabIndex = 17;
            this.amountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(563, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Amount:";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(593, 352);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(95, 23);
            this.submitBtn.TabIndex = 20;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(694, 352);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(95, 23);
            this.cancelBtn.TabIndex = 19;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // WarehouseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 450);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.amountUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.purchaseDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.destinationCb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sourceCb);
            this.Name = "WarehouseManagement";
            this.Text = "WarehouseManagement";
            this.Load += new System.EventHandler(this.WarehouseManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox sourceCb;
        private Label label2;
        private ComboBox destinationCb;
        private DateTimePicker purchaseDate;
        private Label label3;
        private GroupBox groupBox1;
        private DataGridView partsDGV;
        private Label label5;
        private ComboBox batchCb;
        private Label label4;
        private ComboBox partsCb;
        private Button button1;
        private NumericUpDown amountUpDown;
        private Label label6;
        private Button submitBtn;
        private Button cancelBtn;
    }
}