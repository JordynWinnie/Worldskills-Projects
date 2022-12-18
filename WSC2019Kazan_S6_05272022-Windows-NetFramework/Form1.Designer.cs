using System.Windows.Forms;

namespace WSC2019Kazan_S6_05272022_Windows_NetFramework
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.emSpendingByDepGB = new System.Windows.Forms.GroupBox();
            this.emSpendingDepartmentDGV = new System.Windows.Forms.DataGridView();
            this.mostUsedPartsReportGB = new System.Windows.Forms.GroupBox();
            this.monthlyReportMostUsedDGV = new System.Windows.Forms.DataGridView();
            this.costAssetsGB = new System.Windows.Forms.GroupBox();
            this.monthyReportCostlyAssetsDGV = new System.Windows.Forms.DataGridView();
            this.inventoryControlBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.languageLbl = new System.Windows.Forms.Label();
            this.languageCB = new System.Windows.Forms.ComboBox();
            this.depSpendingRatioGB = new System.Windows.Forms.GroupBox();
            this.departmentSpendingRatioChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.monthlyDepartmentSpendingGB = new System.Windows.Forms.GroupBox();
            this.monthlyDepartmentSpendingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.emSpendingByDepGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emSpendingDepartmentDGV)).BeginInit();
            this.mostUsedPartsReportGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyReportMostUsedDGV)).BeginInit();
            this.costAssetsGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthyReportCostlyAssetsDGV)).BeginInit();
            this.depSpendingRatioGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentSpendingRatioChart)).BeginInit();
            this.monthlyDepartmentSpendingGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyDepartmentSpendingChart)).BeginInit();
            this.SuspendLayout();
            // 
            // emSpendingByDepGB
            // 
            this.emSpendingByDepGB.Controls.Add(this.emSpendingDepartmentDGV);
            this.emSpendingByDepGB.Location = new System.Drawing.Point(13, 12);
            this.emSpendingByDepGB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.emSpendingByDepGB.Name = "emSpendingByDepGB";
            this.emSpendingByDepGB.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.emSpendingByDepGB.Size = new System.Drawing.Size(943, 215);
            this.emSpendingByDepGB.TabIndex = 0;
            this.emSpendingByDepGB.TabStop = false;
            this.emSpendingByDepGB.Text = "Em Spending by Department";
            // 
            // emSpendingDepartmentDGV
            // 
            this.emSpendingDepartmentDGV.AllowUserToAddRows = false;
            this.emSpendingDepartmentDGV.AllowUserToDeleteRows = false;
            this.emSpendingDepartmentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.emSpendingDepartmentDGV.Location = new System.Drawing.Point(7, 23);
            this.emSpendingDepartmentDGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.emSpendingDepartmentDGV.Name = "emSpendingDepartmentDGV";
            this.emSpendingDepartmentDGV.ReadOnly = true;
            this.emSpendingDepartmentDGV.RowHeadersWidth = 51;
            this.emSpendingDepartmentDGV.RowTemplate.Height = 25;
            this.emSpendingDepartmentDGV.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.emSpendingDepartmentDGV.Size = new System.Drawing.Size(929, 186);
            this.emSpendingDepartmentDGV.TabIndex = 0;
            // 
            // mostUsedPartsReportGB
            // 
            this.mostUsedPartsReportGB.Controls.Add(this.monthlyReportMostUsedDGV);
            this.mostUsedPartsReportGB.Location = new System.Drawing.Point(13, 235);
            this.mostUsedPartsReportGB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mostUsedPartsReportGB.Name = "mostUsedPartsReportGB";
            this.mostUsedPartsReportGB.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mostUsedPartsReportGB.Size = new System.Drawing.Size(943, 215);
            this.mostUsedPartsReportGB.TabIndex = 1;
            this.mostUsedPartsReportGB.TabStop = false;
            this.mostUsedPartsReportGB.Text = "Monthly Report for Most Used Parts";
            // 
            // monthlyReportMostUsedDGV
            // 
            this.monthlyReportMostUsedDGV.AllowUserToAddRows = false;
            this.monthlyReportMostUsedDGV.AllowUserToDeleteRows = false;
            this.monthlyReportMostUsedDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monthlyReportMostUsedDGV.Location = new System.Drawing.Point(7, 30);
            this.monthlyReportMostUsedDGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.monthlyReportMostUsedDGV.Name = "monthlyReportMostUsedDGV";
            this.monthlyReportMostUsedDGV.ReadOnly = true;
            this.monthlyReportMostUsedDGV.RowHeadersWidth = 51;
            this.monthlyReportMostUsedDGV.RowTemplate.Height = 25;
            this.monthlyReportMostUsedDGV.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.monthlyReportMostUsedDGV.Size = new System.Drawing.Size(929, 180);
            this.monthlyReportMostUsedDGV.TabIndex = 1;
            // 
            // costAssetsGB
            // 
            this.costAssetsGB.Controls.Add(this.monthyReportCostlyAssetsDGV);
            this.costAssetsGB.Location = new System.Drawing.Point(13, 457);
            this.costAssetsGB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.costAssetsGB.Name = "costAssetsGB";
            this.costAssetsGB.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.costAssetsGB.Size = new System.Drawing.Size(943, 215);
            this.costAssetsGB.TabIndex = 2;
            this.costAssetsGB.TabStop = false;
            this.costAssetsGB.Text = "Monthly Report for Most Used Parts";
            // 
            // monthyReportCostlyAssetsDGV
            // 
            this.monthyReportCostlyAssetsDGV.AllowUserToAddRows = false;
            this.monthyReportCostlyAssetsDGV.AllowUserToDeleteRows = false;
            this.monthyReportCostlyAssetsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monthyReportCostlyAssetsDGV.Location = new System.Drawing.Point(7, 23);
            this.monthyReportCostlyAssetsDGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.monthyReportCostlyAssetsDGV.Name = "monthyReportCostlyAssetsDGV";
            this.monthyReportCostlyAssetsDGV.ReadOnly = true;
            this.monthyReportCostlyAssetsDGV.RowHeadersWidth = 51;
            this.monthyReportCostlyAssetsDGV.RowTemplate.Height = 25;
            this.monthyReportCostlyAssetsDGV.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.monthyReportCostlyAssetsDGV.Size = new System.Drawing.Size(929, 186);
            this.monthyReportCostlyAssetsDGV.TabIndex = 2;
            // 
            // inventoryControlBtn
            // 
            this.inventoryControlBtn.Location = new System.Drawing.Point(13, 678);
            this.inventoryControlBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inventoryControlBtn.Name = "inventoryControlBtn";
            this.inventoryControlBtn.Size = new System.Drawing.Size(181, 25);
            this.inventoryControlBtn.TabIndex = 3;
            this.inventoryControlBtn.Text = "Inventory Control";
            this.inventoryControlBtn.UseVisualStyleBackColor = true;
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(203, 678);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(181, 25);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            // 
            // languageLbl
            // 
            this.languageLbl.AutoSize = true;
            this.languageLbl.Location = new System.Drawing.Point(467, 687);
            this.languageLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.languageLbl.Name = "languageLbl";
            this.languageLbl.Size = new System.Drawing.Size(71, 16);
            this.languageLbl.TabIndex = 5;
            this.languageLbl.Text = "Language:";
            // 
            // languageCB
            // 
            this.languageCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageCB.FormattingEnabled = true;
            this.languageCB.Location = new System.Drawing.Point(544, 684);
            this.languageCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.languageCB.Name = "languageCB";
            this.languageCB.Size = new System.Drawing.Size(412, 24);
            this.languageCB.TabIndex = 6;
            this.languageCB.SelectedIndexChanged += new System.EventHandler(this.languageCB_SelectedIndexChanged);
            // 
            // depSpendingRatioGB
            // 
            this.depSpendingRatioGB.Controls.Add(this.departmentSpendingRatioChart);
            this.depSpendingRatioGB.Location = new System.Drawing.Point(972, 11);
            this.depSpendingRatioGB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.depSpendingRatioGB.Name = "depSpendingRatioGB";
            this.depSpendingRatioGB.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.depSpendingRatioGB.Size = new System.Drawing.Size(636, 338);
            this.depSpendingRatioGB.TabIndex = 7;
            this.depSpendingRatioGB.TabStop = false;
            this.depSpendingRatioGB.Text = "Department Spending Ratio";
            // 
            // departmentSpendingRatioChart
            // 
            chartArea5.Name = "ChartArea1";
            this.departmentSpendingRatioChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.departmentSpendingRatioChart.Legends.Add(legend5);
            this.departmentSpendingRatioChart.Location = new System.Drawing.Point(8, 22);
            this.departmentSpendingRatioChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.departmentSpendingRatioChart.Name = "departmentSpendingRatioChart";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.departmentSpendingRatioChart.Series.Add(series5);
            this.departmentSpendingRatioChart.Size = new System.Drawing.Size(620, 308);
            this.departmentSpendingRatioChart.TabIndex = 0;
            this.departmentSpendingRatioChart.Text = "chart1";
            // 
            // monthlyDepartmentSpendingGB
            // 
            this.monthlyDepartmentSpendingGB.Controls.Add(this.monthlyDepartmentSpendingChart);
            this.monthlyDepartmentSpendingGB.Location = new System.Drawing.Point(972, 358);
            this.monthlyDepartmentSpendingGB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.monthlyDepartmentSpendingGB.Name = "monthlyDepartmentSpendingGB";
            this.monthlyDepartmentSpendingGB.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.monthlyDepartmentSpendingGB.Size = new System.Drawing.Size(636, 351);
            this.monthlyDepartmentSpendingGB.TabIndex = 8;
            this.monthlyDepartmentSpendingGB.TabStop = false;
            this.monthlyDepartmentSpendingGB.Text = "Monthly Department Spending";
            // 
            // monthlyDepartmentSpendingChart
            // 
            chartArea6.AxisX.Interval = 1D;
            chartArea6.Name = "ChartArea1";
            this.monthlyDepartmentSpendingChart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.monthlyDepartmentSpendingChart.Legends.Add(legend6);
            this.monthlyDepartmentSpendingChart.Location = new System.Drawing.Point(8, 23);
            this.monthlyDepartmentSpendingChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.monthlyDepartmentSpendingChart.Name = "monthlyDepartmentSpendingChart";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.monthlyDepartmentSpendingChart.Series.Add(series6);
            this.monthlyDepartmentSpendingChart.Size = new System.Drawing.Size(620, 329);
            this.monthlyDepartmentSpendingChart.TabIndex = 0;
            this.monthlyDepartmentSpendingChart.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1650, 722);
            this.Controls.Add(this.monthlyDepartmentSpendingGB);
            this.Controls.Add(this.depSpendingRatioGB);
            this.Controls.Add(this.languageCB);
            this.Controls.Add(this.languageLbl);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.inventoryControlBtn);
            this.Controls.Add(this.costAssetsGB);
            this.Controls.Add(this.mostUsedPartsReportGB);
            this.Controls.Add(this.emSpendingByDepGB);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Inventory Dashboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.emSpendingByDepGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.emSpendingDepartmentDGV)).EndInit();
            this.mostUsedPartsReportGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.monthlyReportMostUsedDGV)).EndInit();
            this.costAssetsGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.monthyReportCostlyAssetsDGV)).EndInit();
            this.depSpendingRatioGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.departmentSpendingRatioChart)).EndInit();
            this.monthlyDepartmentSpendingGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.monthlyDepartmentSpendingChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox emSpendingByDepGB;
        private GroupBox mostUsedPartsReportGB;
        private GroupBox costAssetsGB;
        private Button inventoryControlBtn;
        private Button closeBtn;
        private Label languageLbl;
        private ComboBox languageCB;
        private GroupBox depSpendingRatioGB;
        private GroupBox monthlyDepartmentSpendingGB;
        private DataGridView emSpendingDepartmentDGV;
        private DataGridView monthlyReportMostUsedDGV;
        private DataGridView monthyReportCostlyAssetsDGV;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart departmentSpendingRatioChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart monthlyDepartmentSpendingChart;
    }
}

