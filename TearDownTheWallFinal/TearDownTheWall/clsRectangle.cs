// ####################################################################################################################################
//
// Class of ball
// Created: 26.4.2023
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
using System.Windows.Forms;

namespace TearDownTheWall
{
    internal class clsRectangle
    {
		Graphics mobjGraphics;

        //Rectangle
        int mintXRectangle;
        int mintYRectangle;
        const int mintWidthOfRectangle = 90;
        const int mintHeightOfRectangle = 10;


        //----------------------------|
        //        Constructor         |
        //----------------------------|

        public clsRectangle(Graphics objCanvas)
        {
            mobjGraphics = objCanvas;
            mintYRectangle = (int)objCanvas.VisibleClipBounds.Height - 20;
        }

        //---------------------------------|
        //  load of rectangle coordinates  |
        //---------------------------------|

        public int intXRectangle
        {
            get { return mintXRectangle; }
            set { mintXRectangle = value; }
        }   public int intWidthOfRectangle
        {
            get { return mintWidthOfRectangle; }
        }   public int intHeightOfRectangle
        {
            get { return mintHeightOfRectangle; }
        }   public int intYRectangle
        {
            get { return mintYRectangle; }
        }



        //--------------------------|
        //      Draw rectangle      |
        //--------------------------|


        public void drawRectangle()
        {
            mobjGraphics.FillRectangle(Brushes.Black, mintXRectangle, mintYRectangle, mintWidthOfRectangle, mintHeightOfRectangle);

            //Collision on borders of pbCanvas
            if (mintXRectangle + mintWidthOfRectangle >= (int)mobjGraphics.VisibleClipBounds.Width)
            {
                mintXRectangle = (int)mobjGraphics.VisibleClipBounds.Width - 5 - mintWidthOfRectangle;
            }
            else if (mintXRectangle <= 0)
            {
               mintXRectangle = 5;
            }
        }

        public void setRectangle()
        {
            mintXRectangle = (int)mobjGraphics.VisibleClipBounds.Width / 2 - (intWidthOfRectangle / 2);
        }

        public void moveRectangle(bool blLeft, bool blRight)
        {
            if (blLeft == true)
            {
                intXRectangle -= 10;
            }
            else if (blRight == true)
            {
                intXRectangle += 10;
            }
        }
    }
}
