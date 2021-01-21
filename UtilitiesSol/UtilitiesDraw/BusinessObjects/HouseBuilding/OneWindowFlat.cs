using System;



namespace UtilitiesDraw.BusinessObjects.HouseBuilding
{



    public class OneWindowFlat : Flat
    {



        private Window window;



        //public OneWindowFlat(Window window)
        //{
        //    this.window = window;
        //}



        public OneWindowFlat(double width, double height, Door door, Window window) : base(width, height, door)
        {
            this.window = window;
        }



        public Window Window
        {
            get
            {
                return window;
            }

            set
            {
                window = value;
            }
        }



    }



}
