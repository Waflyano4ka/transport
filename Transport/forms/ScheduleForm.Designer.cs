namespace Transport.forms
{
    partial class ScheduleForm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkConfirmed = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxTransport = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boxRoute = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Tw Cen MT", 12F);
            this.dateTimePicker1.Location = new System.Drawing.Point(122, 50);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(330, 25);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 19);
            this.label2.TabIndex = 50;
            this.label2.Text = "Дата";
            // 
            // textCost
            // 
            this.textCost.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCost.Location = new System.Drawing.Point(122, 100);
            this.textCost.Name = "textCost";
            this.textCost.Size = new System.Drawing.Size(330, 25);
            this.textCost.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 19);
            this.label1.TabIndex = 51;
            this.label1.Text = "Цена";
            // 
            // checkConfirmed
            // 
            this.checkConfirmed.AutoSize = true;
            this.checkConfirmed.Font = new System.Drawing.Font("Tw Cen MT", 12F);
            this.checkConfirmed.Location = new System.Drawing.Point(122, 150);
            this.checkConfirmed.Name = "checkConfirmed";
            this.checkConfirmed.Size = new System.Drawing.Size(109, 23);
            this.checkConfirmed.TabIndex = 54;
            this.checkConfirmed.Text = "Подтвержден";
            this.checkConfirmed.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 56;
            this.label3.Text = "Транспорт";
            // 
            // boxTransport
            // 
            this.boxTransport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxTransport.Font = new System.Drawing.Font("Tw Cen MT", 12F);
            this.boxTransport.FormattingEnabled = true;
            this.boxTransport.Location = new System.Drawing.Point(122, 200);
            this.boxTransport.Name = "boxTransport";
            this.boxTransport.Size = new System.Drawing.Size(330, 27);
            this.boxTransport.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 58;
            this.label4.Text = "Маршрут";
            // 
            // boxRoute
            // 
            this.boxRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxRoute.Font = new System.Drawing.Font("Tw Cen MT", 12F);
            this.boxRoute.FormattingEnabled = true;
            this.boxRoute.Location = new System.Drawing.Point(122, 250);
            this.boxRoute.Name = "boxRoute";
            this.boxRoute.Size = new System.Drawing.Size(330, 27);
            this.boxRoute.TabIndex = 57;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(377, 646);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 59;
            this.button1.Text = "Принять";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 681);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.boxRoute);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.boxTransport);
            this.Controls.Add(this.checkConfirmed);
            this.Controls.Add(this.textCost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.MaximumSize = new System.Drawing.Size(480, 720);
            this.MinimumSize = new System.Drawing.Size(480, 720);
            this.Name = "ScheduleForm";
            this.Text = "ScheduleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkConfirmed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boxTransport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox boxRoute;
        private System.Windows.Forms.Button button1;
    }
}