namespace Covid19AnalysisForm
{
    partial class AnalysisForm
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
            this.travelHistoryLb = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timeToTravelNUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.directContactMembers = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.indirectContactMembers = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.percentileLb = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.officeCloseTime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timeToTravelNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(836, 614);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(383, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "Generate Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // travelHistoryLb
            // 
            this.travelHistoryLb.FormattingEnabled = true;
            this.travelHistoryLb.Location = new System.Drawing.Point(10, 68);
            this.travelHistoryLb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.travelHistoryLb.Name = "travelHistoryLb";
            this.travelHistoryLb.Size = new System.Drawing.Size(565, 524);
            this.travelHistoryLb.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Travel History:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(11, 614);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(397, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 24);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(277, 20);
            this.textBox1.TabIndex = 8;
            // 
            // timeToTravelNUD
            // 
            this.timeToTravelNUD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.timeToTravelNUD.Location = new System.Drawing.Point(299, 24);
            this.timeToTravelNUD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.timeToTravelNUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.timeToTravelNUD.Name = "timeToTravelNUD";
            this.timeToTravelNUD.Size = new System.Drawing.Size(276, 20);
            this.timeToTravelNUD.TabIndex = 9;
            this.timeToTravelNUD.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Contact Number of Affected:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Avg. Time To Travel/Room (s):";
            // 
            // directContactMembers
            // 
            this.directContactMembers.FormattingEnabled = true;
            this.directContactMembers.Location = new System.Drawing.Point(582, 30);
            this.directContactMembers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.directContactMembers.Name = "directContactMembers";
            this.directContactMembers.Size = new System.Drawing.Size(249, 238);
            this.directContactMembers.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(579, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Direct Contact Members (Tier 0):";
            // 
            // indirectContactMembers
            // 
            this.indirectContactMembers.FormattingEnabled = true;
            this.indirectContactMembers.Location = new System.Drawing.Point(582, 288);
            this.indirectContactMembers.Margin = new System.Windows.Forms.Padding(2);
            this.indirectContactMembers.Name = "indirectContactMembers";
            this.indirectContactMembers.Size = new System.Drawing.Size(249, 303);
            this.indirectContactMembers.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(579, 273);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Indirect Contact (Tier 1 And Below)";
            // 
            // percentileLb
            // 
            this.percentileLb.FormattingEnabled = true;
            this.percentileLb.Location = new System.Drawing.Point(835, 30);
            this.percentileLb.Margin = new System.Windows.Forms.Padding(2);
            this.percentileLb.Name = "percentileLb";
            this.percentileLb.Size = new System.Drawing.Size(384, 563);
            this.percentileLb.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(832, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Percentile List:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 599);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Suspected Infection Date:";
            // 
            // officeCloseTime
            // 
            this.officeCloseTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.officeCloseTime.Location = new System.Drawing.Point(414, 614);
            this.officeCloseTime.Name = "officeCloseTime";
            this.officeCloseTime.Size = new System.Drawing.Size(417, 20);
            this.officeCloseTime.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(412, 599);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Time Of Office Closure:";
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 645);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.officeCloseTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.percentileLb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.indirectContactMembers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.directContactMembers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeToTravelNUD);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.travelHistoryLb);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AnalysisForm";
            this.Text = "AnalysisForm";
            ((System.ComponentModel.ISupportInitialize)(this.timeToTravelNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox travelHistoryLb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown timeToTravelNUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox directContactMembers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox indirectContactMembers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox percentileLb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker officeCloseTime;
        private System.Windows.Forms.Label label8;
    }
}