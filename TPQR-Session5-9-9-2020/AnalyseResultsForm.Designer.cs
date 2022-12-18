namespace TPQR_Session5_9_9_2020
{
    partial class AnalyseResultsForm
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
            this.bestPerformingLbl = new System.Windows.Forms.Label();
            this.skilCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flag = new System.Windows.Forms.PictureBox();
            this.easiestSesLbl = new System.Windows.Forms.Label();
            this.toughSesLbl = new System.Windows.Forms.Label();
            this.medianMarkLbl = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // bestPerformingLbl
            // 
            this.bestPerformingLbl.AutoSize = true;
            this.bestPerformingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bestPerformingLbl.Location = new System.Drawing.Point(98, 159);
            this.bestPerformingLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bestPerformingLbl.Name = "bestPerformingLbl";
            this.bestPerformingLbl.Size = new System.Drawing.Size(218, 24);
            this.bestPerformingLbl.TabIndex = 45;
            this.bestPerformingLbl.Text = "Best Performing Country:";
            // 
            // skilCb
            // 
            this.skilCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skilCb.FormattingEnabled = true;
            this.skilCb.Location = new System.Drawing.Point(162, 119);
            this.skilCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.skilCb.Name = "skilCb";
            this.skilCb.Size = new System.Drawing.Size(409, 21);
            this.skilCb.TabIndex = 43;
            this.skilCb.SelectedIndexChanged += new System.EventHandler(this.skilCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(116, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "Skill:";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(7, 12);
            this.backBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(140, 41);
            this.backBtn.TabIndex = 41;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(224, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 24);
            this.label2.TabIndex = 40;
            this.label2.Text = "Enter Marks";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(538, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 26);
            this.label1.TabIndex = 39;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(-2, 636);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(748, 37);
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(748, 67);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // flag
            // 
            this.flag.Location = new System.Drawing.Point(527, 159);
            this.flag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flag.Name = "flag";
            this.flag.Size = new System.Drawing.Size(126, 65);
            this.flag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flag.TabIndex = 46;
            this.flag.TabStop = false;
            // 
            // easiestSesLbl
            // 
            this.easiestSesLbl.AutoSize = true;
            this.easiestSesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easiestSesLbl.Location = new System.Drawing.Point(98, 242);
            this.easiestSesLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.easiestSesLbl.Name = "easiestSesLbl";
            this.easiestSesLbl.Size = new System.Drawing.Size(218, 24);
            this.easiestSesLbl.TabIndex = 47;
            this.easiestSesLbl.Text = "Best Performing Country:";
            // 
            // toughSesLbl
            // 
            this.toughSesLbl.AutoSize = true;
            this.toughSesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toughSesLbl.Location = new System.Drawing.Point(98, 287);
            this.toughSesLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toughSesLbl.Name = "toughSesLbl";
            this.toughSesLbl.Size = new System.Drawing.Size(218, 24);
            this.toughSesLbl.TabIndex = 48;
            this.toughSesLbl.Text = "Best Performing Country:";
            // 
            // medianMarkLbl
            // 
            this.medianMarkLbl.AutoSize = true;
            this.medianMarkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medianMarkLbl.Location = new System.Drawing.Point(98, 324);
            this.medianMarkLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.medianMarkLbl.Name = "medianMarkLbl";
            this.medianMarkLbl.Size = new System.Drawing.Size(218, 24);
            this.medianMarkLbl.TabIndex = 49;
            this.medianMarkLbl.Text = "Best Performing Country:";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(29, 367);
            this.chart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(701, 244);
            this.chart1.TabIndex = 50;
            this.chart1.Text = "chart1";
            // 
            // AnalyseResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 675);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.medianMarkLbl);
            this.Controls.Add(this.toughSesLbl);
            this.Controls.Add(this.easiestSesLbl);
            this.Controls.Add(this.flag);
            this.Controls.Add(this.bestPerformingLbl);
            this.Controls.Add(this.skilCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AnalyseResultsForm";
            this.Text = "AnalyseResultsForm";
            this.Load += new System.EventHandler(this.AnalyseResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bestPerformingLbl;
        private System.Windows.Forms.ComboBox skilCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox flag;
        private System.Windows.Forms.Label easiestSesLbl;
        private System.Windows.Forms.Label toughSesLbl;
        private System.Windows.Forms.Label medianMarkLbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}