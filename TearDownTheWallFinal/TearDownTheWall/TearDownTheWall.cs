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
    public partial class TearDownTheWall : Form
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
        const int mintWidthOfBrick = 60, mintHeightOfBrick = 20;
        const int mintWidthOfGap = 10, mintNumberOfLines = 4;
        int mintHowManyLeft = 0;


        //boolean for HaCkS
        bool mblHack = false;


        //Timer
        const int mintInterval = 10;

        //boolean for when game starts
        bool mblGameStarts = false;
        








        //-----------------------------------------------------------------|
        //                                                                 |
        //                                                                 |
        //                                                                 |
        //                     Functions of code                           |
        //                                                                 |
        //                                                                 |
        //                                                                 |
        //-----------------------------------------------------------------|








        //To set everything bcs I am lazy and I do it too much in this code so yeah...
        public void setEverything()
        {
            //HaCkS fOr NoObIeS
            mblHack = false;


            //Ball
            mobjBall = new clsBall(mobjGraphics);
            mobjBall.vector();
            txtStartGame.Visible = true;


            //Rectangle
            mobjRectangle = new clsRectangle(mobjGraphics);
            mobjRectangle.intXRectangle = pbCanvas.Width / 2 - (mobjRectangle.intWidthOfRectangle/2);
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
                mintHowManyLeft++;

                // init of one brick
                mobjBrick[i] = new clsBrick(mobjGraphics, lintX, lintY, mintWidthOfBrick, mintHeightOfBrick);

                //change of coordinates
                lintX += mintWidthOfBrick + mintWidthOfGap;
            }
        }





        //-----------------------------------------------------------------|
        //                                                                 |
        //                                                                 |
        //                                                                 |
        //                    Setting part of code                         |
        //                                                                 |
        //                                                                 |
        //                                                                 |
        //-----------------------------------------------------------------|






        public TearDownTheWall()
        {
            InitializeComponent();


            //init of variables


            mobjGraphics = pbCanvas.CreateGraphics();


            setEverything();
        }

        //Start of timer
        private void Form1_Load(object sender, EventArgs e)
        {
            tmrRedraw.Interval = mintInterval;
            tmrRedraw.Start();
        }


        //While focused in Form1 and by pressing defined keys some defined action will happen
        private async void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //local int for countdown
            int lintWait = 5;


            if (e.KeyCode == Keys.Left)             //Move rectangle to left
            {    
                mobjRectangle.intXRectangle -= 30;
            }
            else if (e.KeyCode == Keys.Right)       //Move reectangle to right
            {       
                mobjRectangle.intXRectangle += 30;
            } 
            else if (e.KeyCode == Keys.H && mblHack == false)    //Will turn on SoMe HaCkS fOr NoObS
            {       
                mblHack = true;
            }
            else if (e.KeyCode == Keys.H && mblHack == true)     //Will turn off hacks for noncowards
            {       
                mblHack = false;
            }
            else if (e.KeyCode == Keys.Enter)                   //Will start the game
            {
                //changes txtStartGame to a countdown
                txtStartGame.Text = "Game will start in";      
                while (lintWait > -1)
                {
                    if (lintWait == 0)
                    {       //text: game started, sends to 'done'
                        txtStartGame.Text = "Game started!";
                        goto Done;
                    }
                    else
                    {       //countdown with a 1000ms delay
                        txtStartGame.Text = "Game will start in " + lintWait;
                        lintWait--;
                        await Task.Delay(1000);
                    }
                }
                Done:       //delay, sets lintWait back, starts a ball, makes txtStartGame not visible and sets txtS.G. back
                await Task.Delay(1000);
                lintWait = 5;

                mobjBall.startOfTheBall();
                txtStartGame.Visible = false;
                txtStartGame.Text = "Press ENTER  to start the game";
            }
        }



        //-----------------------------------------------------------------|
        //                                                                 |
        //                                                                 |
        //                                                                 |
        //                       Game part of code                         |
        //                                                                 |
        //                                                                 |
        //                                                                 |
        //-----------------------------------------------------------------|





        private void tmrRedraw_Tick(object sender, EventArgs e)
        {

            //--------------------------------|
            //Redrawing of everything on scene|
            //--------------------------------|


            // deletion of scene
            mobjGraphics.Clear(Color.White);

            //moves ball
            mobjBall.vector();

            //moves rectangle
            mobjRectangle.drawRectangle();


            //--------------------------------|
            //          Hacksssss             |
            //--------------------------------|


            if (mblHack == true)
            {
                //Font for text printed on canvas whilst using hAcKsSsSs
                Font ftHack = new Font("Microsoft Sans Serif", 50);
                mobjGraphics.DrawString("You are using hacksss", ftHack, Brushes.CornflowerBlue, (pbCanvas.Width / 4+2), pbCanvas.Height / 2);

                //Rectangle has same X value as ball

                mobjRectangle.intXRectangle = mobjBall.intXBall - (mobjRectangle.intWidthOfRectangle / 2);
            }

            //--------------------------------|
            //           Win/Lose             |
            //--------------------------------|


            if (mintHowManyLeft == 0 && mblHack == false)        //Won w/out hacks
            {   
                setEverything();
                MessageBox.Show("You Won! Congrats!");
            }       
            else if (mintHowManyLeft == 0 && mblHack == true)    //Won w/ hacks
            {
                setEverything();
                MessageBox.Show("AI Won! Next time play without hacks nerd ;)");
            }       
            else if (mobjBall.blGameOver == true)               //Lost
            {
                mobjBall.blGameOver = false;
                setEverything();
                MessageBox.Show("You Lost! Shame on you!");
            }


            //--------------------------------|
            //      Testing collisions        |
            //--------------------------------|


            //collision of ball and rectangle at the bottom
            mobjBall.TestOfCollisionRectangle(mobjRectangle.intXRectangle, mobjRectangle.intYRectangle, mobjRectangle.intWidthOfRectangle, mobjRectangle.intHeightOfRectangle);


            //foreach statement for mobjBrick field

            foreach (clsBrick objBrick in mobjBrick)
            {
                //Collision test
                objBrick.TestOfCollisionBrick(mobjBall.intXBall, mobjBall.intYBall, mobjBall.intRBall, mobjBall.intRBall);

                // if bool blTest equals true,the ball's Y vector changes and blTest is set to false again
                // made like this bcs every other idea wasn't working
                if (objBrick.blCollided == true)
                {
                    mobjBall.ChangeVector();
                    mintHowManyLeft--;
                    objBrick.blCollided = false;
                }

                //drawing of bricks
                objBrick.DrawBrick();

            }
        }



                    //-----------------------------------------------------------------|
                    //                                                                 |
                    //                                                                 |
                    //                                                                 |
                    //                       Menu part of code                         |
                    //                                                                 |
                    //                                                                 |
                    //                                                                 |
                    //-----------------------------------------------------------------|





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
            }
        }
    }
}
