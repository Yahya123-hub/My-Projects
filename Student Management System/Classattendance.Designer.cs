namespace Student_Management_System
{
    partial class Classattendance
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
            this.button6 = new System.Windows.Forms.Button();
            this.stdgridview = new System.Windows.Forms.DataGridView();
            this.main_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stdgridview)).BeginInit();
            this.SuspendLayout();
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
            this.button6.TabIndex = 159;
            this.button6.Text = "Close";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // stdgridview
            // 
            this.stdgridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stdgridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.stdgridview.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.stdgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stdgridview.Location = new System.Drawing.Point(12, 140);
            this.stdgridview.Name = "stdgridview";
            this.stdgridview.ReadOnly = true;
            this.stdgridview.Size = new System.Drawing.Size(747, 436);
            this.stdgridview.TabIndex = 158;
            // 
            // main_lbl
            // 
            this.main_lbl.AutoSize = true;
            this.main_lbl.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.main_lbl.ForeColor = System.Drawing.Color.Red;
            this.main_lbl.Location = new System.Drawing.Point(27, 73);
            this.main_lbl.Name = "main_lbl";
            this.main_lbl.Size = new System.Drawing.Size(285, 28);
            this.main_lbl.TabIndex = 160;
            this.main_lbl.Text = "Student Attendance Average :";
            // 
            // Classattendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(771, 588);
            this.Controls.Add(this.main_lbl);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.stdgridview);
            this.DoubleBuffered = true;
            this.Name = "Classattendance";
            this.Text = "Classresult";
            ((System.ComponentModel.ISupportInitialize)(this.stdgridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView stdgridview;
        private System.Windows.Forms.Label main_lbl;
    }
}