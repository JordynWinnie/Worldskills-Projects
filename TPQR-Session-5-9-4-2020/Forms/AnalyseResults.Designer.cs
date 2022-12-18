namespace TPQR_Session5_9_4_2020
{
    partial class AnalyseResults
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.skillCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bestPerformingCountryLbl = new System.Windows.Forms.Label();
            this.easiestSesLbl = new System.Windows.Forms.Label();
            this.hardestSessionLbl = new System.Windows.Forms.Label();
            this.medianMarkLbl = new System.Windows.Forms.Label();
            this.markChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.countryFlag = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.markChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(280, 143);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(489, 21);
            this.skillCb.TabIndex = 35;
            this.skillCb.SelectedIndexChanged += new System.EventHandler(this.skillCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(216, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 34;
            this.label3.Text = "Skill:";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(9, 16);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(192, 47);
            this.backBtn.TabIndex = 33;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(301, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 32;
            this.label2.Text = "Enter Marks";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(575, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 50);
            this.label1.TabIndex = 31;
            this.label1.Text = "ASEAN Skills 2020\r\n26 - 28 Jul 2020\r\n";
            // 
            // bestPerformingCountryLbl
            // 
            this.bestPerformingCountryLbl.AutoSize = true;
            this.bestPerformingCountryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bestPerformingCountryLbl.Location = new System.Drawing.Point(29, 195);
            this.bestPerformingCountryLbl.Name = "bestPerformingCountryLbl";
            this.bestPerformingCountryLbl.Size = new System.Drawing.Size(252, 25);
            this.bestPerformingCountryLbl.TabIndex = 36;
            this.bestPerformingCountryLbl.Text = "Best Performing Country:";
            // 
            // easiestSesLbl
            // 
            this.easiestSesLbl.AutoSize = true;
            this.easiestSesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easiestSesLbl.Location = new System.Drawing.Point(109, 239);
            this.easiestSesLbl.Name = "easiestSesLbl";
            this.easiestSesLbl.Size = new System.Drawing.Size(172, 25);
            this.easiestSesLbl.TabIndex = 37;
            this.easiestSesLbl.Text = "Easiest Session:";
            // 
            // hardestSessionLbl
            // 
            this.hardestSessionLbl.AutoSize = true;
            this.hardestSessionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardestSessionLbl.Location = new System.Drawing.Point(105, 285);
            this.hardestSessionLbl.Name = "hardestSessionLbl";
            this.hardestSessionLbl.Size = new System.Drawing.Size(176, 25);
            this.hardestSessionLbl.TabIndex = 38;
            this.hardestSessionLbl.Text = "Hardest Session:";
            // 
            // medianMarkLbl
            // 
            this.medianMarkLbl.AutoSize = true;
            this.medianMarkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medianMarkLbl.Location = new System.Drawing.Point(131, 334);
            this.medianMarkLbl.Name = "medianMarkLbl";
            this.medianMarkLbl.Size = new System.Drawing.Size(143, 25);
            this.medianMarkLbl.TabIndex = 39;
            this.medianMarkLbl.Text = "Median Mark:";
            // 
            // markChart
            // 
            chartArea2.Name = "ChartArea1";
            this.markChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.markChart.Legends.Add(legend2);
            this.markChart.Location = new System.Drawing.Point(25, 375);
            this.markChart.Name = "markChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.markChart.Series.Add(series2);
            this.markChart.Size = new System.Drawing.Size(744, 219);
            this.markChart.TabIndex = 40;
            this.markChart.Text = "chart1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(0, 620);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(795, 36);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(795, 80);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // countryFlag
            // 
            this.countryFlag.Location = new System.Drawing.Point(496, 193);
            this.countryFlag.Name = "countryFlag";
            this.countryFlag.Size = new System.Drawing.Size(132, 71);
            this.countryFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.countryFlag.TabIndex = 41;
            this.countryFlag.TabStop = false;
            // 
            // AnalyseResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 656);
            this.Controls.Add(this.countryFlag);
            this.Controls.Add(this.markChart);
            this.Controls.Add(this.medianMarkLbl);
            this.Controls.Add(this.hardestSessionLbl);
            this.Controls.Add(this.easiestSesLbl);
            this.Controls.Add(this.bestPerformingCountryLbl);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AnalyseResults";
            this.Text = "AnalyseResults";
            this.Load += new System.EventHandler(this.AnalyseResults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.markChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryFlag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox skillCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label bestPerformingCountryLbl;
        private System.Windows.Forms.Label easiestSesLbl;
        private System.Windows.Forms.Label hardestSessionLbl;
        private System.Windows.Forms.Label medianMarkLbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart markChart;
        private System.Windows.Forms.PictureBox countryFlag;
    }
}