namespace Student_Management_System
{
    partial class stdac
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
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.search_combox = new System.Windows.Forms.ComboBox();
            this.acname_ind_lbl = new System.Windows.Forms.Label();
            this.rubid_ind_lbl = new System.Windows.Forms.Label();
            this.stdcontact_ind_lbl = new System.Windows.Forms.Label();
            this.rubid_txtbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.acgridview = new System.Windows.Forms.DataGridView();
            this.acname_txtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.actotmrk_ind_lbl = new System.Windows.Forms.Label();
            this.actotmrk_txtbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.aid_ind_lbl = new System.Windows.Forms.Label();
            this.aid_txtbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.aidGridView = new System.Windows.Forms.DataGridView();
            this.rubidGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.acgridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aidGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rubidGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(637, 215);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 37);
            this.button4.TabIndex = 184;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(544, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 25);
            this.label6.TabIndex = 183;
            this.label6.Text = "Search By";
            // 
            // search_combox
            // 
            this.search_combox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_combox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.search_combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.search_combox.ForeColor = System.Drawing.Color.Red;
            this.search_combox.FormattingEnabled = true;
            this.search_combox.Items.AddRange(new object[] {
            "Name",
            "Rubric-ID",
            "Total-Marks",
            "Assessment-ID"});
            this.search_combox.Location = new System.Drawing.Point(638, 100);
            this.search_combox.Name = "search_combox";
            this.search_combox.Size = new System.Drawing.Size(101, 21);
            this.search_combox.TabIndex = 182;
            // 
            // acname_ind_lbl
            // 
            this.acname_ind_lbl.AutoSize = true;
            this.acname_ind_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.acname_ind_lbl.ForeColor = System.Drawing.Color.Red;
            this.acname_ind_lbl.Location = new System.Drawing.Point(149, 80);
            this.acname_ind_lbl.Name = "acname_ind_lbl";
            this.acname_ind_lbl.Size = new System.Drawing.Size(0, 15);
            this.acname_ind_lbl.TabIndex = 181;
            // 
            // rubid_ind_lbl
            // 
            this.rubid_ind_lbl.AutoSize = true;
            this.rubid_ind_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.rubid_ind_lbl.ForeColor = System.Drawing.Color.Red;
            this.rubid_ind_lbl.Location = new System.Drawing.Point(148, 120);
            this.rubid_ind_lbl.Name = "rubid_ind_lbl";
            this.rubid_ind_lbl.Size = new System.Drawing.Size(0, 15);
            this.rubid_ind_lbl.TabIndex = 180;
            // 
            // stdcontact_ind_lbl
            // 
            this.stdcontact_ind_lbl.AutoSize = true;
            this.stdcontact_ind_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.stdcontact_ind_lbl.ForeColor = System.Drawing.Color.Red;
            this.stdcontact_ind_lbl.Location = new System.Drawing.Point(149, 237);
            this.stdcontact_ind_lbl.Name = "stdcontact_ind_lbl";
            this.stdcontact_ind_lbl.Size = new System.Drawing.Size(0, 15);
            this.stdcontact_ind_lbl.TabIndex = 179;
            // 
            // rubid_txtbox
            // 
            this.rubid_txtbox.Enabled = false;
            this.rubid_txtbox.Location = new System.Drawing.Point(152, 96);
            this.rubid_txtbox.Name = "rubid_txtbox";
            this.rubid_txtbox.Size = new System.Drawing.Size(100, 20);
            this.rubid_txtbox.TabIndex = 178;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(67, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 25);
            this.label5.TabIndex = 177;
            this.label5.Text = "Rubric ID";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.Color.Red;
            this.button6.Location = new System.Drawing.Point(32, 12);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(67, 35);
            this.button6.TabIndex = 176;
            this.button6.Text = "Close";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(531, 215);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 37);
            this.button3.TabIndex = 174;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(150, 215);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 37);
            this.button2.TabIndex = 173;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(44, 215);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 37);
            this.button1.TabIndex = 172;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // acgridview
            // 
            this.acgridview.AllowUserToAddRows = false;
            this.acgridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.acgridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.acgridview.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.acgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.acgridview.Location = new System.Drawing.Point(251, 257);
            this.acgridview.Name = "acgridview";
            this.acgridview.ReadOnly = true;
            this.acgridview.Size = new System.Drawing.Size(508, 320);
            this.acgridview.TabIndex = 171;
            this.acgridview.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.acgridview_CellMouseClick);
            this.acgridview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.acgridview_MouseClick);
            // 
            // acname_txtbox
            // 
            this.acname_txtbox.Location = new System.Drawing.Point(152, 57);
            this.acname_txtbox.Name = "acname_txtbox";
            this.acname_txtbox.Size = new System.Drawing.Size(100, 20);
            this.acname_txtbox.TabIndex = 169;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(94, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 167;
            this.label1.Text = "Name";
            // 
            // actotmrk_ind_lbl
            // 
            this.actotmrk_ind_lbl.AutoSize = true;
            this.actotmrk_ind_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.actotmrk_ind_lbl.ForeColor = System.Drawing.Color.Red;
            this.actotmrk_ind_lbl.Location = new System.Drawing.Point(148, 164);
            this.actotmrk_ind_lbl.Name = "actotmrk_ind_lbl";
            this.actotmrk_ind_lbl.Size = new System.Drawing.Size(0, 15);
            this.actotmrk_ind_lbl.TabIndex = 187;
            // 
            // actotmrk_txtbox
            // 
            this.actotmrk_txtbox.Location = new System.Drawing.Point(152, 140);
            this.actotmrk_txtbox.Name = "actotmrk_txtbox";
            this.actotmrk_txtbox.Size = new System.Drawing.Size(100, 20);
            this.actotmrk_txtbox.TabIndex = 186;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(48, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 185;
            this.label3.Text = "Total Marks";
            // 
            // aid_ind_lbl
            // 
            this.aid_ind_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aid_ind_lbl.AutoSize = true;
            this.aid_ind_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.aid_ind_lbl.ForeColor = System.Drawing.Color.Red;
            this.aid_ind_lbl.Location = new System.Drawing.Point(635, 82);
            this.aid_ind_lbl.Name = "aid_ind_lbl";
            this.aid_ind_lbl.Size = new System.Drawing.Size(0, 15);
            this.aid_ind_lbl.TabIndex = 190;
            // 
            // aid_txtbox
            // 
            this.aid_txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aid_txtbox.Enabled = false;
            this.aid_txtbox.Location = new System.Drawing.Point(639, 58);
            this.aid_txtbox.Name = "aid_txtbox";
            this.aid_txtbox.Size = new System.Drawing.Size(100, 20);
            this.aid_txtbox.TabIndex = 189;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(509, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 25);
            this.label7.TabIndex = 188;
            this.label7.Text = "Assessment ID";
            // 
            // aidGridView
            // 
            this.aidGridView.AllowUserToAddRows = false;
            this.aidGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.aidGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.aidGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.aidGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aidGridView.Location = new System.Drawing.Point(32, 257);
            this.aidGridView.Name = "aidGridView";
            this.aidGridView.ReadOnly = true;
            this.aidGridView.Size = new System.Drawing.Size(123, 320);
            this.aidGridView.TabIndex = 191;
            this.aidGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.aidGridView_MouseClick);
            // 
            // rubidGridView
            // 
            this.rubidGridView.AllowUserToAddRows = false;
            this.rubidGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rubidGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rubidGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.rubidGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rubidGridView.Location = new System.Drawing.Point(161, 257);
            this.rubidGridView.Name = "rubidGridView";
            this.rubidGridView.ReadOnly = true;
            this.rubidGridView.Size = new System.Drawing.Size(84, 320);
            this.rubidGridView.TabIndex = 192;
            this.rubidGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rubidGridView_MouseClick_1);
            // 
            // stdac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(771, 588);
            this.Controls.Add(this.rubidGridView);
            this.Controls.Add(this.aidGridView);
            this.Controls.Add(this.aid_ind_lbl);
            this.Controls.Add(this.aid_txtbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.actotmrk_ind_lbl);
            this.Controls.Add(this.actotmrk_txtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.search_combox);
            this.Controls.Add(this.acname_ind_lbl);
            this.Controls.Add(this.rubid_ind_lbl);
            this.Controls.Add(this.stdcontact_ind_lbl);
            this.Controls.Add(this.rubid_txtbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.acgridview);
            this.Controls.Add(this.acname_txtbox);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "stdac";
            this.Text = "stdac";
            this.Load += new System.EventHandler(this.stdac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.acgridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aidGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rubidGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox search_combox;
        private System.Windows.Forms.Label acname_ind_lbl;
        private System.Windows.Forms.Label rubid_ind_lbl;
        private System.Windows.Forms.Label stdcontact_ind_lbl;
        private System.Windows.Forms.TextBox rubid_txtbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView acgridview;
        private System.Windows.Forms.TextBox acname_txtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label actotmrk_ind_lbl;
        private System.Windows.Forms.TextBox actotmrk_txtbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label aid_ind_lbl;
        private System.Windows.Forms.TextBox aid_txtbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView aidGridView;
        private System.Windows.Forms.DataGridView rubidGridView;
    }
}