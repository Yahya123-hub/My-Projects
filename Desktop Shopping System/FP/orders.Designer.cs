namespace final_gui_Template
{
    partial class orders
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
            this.components = new System.ComponentModel.Container();
            this.shipadr_ind_lbl = new System.Windows.Forms.Label();
            this.shipping_adr_txtbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.payment_combox = new System.Windows.Forms.ComboBox();
            this.rubricdet_ind_lbl = new System.Windows.Forms.Label();
            this.ordersgridview = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.payment_ind_lbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ordersgridview)).BeginInit();
            this.SuspendLayout();
            // 
            // shipadr_ind_lbl
            // 
            this.shipadr_ind_lbl.AutoSize = true;
            this.shipadr_ind_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.shipadr_ind_lbl.ForeColor = System.Drawing.Color.Red;
            this.shipadr_ind_lbl.Location = new System.Drawing.Point(173, 51);
            this.shipadr_ind_lbl.Name = "shipadr_ind_lbl";
            this.shipadr_ind_lbl.Size = new System.Drawing.Size(0, 15);
            this.shipadr_ind_lbl.TabIndex = 252;
            // 
            // shipping_adr_txtbox
            // 
            this.shipping_adr_txtbox.Location = new System.Drawing.Point(176, 28);
            this.shipping_adr_txtbox.Name = "shipping_adr_txtbox";
            this.shipping_adr_txtbox.Size = new System.Drawing.Size(100, 20);
            this.shipping_adr_txtbox.TabIndex = 251;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.label3.Location = new System.Drawing.Point(12, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 25);
            this.label3.TabIndex = 250;
            this.label3.Text = "Shipping Address";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.label6.Location = new System.Drawing.Point(498, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 25);
            this.label6.TabIndex = 249;
            this.label6.Text = "Payment Method";
            // 
            // payment_combox
            // 
            this.payment_combox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.payment_combox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.payment_combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.payment_combox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.payment_combox.FormattingEnabled = true;
            this.payment_combox.Items.AddRange(new object[] {
            "Cash",
            "Credit",
            "Debit"});
            this.payment_combox.Location = new System.Drawing.Point(660, 28);
            this.payment_combox.Name = "payment_combox";
            this.payment_combox.Size = new System.Drawing.Size(100, 21);
            this.payment_combox.TabIndex = 248;
            // 
            // rubricdet_ind_lbl
            // 
            this.rubricdet_ind_lbl.AutoSize = true;
            this.rubricdet_ind_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.rubricdet_ind_lbl.ForeColor = System.Drawing.Color.Red;
            this.rubricdet_ind_lbl.Location = new System.Drawing.Point(35, 32);
            this.rubricdet_ind_lbl.Name = "rubricdet_ind_lbl";
            this.rubricdet_ind_lbl.Size = new System.Drawing.Size(0, 15);
            this.rubricdet_ind_lbl.TabIndex = 247;
            // 
            // ordersgridview
            // 
            this.ordersgridview.AllowUserToAddRows = false;
            this.ordersgridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ordersgridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ordersgridview.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.ordersgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersgridview.Location = new System.Drawing.Point(17, 82);
            this.ordersgridview.Name = "ordersgridview";
            this.ordersgridview.ReadOnly = true;
            this.ordersgridview.Size = new System.Drawing.Size(743, 447);
            this.ordersgridview.TabIndex = 298;
            this.ordersgridview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ordersgridview_MouseClick);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.button2.Location = new System.Drawing.Point(658, 534);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 37);
            this.button2.TabIndex = 299;
            this.button2.Text = "Confirm";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.button1.Location = new System.Drawing.Point(17, 534);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 37);
            this.button1.TabIndex = 300;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // payment_ind_lbl
            // 
            this.payment_ind_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.payment_ind_lbl.AutoSize = true;
            this.payment_ind_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.payment_ind_lbl.ForeColor = System.Drawing.Color.Red;
            this.payment_ind_lbl.Location = new System.Drawing.Point(657, 52);
            this.payment_ind_lbl.Name = "payment_ind_lbl";
            this.payment_ind_lbl.Size = new System.Drawing.Size(0, 15);
            this.payment_ind_lbl.TabIndex = 301;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // timer_lbl
            // 
            this.timer_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timer_lbl.AutoSize = true;
            this.timer_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.timer_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.timer_lbl.Location = new System.Drawing.Point(377, 24);
            this.timer_lbl.Name = "timer_lbl";
            this.timer_lbl.Size = new System.Drawing.Size(0, 25);
            this.timer_lbl.TabIndex = 302;
            // 
            // orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 588);
            this.Controls.Add(this.timer_lbl);
            this.Controls.Add(this.payment_ind_lbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ordersgridview);
            this.Controls.Add(this.shipadr_ind_lbl);
            this.Controls.Add(this.shipping_adr_txtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.payment_combox);
            this.Controls.Add(this.rubricdet_ind_lbl);
            this.Name = "orders";
            this.Text = "orders";
            this.Load += new System.EventHandler(this.orders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ordersgridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label shipadr_ind_lbl;
        private System.Windows.Forms.TextBox shipping_adr_txtbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox payment_combox;
        private System.Windows.Forms.Label rubricdet_ind_lbl;
        private System.Windows.Forms.DataGridView ordersgridview;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label payment_ind_lbl;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timer_lbl;
    }
}