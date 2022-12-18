namespace AbuDhabu_Session4_12_11_2020
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
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldWorkLbl = new System.Windows.Forms.Label();
            this.sampleSizeLbl = new System.Windows.Forms.Label();
            this.summaryDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.summaryDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "View Detailed Results";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(271, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Flight Satisfaction (Summary)";
            // 
            // fieldWorkLbl
            // 
            this.fieldWorkLbl.AutoSize = true;
            this.fieldWorkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldWorkLbl.Location = new System.Drawing.Point(17, 126);
            this.fieldWorkLbl.Name = "fieldWorkLbl";
            this.fieldWorkLbl.Size = new System.Drawing.Size(221, 16);
            this.fieldWorkLbl.TabIndex = 4;
            this.fieldWorkLbl.Text = "Fieldwork: June 2017 - October 2017";
            // 
            // sampleSizeLbl
            // 
            this.sampleSizeLbl.AutoSize = true;
            this.sampleSizeLbl.Location = new System.Drawing.Point(423, 128);
            this.sampleSizeLbl.Name = "sampleSizeLbl";
            this.sampleSizeLbl.Size = new System.Drawing.Size(68, 13);
            this.sampleSizeLbl.TabIndex = 5;
            this.sampleSizeLbl.Text = "Sample Size:";
            // 
            // summaryDGV
            // 
            this.summaryDGV.AllowUserToAddRows = false;
            this.summaryDGV.AllowUserToDeleteRows = false;
            this.summaryDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.summaryDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.summaryDGV.Location = new System.Drawing.Point(20, 164);
            this.summaryDGV.Name = "summaryDGV";
            this.summaryDGV.Size = new System.Drawing.Size(1573, 83);
            this.summaryDGV.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1605, 273);
            this.Controls.Add(this.summaryDGV);
            this.Controls.Add(this.sampleSizeLbl);
            this.Controls.Add(this.fieldWorkLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.summaryDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fieldWorkLbl;
        private System.Windows.Forms.Label sampleSizeLbl;
        private System.Windows.Forms.DataGridView summaryDGV;
    }
}

