namespace ASEAN_2018_Paper1_27_10_2020
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.filterTypeCb = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timeTakenLabel = new System.Windows.Forms.Label();
            this.mostNumberLbl = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // filterTypeCb
            // 
            this.filterTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterTypeCb.FormattingEnabled = true;
            this.filterTypeCb.Items.AddRange(new object[] {
            "Number of Users by Offices",
            "Number of Roles by Offices"});
            this.filterTypeCb.Location = new System.Drawing.Point(24, 30);
            this.filterTypeCb.Name = "filterTypeCb";
            this.filterTypeCb.Size = new System.Drawing.Size(581, 28);
            this.filterTypeCb.TabIndex = 0;
            this.filterTypeCb.SelectedIndexChanged += new System.EventHandler(this.filterTypeCb_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(629, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(306, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Graph";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timeTakenLabel
            // 
            this.timeTakenLabel.AutoSize = true;
            this.timeTakenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTakenLabel.Location = new System.Drawing.Point(20, 103);
            this.timeTakenLabel.Name = "timeTakenLabel";
            this.timeTakenLabel.Size = new System.Drawing.Size(93, 32);
            this.timeTakenLabel.TabIndex = 2;
            this.timeTakenLabel.Text = "label1";
            // 
            // mostNumberLbl
            // 
            this.mostNumberLbl.AutoSize = true;
            this.mostNumberLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostNumberLbl.Location = new System.Drawing.Point(20, 732);
            this.mostNumberLbl.Name = "mostNumberLbl";
            this.mostNumberLbl.Size = new System.Drawing.Size(93, 32);
            this.mostNumberLbl.TabIndex = 3;
            this.mostNumberLbl.Text = "label1";
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(26, 164);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series4.LabelToolTip = "#VAL";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(909, 565);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 800);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.mostNumberLbl);
            this.Controls.Add(this.timeTakenLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filterTypeCb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox filterTypeCb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label timeTakenLabel;
        private System.Windows.Forms.Label mostNumberLbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
    }
}

