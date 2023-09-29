namespace final_gui_Template
{
    partial class Recommendations
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
            this.recommended_section = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // recommended_section
            // 
            this.recommended_section.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recommended_section.AutoScroll = true;
            this.recommended_section.Location = new System.Drawing.Point(14, 12);
            this.recommended_section.Name = "recommended_section";
            this.recommended_section.Size = new System.Drawing.Size(742, 559);
            this.recommended_section.TabIndex = 302;
            // 
            // Recommendations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 588);
            this.Controls.Add(this.recommended_section);
            this.Name = "Recommendations";
            this.Text = "Recommendations";
            this.Load += new System.EventHandler(this.Recommendations_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel recommended_section;
    }
}