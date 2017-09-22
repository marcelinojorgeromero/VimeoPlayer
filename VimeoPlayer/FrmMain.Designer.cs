namespace VimeoPlayer
{
    partial class FrmMain
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
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TxtSearchTerm = new System.Windows.Forms.TextBox();
            this.LstView = new System.Windows.Forms.ListView();
            this.StatusStripMain = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLbMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(695, 26);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(101, 36);
            this.BtnSearch.TabIndex = 2;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // TxtSearchTerm
            // 
            this.TxtSearchTerm.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearchTerm.Location = new System.Drawing.Point(8, 29);
            this.TxtSearchTerm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtSearchTerm.Name = "TxtSearchTerm";
            this.TxtSearchTerm.Size = new System.Drawing.Size(684, 30);
            this.TxtSearchTerm.TabIndex = 1;
            this.TxtSearchTerm.Text = "timelapse";
            this.TxtSearchTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtSearchTerm.WordWrap = false;
            // 
            // LstView
            // 
            this.LstView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstView.Location = new System.Drawing.Point(8, 99);
            this.LstView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LstView.Name = "LstView";
            this.LstView.Size = new System.Drawing.Size(789, 451);
            this.LstView.TabIndex = 3;
            this.LstView.UseCompatibleStateImageBehavior = false;
            this.LstView.ItemActivate += new System.EventHandler(this.LstView_ItemActivate);
            this.LstView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LstView_ItemSelectionChanged);
            // 
            // StatusStripMain
            // 
            this.StatusStripMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.StatusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLbMain});
            this.StatusStripMain.Location = new System.Drawing.Point(0, 641);
            this.StatusStripMain.Name = "StatusStripMain";
            this.StatusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.StatusStripMain.Size = new System.Drawing.Size(804, 25);
            this.StatusStripMain.TabIndex = 4;
            this.StatusStripMain.Text = "statusStrip1";
            // 
            // ToolStripStatusLbMain
            // 
            this.ToolStripStatusLbMain.Name = "ToolStripStatusLbMain";
            this.ToolStripStatusLbMain.Size = new System.Drawing.Size(58, 20);
            this.ToolStripStatusLbMain.Text = "Status...";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 666);
            this.Controls.Add(this.StatusStripMain);
            this.Controls.Add(this.LstView);
            this.Controls.Add(this.TxtSearchTerm);
            this.Controls.Add(this.BtnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vimeo Player";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.StatusStripMain.ResumeLayout(false);
            this.StatusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtSearchTerm;
        private System.Windows.Forms.ListView LstView;
        private System.Windows.Forms.StatusStrip StatusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLbMain;
    }
}

