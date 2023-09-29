namespace Student_Management_System
{
    partial class stdcrud
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.stdfname_txtbox = new System.Windows.Forms.TextBox();
            this.stdemail_txtbox = new System.Windows.Forms.TextBox();
            this.stdcontact_txtbox = new System.Windows.Forms.TextBox();
            this.stdregnum_txtbox = new System.Windows.Forms.TextBox();
            this.stdgridview = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.stdlname_txtbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stdcontact_ind_lbl = new System.Windows.Forms.Label();
            this.stdlname_ind_lbl = new System.Windows.Forms.Label();
            this.stdfname_ind_lbl = new System.Windows.Forms.Label();
            this.stdregnum_ind_lbl = new System.Windows.Forms.Label();
            this.stdemail_ind_lbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.stdactive_chkbox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.search_combox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.stdgridview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(43, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(551, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(43, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contact";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(419, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Registration Number";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // stdfname_txtbox
            // 
            this.stdfname_txtbox.Location = new System.Drawing.Point(152, 56);
            this.stdfname_txtbox.Name = "stdfname_txtbox";
            this.stdfname_txtbox.Size = new System.Drawing.Size(100, 20);
            this.stdfname_txtbox.TabIndex = 6;
            // 
            // stdemail_txtbox
            // 
            this.stdemail_txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stdemail_txtbox.Location = new System.Drawing.Point(613, 94);
            this.stdemail_txtbox.Name = "stdemail_txtbox";
            this.stdemail_txtbox.Size = new System.Drawing.Size(100, 20);
            this.stdemail_txtbox.TabIndex = 7;
            // 
            // stdcontact_txtbox
            // 
            this.stdcontact_txtbox.Location = new System.Drawing.Point(152, 140);
            this.stdcontact_txtbox.Name = "stdcontact_txtbox";
            this.stdcontact_txtbox.Size = new System.Drawing.Size(100, 20);
            this.stdcontact_txtbox.TabIndex = 8;
            // 
            // stdregnum_txtbox
            // 
            this.stdregnum_txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stdregnum_txtbox.Location = new System.Drawing.Point(613, 56);
            this.stdregnum_txtbox.Name = "stdregnum_txtbox";
            this.stdregnum_txtbox.Size = new System.Drawing.Size(100, 20);
            this.stdregnum_txtbox.TabIndex = 9;
            // 
            // stdgridview
            // 
            this.stdgridview.AllowUserToAddRows = false;
            this.stdgridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stdgridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stdgridview.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.stdgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stdgridview.Location = new System.Drawing.Point(12, 255);
            this.stdgridview.Name = "stdgridview";
            this.stdgridview.ReadOnly = true;
            this.stdgridview.Size = new System.Drawing.Size(747, 321);
            this.stdgridview.TabIndex = 10;
            this.stdgridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.stdgridview_CellContentClick);
            this.stdgridview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.stdgridview_MouseClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(44, 213);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 37);
            this.button1.TabIndex = 127;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(150, 213);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 37);
            this.button2.TabIndex = 128;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(505, 213);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 37);
            this.button3.TabIndex = 129;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.Color.Red;
            this.button6.Location = new System.Drawing.Point(32, 11);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(67, 35);
            this.button6.TabIndex = 132;
            this.button6.Text = "Close";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // stdlname_txtbox
            // 
            this.stdlname_txtbox.Location = new System.Drawing.Point(152, 95);
            this.stdlname_txtbox.Name = "stdlname_txtbox";
            this.stdlname_txtbox.Size = new System.Drawing.Size(100, 20);
            this.stdlname_txtbox.TabIndex = 134;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(43, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 25);
            this.label5.TabIndex = 133;
            this.label5.Text = "Last Name";
            // 
            // stdcontact_ind_lbl
            // 
            this.stdcontact_ind_lbl.AutoSize = true;
            this.stdcontact_ind_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.stdcontact_ind_lbl.ForeColor = System.Drawing.Color.Red;
            this.stdcontact_ind_lbl.Location = new System.Drawing.Point(149, 164);
            this.stdcontact_ind_lbl.Name = "stdcontact_ind_lbl";
            this.stdcontact_ind_lbl.Size = new System.Drawing.Size(0, 15);
            this.stdcontact_ind_lbl.TabIndex = 135;
            // 
            // stdlname_ind_lbl
            // 
            this.stdlname_ind_lbl.AutoSize = true;
            this.stdlname_ind_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.stdlname_ind_lbl.ForeColor = System.Drawing.Color.Red;
            this.stdlname_ind_lbl.Location = new System.Drawing.Point(148, 119);
            this.stdlname_ind_lbl.Name = "stdlname_ind_lbl";
            this.stdlname_ind_lbl.Size = new System.Drawing.Size(0, 15);
            this.stdlname_ind_lbl.TabIndex = 136;
            // 
            // stdfname_ind_lbl
            // 
            this.stdfname_ind_lbl.AutoSize = true;
            this.stdfname_ind_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.stdfname_ind_lbl.ForeColor = System.Drawing.Color.Red;
            this.stdfname_ind_lbl.Location = new System.Drawing.Point(149, 79);
            this.stdfname_ind_lbl.Name = "stdfname_ind_lbl";
            this.stdfname_ind_lbl.Size = new System.Drawing.Size(0, 15);
            this.stdfname_ind_lbl.TabIndex = 137;
            // 
            // stdregnum_ind_lbl
            // 
            this.stdregnum_ind_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stdregnum_ind_lbl.AutoSize = true;
            this.stdregnum_ind_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.stdregnum_ind_lbl.ForeColor = System.Drawing.Color.Red;
            this.stdregnum_ind_lbl.Location = new System.Drawing.Point(610, 79);
            this.stdregnum_ind_lbl.Name = "stdregnum_ind_lbl";
            this.stdregnum_ind_lbl.Size = new System.Drawing.Size(0, 15);
            this.stdregnum_ind_lbl.TabIndex = 138;
            // 
            // stdemail_ind_lbl
            // 
            this.stdemail_ind_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stdemail_ind_lbl.AutoSize = true;
            this.stdemail_ind_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.stdemail_ind_lbl.ForeColor = System.Drawing.Color.Red;
            this.stdemail_ind_lbl.Location = new System.Drawing.Point(610, 120);
            this.stdemail_ind_lbl.Name = "stdemail_ind_lbl";
            this.stdemail_ind_lbl.Size = new System.Drawing.Size(0, 15);
            this.stdemail_ind_lbl.TabIndex = 139;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(541, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 25);
            this.label6.TabIndex = 141;
            this.label6.Text = "Search";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(611, 213);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 37);
            this.button4.TabIndex = 142;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // stdactive_chkbox
            // 
            this.stdactive_chkbox.AutoSize = true;
            this.stdactive_chkbox.Location = new System.Drawing.Point(152, 183);
            this.stdactive_chkbox.Name = "stdactive_chkbox";
            this.stdactive_chkbox.Size = new System.Drawing.Size(15, 14);
            this.stdactive_chkbox.TabIndex = 143;
            this.stdactive_chkbox.UseVisualStyleBackColor = true;
            this.stdactive_chkbox.CheckedChanged += new System.EventHandler(this.stdactive_chkbox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(43, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 25);
            this.label7.TabIndex = 144;
            this.label7.Text = "Active :";
            // 
            // search_combox
            // 
            this.search_combox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_combox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.search_combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.search_combox.ForeColor = System.Drawing.Color.Red;
            this.search_combox.FormattingEnabled = true;
            this.search_combox.Items.AddRange(new object[] {
            "First-Name",
            "Last-Name",
            "Contact",
            "Registration-Number",
            "Email"});
            this.search_combox.Location = new System.Drawing.Point(613, 140);
            this.search_combox.Name = "search_combox";
            this.search_combox.Size = new System.Drawing.Size(100, 21);
            this.search_combox.TabIndex = 145;
            // 
            // stdcrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(771, 588);
            this.Controls.Add(this.search_combox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.stdactive_chkbox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stdemail_ind_lbl);
            this.Controls.Add(this.stdregnum_ind_lbl);
            this.Controls.Add(this.stdfname_ind_lbl);
            this.Controls.Add(this.stdlname_ind_lbl);
            this.Controls.Add(this.stdcontact_ind_lbl);
            this.Controls.Add(this.stdlname_txtbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stdgridview);
            this.Controls.Add(this.stdregnum_txtbox);
            this.Controls.Add(this.stdcontact_txtbox);
            this.Controls.Add(this.stdemail_txtbox);
            this.Controls.Add(this.stdfname_txtbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "stdcrud";
            this.Text = "stdcrud";
            this.Load += new System.EventHandler(this.stdcrud_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stdgridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox stdfname_txtbox;
        private System.Windows.Forms.TextBox stdemail_txtbox;
        private System.Windows.Forms.TextBox stdcontact_txtbox;
        private System.Windows.Forms.TextBox stdregnum_txtbox;
        private System.Windows.Forms.DataGridView stdgridview;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox stdlname_txtbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label stdcontact_ind_lbl;
        private System.Windows.Forms.Label stdlname_ind_lbl;
        private System.Windows.Forms.Label stdfname_ind_lbl;
        private System.Windows.Forms.Label stdregnum_ind_lbl;
        private System.Windows.Forms.Label stdemail_ind_lbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox stdactive_chkbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox search_combox;
    }
}