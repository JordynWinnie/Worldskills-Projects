namespace WSC2019Kazan_S6_05272022_Windows
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
            this.emSpendingByDepGB = new System.Windows.Forms.GroupBox();
            this.emSpendingDepartmentDGV = new System.Windows.Forms.DataGridView();
            this.mostUsedPartsReportGB = new System.Windows.Forms.GroupBox();
            this.costAssetsGB = new System.Windows.Forms.GroupBox();
            this.inventoryControlBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.languageLbl = new System.Windows.Forms.Label();
            this.languageCB = new System.Windows.Forms.ComboBox();
            this.depSpendingRatioGB = new System.Windows.Forms.GroupBox();
            this.monthlyDepartmentSpendingGB = new System.Windows.Forms.GroupBox();
            this.monthlyReportMostUsedDGV = new System.Windows.Forms.DataGridView();
            this.emSpendingByDepGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emSpendingDepartmentDGV)).BeginInit();
            this.mostUsedPartsReportGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyReportMostUsedDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // emSpendingByDepGB
            // 
            this.emSpendingByDepGB.Controls.Add(this.emSpendingDepartmentDGV);
            this.emSpendingByDepGB.Location = new System.Drawing.Point(12, 12);
            this.emSpendingByDepGB.Name = "emSpendingByDepGB";
            this.emSpendingByDepGB.Size = new System.Drawing.Size(825, 202);
            this.emSpendingByDepGB.TabIndex = 0;
            this.emSpendingByDepGB.TabStop = false;
            this.emSpendingByDepGB.Text = "Em Spending by Department";
            // 
            // emSpendingDepartmentDGV
            // 
            this.emSpendingDepartmentDGV.AllowUserToAddRows = false;
            this.emSpendingDepartmentDGV.AllowUserToDeleteRows = false;
            this.emSpendingDepartmentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.emSpendingDepartmentDGV.Location = new System.Drawing.Point(6, 22);
            this.emSpendingDepartmentDGV.Name = "emSpendingDepartmentDGV";
            this.emSpendingDepartmentDGV.ReadOnly = true;
            this.emSpendingDepartmentDGV.RowTemplate.Height = 25;
            this.emSpendingDepartmentDGV.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.emSpendingDepartmentDGV.Size = new System.Drawing.Size(813, 174);
            this.emSpendingDepartmentDGV.TabIndex = 0;
            // 
            // mostUsedPartsReportGB
            // 
            this.mostUsedPartsReportGB.Controls.Add(this.monthlyReportMostUsedDGV);
            this.mostUsedPartsReportGB.Location = new System.Drawing.Point(12, 220);
            this.mostUsedPartsReportGB.Name = "mostUsedPartsReportGB";
            this.mostUsedPartsReportGB.Size = new System.Drawing.Size(825, 202);
            this.mostUsedPartsReportGB.TabIndex = 1;
            this.mostUsedPartsReportGB.TabStop = false;
            this.mostUsedPartsReportGB.Text = "Monthly Report for Most Used Parts";
            // 
            // costAssetsGB
            // 
            this.costAssetsGB.Location = new System.Drawing.Point(12, 428);
            this.costAssetsGB.Name = "costAssetsGB";
            this.costAssetsGB.Size = new System.Drawing.Size(825, 202);
            this.costAssetsGB.TabIndex = 2;
            this.costAssetsGB.TabStop = false;
            this.costAssetsGB.Text = "Monthly Report for Most Used Parts";
            // 
            // inventoryControlBtn
            // 
            this.inventoryControlBtn.Location = new System.Drawing.Point(12, 636);
            this.inventoryControlBtn.Name = "inventoryControlBtn";
            this.inventoryControlBtn.Size = new System.Drawing.Size(159, 23);
            this.inventoryControlBtn.TabIndex = 3;
            this.inventoryControlBtn.Text = "Inventory Control";
            this.inventoryControlBtn.UseVisualStyleBackColor = true;
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(177, 636);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(159, 23);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // languageLbl
            // 
            this.languageLbl.AutoSize = true;
            this.languageLbl.Location = new System.Drawing.Point(408, 644);
            this.languageLbl.Name = "languageLbl";
            this.languageLbl.Size = new System.Drawing.Size(62, 15);
            this.languageLbl.TabIndex = 5;
            this.languageLbl.Text = "Language:";
            // 
            // languageCB
            // 
            this.languageCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageCB.FormattingEnabled = true;
            this.languageCB.Location = new System.Drawing.Point(476, 641);
            this.languageCB.Name = "languageCB";
            this.languageCB.Size = new System.Drawing.Size(361, 23);
            this.languageCB.TabIndex = 6;
            // 
            // depSpendingRatioGB
            // 
            this.depSpendingRatioGB.Location = new System.Drawing.Point(843, 12);
            this.depSpendingRatioGB.Name = "depSpendingRatioGB";
            this.depSpendingRatioGB.Size = new System.Drawing.Size(459, 317);
            this.depSpendingRatioGB.TabIndex = 7;
            this.depSpendingRatioGB.TabStop = false;
            this.depSpendingRatioGB.Text = "Department Spending Ratio";
            // 
            // monthlyDepartmentSpendingGB
            // 
            this.monthlyDepartmentSpendingGB.Location = new System.Drawing.Point(843, 335);
            this.monthlyDepartmentSpendingGB.Name = "monthlyDepartmentSpendingGB";
            this.monthlyDepartmentSpendingGB.Size = new System.Drawing.Size(459, 329);
            this.monthlyDepartmentSpendingGB.TabIndex = 8;
            this.monthlyDepartmentSpendingGB.TabStop = false;
            this.monthlyDepartmentSpendingGB.Text = "Monthly Department Spending";
            // 
            // monthlyReportMostUsedDGV
            // 
            this.monthlyReportMostUsedDGV.AllowUserToAddRows = false;
            this.monthlyReportMostUsedDGV.AllowUserToDeleteRows = false;
            this.monthlyReportMostUsedDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monthlyReportMostUsedDGV.Location = new System.Drawing.Point(6, 28);
            this.monthlyReportMostUsedDGV.Name = "monthlyReportMostUsedDGV";
            this.monthlyReportMostUsedDGV.ReadOnly = true;
            this.monthlyReportMostUsedDGV.RowTemplate.Height = 25;
            this.monthlyReportMostUsedDGV.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.monthlyReportMostUsedDGV.Size = new System.Drawing.Size(813, 168);
            this.monthlyReportMostUsedDGV.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 677);
            this.Controls.Add(this.monthlyDepartmentSpendingGB);
            this.Controls.Add(this.depSpendingRatioGB);
            this.Controls.Add(this.languageCB);
            this.Controls.Add(this.languageLbl);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.inventoryControlBtn);
            this.Controls.Add(this.costAssetsGB);
            this.Controls.Add(this.mostUsedPartsReportGB);
            this.Controls.Add(this.emSpendingByDepGB);
            this.Name = "Form1";
            this.Text = "Inventory Dashboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.emSpendingByDepGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.emSpendingDepartmentDGV)).EndInit();
            this.mostUsedPartsReportGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.monthlyReportMostUsedDGV)).EndInit();
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
    }
}