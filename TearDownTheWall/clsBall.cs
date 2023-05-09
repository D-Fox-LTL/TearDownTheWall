// ####################################################################################################################################
//
// Class of ball
// Created: 19.4.2023
// Updated: 6.5.2023
// Made by: D-Fox-LTL
//
// ####################################################################################################################################


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        int mintShiftSpeed;
        bool mblGameOver = false;
        int rndStart;
        Random rndNumber = new Random();
        

        //----------------------------|
        //        Constructor         |
        //----------------------------|
        public clsBall(Graphics objCanvas)
        {
            mobjGraphics = objCanvas;

            mintXBall = (int)objCanvas.VisibleClipBounds.Width / 2;
            mintYBall = (int)objCanvas.VisibleClipBounds.Height / 2;

            mintShiftSpeed = 5;
            rndStart = rndNumber.Next(1, 4);

            mintVectorX = 0;
            mintVectorY = 0;
        }

        //----------------------------|
        //  load of ball coordinates  |
        //----------------------------|

        public int intXBall     //property
        {
            get { return mintXBall; }       //field
        }
        public int intYBall     //property
        {
            get { return mintYBall; }       //field
        }
        public int intRBall     //property
        {
            get { return mintRBall; }       //field
        }
        public bool blGameOver
        {
            get { return mblGameOver; }
            set { mblGameOver = value; }
        }



        //----------------------------------------------------------------------|
        //      changes ball's vector -> made  for canvas wall collisions       |
        //----------------------------------------------------------------------|


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
            }
            else if (mintYBall + mintRBall >= (int)mobjGraphics.VisibleClipBounds.Height)
            {
                //mintVectorY = mintVectorY * (-1);
                mblGameOver = true;
            }
        }


        //--------------------------------------------------------------------|
        //      changes ball's vector -> made  for rectangle collisions       |
        //--------------------------------------------------------------------|


        public bool TestOfCollisionRectangle(int intXRectangle, int intYRectangle, int intWidthRectangle, int intHeightRectangle)
        {

            //defines ball and brick as a rectangles to compare
            Rectangle rectangle = new Rectangle(intXRectangle, intYRectangle, intWidthRectangle, intHeightRectangle);
            Rectangle rectBall = new Rectangle(mintXBall, mintYBall, mintRBall, mintRBall);


            //test of collision
            if (rectangle.IntersectsWith(rectBall))
            {
                //mintVectorY *= -1;
                mintVectorY = rndNumber.Next(3, 8) * (-1);

                return true;
            }
            else
            {
                return false;
            }
        }

            //--------------------------------------------------------------------------|
            //      changes ball's vector -> made especially for brick collisions       |
            //--------------------------------------------------------------------------|

            public void ChangeVector()
        {
            // void to change vectorY in the code
            mintVectorY *= (-1);
        }


        //----------------------------|
        //      starts the ball       |
        //----------------------------|

        public void startOfTheBall()
        {
            // Gives a speed to a ball through int given to vectors
            if (rndStart == 1 || rndStart == 2)
            {
                mintVectorX = mintShiftSpeed;
                mintVectorY = rndNumber.Next(2, 5);
            } else
            {
                mintVectorX = mintShiftSpeed * (-1);
                mintVectorY = rndNumber.Next(2, 5);
            }
            rndStart = rndNumber.Next(1, 4);
        }
    }
}
