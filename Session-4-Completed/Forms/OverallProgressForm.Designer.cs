namespace Session_4_JordanKhong.Forms
{
    partial class OverallProgressForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.skillCb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trainingModuleAssignmentDateDGV = new System.Windows.Forms.DataGridView();
            this.expertTrainingDGV = new System.Windows.Forms.DataGridView();
            this.competitorTrainingDGV = new System.Windows.Forms.DataGridView();
            this.overallProgressChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainingModuleAssignmentDateDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertTrainingDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.competitorTrainingDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overallProgressChart)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(9, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 37);
            this.button1.TabIndex = 12;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(764, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 34);
            this.label1.TabIndex = 11;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(0, 841);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1065, 52);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1065, 87);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(300, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(459, 34);
            this.label2.TabIndex = 13;
            this.label2.Text = "Track Overall Training Progress";
            // 
            // skillCb
            // 
            this.skillCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillCb.FormattingEnabled = true;
            this.skillCb.Location = new System.Drawing.Point(387, 164);
            this.skillCb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skillCb.Name = "skillCb";
            this.skillCb.Size = new System.Drawing.Size(381, 24);
            this.skillCb.TabIndex = 23;
            this.skillCb.SelectedIndexChanged += new System.EventHandler(this.skillCb_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(309, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Skill:";
            // 
            // trainingModuleAssignmentDateDGV
            // 
            this.trainingModuleAssignmentDateDGV.AllowUserToAddRows = false;
            this.trainingModuleAssignmentDateDGV.AllowUserToDeleteRows = false;
            this.trainingModuleAssignmentDateDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.trainingModuleAssignmentDateDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trainingModuleAssignmentDateDGV.Location = new System.Drawing.Point(28, 215);
            this.trainingModuleAssignmentDateDGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trainingModuleAssignmentDateDGV.Name = "trainingModuleAssignmentDateDGV";
            this.trainingModuleAssignmentDateDGV.RowHeadersWidth = 51;
            this.trainingModuleAssignmentDateDGV.Size = new System.Drawing.Size(1007, 112);
            this.trainingModuleAssignmentDateDGV.TabIndex = 24;
            // 
            // expertTrainingDGV
            // 
            this.expertTrainingDGV.AllowUserToAddRows = false;
            this.expertTrainingDGV.AllowUserToDeleteRows = false;
            this.expertTrainingDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.expertTrainingDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expertTrainingDGV.Location = new System.Drawing.Point(28, 335);
            this.expertTrainingDGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.expertTrainingDGV.Name = "expertTrainingDGV";
            this.expertTrainingDGV.RowHeadersWidth = 51;
            this.expertTrainingDGV.Size = new System.Drawing.Size(493, 185);
            this.expertTrainingDGV.TabIndex = 25;
            // 
            // competitorTrainingDGV
            // 
            this.competitorTrainingDGV.AllowUserToAddRows = false;
            this.competitorTrainingDGV.AllowUserToDeleteRows = false;
            this.competitorTrainingDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.competitorTrainingDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.competitorTrainingDGV.Location = new System.Drawing.Point(529, 335);
            this.competitorTrainingDGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.competitorTrainingDGV.Name = "competitorTrainingDGV";
            this.competitorTrainingDGV.RowHeadersWidth = 51;
            this.competitorTrainingDGV.Size = new System.Drawing.Size(505, 185);
            this.competitorTrainingDGV.TabIndex = 26;
            // 
            // overallProgressChart
            // 
            chartArea1.Name = "ChartArea1";
            this.overallProgressChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.overallProgressChart.Legends.Add(legend1);
            this.overallProgressChart.Location = new System.Drawing.Point(28, 527);
            this.overallProgressChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.overallProgressChart.Name = "overallProgressChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.overallProgressChart.Series.Add(series1);
            this.overallProgressChart.Size = new System.Drawing.Size(1007, 299);
            this.overallProgressChart.TabIndex = 27;
            this.overallProgressChart.Text = "chart1";
            // 
            // OverallProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 891);
            this.Controls.Add(this.overallProgressChart);
            this.Controls.Add(this.competitorTrainingDGV);
            this.Controls.Add(this.expertTrainingDGV);
            this.Controls.Add(this.trainingModuleAssignmentDateDGV);
            this.Controls.Add(this.skillCb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "OverallProgressForm";
            this.Text = "OverallProgressForm";
            this.Load += new System.EventHandler(this.OverallProgressForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainingModuleAssignmentDateDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertTrainingDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.competitorTrainingDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overallProgressChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox skillCb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView trainingModuleAssignmentDateDGV;
        private System.Windows.Forms.DataGridView expertTrainingDGV;
        private System.Windows.Forms.DataGridView competitorTrainingDGV;
        private System.Windows.Forms.DataVisualization.Charting.Chart overallProgressChart;
    }
}