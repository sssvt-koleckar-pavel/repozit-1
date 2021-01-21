using System;



namespace UtilitiesDraw.BusinessObjects.HouseBuilding
{



    public class TwoWindowFlat : Flat
    {



        private Window leftWindow;
        private Window rightWindow;



        //public TwoWindowFlat(Window leftWindow, Window rightWindow)
        //{
        //    this.leftWindow = leftWindow;
        //    this.rightWindow = rightWindow;
        //}



        public TwoWindowFlat(double width, double height, Door door, Window leftWindow, Window rightWindow) : base(width, height, door)
        {
            this.leftWindow = leftWindow;
            this.rightWindow = rightWindow;
        }



        public Window LeftWindow
        {
            get
            {
                return leftWindow;
            }

            set
            {
                leftWindow = value;
            }
        }

        public Window RightWindow
        {
            get
            {
                return rightWindow;
            }

            set
            {
                rightWindow = value;
            }
        }



    }



}
