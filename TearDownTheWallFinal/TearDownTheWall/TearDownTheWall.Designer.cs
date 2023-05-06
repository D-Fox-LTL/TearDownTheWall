namespace TearDownTheWall
{
    partial class TearDownTheWall
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuStripRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuStripFullscreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuStripSizeableWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItem720x480 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItem720x576 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItem1280x720 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItem1920x1080 = new System.Windows.Forms.ToolStripMenuItem();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.tmrRedraw = new System.Windows.Forms.Timer(this.components);
            this.txtStartGame = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.sizeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuStripExit,
            this.tsMenuStripRestart});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.exitToolStripMenuItem.Text = "Menu";
            // 
            // tsMenuStripExit
            // 
            this.tsMenuStripExit.Name = "tsMenuStripExit";
            this.tsMenuStripExit.Size = new System.Drawing.Size(110, 22);
            this.tsMenuStripExit.Text = "Exit";
            this.tsMenuStripExit.Click += new System.EventHandler(this.tsMenuStripExit_Click);
            // 
            // tsMenuStripRestart
            // 
            this.tsMenuStripRestart.Name = "tsMenuStripRestart";
            this.tsMenuStripRestart.Size = new System.Drawing.Size(110, 22);
            this.tsMenuStripRestart.Text = "Restart";
            this.tsMenuStripRestart.Click += new System.EventHandler(this.tsMenuStripExit_Click);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuStripFullscreen,
            this.tsMenuStripSizeableWindow});
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.sizeToolStripMenuItem.Text = "Size";
            this.sizeToolStripMenuItem.Visible = false;
            // 
            // tsMenuStripFullscreen
            // 
            this.tsMenuStripFullscreen.Name = "tsMenuStripFullscreen";
            this.tsMenuStripFullscreen.Size = new System.Drawing.Size(161, 22);
            // 
            // tsMenuStripSizeableWindow
            // 
            this.tsMenuStripSizeableWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItem720x480,
            this.tsMenuItem720x576,
            this.tsMenuItem1280x720,
            this.tsMenuItem1920x1080});
            this.tsMenuStripSizeableWindow.Name = "tsMenuStripSizeableWindow";
            this.tsMenuStripSizeableWindow.Size = new System.Drawing.Size(161, 22);
            this.tsMenuStripSizeableWindow.Text = "Sizeable window";
            // 
            // tsMenuItem720x480
            // 
            this.tsMenuItem720x480.Name = "tsMenuItem720x480";
            this.tsMenuItem720x480.Size = new System.Drawing.Size(67, 22);
            // 
            // tsMenuItem720x576
            // 
            this.tsMenuItem720x576.Name = "tsMenuItem720x576";
            this.tsMenuItem720x576.Size = new System.Drawing.Size(67, 22);
            // 
            // tsMenuItem1280x720
            // 
            this.tsMenuItem1280x720.Name = "tsMenuItem1280x720";
            this.tsMenuItem1280x720.Size = new System.Drawing.Size(67, 22);
            // 
            // tsMenuItem1920x1080
            // 
            this.tsMenuItem1920x1080.Name = "tsMenuItem1920x1080";
            this.tsMenuItem1920x1080.Size = new System.Drawing.Size(67, 22);
            // 
            // pbCanvas
            // 
            this.pbCanvas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbCanvas.BackColor = System.Drawing.SystemColors.Control;
            this.pbCanvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCanvas.Location = new System.Drawing.Point(12, 37);
            this.pbCanvas.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(1346, 645);
            this.pbCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCanvas.TabIndex = 2;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.WaitOnLoad = true;
            // 
            // tmrRedraw
            // 
            this.tmrRedraw.Tick += new System.EventHandler(this.tmrRedraw_Tick);
            // 
            // txtStartGame
            // 
            this.txtStartGame.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtStartGame.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStartGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStartGame.Enabled = false;
            this.txtStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartGame.Location = new System.Drawing.Point(0, 24);
            this.txtStartGame.Name = "txtStartGame";
            this.txtStartGame.ReadOnly = true;
            this.txtStartGame.Size = new System.Drawing.Size(1370, 33);
            this.txtStartGame.TabIndex = 3;
            this.txtStartGame.Text = "Press ENTER  to start the game";
            this.txtStartGame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TearDownTheWall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1370, 694);
            this.Controls.Add(this.txtStartGame);
            this.Controls.Add(this.pbCanvas);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TearDownTheWall";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "TearDownTheWall";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsMenuStripExit;
        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Timer tmrRedraw;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsMenuStripFullscreen;
        private System.Windows.Forms.ToolStripMenuItem tsMenuStripSizeableWindow;
        private System.Windows.Forms.ToolStripMenuItem tsMenuStripRestart;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem720x480;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem720x576;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem1280x720;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem1920x1080;
        private System.Windows.Forms.TextBox txtStartGame;
    }
}

