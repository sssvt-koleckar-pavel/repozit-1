using System;



namespace UtilitiesDraw.BusinessObjects.HouseBuilding
{



    public class Address
    {



        private string street;
        private string houseNumber;
        private string city;
        private string zipCode;



        public Address(string street, string houseNumber, string city, string zipCode)
        {
            this.street = street;
            this.houseNumber = houseNumber;
            this.city = city;
            this.zipCode = zipCode;
        }



        public string Street
        {
            get
            {
                return street;
            }

            set
            {
                street = value;
            }
        }

        public string HouseNumber
        {
            get
            {
                return houseNumber;
            }

            set
            {
                houseNumber = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public string ZipCode
        {
            get
            {
                return zipCode;
            }

            set
            {
                zipCode = value;
            }
        }



        // Adresa: K Ládví 344, Praha 8, 181 00
        public static Address GetKLadviAddress()
        {
            Address address = new Address("K Ládví", "344", "Praha 8", "181 00");
            return address;
        }



        // Adresa: Vodičkova 699, Praha 1, 110 00
        public static Address GetVodickovaAddress()
        {
            Address address = new Address("Vodičkova", "699", "Praha 1", "110 00");
            return address;
        }



        // Adresa: Sněmovní 176, Praha 1, 118 26
        public static Address GetSnemovniAddress()
        {
            Address address = new Address("Sněmovní", "176", "Praha 1", "118 26");
            return address;
        }



    }



}
