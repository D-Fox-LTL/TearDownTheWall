using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        const int mintShiftSpeed = 10;
        const int mintInterval = 15;

        //For resizing
        private DataGridView dataGridViewForm = new DataGridView();



        public Form1()
        {
            InitializeComponent();

            //init of variables
            mobjGraphics = pbCanvas.CreateGraphics();
            //Ball set to center
            mintXBall = pbCanvas.Width / 2;
            mintYBall = pbCanvas.Height / 2;
            mintVectorX = mintShiftSpeed;
            mintVectorY = mintShiftSpeed;


        }

        private void tsMenuStripFullscreen_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrRedraw.Interval = mintInterval;
            tmrRedraw.Start();
        }

        private void tsMenuStripExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
