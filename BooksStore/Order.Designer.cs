namespace BooksStore
{
    partial class Order
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.totalAmountLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanelOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(644, 604);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(137, 35);
            this.buttonBack.TabIndex = 13;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Нажмите ПКМ на название товара, чтобы удалить из корзины";
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreateOrder.Location = new System.Drawing.Point(25, 610);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(223, 29);
            this.buttonCreateOrder.TabIndex = 10;
            this.buttonCreateOrder.Text = "Оформить заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // totalAmountLabel
            // 
            this.totalAmountLabel.AutoSize = true;
            this.totalAmountLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalAmountLabel.Location = new System.Drawing.Point(21, 551);
            this.totalAmountLabel.Name = "totalAmountLabel";
            this.totalAmountLabel.Size = new System.Drawing.Size(0, 21);
            this.totalAmountLabel.TabIndex = 9;
            // 
            // flowLayoutPanelOrder
            // 
            this.flowLayoutPanelOrder.AutoScroll = true;
            this.flowLayoutPanelOrder.Location = new System.Drawing.Point(21, 31);
            this.flowLayoutPanelOrder.Name = "flowLayoutPanelOrder";
            this.flowLayoutPanelOrder.Size = new System.Drawing.Size(760, 500);
            this.flowLayoutPanelOrder.TabIndex = 8;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addressTextBox.Location = new System.Drawing.Point(270, 610);
            this.addressTextBox.Multiline = true;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(223, 29);
            this.addressTextBox.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(266, 586);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Введите адрес доставки";
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 648);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.totalAmountLabel);
            this.Controls.Add(this.flowLayoutPanelOrder);
            this.Name = "Order";
            this.Text = "Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Label totalAmountLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOrder;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label label2;
    }
}