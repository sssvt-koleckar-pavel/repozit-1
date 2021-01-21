using System;
using System.Collections.Generic;
using System.Drawing;

using UtilitiesDraw.PaintersObjects;



namespace UtilitiesDraw.BusinessObjects.HouseBuilding
{



    public class BuildingElement
    {



        public virtual void DrawSelf(Graphics g, CanvasContext context)
        {
            //Pen pen = new Pen(Color.Magenta, 1.0f);
            //g.DrawRectangle(pen, context.Left, context.Top, context.Width, context.Height);
            //Brush brush = new Brush();
            using (Brush brush = new SolidBrush(Color.Magenta))
            {
                g.FillRectangle(brush, context.Left, context.Top, context.Width, context.Height);
            }
        }



        public virtual LayoutType GetLayoutForChildren()
        {
            return LayoutType.Horizontal;
        }



        public virtual CanvasContext GetContextForChildren(CanvasContext context)
        {
            return context;
        }



        public virtual double GetRealWidth()
        {
            //return 0.0;
            return 1.0;
        }



        public virtual double GetRealHeight()
        {
            //return 0.0;
            return 1.0;
        }



        public virtual List<BuildingElement> GetChildren()
        {
            // Return an empty list (default behaviour).
            return new List<BuildingElement>();
        }



    }



}
