using System;
using System.Collections.Generic;
using System.Drawing;

using UtilitiesDraw.BusinessObjects.HouseBuilding;



namespace UtilitiesDraw.PaintersObjects
{



    public class DrawEngine
    {



        private BuildingElement rootElement;
        private Graphics graphics;
        private CanvasContext rootContext;



        public DrawEngine(BuildingElement rootElement, Graphics graphics, CanvasContext rootContext)
        {
            this.rootElement = rootElement;
            this.graphics = graphics;
            this.rootContext = rootContext;
        }



        public void DrawAllElements()
        {
            DrawElementAndItsChildren(rootElement, rootContext);
        }



        private void DrawElementAndItsChildren(BuildingElement element, CanvasContext context)
        {
            //rootElement.DrawSelf(graphics, context);
            element.DrawSelf(graphics, context);
            //CanvasContext context = GetCanvasForChildren(rootContext);
            //DrawChildren(rootElement, )
            List<BuildingElement> childElements = element.GetChildren();
            // Are there any children at all?
            if (childElements.Count > 0)
            {
                CanvasContext contextForChildren = element.GetContextForChildren(context);
                LayoutType layoutForChildren = element.GetLayoutForChildren();
                double sizeRecalcRatio = GetSizeRecalculationRatio(childElements, contextForChildren, layoutForChildren);
                //int childLeft = contextForChildren.Left;
                //int childTop = contextForChildren.Top;
                //int childLeft = GetChildLeftStart(childElements, sizeRecalcRatio, contextForChildren, layoutForChildren);
                //int childTop = GetChildTopStart(childElements, sizeRecalcRatio, contextForChildren, layoutForChildren);
                int childLeft = GetChildLeftStart(contextForChildren, layoutForChildren);
                int childTop = GetChildTopStart(contextForChildren, layoutForChildren);
                foreach (BuildingElement childElement in childElements)
                {
                    //int childWidth = CalculateWidth(childLeft, childElement.GetRealWidth(), sizeRecalcRatio, contextForChildren, layoutForChildren);
                    //int childHeight = CalculateHeight(childTop, childElement.GetRealHeight(), sizeRecalcRatio, contextForChildren, layoutForChildren);
                    int childWidth = CalculateWidth(childElement.GetRealWidth(), sizeRecalcRatio, contextForChildren, layoutForChildren);
                    int childHeight = CalculateHeight(childElement.GetRealHeight(), sizeRecalcRatio, contextForChildren, layoutForChildren);
                    // ***
                    childLeft -= GetWidthDecrement(childWidth, layoutForChildren);
                    childTop -= GetHeightDecrement(childHeight, layoutForChildren);
                    // ***
                    CanvasContext childContext = GenerateChildContext(childLeft, childTop, childWidth, childHeight);
                    DrawElementAndItsChildren(childElement, childContext);
                    //childLeft += childWidth;
                    //childTop += childHeight;
                    childLeft += GetWidthIncrement(childWidth, layoutForChildren);
                    childTop += GetHeightIncrement(childHeight, layoutForChildren);
                }
            }
        }



        private double GetSizeRecalculationRatio(List<BuildingElement> elements, CanvasContext context, LayoutType layoutType)
        {
            switch (layoutType)
            {
                case LayoutType.Horizontal:
                case LayoutType.HorizontalRightToLeft:
                    double sumOfRealWidths = 0.0;
                    foreach (BuildingElement element in elements)
                    {
                        sumOfRealWidths += element.GetRealWidth();
                    }
                    double contextWidth = context.Width;
                    double widthRatio = contextWidth / sumOfRealWidths;
                    return widthRatio;
                    //break;

                case LayoutType.Vertical:
                case LayoutType.VerticalBottomToTop:
                    double sumOfRealHeights = 0.0;
                    foreach (BuildingElement element in elements)
                    {
                        //sumOfRealHeigths += element.GetRealWidth();
                        sumOfRealHeights += element.GetRealHeight();
                    }
                    double contextHeight = context.Height;
                    double heightRatio = contextHeight / sumOfRealHeights;
                    return heightRatio;
                    //break;

                default:
                    throw new NotSupportedException($"This layout type is not supported here: {layoutType}");
            }
        }



        private int CalculateWidth(double realWidth, double sizeRecalcRatio, CanvasContext totalContext, LayoutType layoutType)
        {
            switch (layoutType)
            {
                case LayoutType.Horizontal:
                case LayoutType.HorizontalRightToLeft:
                    double recalculatedWidth = realWidth * sizeRecalcRatio;
                    return Convert.ToInt32(Math.Truncate(recalculatedWidth));
                    //break;

                case LayoutType.Vertical:
                case LayoutType.VerticalBottomToTop:
                    return totalContext.Width;
                    //break;

                default:
                    throw new NotSupportedException($"This layout type is not supported here: {layoutType}");
            }
        }



        private int CalculateHeight(double realHeight, double sizeRecalcRatio, CanvasContext totalContext, LayoutType layoutType)
        {
            switch (layoutType)
            {
                case LayoutType.Horizontal:
                case LayoutType.HorizontalRightToLeft:
                    return totalContext.Height;
                    //break;

                case LayoutType.Vertical:
                case LayoutType.VerticalBottomToTop:
                    double recalculatedHeight = realHeight * sizeRecalcRatio;
                    return Convert.ToInt32(Math.Truncate(recalculatedHeight));
                    //break;

                default:
                    throw new NotSupportedException($"This layout type is not supported here: {layoutType}");
            }
        }



        //private int GetChildLeftStart(List<BuildingElement> childElements, double sizeRecalcRatio, CanvasContext contextForChildren, LayoutType layoutType)
        //{
        //    switch (layoutType)
        //    {
        //        case LayoutType.Horizontal:
        //            return contextForChildren.Left;

        //        case LayoutType.HorizontalRightToLeft:
        //            BuildingElement firstChild = childElements[0];
        //            int childWidth = CalculateWidth(firstChild.GetRealWidth(), sizeRecalcRatio, contextForChildren, layoutType);
        //            //int childHeight = CalculateHeight(firstChild.GetRealHeight(), sizeRecalcRatio, contextForChildren, layoutType);
        //            return contextForChildren.Left + (contextForChildren.Width - childWidth);

        //        case LayoutType.Vertical:
        //        case LayoutType.VerticalBottomToTop:
        //            return contextForChildren.Left;

        //        default:
        //            throw new NotSupportedException($"This layout type is not supported here: {layoutType}");
        //    }
        //}



        //private int GetChildTopStart(List<BuildingElement> childElements, double sizeRecalcRatio, CanvasContext contextForChildren, LayoutType layoutType)
        //{
        //    switch (layoutType)
        //    {
        //        case LayoutType.Horizontal:
        //        case LayoutType.HorizontalRightToLeft:
        //            return contextForChildren.Top;

        //        case LayoutType.Vertical:
        //            return contextForChildren.Top;

        //        case LayoutType.VerticalBottomToTop:
        //            BuildingElement firstChild = childElements[0];
        //            //int childWidth = CalculateWidth(firstChild.GetRealWidth(), sizeRecalcRatio, contextForChildren, layoutType);
        //            int childHeight = CalculateHeight(firstChild.GetRealHeight(), sizeRecalcRatio, contextForChildren, layoutType);
        //            return contextForChildren.Top + (contextForChildren.Height - childHeight);

        //        default:
        //            throw new NotSupportedException($"This layout type is not supported here: {layoutType}");
        //    }
        //}



        private int GetChildLeftStart(CanvasContext contextForChildren, LayoutType layoutType)
        {
            switch (layoutType)
            {
                case LayoutType.Horizontal:
                    return contextForChildren.Left;

                case LayoutType.HorizontalRightToLeft:
                    return contextForChildren.Left + contextForChildren.Width;

                case LayoutType.Vertical:
                case LayoutType.VerticalBottomToTop:
                    return contextForChildren.Left;

                default:
                    throw new NotSupportedException($"This layout type is not supported here: {layoutType}");
            }
        }



        private int GetChildTopStart(CanvasContext contextForChildren, LayoutType layoutType)
        {
            switch (layoutType)
            {
                case LayoutType.Horizontal:
                case LayoutType.HorizontalRightToLeft:
                    return contextForChildren.Top;

                case LayoutType.Vertical:
                    return contextForChildren.Top;

                case LayoutType.VerticalBottomToTop:
                    return contextForChildren.Top + contextForChildren.Height;

                default:
                    throw new NotSupportedException($"This layout type is not supported here: {layoutType}");
            }
        }



        private int GetWidthIncrement(int childWidth, LayoutType layoutType)
        {
            switch (layoutType)
            {
                case LayoutType.Horizontal:
                    return childWidth;

                case LayoutType.HorizontalRightToLeft:
                    //return (-1) * childWidth;
                    return 0;

                case LayoutType.Vertical:
                case LayoutType.VerticalBottomToTop:
                    return 0;

                default:
                    throw new NotSupportedException($"This layout type is not supported here: {layoutType}");
            }
        }



        private int GetHeightIncrement(int childHeight, LayoutType layoutType)
        {
            switch (layoutType)
            {
                case LayoutType.Horizontal:
                case LayoutType.HorizontalRightToLeft:
                    return 0;

                case LayoutType.Vertical:
                    return childHeight;

                case LayoutType.VerticalBottomToTop:
                    //return (-1) * childHeight;
                    return 0;

                default:
                    throw new NotSupportedException($"This layout type is not supported here: {layoutType}");
            }
        }



        private int GetWidthDecrement(int childWidth, LayoutType layoutType)
        {
            switch (layoutType)
            {
                case LayoutType.Horizontal:
                    return 0;

                case LayoutType.HorizontalRightToLeft:
                    //return (-1) * childWidth;
                    return childWidth;

                case LayoutType.Vertical:
                case LayoutType.VerticalBottomToTop:
                    return 0;

                default:
                    throw new NotSupportedException($"This layout type is not supported here: {layoutType}");
            }
        }



        private int GetHeightDecrement(int childHeight, LayoutType layoutType)
        {
            switch (layoutType)
            {
                case LayoutType.Horizontal:
                case LayoutType.HorizontalRightToLeft:
                    return 0;

                case LayoutType.Vertical:
                    return 0;

                case LayoutType.VerticalBottomToTop:
                    //return (-1) * childHeight;
                    return childHeight;

                default:
                    throw new NotSupportedException($"This layout type is not supported here: {layoutType}");
            }
        }



        private CanvasContext GenerateChildContext(int left, int top, int width, int height)
        {
            //CanvasContext context = new CanvasContext(left, top, width, height);
            CanvasContext context = new CanvasContext(left, top, width - 1, height - 1);
            return context;
        }



    }



}
