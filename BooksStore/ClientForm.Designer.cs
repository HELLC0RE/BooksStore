namespace BooksStore
{
    partial class ClientForm
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
            this.showOrder = new System.Windows.Forms.Button();
            this.flowLayoutPanelProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelPagination = new System.Windows.Forms.FlowLayoutPanel();
            this.sortBox = new System.Windows.Forms.ComboBox();
            this.searchText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // showOrder
            // 
            this.showOrder.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showOrder.Location = new System.Drawing.Point(673, 12);
            this.showOrder.Name = "showOrder";
            this.showOrder.Size = new System.Drawing.Size(100, 38);
            this.showOrder.TabIndex = 9;
            this.showOrder.Text = "Показать заказ";
            this.showOrder.UseVisualStyleBackColor = true;
            this.showOrder.Click += new System.EventHandler(this.showOrder_Click);
            // 
            // flowLayoutPanelProducts
            // 
            this.flowLayoutPanelProducts.Location = new System.Drawing.Point(12, 88);
            this.flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            this.flowLayoutPanelProducts.Size = new System.Drawing.Size(760, 500);
            this.flowLayoutPanelProducts.TabIndex = 6;
            // 
            // flowLayoutPanelPagination
            // 
            this.flowLayoutPanelPagination.Location = new System.Drawing.Point(473, 594);
            this.flowLayoutPanelPagination.Name = "flowLayoutPanelPagination";
            this.flowLayoutPanelPagination.Size = new System.Drawing.Size(300, 32);
            this.flowLayoutPanelPagination.TabIndex = 10;
            // 
            // sortBox
            // 
            this.sortBox.DropDownWidth = 189;
            this.sortBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sortBox.FormattingEnabled = true;
            this.sortBox.Items.AddRange(new object[] {
            "По умолчанию",
            "По наименованию (по возрастанию)",
            "По наименованию (по убыванию)",
            "По стоимости (по возрастанию)",
            "По стоимости (по убыванию)"});
            this.sortBox.Location = new System.Drawing.Point(11, 41);
            this.sortBox.Margin = new System.Windows.Forms.Padding(2);
            this.sortBox.Name = "sortBox";
            this.sortBox.Size = new System.Drawing.Size(167, 23);
            this.sortBox.TabIndex = 12;
            this.sortBox.Text = "Сортировка";
            this.sortBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.SortBox_DrawItem);
            this.sortBox.SelectedIndexChanged += new System.EventHandler(this.SortBox_SelectedIndexChanged);
            // 
            // searchText
            // 
            this.searchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchText.Location = new System.Drawing.Point(12, 11);
            this.searchText.Margin = new System.Windows.Forms.Padding(2);
            this.searchText.MaxLength = 200;
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(350, 26);
            this.searchText.TabIndex = 11;
            this.searchText.Enter += new System.EventHandler(this.SearchText_Enter);
            this.searchText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchText_KeyPress);
            this.searchText.Leave += new System.EventHandler(this.SearchText_Leave);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 647);
            this.Controls.Add(this.sortBox);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.flowLayoutPanelPagination);
            this.Controls.Add(this.showOrder);
            this.Controls.Add(this.flowLayoutPanelProducts);
            this.Name = "ClientForm";
            this.Text = "Выбор книг";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showOrder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProducts;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPagination;
        private System.Windows.Forms.ComboBox sortBox;
        private System.Windows.Forms.TextBox searchText;
    }
}