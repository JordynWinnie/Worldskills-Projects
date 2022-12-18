namespace Session2_JordanKhong.Forms
{
    partial class ViewSponsorshipSummaryForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label6 = new System.Windows.Forms.Label();
            this.summaryChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tierCb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totalLbl = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.summaryChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(171, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(414, 34);
            this.label6.TabIndex = 16;
            this.label6.Text = "View Sponsorship Summary";
            // 
            // summaryChart
            // 
            chartArea3.Name = "ChartArea1";
            this.summaryChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.summaryChart.Legends.Add(legend3);
            this.summaryChart.Location = new System.Drawing.Point(63, 190);
            this.summaryChart.Name = "summaryChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.LabelToolTip = "Set Name: #AXISLABEL\\nQuantity: #VALX\\nPercentage:  #PERCENT, ";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.summaryChart.Series.Add(series3);
            this.summaryChart.Size = new System.Drawing.Size(709, 300);
            this.summaryChart.TabIndex = 17;
            this.summaryChart.Text = "chart1";
            // 
            // tierCb
            // 
            this.tierCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tierCb.FormattingEnabled = true;
            this.tierCb.Location = new System.Drawing.Point(63, 150);
            this.tierCb.Name = "tierCb";
            this.tierCb.Size = new System.Drawing.Size(709, 24);
            this.tierCb.TabIndex = 23;
            this.tierCb.SelectedIndexChanged += new System.EventHandler(this.tierCb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tier:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 519);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 34);
            this.label3.TabIndex = 24;
            this.label3.Text = "Total Value ($):";
            // 
            // totalLbl
            // 
            this.totalLbl.AutoSize = true;
            this.totalLbl.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLbl.Location = new System.Drawing.Point(302, 519);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(277, 34);
            this.totalLbl.TabIndex = 25;
            this.totalLbl.Text = "(TotalPlaceHolder)";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(2, 576);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(808, 62);
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(509, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 34);
            this.label1.TabIndex = 27;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(30, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 51);
            this.button1.TabIndex = 26;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(808, 83);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // ViewSponsorshipSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 637);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.totalLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tierCb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.summaryChart);
            this.Controls.Add(this.label6);
            this.Name = "ViewSponsorshipSummaryForm";
            this.Text = "ViewSponsorshipSummaryForm";
            this.Load += new System.EventHandler(this.ViewSponsorshipSummaryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.summaryChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart summaryChart;
        private System.Windows.Forms.ComboBox tierCb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalLbl;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}