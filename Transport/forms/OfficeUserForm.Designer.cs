namespace Transport.forms
{
    partial class OfficeUserForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.boxUser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.boxOffice = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 48;
            this.label2.Text = "Пользователь";
            // 
            // boxUser
            // 
            this.boxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxUser.Font = new System.Drawing.Font("Tw Cen MT", 12F);
            this.boxUser.FormattingEnabled = true;
            this.boxUser.Location = new System.Drawing.Point(122, 50);
            this.boxUser.Name = "boxUser";
            this.boxUser.Size = new System.Drawing.Size(330, 27);
            this.boxUser.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 50;
            this.label1.Text = "Оффис";
            // 
            // boxOffice
            // 
            this.boxOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxOffice.Font = new System.Drawing.Font("Tw Cen MT", 12F);
            this.boxOffice.FormattingEnabled = true;
            this.boxOffice.Location = new System.Drawing.Point(122, 100);
            this.boxOffice.Name = "boxOffice";
            this.boxOffice.Size = new System.Drawing.Size(330, 27);
            this.boxOffice.TabIndex = 49;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(377, 646);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 51;
            this.button1.Text = "Принять";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OfficeUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 681);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxOffice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.boxUser);
            this.MaximumSize = new System.Drawing.Size(480, 720);
            this.MinimumSize = new System.Drawing.Size(480, 720);
            this.Name = "OfficeUserForm";
            this.Text = "OfficeUserForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox boxUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxOffice;
        private System.Windows.Forms.Button button1;
    }
}