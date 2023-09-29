namespace Student_Management_System
{
    partial class stdattendance
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
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.attendancegridview = new System.Windows.Forms.DataGridView();
            this.stdid_txtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.atd_date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.stdid_gridview = new System.Windows.Forms.DataGridView();
            this.classattendance_gridview = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.attendancegridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdid_gridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classattendance_gridview)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(506, 119);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 37);
            this.button4.TabIndex = 166;
            this.button4.Text = "Leave";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.button6.TabIndex = 156;
            this.button6.Text = "Close";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(612, 119);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 37);
            this.button5.TabIndex = 155;
            this.button5.Text = "Late";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(59, 119);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 37);
            this.button2.TabIndex = 153;
            this.button2.Text = "Present";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(165, 119);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 37);
            this.button1.TabIndex = 152;
            this.button1.Text = "Absent";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // attendancegridview
            // 
            this.attendancegridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attendancegridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.attendancegridview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.attendancegridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attendancegridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attendancegridview.Location = new System.Drawing.Point(165, 161);
            this.attendancegridview.Name = "attendancegridview";
            this.attendancegridview.ReadOnly = true;
            this.attendancegridview.Size = new System.Drawing.Size(337, 416);
            this.attendancegridview.TabIndex = 151;
            this.attendancegridview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.attendancegridview_MouseClick);
            // 
            // stdid_txtbox
            // 
            this.stdid_txtbox.Enabled = false;
            this.stdid_txtbox.Location = new System.Drawing.Point(165, 68);
            this.stdid_txtbox.Name = "stdid_txtbox";
            this.stdid_txtbox.Size = new System.Drawing.Size(102, 20);
            this.stdid_txtbox.TabIndex = 168;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(59, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 167;
            this.label2.Text = "Student ID";
            // 
            // atd_date
            // 
            this.atd_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.atd_date.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.atd_date.CalendarMonthBackground = System.Drawing.SystemColors.WindowFrame;
            this.atd_date.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.atd_date.CalendarTitleForeColor = System.Drawing.Color.AliceBlue;
            this.atd_date.CustomFormat = "yyyy-MM-dd";
            this.atd_date.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.atd_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.atd_date.Location = new System.Drawing.Point(612, 68);
            this.atd_date.Name = "atd_date";
            this.atd_date.Size = new System.Drawing.Size(102, 27);
            this.atd_date.TabIndex = 169;
            this.atd_date.ValueChanged += new System.EventHandler(this.atd_date_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(489, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 170;
            this.label1.Text = "Choose Date";
            // 
            // stdid_gridview
            // 
            this.stdid_gridview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.stdid_gridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stdid_gridview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.stdid_gridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stdid_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stdid_gridview.Location = new System.Drawing.Point(12, 162);
            this.stdid_gridview.Name = "stdid_gridview";
            this.stdid_gridview.ReadOnly = true;
            this.stdid_gridview.Size = new System.Drawing.Size(149, 415);
            this.stdid_gridview.TabIndex = 171;
            this.stdid_gridview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.stdid_gridview_MouseClick);
            // 
            // classattendance_gridview
            // 
            this.classattendance_gridview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.classattendance_gridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.classattendance_gridview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.classattendance_gridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.classattendance_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.classattendance_gridview.Location = new System.Drawing.Point(506, 162);
            this.classattendance_gridview.Name = "classattendance_gridview";
            this.classattendance_gridview.ReadOnly = true;
            this.classattendance_gridview.Size = new System.Drawing.Size(262, 415);
            this.classattendance_gridview.TabIndex = 173;
            // 
            // stdattendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(771, 588);
            this.Controls.Add(this.classattendance_gridview);
            this.Controls.Add(this.stdid_gridview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.atd_date);
            this.Controls.Add(this.stdid_txtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.attendancegridview);
            this.DoubleBuffered = true;
            this.Name = "stdattendance";
            this.Text = "stdattendance";
            this.Load += new System.EventHandler(this.stdattendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.attendancegridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdid_gridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classattendance_gridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView attendancegridview;
        private System.Windows.Forms.TextBox stdid_txtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker atd_date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView stdid_gridview;
        private System.Windows.Forms.DataGridView classattendance_gridview;
    }
}