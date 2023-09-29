namespace final_gui_Template
{
    partial class browse_products
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
            this.search_txtbox = new System.Windows.Forms.TextBox();
            this.products_section = new System.Windows.Forms.FlowLayoutPanel();
            this.sort_combox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // search_txtbox
            // 
            this.search_txtbox.ForeColor = System.Drawing.Color.Gray;
            this.search_txtbox.Location = new System.Drawing.Point(17, 16);
            this.search_txtbox.Name = "search_txtbox";
            this.search_txtbox.Size = new System.Drawing.Size(179, 20);
            this.search_txtbox.TabIndex = 0;
            this.search_txtbox.Text = "Search by Name,Price or Category";
            this.search_txtbox.TextChanged += new System.EventHandler(this.search_txtbox_TextChanged);
            this.search_txtbox.Enter += new System.EventHandler(this.search_txtbox_Enter);
            this.search_txtbox.Leave += new System.EventHandler(this.search_txtbox_Leave);
            // 
            // products_section
            // 
            this.products_section.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.products_section.AutoScroll = true;
            this.products_section.Location = new System.Drawing.Point(17, 42);
            this.products_section.Name = "products_section";
            this.products_section.Size = new System.Drawing.Size(742, 523);
            this.products_section.TabIndex = 298;
            this.products_section.Paint += new System.Windows.Forms.PaintEventHandler(this.products_section_Paint);
            // 
            // sort_combox
            // 
            this.sort_combox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sort_combox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.sort_combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sort_combox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.sort_combox.FormattingEnabled = true;
            this.sort_combox.Items.AddRange(new object[] {
            "Name",
            "Price",
            "Category",
            "Quantity"});
            this.sort_combox.Location = new System.Drawing.Point(659, 15);
            this.sort_combox.Name = "sort_combox";
            this.sort_combox.Size = new System.Drawing.Size(100, 21);
            this.sort_combox.TabIndex = 299;
            this.sort_combox.SelectedIndexChanged += new System.EventHandler(this.search_combox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.label1.Location = new System.Drawing.Point(581, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 25);
            this.label1.TabIndex = 300;
            this.label1.Text = "Sort By";
            // 
            // browse_products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 588);
            this.Controls.Add(this.sort_combox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.products_section);
            this.Controls.Add(this.search_txtbox);
            this.DoubleBuffered = true;
            this.Name = "browse_products";
            this.Text = "browse_products";
            this.Load += new System.EventHandler(this.browse_products_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox search_txtbox;
        private System.Windows.Forms.FlowLayoutPanel products_section;
        private System.Windows.Forms.ComboBox sort_combox;
        private System.Windows.Forms.Label label1;
    }
}