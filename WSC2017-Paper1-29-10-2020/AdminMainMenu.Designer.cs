namespace WSC2017_Paper1_29_10_2020
{
    partial class AdminMainMenu
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
            this.addUserBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.officeCb = new System.Windows.Forms.ComboBox();
            this.userDGV = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // addUserBtn
            // 
            this.addUserBtn.Location = new System.Drawing.Point(12, 12);
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Size = new System.Drawing.Size(151, 23);
            this.addUserBtn.TabIndex = 0;
            this.addUserBtn.Text = "Add User";
            this.addUserBtn.UseVisualStyleBackColor = true;
            this.addUserBtn.Click += new System.EventHandler(this.addUserBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Exit / Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Offices:";
            // 
            // officeCb
            // 
            this.officeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.officeCb.FormattingEnabled = true;
            this.officeCb.Location = new System.Drawing.Point(61, 50);
            this.officeCb.Name = "officeCb";
            this.officeCb.Size = new System.Drawing.Size(727, 21);
            this.officeCb.TabIndex = 3;
            this.officeCb.SelectedIndexChanged += new System.EventHandler(this.officeCb_SelectedIndexChanged);
            // 
            // userDGV
            // 
            this.userDGV.AllowUserToAddRows = false;
            this.userDGV.AllowUserToDeleteRows = false;
            this.userDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.userDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDGV.Location = new System.Drawing.Point(15, 87);
            this.userDGV.Name = "userDGV";
            this.userDGV.Size = new System.Drawing.Size(773, 481);
            this.userDGV.TabIndex = 4;
            this.userDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userDGV_CellClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(172, 583);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Enable / Disable Login";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 583);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Change Role";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AdminMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 629);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.userDGV);
            this.Controls.Add(this.officeCb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addUserBtn);
            this.Name = "AdminMainMenu";
            this.Text = "AdminMainMenu";
            this.Load += new System.EventHandler(this.AdminMainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addUserBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox officeCb;
        private System.Windows.Forms.DataGridView userDGV;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}