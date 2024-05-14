namespace BooksStore
{
    partial class AddBook
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
            this.titleBox = new System.Windows.Forms.TextBox();
            this.priceBox = new System.Windows.Forms.TextBox();
            this.quantityBox = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.authorsBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // titleBox
            // 
            this.titleBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleBox.Location = new System.Drawing.Point(12, 32);
            this.titleBox.Multiline = true;
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(202, 29);
            this.titleBox.TabIndex = 0;
            // 
            // priceBox
            // 
            this.priceBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceBox.Location = new System.Drawing.Point(12, 160);
            this.priceBox.Multiline = true;
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(202, 29);
            this.priceBox.TabIndex = 2;
            // 
            // quantityBox
            // 
            this.quantityBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quantityBox.Location = new System.Drawing.Point(12, 219);
            this.quantityBox.Multiline = true;
            this.quantityBox.Name = "quantityBox";
            this.quantityBox.Size = new System.Drawing.Size(202, 29);
            this.quantityBox.TabIndex = 3;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(44, 278);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(142, 31);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "Добавить";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Название ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Автор";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Цена";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "Количество";
            // 
            // authorsBox
            // 
            this.authorsBox.FormattingEnabled = true;
            this.authorsBox.Location = new System.Drawing.Point(12, 97);
            this.authorsBox.Name = "authorsBox";
            this.authorsBox.Size = new System.Drawing.Size(121, 21);
            this.authorsBox.TabIndex = 12;
            // 
            // AddBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 321);
            this.Controls.Add(this.authorsBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.quantityBox);
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.titleBox);
            this.Name = "AddBook";
            this.Text = "AddBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.TextBox priceBox;
        private System.Windows.Forms.TextBox quantityBox;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox authorsBox;
    }
}