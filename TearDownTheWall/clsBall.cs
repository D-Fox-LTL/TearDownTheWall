// ####################################################################################################################################
//
// Class of ball
// Created: 19.4.2023
// Updated: 19.4.2023
// Made by: D-Fox-LTL
//
// ####################################################################################################################################


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TearDownTheWall
{
    public class clsBall
    {
        //Variables

        //Graphics
        Graphics mobjGraphics;

        // Ball variables
        int mintXBall, mintYBall;
        int mintXRectangle, mintYRectangle;
        public int mintVectorX, mintVectorY;
        const int mintRBall = 10;
        const int mintShiftSpeed = 5;
        const int mintInterval = 15;

        //----------------------------
        //Constructor
        //----------------------------
        public clsBall(Graphics objCanvas)
        {
            //Ball set to center and adding start bt
            //Done like that to use it in other lines
            //of code without writing too many lines

            public static void ballSetToCenter()
            {
                mobjGraphics = objCanvas;

                mintXBall = (int)objCanvas.ClipBounds.Width / 2;
                mintYBall = (int)objCanvas.ClipBounds.Height / 2;

                mintVectorX = 0;
                mintVectorY = 0;
            }
        }
        public void vector(Graphics objCanvas)
        {
            //Drawing  of ball
            mobjGraphics.FillEllipse(Brushes.Black, mintXBall, mintYBall, mintRBall, mintRBall);

            //Drawing of Rectangle
            mobjGraphics.FillRectangle(Brushes.Black, mintXRectangle, mintYRectangle, 60, 15);

            //shift

            mintXBall += mintVectorX;
            mintYBall += mintVectorY;

            //Collision on borders of pbCanvas
            if (mintYBall + mintRBall >= (int)objCanvas.ClipBounds.Height || mintYBall <= 0)
            {
                mintVectorY = mintVectorY * (-1);
            }
            else if (mintXBall + mintRBall >= (int)objCanvas.ClipBounds.Width || mintXBall <= 0)
            {
                mintVectorX = mintVectorX * (-1);
            }
        }
        public void startOfTheBall()
        {
            mintVectorX = mintShiftSpeed;
            mintVectorY = mintShiftSpeed;
        }

    }
}
