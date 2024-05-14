namespace BooksStore
{
    partial class OrdersList
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
            this.buttonBack = new System.Windows.Forms.Button();
            this.dataGridOrders = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cancelOrder = new System.Windows.Forms.Button();
            this.acceptOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(12, 7);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(137, 35);
            this.buttonBack.TabIndex = 8;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // dataGridOrders
            // 
            this.dataGridOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrders.Location = new System.Drawing.Point(12, 48);
            this.dataGridOrders.Name = "dataGridOrders";
            this.dataGridOrders.Size = new System.Drawing.Size(760, 496);
            this.dataGridOrders.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(635, 23);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 19);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cancelOrder
            // 
            this.cancelOrder.Location = new System.Drawing.Point(183, 7);
            this.cancelOrder.Name = "cancelOrder";
            this.cancelOrder.Size = new System.Drawing.Size(137, 35);
            this.cancelOrder.TabIndex = 10;
            this.cancelOrder.Text = "Отклонить";
            this.cancelOrder.UseVisualStyleBackColor = true;
            this.cancelOrder.Click += new System.EventHandler(this.cancelOrder_Click);
            // 
            // acceptOrder
            // 
            this.acceptOrder.Location = new System.Drawing.Point(343, 7);
            this.acceptOrder.Name = "acceptOrder";
            this.acceptOrder.Size = new System.Drawing.Size(137, 35);
            this.acceptOrder.TabIndex = 11;
            this.acceptOrder.Text = "Одобрить";
            this.acceptOrder.UseVisualStyleBackColor = true;
            this.acceptOrder.Click += new System.EventHandler(this.acceptOrder_Click);
            // 
            // OrdersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 557);
            this.Controls.Add(this.acceptOrder);
            this.Controls.Add(this.cancelOrder);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.dataGridOrders);
            this.Name = "OrdersList";
            this.Text = "OrdersList";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.DataGridView dataGridOrders;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cancelOrder;
        private System.Windows.Forms.Button acceptOrder;
    }
}