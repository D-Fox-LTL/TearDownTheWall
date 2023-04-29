using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TearDownTheWall
{
    public partial class Form1 : Form
    {

        //Variables

        Graphics mobjGraphics;

        // Ball
        int mintXBall, mintYBall;
        int mintVectorX, mintVectorY;
        const int mintRBall = 10;
        const int mintShiftSpeed = 5;
        const int mintInterval = 15;

        
        //Ball set to center and adding start bt
        //Done like that to use it in other lines
        //of code without writing too many lines
        public void ballSetToCenter()
        {
            mintXBall = pbCanvas.Width / 2;
            mintYBall = pbCanvas.Height / 2;
            mintVectorX = 0;
            mintVectorY = 0;
            btStartGame.Visible = true;
        }

        //To set window size in menu
        public void pbCanvasSet()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            pbCanvas.Anchor = AnchorStyles.None;
            pbCanvas.Dock = DockStyle.Fill;
        }


        public Form1()
        {
            InitializeComponent();

            //init of variables
            ballSetToCenter();

            mobjGraphics = pbCanvas.CreateGraphics();
        }



                        //Menu and form part of code



        private void tsMenuStripFullscreen_Click(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(0, 0);
            this.MaximumSize = new Size(2000, 2000);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            pbCanvas.SizeMode = PictureBoxSizeMode.StretchImage;
            BackgroundImageLayout = ImageLayout.Stretch;
            ballSetToCenter();
            mobjGraphics = pbCanvas.CreateGraphics();
        }



        private void tsMenuStripSizeableWindow_Click(object sender, EventArgs e)
        {
        ToolStripMenuItem lobjTsMenuITemSender = (ToolStripMenuItem)sender;
            if (lobjTsMenuITemSender.Text == "720x480")
            {
                this.MinimumSize = new Size(720, 480);
                this.MaximumSize = new Size(720, 480);
                pbCanvasSet();
                ballSetToCenter();
                mobjGraphics = pbCanvas.CreateGraphics();
            } else if (lobjTsMenuITemSender.Text == "720x576")
            {
                this.MinimumSize = new Size(720, 576);
                this.MaximumSize = new Size(720, 576);
                pbCanvasSet();
                ballSetToCenter();
                mobjGraphics = pbCanvas.CreateGraphics();
            } else if (lobjTsMenuITemSender.Text == "1280x720")
            {
                this.MinimumSize = new Size(1280, 720);
                this.MaximumSize = new Size(1280, 720);
                pbCanvasSet();
                ballSetToCenter();
                mobjGraphics = pbCanvas.CreateGraphics();
            } else if (lobjTsMenuITemSender.Text == "1280x720")
            {
                this.MinimumSize = new Size(1920, 1080);
                this.MaximumSize = new Size(1920, 1080);
                pbCanvasSet();
                ballSetToCenter();
                mobjGraphics = pbCanvas.CreateGraphics();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrRedraw.Interval = mintInterval;
            tmrRedraw.Start();
        }


        /// <summary>
        /// This private void exits or restarts the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuStripExit_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem lobjTsMenuITemSender = (ToolStripMenuItem)sender;
            if (lobjTsMenuITemSender.Text == "Exit")
            {
                Application.Exit();
            } else if (lobjTsMenuITemSender.Text == "Restart")
            {
                ballSetToCenter();
            }
        }





        //Game part of code






        private void btStartGame_Click(object sender, EventArgs e)
        {
            mintVectorX = mintShiftSpeed;
            mintVectorY = mintShiftSpeed;
            btStartGame.Visible = false;
        }

        private void tmrRedraw_Tick(object sender, EventArgs e)
        {

            //Deletion of scene
            mobjGraphics.Clear(Color.White);


            //Drawing  of ball
            mobjGraphics.FillEllipse(Brushes.Black, mintXBall, mintYBall, mintRBall, mintRBall);

            //shift

            mintXBall += mintVectorX;
            mintYBall += mintVectorY;

            //Collision on borders of pbCanvas
            if (mintYBall + mintRBall >= pbCanvas.Height|| mintYBall <= 0)
            {
                mintVectorY = mintVectorY * (-1);
            }
            else if (mintXBall + mintRBall >= pbCanvas.Width || mintXBall<= 0)
            {
                mintVectorX = mintVectorX * (-1);
            }
        }
    }
}
