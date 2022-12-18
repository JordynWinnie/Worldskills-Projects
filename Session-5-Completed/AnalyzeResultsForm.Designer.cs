namespace Session5
{
    partial class AnalyzeResultsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.skillCb = new System.Windows.Forms.ComboBox();
            this.totalMarksLbl = new System.Windows.Forms.Label();
            this.easiestSessionLbl = new System.Windows.Forms.Label();
            this.toughestSessionLbl = new System.Windows.Forms.Label();
            this.medianMarkLbl = new System.Windows.Forms.Label();
            this.trendCompetitor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.medianUpArrow = new System.Windows.Forms.PictureBox();
            this.medianDownArrow = new System.Windows.Forms.PictureBox();
            this.currentFlag = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trendCompetitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianUpArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianDownArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(205, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 26);
            this.label2.TabIndex = 19;
            this.label2.Text = "Analyze Results";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(17, 27);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 37);
            this.button1.TabIndex = 18;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(381, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 17;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 26);
            this.label3.TabIndex = 20;
            this.label3.Text = "Skill:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 283);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 26);
            this.label4.TabIndex = 21;
            this.label4.Text = "Toughest Session:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 243);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 26);
            this.label5.TabIndex = 22;
            this.label5.Text = "Easiest Session:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 171);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 26);
            this.label6.TabIndex = 23;
            this.label6.Text = "Best Performing:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 329);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 26);
            this.label7.TabIndex = 24;
            this.label7.Text = "Median Mark:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(154, 397);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(222, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "Trend of Competitors Results:";
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(94, 130);
            this.skillCb.Margin = new System.Windows.Forms.Padding(2);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(496, 21);
            this.skillCb.TabIndex = 26;
            this.skillCb.SelectedIndexChanged += new System.EventHandler(this.skillCb_SelectedIndexChanged);
            // 
            // totalMarksLbl
            // 
            this.totalMarksLbl.AutoSize = true;
            this.totalMarksLbl.BackColor = System.Drawing.SystemColors.Control;
            this.totalMarksLbl.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalMarksLbl.Location = new System.Drawing.Point(215, 171);
            this.totalMarksLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalMarksLbl.Name = "totalMarksLbl";
            this.totalMarksLbl.Size = new System.Drawing.Size(158, 26);
            this.totalMarksLbl.TabIndex = 27;
            this.totalMarksLbl.Text = "(Total Marks)";
            // 
            // easiestSessionLbl
            // 
            this.easiestSessionLbl.AutoSize = true;
            this.easiestSessionLbl.BackColor = System.Drawing.SystemColors.Control;
            this.easiestSessionLbl.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easiestSessionLbl.Location = new System.Drawing.Point(215, 243);
            this.easiestSessionLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.easiestSessionLbl.Name = "easiestSessionLbl";
            this.easiestSessionLbl.Size = new System.Drawing.Size(200, 26);
            this.easiestSessionLbl.TabIndex = 28;
            this.easiestSessionLbl.Text = "(Easiest Session)";
            // 
            // toughestSessionLbl
            // 
            this.toughestSessionLbl.AutoSize = true;
            this.toughestSessionLbl.BackColor = System.Drawing.SystemColors.Control;
            this.toughestSessionLbl.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toughestSessionLbl.Location = new System.Drawing.Point(217, 283);
            this.toughestSessionLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toughestSessionLbl.Name = "toughestSessionLbl";
            this.toughestSessionLbl.Size = new System.Drawing.Size(215, 26);
            this.toughestSessionLbl.TabIndex = 29;
            this.toughestSessionLbl.Text = "(ToughestSession)";
            // 
            // medianMarkLbl
            // 
            this.medianMarkLbl.AutoSize = true;
            this.medianMarkLbl.BackColor = System.Drawing.SystemColors.Control;
            this.medianMarkLbl.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medianMarkLbl.Location = new System.Drawing.Point(189, 329);
            this.medianMarkLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.medianMarkLbl.Name = "medianMarkLbl";
            this.medianMarkLbl.Size = new System.Drawing.Size(165, 26);
            this.medianMarkLbl.TabIndex = 30;
            this.medianMarkLbl.Text = "(MedianMark)";
            // 
            // trendCompetitor
            // 
            chartArea1.Name = "ChartArea1";
            this.trendCompetitor.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.trendCompetitor.Legends.Add(legend1);
            this.trendCompetitor.Location = new System.Drawing.Point(17, 416);
            this.trendCompetitor.Margin = new System.Windows.Forms.Padding(2);
            this.trendCompetitor.Name = "trendCompetitor";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.trendCompetitor.Series.Add(series1);
            this.trendCompetitor.Size = new System.Drawing.Size(574, 209);
            this.trendCompetitor.TabIndex = 31;
            this.trendCompetitor.Text = "chart1";
            // 
            // medianUpArrow
            // 
            this.medianUpArrow.Image = global::Session5.Properties.Resources.greenArrow;
            this.medianUpArrow.Location = new System.Drawing.Point(490, 329);
            this.medianUpArrow.Name = "medianUpArrow";
            this.medianUpArrow.Size = new System.Drawing.Size(65, 50);
            this.medianUpArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.medianUpArrow.TabIndex = 35;
            this.medianUpArrow.TabStop = false;
            this.medianUpArrow.Visible = false;
            // 
            // medianDownArrow
            // 
            this.medianDownArrow.Image = global::Session5.Properties.Resources.redArrow;
            this.medianDownArrow.Location = new System.Drawing.Point(420, 329);
            this.medianDownArrow.Name = "medianDownArrow";
            this.medianDownArrow.Size = new System.Drawing.Size(65, 50);
            this.medianDownArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.medianDownArrow.TabIndex = 34;
            this.medianDownArrow.TabStop = false;
            this.medianDownArrow.Visible = false;
            // 
            // currentFlag
            // 
            this.currentFlag.Location = new System.Drawing.Point(419, 162);
            this.currentFlag.Name = "currentFlag";
            this.currentFlag.Size = new System.Drawing.Size(124, 63);
            this.currentFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.currentFlag.TabIndex = 33;
            this.currentFlag.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(2, 638);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(599, 43);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(599, 80);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // AnalyzeResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 679);
            this.Controls.Add(this.medianUpArrow);
            this.Controls.Add(this.medianDownArrow);
            this.Controls.Add(this.currentFlag);
            this.Controls.Add(this.trendCompetitor);
            this.Controls.Add(this.medianMarkLbl);
            this.Controls.Add(this.toughestSessionLbl);
            this.Controls.Add(this.easiestSessionLbl);
            this.Controls.Add(this.totalMarksLbl);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AnalyzeResultsForm";
            this.Text = "ViewResultsForm";
            this.Load += new System.EventHandler(this.AnalyzeResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trendCompetitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianUpArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medianDownArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox skillCb;
        private System.Windows.Forms.Label totalMarksLbl;
        private System.Windows.Forms.Label easiestSessionLbl;
        private System.Windows.Forms.Label toughestSessionLbl;
        private System.Windows.Forms.Label medianMarkLbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart trendCompetitor;
        private System.Windows.Forms.PictureBox currentFlag;
        private System.Windows.Forms.PictureBox medianDownArrow;
        private System.Windows.Forms.PictureBox medianUpArrow;
    }
}