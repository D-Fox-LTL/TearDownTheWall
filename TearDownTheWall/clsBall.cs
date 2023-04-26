// ####################################################################################################################################
//
// Class of ball
// Created: 19.4.2023
// Updated: 26.4.2023
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
			
		}

		//Ball set to center and adding start bt
		//Done like that to use it in other lines
		//of code without writing too many lines
		public void ballSetToCenter(Graphics objCanvas)
		{
			mobjGraphics = objCanvas;


			mintXBall = (int)objCanvas.VisibleClipBounds.Width / 2;
			mintYBall = (int)objCanvas.VisibleClipBounds.Height / 2;

			mintVectorX = 0;
			mintVectorY = 0;


		}

		public void vector(Graphics objCanvas)
        {
			mobjGraphics = objCanvas;

			//Drawing  of ball
			mobjGraphics.FillEllipse(Brushes.Black, mintXBall, mintYBall, mintRBall, mintRBall);

			//Drawing of Rectangle
			//objCanvas.FillRectangle(Brushes.Black, mintXRectangle, mintYRectangle, 60, 15);

            //shift

            mintXBall += mintVectorX;
            mintYBall += mintVectorY;

            //Collision on borders of pbCanvas
            if (mintYBall + mintRBall >= (int)objCanvas.VisibleClipBounds.Height || mintYBall <= 0)
            {
                mintVectorY = mintVectorY * (-1);
            }
            else if (mintXBall + mintRBall >= (int)objCanvas.VisibleClipBounds.Width || mintXBall <= 0)
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
