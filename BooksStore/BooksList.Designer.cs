namespace BooksStore
{
    partial class BooksList
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
            this.addBook = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.dataGridOrders = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // addBook
            // 
            this.addBook.Location = new System.Drawing.Point(183, 11);
            this.addBook.Name = "addBook";
            this.addBook.Size = new System.Drawing.Size(137, 35);
            this.addBook.TabIndex = 15;
            this.addBook.Text = "Добавить книгу";
            this.addBook.UseVisualStyleBackColor = true;
            this.addBook.Click += new System.EventHandler(this.addBook_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(12, 11);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(137, 35);
            this.buttonBack.TabIndex = 13;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // dataGridOrders
            // 
            this.dataGridOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrders.Location = new System.Drawing.Point(12, 52);
            this.dataGridOrders.Name = "dataGridOrders";
            this.dataGridOrders.Size = new System.Drawing.Size(760, 496);
            this.dataGridOrders.TabIndex = 12;
            // 
            // BooksList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 570);
            this.Controls.Add(this.addBook);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.dataGridOrders);
            this.Name = "BooksList";
            this.Text = "BooksList";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addBook;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.DataGridView dataGridOrders;
    }
}