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

        // Class of rectangle
        clsRectangle mobjRectangle;



        // Field of bricks
        int mintAmountOfBricks;
        clsBrick[] mobjBrick;
        const int mintWidthOfBrick = 80, mintHeightOfBrick = 20;
        const int mintWidthOfGap = 20, mintNumberOfLines = 3;

        //Timer
        const int mintInterval = 15;

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

            int lintX, lintY;
            InitializeComponent();

            mobjGraphics = pbCanvas.CreateGraphics();

            //Create of ball
            mobjBall = new clsBall(mobjGraphics);

            //Creation of rectangle
            mobjRectangle = new clsRectangle();

            //init of variables
            mobjBall.vector(mobjGraphics);
            mobjBall.ballSetToCenter(mobjGraphics);
            btStartGame.Visible = true;

            mobjRectangle.rectangleSetToPlace(mobjGraphics);



            // Creation of field
            mintAmountOfBricks = (pbCanvas.Width-mintWidthOfGap) / (mintWidthOfBrick+mintWidthOfGap);
            mobjBrick = new clsBrick[mintAmountOfBricks];

            // creation of bricks
            lintX = lintY = mintWidthOfGap;

            if ((lintX + mintWidthOfBrick + mintWidthOfGap) > pbCanvas.Width)
            {
                lintX = mintWidthOfGap;
                lintY = lintY + mintHeightOfBrick + mintWidthOfGap;
            }
			// init of one brick
			mobjBrick[mintAmountOfBricks] = new clsBrick(mobjGraphics, lintX, lintY, mintWidthOfBrick, mintHeightOfBrick);


			//change of coordinates
			lintX = lintX + mintWidthOfGap + mintWidthOfGap;

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
			mobjBall.ballSetToCenter(mobjGraphics);
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
				mobjBall.ballSetToCenter(mobjGraphics);
				mobjGraphics = pbCanvas.CreateGraphics();
            } else if (lobjTsMenuITemSender.Text == "720x576")
            {
                this.MinimumSize = new Size(720, 576);
                this.MaximumSize = new Size(720, 576);
                pbCanvasSet();
				mobjBall.ballSetToCenter(mobjGraphics);
				mobjGraphics = pbCanvas.CreateGraphics();
            } else if (lobjTsMenuITemSender.Text == "1280x720")
            {
                this.MinimumSize = new Size(1280, 720);
                this.MaximumSize = new Size(1280, 720);
                pbCanvasSet();
                mobjBall.ballSetToCenter(mobjGraphics);
                mobjGraphics = pbCanvas.CreateGraphics();
            } else if (lobjTsMenuITemSender.Text == "1280x720")
            {
                this.MinimumSize = new Size(1920, 1080);
                this.MaximumSize = new Size(1920, 1080);
                pbCanvasSet();
                mobjBall.ballSetToCenter(mobjGraphics);
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
                mobjRectangle.mintXRectangle -= 10;
            } else if (e.KeyCode == Keys.Right)
            {
				mobjRectangle.mintXRectangle += 10;
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
				mobjBall.ballSetToCenter(mobjGraphics);
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

            //
            //for (int i = 0;  i < mintAmountOfBricks; i++)
            foreach (clsBrick objBrick in mobjBrick) ;
            {
                mobjBrick[mintAmountOfBricks].DrawBrick();
            }
        }
    }
}
