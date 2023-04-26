﻿// ####################################################################################################################################
//
// Class of bricks
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
    class clsBrick
    {
		//Variables

		//Graphics
		Graphics mobjGraphics;

		// Ball variables
		int mintXBrick, mintYBrick;
		int mintWidthBrick, mintHeightBrick;

		//----------------------------
		//Constructor
		//----------------------------
		public clsBrick(Graphics objCanvas, int intXBrick, int intYBrick, int intWidthBrick, int intHeightBrick)
		{
			mobjGraphics = objCanvas;

			mintXBrick = intXBrick;
			mintYBrick = intYBrick;
			mintHeightBrick = intHeightBrick;
			mintWidthBrick = intWidthBrick;

			mintXBrick = (int)objCanvas.ClipBounds.Width / 2;
			mintYBrick = (int)objCanvas.ClipBounds.Height / 2;


		}
		//----------------------------
		// Drawing of Bricks
		//----------------------------
		public void DrawBrick()
		{
			mobjGraphics.FillRectangle(Brushes.Orange, mintXBrick, mintYBrick, mintWidthBrick, mintHeightBrick);
		}
	}
}
