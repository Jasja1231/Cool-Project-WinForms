namespace GradedLab3P4
{
    partial class GameForm
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panelBase = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar1.Location = new System.Drawing.Point(0, 459);
            this.trackBar1.Maximum = 3;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(520, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // panelBase
            // 
            this.panelBase.Location = new System.Drawing.Point(0, 1);
            this.panelBase.Name = "panelBase";
            this.panelBase.Size = new System.Drawing.Size(520, 452);
            this.panelBase.TabIndex = 1;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(520, 504);
            this.Controls.Add(this.panelBase);
            this.Controls.Add(this.trackBar1);
            this.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panelBase;
    }
}