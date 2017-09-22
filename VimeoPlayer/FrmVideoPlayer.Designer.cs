namespace VimeoPlayer
{
    partial class FrmVideoPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVideoPlayer));
            this.FlashVideo = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.FlashVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // FlashVideo
            // 
            this.FlashVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlashVideo.Enabled = true;
            this.FlashVideo.Location = new System.Drawing.Point(0, 0);
            this.FlashVideo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FlashVideo.Name = "FlashVideo";
            this.FlashVideo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FlashVideo.OcxState")));
            this.FlashVideo.Size = new System.Drawing.Size(663, 417);
            this.FlashVideo.TabIndex = 0;
            // 
            // FrmVideoPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 417);
            this.Controls.Add(this.FlashVideo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmVideoPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmVideoPlayer";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.FlashVideo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash FlashVideo;
    }
}