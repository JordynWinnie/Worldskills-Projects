namespace TPQR_Session4_9_8_2020
{
    partial class OverallTrainingProgressForm
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
            this.skillCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.traineeCatDGV = new System.Windows.Forms.DataGridView();
            this.expertsDGV = new System.Windows.Forms.DataGridView();
            this.competitorsDGV = new System.Windows.Forms.DataGridView();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traineeCatDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.competitorsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(259, 154);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(679, 24);
            this.skillCb.TabIndex = 45;
            this.skillCb.SelectedIndexChanged += new System.EventHandler(this.skillCb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(168, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 29);
            this.label3.TabIndex = 44;
            this.label3.Text = "Skill:";
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(8, 24);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(192, 31);
            this.closeBtn.TabIndex = 43;
            this.closeBtn.Text = "Back";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(356, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(356, 29);
            this.label2.TabIndex = 42;
            this.label2.Text = "Track Overall Training Progress";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(798, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 32);
            this.label1.TabIndex = 41;
            this.label1.Text = "ASEAN Skill 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox2.Location = new System.Drawing.Point(-5, 804);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1078, 93);
            this.pictureBox2.TabIndex = 40;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Location = new System.Drawing.Point(-5, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1078, 79);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // traineeCatDGV
            // 
            this.traineeCatDGV.AllowUserToAddRows = false;
            this.traineeCatDGV.AllowUserToDeleteRows = false;
            this.traineeCatDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.traineeCatDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.traineeCatDGV.Location = new System.Drawing.Point(30, 194);
            this.traineeCatDGV.Name = "traineeCatDGV";
            this.traineeCatDGV.RowHeadersWidth = 51;
            this.traineeCatDGV.RowTemplate.Height = 24;
            this.traineeCatDGV.Size = new System.Drawing.Size(1027, 150);
            this.traineeCatDGV.TabIndex = 46;
            // 
            // expertsDGV
            // 
            this.expertsDGV.AllowUserToAddRows = false;
            this.expertsDGV.AllowUserToDeleteRows = false;
            this.expertsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.expertsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expertsDGV.Location = new System.Drawing.Point(30, 375);
            this.expertsDGV.Name = "expertsDGV";
            this.expertsDGV.RowHeadersWidth = 51;
            this.expertsDGV.RowTemplate.Height = 24;
            this.expertsDGV.Size = new System.Drawing.Size(486, 150);
            this.expertsDGV.TabIndex = 47;
            // 
            // competitorsDGV
            // 
            this.competitorsDGV.AllowUserToAddRows = false;
            this.competitorsDGV.AllowUserToDeleteRows = false;
            this.competitorsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.competitorsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.competitorsDGV.Location = new System.Drawing.Point(547, 375);
            this.competitorsDGV.Name = "competitorsDGV";
            this.competitorsDGV.RowHeadersWidth = 51;
            this.competitorsDGV.RowTemplate.Height = 24;
            this.competitorsDGV.Size = new System.Drawing.Size(510, 150);
            this.competitorsDGV.TabIndex = 48;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(30, 553);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(1027, 235);
            this.chart.TabIndex = 49;
            this.chart.Text = "chart1";
            // 
            // OverallTrainingProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 897);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.competitorsDGV);
            this.Controls.Add(this.expertsDGV);
            this.Controls.Add(this.traineeCatDGV);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "OverallTrainingProgressForm";
            this.Text = "OverallTrainingProgressForm";
            this.Load += new System.EventHandler(this.OverallTrainingProgressForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traineeCatDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.competitorsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox skillCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView traineeCatDGV;
        private System.Windows.Forms.DataGridView expertsDGV;
        private System.Windows.Forms.DataGridView competitorsDGV;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}