namespace Session2__17_12_2019
{
    partial class RegisteringNewEmRequestForAsset
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
            this.components = new System.ComponentModel.Container();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.assetNameLbl = new System.Windows.Forms.Label();
            this.departmentLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.assetSNLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.priorityCb = new System.Windows.Forms.ComboBox();
            this.prioritiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.session2DataSet = new Session2__17_12_2019.Session2DataSet();
            this.otherCondTb = new System.Windows.Forms.TextBox();
            this.descEmTb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.prioritiesTableAdapter = new Session2__17_12_2019.Session2DataSetTableAdapters.PrioritiesTableAdapter();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prioritiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.session2DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.assetNameLbl);
            this.groupBox1.Controls.Add(this.departmentLbl);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.assetSNLbl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Asset";
            // 
            // assetNameLbl
            // 
            this.assetNameLbl.AutoSize = true;
            this.assetNameLbl.Location = new System.Drawing.Point(365, 46);
            this.assetNameLbl.Name = "assetNameLbl";
            this.assetNameLbl.Size = new System.Drawing.Size(46, 17);
            this.assetNameLbl.TabIndex = 5;
            this.assetNameLbl.Text = "label6";
            // 
            // departmentLbl
            // 
            this.departmentLbl.AutoSize = true;
            this.departmentLbl.Location = new System.Drawing.Point(623, 46);
            this.departmentLbl.Name = "departmentLbl";
            this.departmentLbl.Size = new System.Drawing.Size(46, 17);
            this.departmentLbl.TabIndex = 4;
            this.departmentLbl.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(531, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Department:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Asset Name:";
            // 
            // assetSNLbl
            // 
            this.assetSNLbl.AutoSize = true;
            this.assetSNLbl.Location = new System.Drawing.Point(98, 46);
            this.assetSNLbl.Name = "assetSNLbl";
            this.assetSNLbl.Size = new System.Drawing.Size(46, 17);
            this.assetSNLbl.TabIndex = 1;
            this.assetSNLbl.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asset SN:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.priorityCb);
            this.groupBox2.Controls.Add(this.otherCondTb);
            this.groupBox2.Controls.Add(this.descEmTb);
            this.groupBox2.Location = new System.Drawing.Point(13, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(775, 226);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request Report";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Other Considerations:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Description of Emergency:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Priority:";
            // 
            // priorityCb
            // 
            this.priorityCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityCb.FormattingEnabled = true;
            this.priorityCb.Location = new System.Drawing.Point(83, 34);
            this.priorityCb.Name = "priorityCb";
            this.priorityCb.Size = new System.Drawing.Size(214, 24);
            this.priorityCb.TabIndex = 2;
            // 
            // prioritiesBindingSource
            // 
            this.prioritiesBindingSource.DataMember = "Priorities";
            this.prioritiesBindingSource.DataSource = this.session2DataSet;
            // 
            // session2DataSet
            // 
            this.session2DataSet.DataSetName = "Session2DataSet";
            this.session2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // otherCondTb
            // 
            this.otherCondTb.Location = new System.Drawing.Point(83, 165);
            this.otherCondTb.Multiline = true;
            this.otherCondTb.Name = "otherCondTb";
            this.otherCondTb.Size = new System.Drawing.Size(686, 46);
            this.otherCondTb.TabIndex = 1;
            // 
            // descEmTb
            // 
            this.descEmTb.Location = new System.Drawing.Point(83, 96);
            this.descEmTb.Multiline = true;
            this.descEmTb.Name = "descEmTb";
            this.descEmTb.Size = new System.Drawing.Size(686, 44);
            this.descEmTb.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(516, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send Request";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // prioritiesTableAdapter
            // 
            this.prioritiesTableAdapter.ClearBeforeFill = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(652, 378);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 40);
            this.button3.TabIndex = 4;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // RegisteringNewEmRequestForAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegisteringNewEmRequestForAsset";
            this.Text = "RegisteringNewEmRequestForAsset";
            this.Load += new System.EventHandler(this.RegisteringNewEmRequestForAsset_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prioritiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.session2DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label assetNameLbl;
        private System.Windows.Forms.Label departmentLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label assetSNLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox priorityCb;
        private System.Windows.Forms.TextBox otherCondTb;
        private System.Windows.Forms.TextBox descEmTb;
        private System.Windows.Forms.Button button1;
        private Session2DataSet session2DataSet;
        private System.Windows.Forms.BindingSource prioritiesBindingSource;
        private Session2DataSetTableAdapters.PrioritiesTableAdapter prioritiesTableAdapter;
        private System.Windows.Forms.Button button3;
    }
}