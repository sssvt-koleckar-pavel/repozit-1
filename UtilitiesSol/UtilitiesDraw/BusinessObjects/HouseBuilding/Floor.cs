using System;
using System.Collections.Generic;
using System.Drawing;

using UtilitiesDraw.PaintersObjects;



namespace UtilitiesDraw.BusinessObjects.HouseBuilding
{



    public class Floor : BuildingElement
    {



        private int floorNumber;
        private string description;
        private List<Flat> flats;



        public Floor(int floorNumber, string description)
        {
            this.floorNumber = floorNumber;
            this.description = description;
            this.flats = new List<Flat>();
        }



        public int FloorNumber
        {
            get
            {
                return floorNumber;
            }

            set
            {
                floorNumber = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public List<Flat> Flats
        {
            get
            {
                return flats;
            }

            set
            {
                flats = value;
            }
        }



        public override void DrawSelf(Graphics g, CanvasContext context)
        {
            Rectangle ladderRectangle = GetLadderRectangle(context);
            Rectangle flatsRectangle = GetFlatsRectangle(context);
            // ***
            //using (Pen pen = new Pen(Color.Black, 1.0f))
            using (Pen pen = new Pen(Color.Black, 2.0f))
            {
                DrawLadder(g, pen, ladderRectangle);
                DrawFlatsArea(g, pen, flatsRectangle);
            }
        }



        private void DrawLadder(Graphics g, Pen pen, Rectangle rectangle)
        {
            // Vertical parts.
            int left = rectangle.Left + 5;
            int right = rectangle.Right - 5;
            int bottom = rectangle.Bottom;
            int top = rectangle.Top + 5;
            g.DrawLine(pen, left, top, left, bottom);
            g.DrawLine(pen, left + 2, top, left + 2, bottom);
            g.DrawLine(pen, right, top, right, bottom);
            g.DrawLine(pen, right - 2, top, right - 2, bottom);
            // Rungs.
            using (Brush brush = new SolidBrush(Color.Blue))
            {
                //for (int i = rectangle.Bottom - 10; i < rectangle.Top - 5; i -= 15)
                for (int i = rectangle.Bottom - 25; i > rectangle.Top - 5; i -= 15)
                {
                        //g.DrawLine(pen, rectangle.Left, i, rectangle.Right, i);
                        //g.FillRectangle(brush, rectangle.Left, i, rectangle.Width, i - 10);
                        g.FillRectangle(brush, rectangle.Left, i, rectangle.Width, 10);
                }
            }
        }



        private void DrawFlatsArea(Graphics g, Pen pen, Rectangle rectangle)
        {
            // Display the flats area depending on the ladder position.
            if (this.floorNumber % 2 == 0)
            {
                // The floor number is even.
                g.DrawLine(pen, rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top);
                g.DrawLine(pen, rectangle.Right, rectangle.Top, rectangle.Right, rectangle.Bottom);
                g.DrawLine(pen, rectangle.Right, rectangle.Bottom, rectangle.Left, rectangle.Bottom);
            }
            else
            {
                // The floor number is odd.
                g.DrawLine(pen, rectangle.Right, rectangle.Top, rectangle.Left, rectangle.Top);
                g.DrawLine(pen, rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Bottom);
                g.DrawLine(pen, rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Bottom);
            }
        }



        private int GetLadderWidth()
        {
            int ladderWidth = 100;
            return ladderWidth;
        }



        private int GetFlatsWidth(CanvasContext context)
        {
            int flatsWidth = context.Width - GetLadderWidth();
            return flatsWidth;
        }



        private Rectangle GetLadderRectangle(CanvasContext context)
        {
            int ladderWidth = GetLadderWidth();
            // The ladder shall display:
            // On the left for even-numbered floors.
            // On the right for odd-numbered floors.
            Rectangle ladderRectangle;
            if (this.floorNumber % 2 == 0)
            {
                // The floor number is even.
                ladderRectangle = new Rectangle(context.Left, context.Top, ladderWidth, context.Height);
            }
            else
            {
                // The floor number is odd.
                ladderRectangle = new Rectangle(context.Left + context.Width - ladderWidth, context.Top, ladderWidth, context.Height);
            }
            return ladderRectangle;
        }



        private Rectangle GetFlatsRectangle(CanvasContext context)
        {
            int ladderWidth = GetLadderWidth();
            int flatsWidth = GetFlatsWidth(context);
            // The ladder shall display:
            // On the left for even-numbered floors.
            // On the right for odd-numbered floors.
            Rectangle flatsRectangle;
            if (this.floorNumber % 2 == 0)
            {
                // The floor number is even.
                flatsRectangle = new Rectangle(context.Left + ladderWidth, context.Top, flatsWidth, context.Height);
            }
            else
            {
                // The floor number is odd.
                flatsRectangle = new Rectangle(context.Left, context.Top, flatsWidth, context.Height);
            }
            return flatsRectangle;
        }



        public override LayoutType GetLayoutForChildren()
        {
            return LayoutType.Horizontal;
        }



        public override CanvasContext GetContextForChildren(CanvasContext context)
        {
            Rectangle flatsRectangle = GetFlatsRectangle(context);
            CanvasContext contextForChildren = new CanvasContext(flatsRectangle);
            // Make the space for children a little bit smaller.
            contextForChildren.Left += 5;
            contextForChildren.Top += 5;
            contextForChildren.Width -= 10;
            contextForChildren.Height -= 10;
            return contextForChildren;
        }



        public override double GetRealWidth()
        {
            return 20.0;
        }



        public override double GetRealHeight()
        {
            double maxFlatHeight = 0.0;
            this.flats.ForEach(flat => { if (flat.Height > maxFlatHeight) { maxFlatHeight = flat.Height; } });
            double realHeight = Math.Ceiling(maxFlatHeight);
            return realHeight;
        }



        public override List<BuildingElement> GetChildren()
        {
            List<BuildingElement> children = new List<BuildingElement>();
            foreach (Flat flat in this.flats)
            {
                BuildingElement child = flat;
                children.Add(child);
            }
            return children;
        }



        // 0. patro (přízemí)
        // Byt: 10,2 m x 3,2 m, dvoukřídlé dveře, dvě okna "Standard"
        // Byt: 5,5 m x 3,2 m, jednokřídlé dveře, jedno okno "Standard"
        public static Floor GetGroundFloor()
        {
            Floor floor = new Floor(0, "přízemí");
            floor.Flats.Add(Flat.GetDoubleDoorTwoStandardWindowFlat());
            floor.Flats.Add(Flat.GetSingleDoorOneStandardWindowFlat());
            return floor;
        }



        // 1. patro (byt s francouzskými okny má balkon)
        // Byt: 8,2 m x 3,2 m, jednokřídlé dveře, dvě okna "Francouz"
        // Byt: 8,5 m x 3,2 m, jednokřídlé dveře, dvě okna "Standard"
        public static Floor GetFirstFloor()
        {
            Floor floor = new Floor(1, "byt s francouzskými okny má balkon");
            floor.Flats.Add(Flat.GetSingleDoorTwoFrenchWindowFlat());
            floor.Flats.Add(Flat.GetSingleDoorTwoStandardWindowFlat());
            return floor;
        }



        // 2. patro (s luxusním bytem a verandou)
        // Byt: 12,1 m x 4,5 m, dvoukřídlé dveře, jedno okno "Standard", jedno okno "Francouz"
        public static Floor GetSecondFloor()
        {
            Floor floor = new Floor(2, "s luxusním bytem a verandou");
            floor.Flats.Add(Flat.GetDoubleDoorOneStandardOneFrenchWindowFlat());
            return floor;
        }



    }



}
