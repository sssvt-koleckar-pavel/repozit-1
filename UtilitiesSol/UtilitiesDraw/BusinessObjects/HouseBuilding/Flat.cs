using System;



namespace UtilitiesDraw.BusinessObjects.HouseBuilding
{



    public class Flat : BuildingElement
    {



        private double width;
        private double height;
        private Door door;



        public Flat(double width, double height, Door door)
        {
            this.width = width;
            this.height = height;
            this.door = door;
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

        public Door Door
        {
            get
            {
                return door;
            }

            set
            {
                door = value;
            }
        }



        // Byt: 8,5 m x 3,2 m, jednokřídlé dveře, dvě okna "Standard"
        public static Flat GetSingleDoorTwoStandardWindowFlat()
        {
            Flat flat = new TwoWindowFlat(8.5, 3.2, Door.GetSingleDoor(), Window.GetStandardWindow(), Window.GetStandardWindow());
            return flat;
        }



        // Byt: 12,1 m x 4,5 m, dvoukřídlé dveře, jedno okno "Standard", jedno okno "Francouz"
        public static Flat GetDoubleDoorOneStandardOneFrenchWindowFlat()
        {
            Flat flat = new TwoWindowFlat(12.1, 4.5, Door.GetDoubleDoor(), Window.GetStandardWindow(), Window.GetFrenchWindow());
            return flat;
        }



        // Byt: 10,2 m x 3,2 m, dvoukřídlé dveře, dvě okna "Standard"
        public static Flat GetDoubleDoorTwoStandardWindowFlat()
        {
            Flat flat = new TwoWindowFlat(10.2, 3.2, Door.GetDoubleDoor(), Window.GetStandardWindow(), Window.GetStandardWindow());
            return flat;
        }



        // Byt: 5,5 m x 3,2 m, jednokřídlé dveře, jedno okno "Standard"
        public static Flat GetSingleDoorOneStandardWindowFlat()
        {
            Flat flat = new OneWindowFlat(5.5, 3.2, Door.GetSingleDoor(), Window.GetStandardWindow());
            return flat;
        }



        // Byt: 8,2 m x 3,2 m, jednokřídlé dveře, dvě okna "Francouz"
        public static Flat GetSingleDoorTwoFrenchWindowFlat()
        {
            Flat flat = new TwoWindowFlat(8.2, 3.2, Door.GetSingleDoor(), Window.GetFrenchWindow(), Window.GetFrenchWindow());
            return flat;
        }



    }



}
