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
        public int mintAmountOfBricks;
        clsBrick[] mobjBrick;
        const int mintWidthOfBrick = 80, mintHeightOfBrick = 20;
        const int mintWidthOfGap = 20, mintNumberOfLines = 3;
        bool blHack = false;
        clsBrick mobjBrickWoutField;
        

        //Timer
        const int mintInterval = 10;

        //To set window size in menu
        public void pbCanvasSet()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            pbCanvas.Anchor = AnchorStyles.None;
            pbCanvas.Dock = DockStyle.Fill;
        }


        //To set everything bcs I am lazy and I do it too much in this code so yeah...
        public void setEverything()
        {
                //Ball
            mobjBall = new clsBall(mobjGraphics);
            mobjBall.vector();
            btStartGame.Visible = true;

            //Rectangle
            mobjRectangle = new clsRectangle(mobjGraphics);
            mobjRectangle.intXRectangle = pbCanvas.Width / 2;
            mobjRectangle.drawRectangle();

                //Bricks
            // Creation of field 
            mintAmountOfBricks = mintNumberOfLines * (pbCanvas.Width - mintWidthOfGap) / (mintWidthOfBrick + mintWidthOfGap);
            mobjBrick = new clsBrick[mintAmountOfBricks];


            // creation of bricks
            int lintX, lintY;
            lintX = lintY = mintWidthOfGap;
            for (int i = 0; i < mintAmountOfBricks; i++)
            {
                if ((lintX + mintWidthOfBrick + mintWidthOfGap) > pbCanvas.Width)
                {
                    lintX = mintWidthOfGap;
                    lintY = lintY + mintHeightOfBrick + mintWidthOfGap;
                }


                // init of one brick
                mobjBrick[i] = new clsBrick(mobjGraphics, lintX, lintY, mintWidthOfBrick, mintHeightOfBrick, mintAmountOfBricks);


                //change of coordinates
                lintX += mintWidthOfBrick + mintWidthOfGap;

            }
        }


        public Form1()
        {
            InitializeComponent();


            //init of variables


            mobjGraphics = pbCanvas.CreateGraphics();


            setEverything();
        }






                    //Game part of code






        private void btStartGame_Click(object sender, EventArgs e)
        {
            mobjBall.startOfTheBall();
            btStartGame.Visible = false;
        }

        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            mobjBrickWoutField = new clsBrick(mobjGraphics, 0, 0, 0, 0, mintAmountOfBricks);
            if (mobjBrickWoutField.blEndOfGame() == true)
            {
                GameOver();
                MessageBox.Show("You have Won! Congrats!");
            }
            // deletion of scene
            mobjGraphics.Clear(Color.White);

            //moves ball
            mobjBall.vector();

            //moves rectangle
            mobjRectangle.drawRectangle();

            //Hacksssss
            if (blHack == true)
            {
                mobjRectangle.intXRectangle = mobjBall.intXBall;
            }

            //Collision test
            foreach (clsBrick objBrick in mobjBrick)
            {
                //Collision test
                objBrick.TestOfCollision(mobjBall.intXBall, mobjBall.intYBall, mobjBall.intRBall, mobjBall.intRBall);

                //drawing of bricks
                objBrick.DrawBrick();

                GameOver();
            }
        }

        private void GameOver()
        {
            if (mobjBall.blGameOver == true)
            {
                setEverything();
                mobjBall.blGameOver = false;
            }

        }
        




                    //Menu and form part of code






        //Option of changing size of the window is not working at the moment
        //It is still in the process so this part of the code till exit/restart menu makes no difference



        private void tsMenuStripFullscreen_Click(object sender, EventArgs e)
            {
                this.MinimumSize = new Size(0, 0);
                this.MaximumSize = new Size(2000, 2000);
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
                pbCanvas.SizeMode = PictureBoxSizeMode.StretchImage;
                BackgroundImageLayout = ImageLayout.Stretch;
                mobjGraphics = pbCanvas.CreateGraphics();
                setEverything();
            }

        

            private void tsMenuStripSizeableWindow_Click(object sender, EventArgs e)
            {
                ToolStripMenuItem lobjTsMenuITemSender = (ToolStripMenuItem)sender;
                if (lobjTsMenuITemSender.Text == "720x480")
                {
                    this.MinimumSize = new Size(720, 480);
                    this.MaximumSize = new Size(720, 480);
                    pbCanvasSet();
                    setEverything();
                }
                else if (lobjTsMenuITemSender.Text == "720x576")
                {
                    this.MinimumSize = new Size(720, 576);
                    this.MaximumSize = new Size(720, 576);
                    pbCanvasSet();
                    setEverything();
                }
                else if (lobjTsMenuITemSender.Text == "1280x720")
                {
                    this.MinimumSize = new Size(1280, 720);
                    this.MaximumSize = new Size(1280, 720);
                    pbCanvasSet();
                    setEverything();
                }
                else if (lobjTsMenuITemSender.Text == "1280x720")
                {
                    this.MinimumSize = new Size(1920, 1080);
                    this.MaximumSize = new Size(1920, 1080);
                    pbCanvasSet();
                    setEverything();
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
                mobjRectangle.intXRectangle -= 25;
            }
            else if (e.KeyCode == Keys.Right)
            {
                mobjRectangle.intXRectangle += 25;
            } else if (e.KeyCode == Keys.H)
            {
                blHack = true;
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
                }
                else if (lobjTsMenuITemSender.Text == "Restart")
                {
                    setEverything();
                    mobjBall.blGameOver = false;
            }
        }
    }
}
