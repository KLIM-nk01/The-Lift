namespace TheLift.Dialogs
{
    partial class FrmResults
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
            this.txtAllWeight = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.btnToWord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPeople = new System.Windows.Forms.TextBox();
            this.txtTrips = new System.Windows.Forms.TextBox();
            this.txtEmptyTrips = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAllWeight
            // 
            this.txtAllWeight.Location = new System.Drawing.Point(433, 117);
            this.txtAllWeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAllWeight.Name = "txtAllWeight";
            this.txtAllWeight.ReadOnly = true;
            this.txtAllWeight.Size = new System.Drawing.Size(151, 36);
            this.txtAllWeight.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnToExcel);
            this.groupBox1.Controls.Add(this.btnToWord);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPeople);
            this.groupBox1.Controls.Add(this.txtTrips);
            this.groupBox1.Controls.Add(this.txtEmptyTrips);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAllWeight);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(16, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(603, 370);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(332, 208);
            this.txtTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(252, 36);
            this.txtTime.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(4, 208);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 29);
            this.label6.TabIndex = 15;
            this.label6.Text = "Время работы лифта";
            // 
            // btnToExcel
            // 
            this.btnToExcel.Location = new System.Drawing.Point(128, 309);
            this.btnToExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(457, 38);
            this.btnToExcel.TabIndex = 14;
            this.btnToExcel.Text = "Вывод информации в MS Excel";
            this.btnToExcel.UseVisualStyleBackColor = true;
            // 
            // btnToWord
            // 
            this.btnToWord.Location = new System.Drawing.Point(128, 263);
            this.btnToWord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnToWord.Name = "btnToWord";
            this.btnToWord.Size = new System.Drawing.Size(457, 38);
            this.btnToWord.TabIndex = 8;
            this.btnToWord.Text = "Вывод информации в MS Word";
            this.btnToWord.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(4, 165);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Количество перевезенных людей";
            // 
            // txtPeople
            // 
            this.txtPeople.Location = new System.Drawing.Point(433, 161);
            this.txtPeople.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPeople.Name = "txtPeople";
            this.txtPeople.ReadOnly = true;
            this.txtPeople.Size = new System.Drawing.Size(151, 36);
            this.txtPeople.TabIndex = 12;
            // 
            // txtTrips
            // 
            this.txtTrips.Location = new System.Drawing.Point(380, 28);
            this.txtTrips.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTrips.Name = "txtTrips";
            this.txtTrips.ReadOnly = true;
            this.txtTrips.Size = new System.Drawing.Size(204, 36);
            this.txtTrips.TabIndex = 11;
            // 
            // txtEmptyTrips
            // 
            this.txtEmptyTrips.Location = new System.Drawing.Point(380, 73);
            this.txtEmptyTrips.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmptyTrips.Name = "txtEmptyTrips";
            this.txtEmptyTrips.ReadOnly = true;
            this.txtEmptyTrips.Size = new System.Drawing.Size(204, 36);
            this.txtEmptyTrips.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(4, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(391, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Суммарный перемещенный вес";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(4, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(369, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Количество холостых поездок";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(4, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(339, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Общее количество поездок";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(456, 434);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(163, 41);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "ОK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(577, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // FrmResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(635, 490);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmResults";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Итоговая информация";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmResults_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmResults_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnToExcel;
        internal System.Windows.Forms.Button btnToWord;
        internal System.Windows.Forms.TextBox txtAllWeight;
        internal System.Windows.Forms.TextBox txtPeople;
        internal System.Windows.Forms.TextBox txtTrips;
        internal System.Windows.Forms.TextBox txtEmptyTrips;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label6;
    }
}