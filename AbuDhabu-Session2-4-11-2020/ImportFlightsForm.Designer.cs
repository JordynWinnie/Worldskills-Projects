namespace AbuDhabu_Session2_4_11_2020
{
    partial class ImportFlightsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.importButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.missingRecords = new System.Windows.Forms.Label();
            this.duplicateRecords = new System.Windows.Forms.Label();
            this.successfulRecords = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Text File with changes:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(445, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(472, 35);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(130, 23);
            this.importButton.TabIndex = 2;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.missingRecords);
            this.groupBox1.Controls.Add(this.duplicateRecords);
            this.groupBox1.Controls.Add(this.successfulRecords);
            this.groupBox1.Location = new System.Drawing.Point(20, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 130);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results:";
            // 
            // missingRecords
            // 
            this.missingRecords.AutoSize = true;
            this.missingRecords.Location = new System.Drawing.Point(25, 101);
            this.missingRecords.Name = "missingRecords";
            this.missingRecords.Size = new System.Drawing.Size(10, 13);
            this.missingRecords.TabIndex = 6;
            this.missingRecords.Text = "-";
            // 
            // duplicateRecords
            // 
            this.duplicateRecords.AutoSize = true;
            this.duplicateRecords.Location = new System.Drawing.Point(25, 70);
            this.duplicateRecords.Name = "duplicateRecords";
            this.duplicateRecords.Size = new System.Drawing.Size(10, 13);
            this.duplicateRecords.TabIndex = 5;
            this.duplicateRecords.Text = "-";
            // 
            // successfulRecords
            // 
            this.successfulRecords.AutoSize = true;
            this.successfulRecords.Location = new System.Drawing.Point(25, 35);
            this.successfulRecords.Name = "successfulRecords";
            this.successfulRecords.Size = new System.Drawing.Size(10, 13);
            this.successfulRecords.TabIndex = 4;
            this.successfulRecords.Text = "-";
            // 
            // ImportFlightsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 220);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "ImportFlightsForm";
            this.Text = "ImportFlightsForm";
            this.Load += new System.EventHandler(this.ImportFlightsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label missingRecords;
        private System.Windows.Forms.Label duplicateRecords;
        private System.Windows.Forms.Label successfulRecords;
    }
}