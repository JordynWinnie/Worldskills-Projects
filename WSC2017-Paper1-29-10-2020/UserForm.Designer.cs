namespace WSC2017_Paper1_29_10_2020
{
    partial class UserForm
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
            this.welcomeLbl = new System.Windows.Forms.Label();
            this.timeSpentLbl = new System.Windows.Forms.Label();
            this.numberCrashes = new System.Windows.Forms.Label();
            this.addUserBtn = new System.Windows.Forms.Button();
            this.logDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.logDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // welcomeLbl
            // 
            this.welcomeLbl.AutoSize = true;
            this.welcomeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLbl.Location = new System.Drawing.Point(27, 49);
            this.welcomeLbl.Name = "welcomeLbl";
            this.welcomeLbl.Size = new System.Drawing.Size(45, 16);
            this.welcomeLbl.TabIndex = 0;
            this.welcomeLbl.Text = "label1";
            // 
            // timeSpentLbl
            // 
            this.timeSpentLbl.AutoSize = true;
            this.timeSpentLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeSpentLbl.Location = new System.Drawing.Point(156, 102);
            this.timeSpentLbl.Name = "timeSpentLbl";
            this.timeSpentLbl.Size = new System.Drawing.Size(45, 16);
            this.timeSpentLbl.TabIndex = 1;
            this.timeSpentLbl.Text = "label1";
            // 
            // numberCrashes
            // 
            this.numberCrashes.AutoSize = true;
            this.numberCrashes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberCrashes.Location = new System.Drawing.Point(550, 102);
            this.numberCrashes.Name = "numberCrashes";
            this.numberCrashes.Size = new System.Drawing.Size(45, 16);
            this.numberCrashes.TabIndex = 2;
            this.numberCrashes.Text = "label1";
            // 
            // addUserBtn
            // 
            this.addUserBtn.Location = new System.Drawing.Point(12, 12);
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Size = new System.Drawing.Size(151, 23);
            this.addUserBtn.TabIndex = 3;
            this.addUserBtn.Text = "Exit / Logout";
            this.addUserBtn.UseVisualStyleBackColor = true;
            this.addUserBtn.Click += new System.EventHandler(this.addUserBtn_Click);
            // 
            // logDGV
            // 
            this.logDGV.AllowUserToAddRows = false;
            this.logDGV.AllowUserToDeleteRows = false;
            this.logDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.logDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logDGV.Location = new System.Drawing.Point(12, 162);
            this.logDGV.Name = "logDGV";
            this.logDGV.Size = new System.Drawing.Size(776, 455);
            this.logDGV.TabIndex = 4;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 629);
            this.Controls.Add(this.logDGV);
            this.Controls.Add(this.addUserBtn);
            this.Controls.Add(this.numberCrashes);
            this.Controls.Add(this.timeSpentLbl);
            this.Controls.Add(this.welcomeLbl);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLbl;
        private System.Windows.Forms.Label timeSpentLbl;
        private System.Windows.Forms.Label numberCrashes;
        private System.Windows.Forms.Button addUserBtn;
        private System.Windows.Forms.DataGridView logDGV;
    }
}