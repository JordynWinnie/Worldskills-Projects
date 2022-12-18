namespace Session2__17_12_2019
{
    partial class ManageEmRequestAccountableParty
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
            this.assetDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.sendToEmBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.assetDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // assetDGV
            // 
            this.assetDGV.AllowUserToAddRows = false;
            this.assetDGV.AllowUserToDeleteRows = false;
            this.assetDGV.AllowUserToOrderColumns = true;
            this.assetDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assetDGV.Location = new System.Drawing.Point(15, 29);
            this.assetDGV.Name = "assetDGV";
            this.assetDGV.RowHeadersWidth = 51;
            this.assetDGV.RowTemplate.Height = 24;
            this.assetDGV.Size = new System.Drawing.Size(773, 367);
            this.assetDGV.TabIndex = 0;
            this.assetDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.assetDGV_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available Assets:";
            // 
            // sendToEmBtn
            // 
            this.sendToEmBtn.Location = new System.Drawing.Point(15, 402);
            this.sendToEmBtn.Name = "sendToEmBtn";
            this.sendToEmBtn.Size = new System.Drawing.Size(556, 36);
            this.sendToEmBtn.TabIndex = 2;
            this.sendToEmBtn.Text = "Send Emergency Maintanence Request";
            this.sendToEmBtn.UseVisualStyleBackColor = true;
            this.sendToEmBtn.Click += new System.EventHandler(this.sendToEmBtn_Click);
            // 
            // ManageEmRequestAccountableParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sendToEmBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.assetDGV);
            this.Name = "ManageEmRequestAccountableParty";
            this.Text = "ManageEmRequestAccountableParty";
            this.Load += new System.EventHandler(this.ManageEmRequestAccountableParty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.assetDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView assetDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendToEmBtn;
    }
}