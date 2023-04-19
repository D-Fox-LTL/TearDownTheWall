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


        // Class of ball
        clsBall mobjBall;


        // Field of bricks
        int mintAmountOfBricks;
        clsBrick[] mobjBrick;

        //Timer and Rectangle
        int mintXRectangle, mintYRectangle;
        const int mintInterval = 15;
        

        public void rectangleSetToPlace()
        {
            mintXRectangle = pbCanvas.Width / 2;
            mintYRectangle = pbCanvas.Height - 100 ;
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

            mobjGraphics = pbCanvas.CreateGraphics();

            //Create of ball
            mobjBall = new clsBall(mobjGraphics);

            //init of variables
            ballSetToCenter();
            btStartGame.Visible = true;

            rectangleSetToPlace();
            // Creation of field
            mintAmountOfBricks = ;
            mobjBrick = new clsBrick[mintAmountOfBricks];

            // creation of bricks
            for (int i = 0; i < mintAmountOfBricks; i++)
                mobjBrick[i] = new clsBrick();

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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                mintXRectangle -= 10;
            } else if (e.KeyCode == Keys.Right)
            {
                mintXRectangle += 10;
            }
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
                mobjBall.ballSetToCenter();
            }
        }






        //Game part of code






        private void btStartGame_Click(object sender, EventArgs e)
        {
            mobjBall.startOfTheBall();
            btStartGame.Visible = false;
        }

        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            // deletion of scene
            mobjGraphics.Clear(Color.White);

            //
            mobjBall.vector(mobjGraphics);
        }
    }
}
