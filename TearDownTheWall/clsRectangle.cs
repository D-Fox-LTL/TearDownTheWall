// ####################################################################################################################################
//
// Class of ball
// Created: 26.4.2023
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
using System.Windows.Forms;

namespace TearDownTheWall
{
    internal class clsRectangle
    {
		Graphics mobjGraphics;
        //Rectangle
        public int mintXRectangle, mintYRectangle;
        const int mintWidthOfRectangle = 120;
        const int mintHeightOfRectangle = 20;

        public clsRectangle(Graphics objCanvas)
        {
            mobjGraphics = objCanvas;
            mintXRectangle = (int)objCanvas.VisibleClipBounds.Width / 2;
            mintYRectangle = (int)objCanvas.VisibleClipBounds.Height - 100;
        }

        public void drawRectangle()
        {
            mobjGraphics.FillRectangle(Brushes.Black, mintXRectangle, mintYRectangle, mintWidthOfRectangle, mintHeightOfRectangle);
        }
	}
}
