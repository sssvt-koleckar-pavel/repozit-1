using System;
using System.Drawing;
using UtilitiesDraw.BusinessObjects;
using UtilitiesDraw.PaintersObjects;

namespace UtilitiesDraw.BusinessObjects.HouseBuilding
{



    public class Door : BuildingElement
    {



        private double width;
        private double height;
        private bool isDoubleWinged;



        public Door(double width, double height, bool isDoubleWinged)
        {
            this.width = width;
            this.height = height;
            this.isDoubleWinged = isDoubleWinged;
        }



        public double Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public bool IsDoubleWinged
        {
            get
            {
                return isDoubleWinged;
            }

            set
            {
                isDoubleWinged = value;
            }
        }



        // Dveře: 0,9 metru x 2,2 metru, jednokřídlé
        public static Door GetSingleDoor()
        {
            Door door = new Door(0.9, 2.2, false);
            return door;
        }



        // Dveře: 1,8 metru x 2,1 metru, dvoukřídlé
        public static Door GetDoubleDoor()
        {
            Door door = new Door(1.8, 2.1, true);
            return door;
        }

        public override void DrawSelf(Graphics g, CanvasContext context)
        {
            using (Pen pen = new Pen(Color.Brown, 5.0f))
            {
                g.DrawRectangle(pen, context.Left + (context.Width / 3),context.Height - 60, (context.Width + context.Height) / 2 / 6, (context.Width + context.Height)/2 / 5 );
                
            }
            using (Pen pen2 = new Pen(Color.Black, 2.0f))
            {
                g.DrawLine(pen2, context.Left + (context.Width / 3) + (context.Width + context.Height) / 2 / 6 - 20, context.Height - 35, context.Left + (context.Width / 3) + (context.Width + context.Height) / 2 / 6, context.Height - 35);
            }
        }



    }



}
