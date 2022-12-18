namespace AbuDhabu_Session2_4_11_2020
{
    partial class EditFlightForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fromLbl = new System.Windows.Forms.Label();
            this.toLbl = new System.Windows.Forms.Label();
            this.aircraftLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDTP = new System.Windows.Forms.DateTimePicker();
            this.timeDTP = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.economicPriceNUD = new System.Windows.Forms.NumericUpDown();
            this.updateBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.economicPriceNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.aircraftLbl);
            this.groupBox1.Controls.Add(this.toLbl);
            this.groupBox1.Controls.Add(this.fromLbl);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flight Route";
            // 
            // fromLbl
            // 
            this.fromLbl.AutoSize = true;
            this.fromLbl.Location = new System.Drawing.Point(16, 37);
            this.fromLbl.Name = "fromLbl";
            this.fromLbl.Size = new System.Drawing.Size(33, 13);
            this.fromLbl.TabIndex = 1;
            this.fromLbl.Text = "From:";
            // 
            // toLbl
            // 
            this.toLbl.AutoSize = true;
            this.toLbl.Location = new System.Drawing.Point(217, 37);
            this.toLbl.Name = "toLbl";
            this.toLbl.Size = new System.Drawing.Size(33, 13);
            this.toLbl.TabIndex = 2;
            this.toLbl.Text = "From:";
            // 
            // aircraftLbl
            // 
            this.aircraftLbl.AutoSize = true;
            this.aircraftLbl.Location = new System.Drawing.Point(409, 37);
            this.aircraftLbl.Name = "aircraftLbl";
            this.aircraftLbl.Size = new System.Drawing.Size(33, 13);
            this.aircraftLbl.TabIndex = 3;
            this.aircraftLbl.Text = "From:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Time:";
            // 
            // dateDTP
            // 
            this.dateDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDTP.Location = new System.Drawing.Point(68, 117);
            this.dateDTP.Name = "dateDTP";
            this.dateDTP.Size = new System.Drawing.Size(103, 20);
            this.dateDTP.TabIndex = 7;
            // 
            // timeDTP
            // 
            this.timeDTP.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeDTP.Location = new System.Drawing.Point(269, 118);
            this.timeDTP.Name = "timeDTP";
            this.timeDTP.Size = new System.Drawing.Size(108, 20);
            this.timeDTP.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Economy Price:";
            // 
            // economicPriceNUD
            // 
            this.economicPriceNUD.Location = new System.Drawing.Point(510, 117);
            this.economicPriceNUD.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.economicPriceNUD.Name = "economicPriceNUD";
            this.economicPriceNUD.Size = new System.Drawing.Size(167, 20);
            this.economicPriceNUD.TabIndex = 11;
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(632, 165);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 12;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(713, 165);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 13;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // EditFlightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 202);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.economicPriceNUD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timeDTP);
            this.Controls.Add(this.dateDTP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditFlightForm";
            this.Text = "EditFlightForm";
            this.Load += new System.EventHandler(this.EditFlightForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.economicPriceNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label aircraftLbl;
        private System.Windows.Forms.Label toLbl;
        private System.Windows.Forms.Label fromLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDTP;
        private System.Windows.Forms.DateTimePicker timeDTP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown economicPriceNUD;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}