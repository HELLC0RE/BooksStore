﻿namespace BooksStore
{
    partial class Registration
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
            this.buttonReg = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passStr = new System.Windows.Forms.TextBox();
            this.loginStr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonReg
            // 
            this.buttonReg.AutoEllipsis = true;
            this.buttonReg.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReg.Location = new System.Drawing.Point(24, 291);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(186, 34);
            this.buttonReg.TabIndex = 30;
            this.buttonReg.Text = "Зарегистрироваться";
            this.buttonReg.UseVisualStyleBackColor = true;
            this.buttonReg.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(33, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 21);
            this.label3.TabIndex = 29;
            this.label3.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(33, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "Логин";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(59, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = "Регистрация";
            // 
            // passStr
            // 
            this.passStr.Location = new System.Drawing.Point(37, 164);
            this.passStr.Multiline = true;
            this.passStr.Name = "passStr";
            this.passStr.PasswordChar = '*';
            this.passStr.Size = new System.Drawing.Size(160, 40);
            this.passStr.TabIndex = 26;
            // 
            // loginStr
            // 
            this.loginStr.Location = new System.Drawing.Point(37, 75);
            this.loginStr.Multiline = true;
            this.loginStr.Name = "loginStr";
            this.loginStr.Size = new System.Drawing.Size(160, 40);
            this.loginStr.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(33, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 21);
            this.label4.TabIndex = 32;
            this.label4.Text = "Имя";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(37, 245);
            this.nameTextBox.Multiline = true;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.PasswordChar = '*';
            this.nameTextBox.Size = new System.Drawing.Size(160, 40);
            this.nameTextBox.TabIndex = 31;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 352);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.buttonReg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passStr);
            this.Controls.Add(this.loginStr);
            this.Name = "Registration";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonReg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passStr;
        private System.Windows.Forms.TextBox loginStr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameTextBox;
    }
}