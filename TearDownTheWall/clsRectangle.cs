// ####################################################################################################################################
//
// Class of ball
// Created: 26.4.2023
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
using System.Windows.Forms;

namespace TearDownTheWall
{
    internal class clsRectangle
    {
		Graphics mobjGraphics;
		//Rectangle
		public int mintXRectangle, mintYRectangle;




		public void rectangleSetToPlace(Graphics objCanvas)
		{
			mobjGraphics = objCanvas;
			mintXRectangle = (int)mobjGraphics.VisibleClipBounds.Width / 2;
			mintYRectangle = (int)mobjGraphics.VisibleClipBounds.Height - 100;
		}
	}
}
