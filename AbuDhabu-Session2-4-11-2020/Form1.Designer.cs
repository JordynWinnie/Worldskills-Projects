namespace AbuDhabu_Session2_4_11_2020
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flightNoTb = new System.Windows.Forms.TextBox();
            this.outboundDTP = new System.Windows.Forms.DateTimePicker();
            this.sortByCb = new System.Windows.Forms.ComboBox();
            this.toCb = new System.Windows.Forms.ComboBox();
            this.fromCb = new System.Windows.Forms.ComboBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flightsDGV = new System.Windows.Forms.DataGridView();
            this.cancelFlightButton = new System.Windows.Forms.Button();
            this.editFlightBtn = new System.Windows.Forms.Button();
            this.importChangesButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flightsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flightNoTb);
            this.groupBox1.Controls.Add(this.outboundDTP);
            this.groupBox1.Controls.Add(this.sortByCb);
            this.groupBox1.Controls.Add(this.toCb);
            this.groupBox1.Controls.Add(this.fromCb);
            this.groupBox1.Controls.Add(this.applyButton);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1119, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter By:";
            // 
            // flightNoTb
            // 
            this.flightNoTb.Location = new System.Drawing.Point(357, 77);
            this.flightNoTb.Name = "flightNoTb";
            this.flightNoTb.Size = new System.Drawing.Size(152, 20);
            this.flightNoTb.TabIndex = 10;
            // 
            // outboundDTP
            // 
            this.outboundDTP.Checked = false;
            this.outboundDTP.Location = new System.Drawing.Point(69, 74);
            this.outboundDTP.Name = "outboundDTP";
            this.outboundDTP.ShowCheckBox = true;
            this.outboundDTP.Size = new System.Drawing.Size(187, 20);
            this.outboundDTP.TabIndex = 9;
            // 
            // sortByCb
            // 
            this.sortByCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortByCb.FormattingEnabled = true;
            this.sortByCb.Location = new System.Drawing.Point(515, 25);
            this.sortByCb.Name = "sortByCb";
            this.sortByCb.Size = new System.Drawing.Size(154, 21);
            this.sortByCb.TabIndex = 8;
            this.sortByCb.SelectedIndexChanged += new System.EventHandler(this.sortByCb_SelectedIndexChanged);
            // 
            // toCb
            // 
            this.toCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toCb.FormattingEnabled = true;
            this.toCb.Location = new System.Drawing.Point(251, 24);
            this.toCb.Name = "toCb";
            this.toCb.Size = new System.Drawing.Size(154, 21);
            this.toCb.TabIndex = 7;
            // 
            // fromCb
            // 
            this.fromCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromCb.FormattingEnabled = true;
            this.fromCb.Location = new System.Drawing.Point(62, 24);
            this.fromCb.Name = "fromCb";
            this.fromCb.Size = new System.Drawing.Size(154, 21);
            this.fromCb.TabIndex = 6;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(515, 72);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(154, 23);
            this.applyButton.TabIndex = 5;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Flight Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Outbound:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(465, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sort By:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From:";
            // 
            // flightsDGV
            // 
            this.flightsDGV.AllowUserToAddRows = false;
            this.flightsDGV.AllowUserToDeleteRows = false;
            this.flightsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.flightsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flightsDGV.Location = new System.Drawing.Point(13, 127);
            this.flightsDGV.Name = "flightsDGV";
            this.flightsDGV.Size = new System.Drawing.Size(1119, 426);
            this.flightsDGV.TabIndex = 1;
            this.flightsDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flightsDGV_CellClick);
            // 
            // cancelFlightButton
            // 
            this.cancelFlightButton.Location = new System.Drawing.Point(13, 560);
            this.cancelFlightButton.Name = "cancelFlightButton";
            this.cancelFlightButton.Size = new System.Drawing.Size(176, 23);
            this.cancelFlightButton.TabIndex = 2;
            this.cancelFlightButton.Text = "Cancel/Confirm Flight";
            this.cancelFlightButton.UseVisualStyleBackColor = true;
            this.cancelFlightButton.Click += new System.EventHandler(this.cancelFlightButton_Click);
            // 
            // editFlightBtn
            // 
            this.editFlightBtn.Location = new System.Drawing.Point(195, 559);
            this.editFlightBtn.Name = "editFlightBtn";
            this.editFlightBtn.Size = new System.Drawing.Size(176, 23);
            this.editFlightBtn.TabIndex = 3;
            this.editFlightBtn.Text = "Edit Flight";
            this.editFlightBtn.UseVisualStyleBackColor = true;
            this.editFlightBtn.Click += new System.EventHandler(this.editFlightBtn_Click);
            // 
            // importChangesButton
            // 
            this.importChangesButton.Location = new System.Drawing.Point(956, 560);
            this.importChangesButton.Name = "importChangesButton";
            this.importChangesButton.Size = new System.Drawing.Size(176, 23);
            this.importChangesButton.TabIndex = 4;
            this.importChangesButton.Text = "Import Changes";
            this.importChangesButton.UseVisualStyleBackColor = true;
            this.importChangesButton.Click += new System.EventHandler(this.importChangesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 600);
            this.Controls.Add(this.importChangesButton);
            this.Controls.Add(this.editFlightBtn);
            this.Controls.Add(this.cancelFlightButton);
            this.Controls.Add(this.flightsDGV);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Manage Flight Schedules";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flightsDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox flightNoTb;
        private System.Windows.Forms.DateTimePicker outboundDTP;
        private System.Windows.Forms.ComboBox sortByCb;
        private System.Windows.Forms.ComboBox toCb;
        private System.Windows.Forms.ComboBox fromCb;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView flightsDGV;
        private System.Windows.Forms.Button cancelFlightButton;
        private System.Windows.Forms.Button editFlightBtn;
        private System.Windows.Forms.Button importChangesButton;
    }
}

