namespace concept_class
{
    partial class PassChangeFrm
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
            this.txt_CurrentPass = new System.Windows.Forms.TextBox();
            this.txt_newPass = new System.Windows.Forms.TextBox();
            this.txt_confirmPass = new System.Windows.Forms.TextBox();
            this.btn_Change = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_CurrentPass
            // 
            this.txt_CurrentPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CurrentPass.Location = new System.Drawing.Point(249, 26);
            this.txt_CurrentPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_CurrentPass.Name = "txt_CurrentPass";
            this.txt_CurrentPass.PasswordChar = '*';
            this.txt_CurrentPass.Size = new System.Drawing.Size(465, 26);
            this.txt_CurrentPass.TabIndex = 0;
            // 
            // txt_newPass
            // 
            this.txt_newPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_newPass.Location = new System.Drawing.Point(249, 85);
            this.txt_newPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_newPass.Name = "txt_newPass";
            this.txt_newPass.PasswordChar = '*';
            this.txt_newPass.Size = new System.Drawing.Size(465, 26);
            this.txt_newPass.TabIndex = 1;
            // 
            // txt_confirmPass
            // 
            this.txt_confirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_confirmPass.Location = new System.Drawing.Point(249, 138);
            this.txt_confirmPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_confirmPass.Name = "txt_confirmPass";
            this.txt_confirmPass.PasswordChar = '*';
            this.txt_confirmPass.Size = new System.Drawing.Size(465, 26);
            this.txt_confirmPass.TabIndex = 2;
            this.txt_confirmPass.TextChanged += new System.EventHandler(this.txt_confirmPass_TextChanged);
            // 
            // btn_Change
            // 
            this.btn_Change.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Change.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Change.ForeColor = System.Drawing.Color.White;
            this.btn_Change.Location = new System.Drawing.Point(101, 196);
            this.btn_Change.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Change.Name = "btn_Change";
            this.btn_Change.Size = new System.Drawing.Size(529, 58);
            this.btn_Change.TabIndex = 3;
            this.btn_Change.Text = "Change Password";
            this.btn_Change.UseVisualStyleBackColor = true;
            this.btn_Change.Click += new System.EventHandler(this.btn_Change_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(24, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(724, 145);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(638, 234);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Close";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // PassChangeFrm
            // 
            this.AcceptButton = this.btn_Change;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(865, 282);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Change);
            this.Controls.Add(this.txt_confirmPass);
            this.Controls.Add(this.txt_newPass);
            this.Controls.Add(this.txt_CurrentPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PassChangeFrm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_CurrentPass;
        private System.Windows.Forms.TextBox txt_newPass;
        private System.Windows.Forms.TextBox txt_confirmPass;
        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}