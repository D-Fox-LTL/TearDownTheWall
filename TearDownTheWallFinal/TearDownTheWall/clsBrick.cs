// ####################################################################################################################################
//
// Class of bricks
// Created: 19.4.2023
// Updated: 6.5.2023
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
	internal class clsBrick
	{
		//Variables


		//Graphics
		Graphics mobjGraphics;

		// Ball variables
		int mintXBrick, mintYBrick;
		int mintWidthBrick, mintHeightBrick;
		bool mblVisible;
		bool mblCollided;


		//----------------------------|
		//		  Constructor		  |
		//----------------------------|

		public clsBrick(Graphics objCanvas, int intXBrick, int intYBrick, int intWidthBrick, int intHeightBrick)
		{
			mobjGraphics = objCanvas;

			mintXBrick = intXBrick;
			mintYBrick = intYBrick;
			mintHeightBrick = intHeightBrick;
			mintWidthBrick = intWidthBrick;
			mblVisible = true;
            mblCollided = false;
		}

        //-----------------------------------------------------------------------|
        //boolean if ball and brick collided -> made for ball's change of vectorY|
        //-----------------------------------------------------------------------|

        public bool blCollided
        {
			get { return mblCollided; }
			set { mblCollided = value; }
		}

        //----------------------------|
        //		Drawing of Bricks	  |
        //----------------------------|
        public void DrawBrick()
		{
			// if brick is visible
			if (mblVisible == false) return;

			//drawing of rectangle
			mobjGraphics.FillRectangle(Brushes.Orange, mintXBrick, mintYBrick, mintWidthBrick, mintHeightBrick);
		}

		//-----------------------------------------|
		// Test of brick/ball collision			   |
		// - returns True if the collision happened|
		//-----------------------------------------|


		public bool TestOfCollisionBrick(int intXBall, int intYBall, int intWidthBall, int intHeightBall)
		{
			// if brick is visible
			if (mblVisible == false) { return false; }


			//defines ball and brick as a rectangles to compare
			Rectangle ball = new Rectangle(intXBall, intYBall, intWidthBall, intHeightBall);
			Rectangle brick = new Rectangle(mintXBrick, mintYBrick, mintWidthBrick, mintHeightBrick);

            //test of collision
            if (brick.IntersectsWith(ball))
			{


                mblVisible = false;
                mblCollided = true;

                return true;
			}
			else
			{
				return false;
			}
		}
    }
}
