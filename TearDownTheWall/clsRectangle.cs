// ####################################################################################################################################
//
// Class of ball
// Created: 26.4.2023
// Updated: 3.5.2023
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
        int mintXRectangle, mintYRectangle;
        const int mintWidthOfRectangle = 120;
        const int mintHeightOfRectangle = 20;

        public clsRectangle(Graphics objCanvas)
        {
            mobjGraphics = objCanvas;
            mintXRectangle = ((int)objCanvas.VisibleClipBounds.Width / 2) + (mintWidthOfRectangle/2);
            mintYRectangle = (int)objCanvas.VisibleClipBounds.Height - 100;
        }

        public int intXRectangle
        {
            get { return mintXRectangle; }
            set { mintXRectangle = value; }
        }


        public void drawRectangle()
        {
            mobjGraphics.FillRectangle(Brushes.Black, mintXRectangle, mintYRectangle, mintWidthOfRectangle, mintHeightOfRectangle);

            //Collision on borders of pbCanvas
            if (mintXRectangle + 120 >= (int)mobjGraphics.VisibleClipBounds.Height)
            {
                mintXRectangle = mintWidthOfRectangle - 5;
            }
            else if (mintXRectangle <= 0)
            {
               mintXRectangle = 5;
            }
        }
	}
}
