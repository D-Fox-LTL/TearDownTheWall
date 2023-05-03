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
        int mintXBall, mintYBall;
        int mintVectorX, mintVectorY;
        const int mintRBall = 10;
        const int mintShiftSpeed = 5;
        bool mblGameOver = false;

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


        // load of ball coordinates
        public int intXBall     //property
        {
            get { return mintXBall; }       //field
        }   public int intYBall     //property
        {
            get { return mintYBall; }       //field
        }   public int intRBall     //property
        {
            get { return mintRBall; }       //field
        }   public bool blGameOver     //property
        {
            get { return mblGameOver; }       //field
            set { mblGameOver = value; }
        }

        


        public void vector()
        {
			//Drawing  of ball
			mobjGraphics.FillEllipse(Brushes.Black, mintXBall, mintYBall, mintRBall, mintRBall);


            //shift
            mintXBall += mintVectorX;
            mintYBall += mintVectorY;

            //Collision on borders of pbCanvas
            if (mintYBall <= 0)
            {
                mintVectorY = mintVectorY * (-1);
            }
            else if (mintXBall + mintRBall >= (int)mobjGraphics.VisibleClipBounds.Width || mintXBall <= 0)
            {
                mintVectorX = mintVectorX * (-1);
            } else if (mintYBall + mintRBall >= (int)mobjGraphics.VisibleClipBounds.Height) {
                mintVectorY = mintVectorY * (-1);
                //mblGameOver = true;
            }
        }
        public void startOfTheBall()
        {
            mintVectorX = mintShiftSpeed;
            mintVectorY = mintShiftSpeed;
        }

    }
}
