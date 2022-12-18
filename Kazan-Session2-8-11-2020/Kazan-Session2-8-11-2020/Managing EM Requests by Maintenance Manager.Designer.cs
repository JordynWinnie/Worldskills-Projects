namespace Kazan_Session2_8_11_2020
{
    partial class Managing_EM_Requests_by_Maintenance_Manager
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
            this.assetDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.assetDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 413);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(772, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Manage Request";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // assetDGV
            // 
            this.assetDGV.AllowUserToAddRows = false;
            this.assetDGV.AllowUserToDeleteRows = false;
            this.assetDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.assetDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assetDGV.Location = new System.Drawing.Point(16, 47);
            this.assetDGV.Name = "assetDGV";
            this.assetDGV.Size = new System.Drawing.Size(772, 360);
            this.assetDGV.TabIndex = 4;
            this.assetDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.assetDGV_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "List of Assets Requesting EM:";
            // 
            // Managing_EM_Requests_by_Maintenance_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.assetDGV);
            this.Controls.Add(this.label1);
            this.Name = "Managing_EM_Requests_by_Maintenance_Manager";
            this.Text = "Managing_EM_Requests_by_Maintenance_Manager";
            this.Load += new System.EventHandler(this.Managing_EM_Requests_by_Maintenance_Manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.assetDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView assetDGV;
        private System.Windows.Forms.Label label1;
    }
}