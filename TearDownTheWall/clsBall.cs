// ####################################################################################################################################
//
// Class of ball
// Created: 19.4.2023
// Updated: 29.4.2023
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
        public int mintXBall, mintYBall;
        public int mintVectorX, mintVectorY;
        const int mintRBall = 10;
        const int mintShiftSpeed = 5;
        const int mintInterval = 15;

        //----------------------------
        //Constructor
        //----------------------------
        public clsBall(Graphics objCanvas)
        {
            mobjGraphics = objCanvas;

            mintXBall = (int)objCanvas.VisibleClipBounds.Width / 2;
            mintYBall = (int)objCanvas.VisibleClipBounds.Height / 2;

            mintVectorX = 0;
            mintVectorY = 0;
        }

        public void vector()
        {
			//Drawing  of ball
			mobjGraphics.FillEllipse(Brushes.Black, mintXBall, mintYBall, mintRBall, mintRBall);

            //shift

            mintXBall += mintVectorX;
            mintYBall += mintVectorY;

            //Collision on borders of pbCanvas
            if (mintYBall + mintRBall >= (int)mobjGraphics.VisibleClipBounds.Height || mintYBall <= 0)
            {
                mintVectorY = mintVectorY * (-1);
            }
            else if (mintXBall + mintRBall >= (int)mobjGraphics.VisibleClipBounds.Width || mintXBall <= 0)
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
