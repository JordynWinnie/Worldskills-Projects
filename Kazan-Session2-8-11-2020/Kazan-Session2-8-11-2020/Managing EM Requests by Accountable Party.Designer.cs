namespace Kazan_Session2_8_11_2020
{
    partial class Managing_EM_Requests_by_Accountable_Party
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
            this.assetDGV = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.assetDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Assets:";
            // 
            // assetDGV
            // 
            this.assetDGV.AllowUserToAddRows = false;
            this.assetDGV.AllowUserToDeleteRows = false;
            this.assetDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.assetDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assetDGV.Location = new System.Drawing.Point(16, 45);
            this.assetDGV.Name = "assetDGV";
            this.assetDGV.Size = new System.Drawing.Size(772, 360);
            this.assetDGV.TabIndex = 1;
            this.assetDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.assetDGV_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 411);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(772, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send EM Request";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Managing_EM_Requests_by_Accountable_Party
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.assetDGV);
            this.Controls.Add(this.label1);
            this.Name = "Managing_EM_Requests_by_Accountable_Party";
            this.Text = "Managing_EM_Requests_by_Accountable_Party";
            this.Load += new System.EventHandler(this.Managing_EM_Requests_by_Accountable_Party_Load);
            ((System.ComponentModel.ISupportInitialize)(this.assetDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView assetDGV;
        private System.Windows.Forms.Button button1;
    }
}