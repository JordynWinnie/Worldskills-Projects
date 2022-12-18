namespace Session1_JordanKhong.Forms
{
    partial class MainMenuForm
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.resourceManagerLoginBtn = new System.Windows.Forms.Button();
            this.createNewAccountBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(197, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "ASEAN Skills 2020 26 - 28 Jul 2020";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(0, 412);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(802, 41);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(802, 81);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // resourceManagerLoginBtn
            // 
            this.resourceManagerLoginBtn.Location = new System.Drawing.Point(113, 244);
            this.resourceManagerLoginBtn.Margin = new System.Windows.Forms.Padding(2);
            this.resourceManagerLoginBtn.Name = "resourceManagerLoginBtn";
            this.resourceManagerLoginBtn.Size = new System.Drawing.Size(564, 45);
            this.resourceManagerLoginBtn.TabIndex = 6;
            this.resourceManagerLoginBtn.Text = "Resource Manager Login";
            this.resourceManagerLoginBtn.UseVisualStyleBackColor = true;
            this.resourceManagerLoginBtn.Click += new System.EventHandler(this.resourceManagerLoginBtn_Click);
            // 
            // createNewAccountBtn
            // 
            this.createNewAccountBtn.Location = new System.Drawing.Point(113, 195);
            this.createNewAccountBtn.Margin = new System.Windows.Forms.Padding(2);
            this.createNewAccountBtn.Name = "createNewAccountBtn";
            this.createNewAccountBtn.Size = new System.Drawing.Size(564, 45);
            this.createNewAccountBtn.TabIndex = 5;
            this.createNewAccountBtn.Text = "Create New Account";
            this.createNewAccountBtn.UseVisualStyleBackColor = true;
            this.createNewAccountBtn.Click += new System.EventHandler(this.createNewAccountBtn_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.resourceManagerLoginBtn);
            this.Controls.Add(this.createNewAccountBtn);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button resourceManagerLoginBtn;
        private System.Windows.Forms.Button createNewAccountBtn;
    }
}