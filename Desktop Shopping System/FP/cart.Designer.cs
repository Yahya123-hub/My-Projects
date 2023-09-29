namespace final_gui_Template
{
    partial class cart
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
            this.cart_gridview = new System.Windows.Forms.DataGridView();
            this.inc_btn = new System.Windows.Forms.Button();
            this.dec_btn = new System.Windows.Forms.Button();
            this.cnfrm_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cart_gridview)).BeginInit();
            this.SuspendLayout();
            // 
            // cart_gridview
            // 
            this.cart_gridview.AllowUserToAddRows = false;
            this.cart_gridview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cart_gridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cart_gridview.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.cart_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cart_gridview.Location = new System.Drawing.Point(12, 12);
            this.cart_gridview.Name = "cart_gridview";
            this.cart_gridview.ReadOnly = true;
            this.cart_gridview.Size = new System.Drawing.Size(747, 480);
            this.cart_gridview.TabIndex = 298;
            this.cart_gridview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cart_gridview_MouseClick);
            // 
            // inc_btn
            // 
            this.inc_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inc_btn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.inc_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inc_btn.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.inc_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.inc_btn.Location = new System.Drawing.Point(12, 497);
            this.inc_btn.Margin = new System.Windows.Forms.Padding(2);
            this.inc_btn.Name = "inc_btn";
            this.inc_btn.Size = new System.Drawing.Size(81, 46);
            this.inc_btn.TabIndex = 299;
            this.inc_btn.Text = "+";
            this.inc_btn.UseVisualStyleBackColor = false;
            this.inc_btn.Click += new System.EventHandler(this.inc_btn_Click);
            // 
            // dec_btn
            // 
            this.dec_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dec_btn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dec_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dec_btn.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.dec_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.dec_btn.Location = new System.Drawing.Point(97, 497);
            this.dec_btn.Margin = new System.Windows.Forms.Padding(2);
            this.dec_btn.Name = "dec_btn";
            this.dec_btn.Size = new System.Drawing.Size(81, 46);
            this.dec_btn.TabIndex = 300;
            this.dec_btn.Text = "-";
            this.dec_btn.UseVisualStyleBackColor = false;
            this.dec_btn.Click += new System.EventHandler(this.dec_btn_Click);
            // 
            // cnfrm_btn
            // 
            this.cnfrm_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cnfrm_btn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cnfrm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cnfrm_btn.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.cnfrm_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.cnfrm_btn.Location = new System.Drawing.Point(655, 497);
            this.cnfrm_btn.Margin = new System.Windows.Forms.Padding(2);
            this.cnfrm_btn.Name = "cnfrm_btn";
            this.cnfrm_btn.Size = new System.Drawing.Size(105, 46);
            this.cnfrm_btn.TabIndex = 301;
            this.cnfrm_btn.Text = "Checkout";
            this.cnfrm_btn.UseVisualStyleBackColor = false;
            this.cnfrm_btn.Click += new System.EventHandler(this.cnfrm_btn_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.button1.Location = new System.Drawing.Point(515, 497);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 46);
            this.button1.TabIndex = 302;
            this.button1.Text = "Remove Item";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 588);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cnfrm_btn);
            this.Controls.Add(this.dec_btn);
            this.Controls.Add(this.inc_btn);
            this.Controls.Add(this.cart_gridview);
            this.Name = "cart";
            this.Text = "cart";
            this.Load += new System.EventHandler(this.cart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cart_gridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView cart_gridview;
        private System.Windows.Forms.Button inc_btn;
        private System.Windows.Forms.Button dec_btn;
        private System.Windows.Forms.Button cnfrm_btn;
        private System.Windows.Forms.Button button1;
    }
}