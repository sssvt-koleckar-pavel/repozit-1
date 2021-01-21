using System;
using System.Text;
using System.Collections.Generic;

//using UtilitiesMain.MethodExtraction.Example;
//using UtilitiesMain.MethodExtraction.Exercise;
using UtilitiesMain.DataClasses;

namespace UtilitiesMain
{
    class Program
    {
        static void Main(string[] args)
        {


            //// The code provided will print ‘Hello World’ to the console.
            //// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            ////Console.WriteLine("Hello World!");
            ////Console.ReadKey();

            //// Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 


            //// Try the "method extraction" example.
            //PersonService personService = new PersonService();
            //personService.MethodToRefactor();
            //Console.WriteLine();
            //Console.WriteLine();
            //personService.RefactoredMethod();

            //// Merge files.
            //string pathToFileA = @"C:\pfoltyn\MyProjects\Utilities\20201012_hodina\UtilitiesSol\Resources\InputFileA.txt";
            //string pathToFileB = @"C:\pfoltyn\MyProjects\Utilities\20201012_hodina\UtilitiesSol\Resources\InputFileB.txt";
            //string pathToFileC = @"C:\pfoltyn\MyProjects\Utilities\20201012_hodina\UtilitiesSol\Resources\InputFileC.txt";
            //string pathToFileD = @"C:\pfoltyn\MyProjects\Utilities\20201012_hodina\UtilitiesSol\Resources\InputFileD.txt";
            //FileService fileService = new FileService();
            //fileService.MergeFiles(pathToFileA, pathToFileB, pathToFileC, pathToFileD);


            //ShowDataClasses();

            //ShowVariablesAndProperties();

            // Ahoj Olgo!

            //string sentence = "Není kouře bez ohýnku.";
            ////Console.WriteLine(sentence.Length);
            //char first = sentence[0];
            //char fourth = sentence[3];
            //char tenth = sentence[9];
            //string firstAndTenth = first.ToString() + tenth.ToString();
            //Console.WriteLine(firstAndTenth);
            //Console.WriteLine(fourth);

            //string s = "Dlužíte nám 100 Kč";
            //s = s.Replace("100", "1000");
            //Console.WriteLine(s);
            //string u = s.Substring(8, 3);
            //Console.WriteLine(u);


            //StringBuilder sentence = new StringBuilder("Není kouře bez ohýnku.");
            //sentence.Append(" Kuk!");
            //Console.WriteLine(sentence.Length);
            //Console.WriteLine(sentence.Capacity);

            ////string personName = "John";
            //StringBuilder personName = new StringBuilder("John");
            //Person john = new Person(personName, 35);
            //Person mary = new Person(personName, 22);
            ////mary.firstName = mary.firstName.Replace("John", "Mary");
            //mary.firstName.Replace("John", "Mary");
            //Console.WriteLine($"Jméno: {john.firstName}  Věk: {john.age}");
            //Console.WriteLine($"Jméno: {mary.firstName}  Věk: {mary.age}");

            //EncryptMessage();

            //TestGenericList();

            ShowVariablesAndProperties();

        }

        //public class Person
        //{
        //    //public string firstName;
        //    public StringBuilder firstName;
        //    public int age;

        //    //public Person(string firstName, int age)
        //    public Person(StringBuilder firstName, int age)
        //    {
        //        this.firstName = firstName;
        //        this.age = age;
        //    }
        //}


        static void ShowVariablesAndProperties()
        {

            // Persons
            Person milada = new Person("Milada", "Horáková", new DateTime(1901, 12, 25), true);
            //Console.WriteLine($"Jméno: {milada.firstName}, Příjmení: {milada.lastName}, Datum narození: {milada.dateOfBirth.ToString("d.MM.yyyy")}, Občan ČR: {milada.isCitizenCZ}");
            //Console.WriteLine($"Jméno: {milada.GetFirstName()}, Příjmení: {milada.GetLastName()}, Datum narození: {milada.GetDateOfBirth().ToString("d.MM.yyyy")}, Občan ČR: {milada.GetIsCitizenCZ()}");
            Console.WriteLine($"Jméno: {milada.FirstName}, Příjmení: {milada.LastName}, Datum narození: {milada.DateOfBirth.ToString("d.MM.yyyy")}, Občan ČR: {milada.IsCitizenCZ}");
            Console.WriteLine();

            //milada.firstName = "Horáková";
            ////milada.SetFirstName("Horáková");
            //milada.lastName = "Milada";
            //Console.WriteLine($"Jméno: {milada.firstName}, Příjmení: {milada.lastName}, Datum narození: {milada.dateOfBirth.ToString("d.MM.yyyy")}, Občan ČR: {milada.isCitizenCZ}");
            //Console.WriteLine();
            //Console.WriteLine();


            // Books
            Person stendhal = new Person("Marie-Henri", "Beyle", new DateTime(1783, 1, 23), false);
            Publisher odeon = new Publisher("Odeon", 1966, 49709895);
            Book kartouza = new Book("Kartouza parmská", 1974, stendhal, odeon);
            DisplayBook(kartouza);
            Console.WriteLine();
            Console.WriteLine();

            //kartouza.publishedIn = 1927;
            //kartouza.SetPublishedIn(1927);
            //kartouza.PublishedIn = 1970;
            kartouza.PublishedIn = 1927;
            DisplayBook(kartouza);
            Console.WriteLine();
            Console.WriteLine();

            // e-Bookshop
            Person padevet = new Person("Jiří", "Padevět", new DateTime(1966, 7, 20), true);
            Person tesson = new Person("Sylvain", "Tesson", new DateTime(1972, 4, 26), false);
            Publisher academia = new Publisher("Academia", 1953, 60457856);
            Publisher garamond = new Publisher("Garamond", 1997, 25126202);
            Book pruvodce = new Book("Průvodce protektorátní Prahou", 2013, padevet, academia);
            Book levhart = new Book("Sněžný levhart", 2020, tesson, garamond);

            EBookshop moje = new EBookshop("https://www.mojeskveleknihy.cz");
            //moje.books.Add(pruvodce);
            //moje.books.Add(levhart);
            //moje.GetBooks().Add(pruvodce);
            //moje.GetBooks().Add(levhart);
            moje.Books.Add(pruvodce);
            moje.Books.Add(levhart);
            DisplayEBookshop(moje);
            Console.WriteLine();
            Console.WriteLine();

            //moje.books = null;
            // ....
            //moje.books = new List<Book>();
            // Následující řádek způsobí vyhození výjimky NullRefenceException
            //moje.books.Add(kartouza);
            //moje.GetBooks().Add(kartouza);
            moje.Books.Add(kartouza);


            Console.ReadKey(true);
        }

        //static void ShowDataClasses()
        //{

        //    // Persons
        //    Person pavel = new Person("Pavel", "Novák", new DateTime(1992, 9, 26), true);
        //    Person jana = new Person("Jana", "Výborná", new DateTime(1987, 2, 4), false);
        //    Console.WriteLine($"Jméno: {pavel.firstName}, Příjmení: {pavel.lastName}, Datum narození: {pavel.dateOfBirth}, Občan ČR: {pavel.isCitizenCZ}");
        //    Console.WriteLine($"Jméno: {jana.firstName}, Příjmení: {jana.lastName}, Datum narození: {jana.dateOfBirth}, Občan ČR: {jana.isCitizenCZ}");

        //    // Publishers
        //    //Albatros, založeno 1949, IČO: 28377141
        //    //Academia, založeno 1953, IČO: 60457856
        //    //Garamond, založeno 1997, IČO: 25126202

        //    Publisher albatros = new Publisher("Albatros", 1949, 28377141);
        //    Publisher academia = new Publisher("Academia", 1953, 60457856);
        //    Publisher garamond = new Publisher("Garamond", 1997, 25126202);

        //    Console.WriteLine($"Název: {albatros.name}  Založeno: {albatros.since}  IČO: {albatros.ico}  ");
        //    Console.WriteLine($"Název: {academia.name}  Založeno: {academia.since}  IČO: {academia.ico}  ");
        //    Console.WriteLine($"Název: {garamond.name}  Založeno: {garamond.since}  IČO: {garamond.ico}  ");



        //    Console.WriteLine();
        //    Console.WriteLine();

        //    // Books
        //    //Jiří Padevět, nar. 20. července 1966, občan ČR
        //    Person padevet = new Person("Jiří", "Padevět", new DateTime(1966, 7, 20), true);
        //    //Sylvain Tesson, nar. 26. dubna 1972, není občan ČR
        //    Person tesson = new Person("Sylvain", "Tesson", new DateTime(1972, 4, 26), false);
        //    Person rowlingova = new Person("J. K.", "Rowlingová", new DateTime(1965, 7, 31), false);
        //    Person macourek = new Person("Miloš", "Macourek", new DateTime(1926, 12, 2), true);


        //    //Průvodce protektorátní Prahou, 2013, (Jiří Padevět, nar. 20.července 1966, občan ČR), (Academia, zal. 1953, IČO: 60457856) 
        //    Book pruvodce = new Book();
        //    pruvodce.title = "Průvodce protektorátní Prahou";
        //    pruvodce.publishedIn = 2013;
        //    pruvodce.author = padevet;
        //    pruvodce.publisher = academia;

        //    //Sněžný levhart, 2020, (Sylvain Tesson, nar. 26.dubna 1972, není občan ČR), (Garamond, zal. 1997, IČO: 25126202)
        //    Book levhart = new Book();
        //    levhart.title = "Sněžný levhart";
        //    levhart.publishedIn = 2020;
        //    levhart.author = tesson;
        //    levhart.publisher = garamond;

        //    //Ikabog, 2020, (J. K. Rowlingová, nar. 31. července 1965, není občankou ČR), (Albatros, zal. 1949, IČO: 28377141)
        //    Book ikabog = new Book();
        //    ikabog.title = "Ikabog";
        //    ikabog.publishedIn = 2020;
        //    ikabog.author = rowlingova;
        //    ikabog.publisher = albatros;

        //    //Mach a Šebestová v historii, 2009, (Miloš Macourek, nar. 2. prosince 1926, občan ČR), (Albatros, zal. 1949, IČO: 28377141)
        //    Book machASebestova = new Book();
        //    machASebestova.title = "Mach a Šebestová v historii";
        //    machASebestova.publishedIn = 2009;
        //    machASebestova.author = macourek;
        //    machASebestova.publisher = albatros;

        //    DisplayBook(pruvodce);
        //    //Console.WriteLine();
        //    DisplayBook(levhart);
        //    //Console.WriteLine();
        //    DisplayBook(ikabog);
        //    //Console.WriteLine();
        //    DisplayBook(machASebestova);


        //    Console.WriteLine();
        //    Console.WriteLine();


        //    // EBookshop
        //    EBookshop eBookshop = new EBookshop("https://www.mojeskveleknihy.cz");
        //    eBookshop.books.Add(pruvodce);
        //    eBookshop.books.Add(levhart);
        //    eBookshop.books.Add(ikabog);
        //    eBookshop.books.Add(machASebestova);

        //    DisplayEBookshop(eBookshop);

        //    Console.ReadKey(true);
        //}


        static void DisplayBook(Book book)
        {
            //Console.Write($"Název: {book.title}   ");
            //Console.WriteLine($"Vydáno: {book.publishedIn}   ");
            //Console.WriteLine("Autor:");
            //Console.WriteLine($"Jméno: {book.author.firstName}, Příjmení: {book.author.lastName}, Datum narození: {book.author.dateOfBirth.ToString("d.M.yyyy")}, Občan ČR: {book.author.isCitizenCZ}");
            //Console.WriteLine("Nakladatelství:");
            //Console.WriteLine($"Název: {book.publisher.name}  Založeno: {book.publisher.since}  IČO: {book.publisher.ico}  ");

            //Console.Write($"Název: {book.GetTitle()}   ");
            //Console.WriteLine($"Vydáno: {book.GetPublishedIn()}   ");
            //Console.WriteLine("Autor:");
            //Console.WriteLine($"Jméno: {book.GetAuthor().GetFirstName()}, Příjmení: {book.GetAuthor().GetLastName()}, Datum narození: {book.GetAuthor().GetDateOfBirth().ToString("d.M.yyyy")}, Občan ČR: {book.GetAuthor().GetIsCitizenCZ()}");
            //Console.WriteLine("Nakladatelství:");
            //Console.WriteLine($"Název: {book.GetPublisher().GetName()}  Založeno: {book.GetPublisher().GetSince()}  IČO: {book.GetPublisher().GetIco()}  ");

            Console.Write($"Název: {book.Title}   ");
            Console.WriteLine($"Vydáno: {book.PublishedIn}   ");
            Console.WriteLine("Autor:");
            Console.WriteLine($"Jméno: {book.Author.FirstName}, Příjmení: {book.Author.LastName}, Datum narození: {book.Author.DateOfBirth.ToString("d.M.yyyy")}, Občan ČR: {book.Author.IsCitizenCZ}");
            Console.WriteLine("Nakladatelství:");
            Console.WriteLine($"Název: {book.Publisher.Name}  Založeno: {book.Publisher.Since}  IČO: {book.Publisher.Ico}  ");

            Console.WriteLine();
        }


        static void DisplayEBookshop(EBookshop eBookshop)
        {
            //Console.WriteLine();
            //Console.WriteLine(eBookshop.url);
            //Console.WriteLine();
            //Console.WriteLine("Knihy, které nabízíme:");
            //Console.WriteLine();

            //for (int i = 0; i < eBookshop.books.Count; i++)
            //{
            //    DisplayBook(eBookshop.books[i]);
            //}

            //Console.WriteLine();
            //Console.WriteLine(eBookshop.GetUrl());
            //Console.WriteLine();
            //Console.WriteLine("Knihy, které nabízíme:");
            //Console.WriteLine();

            //for (int i = 0; i < eBookshop.GetBooks().Count; i++)
            //{
            //    DisplayBook(eBookshop.GetBooks()[i]);
            //}

            Console.WriteLine();
            Console.WriteLine(eBookshop.Url);
            Console.WriteLine();
            Console.WriteLine("Knihy, které nabízíme:");
            Console.WriteLine();

            for (int i = 0; i < eBookshop.Books.Count; i++)
            {
                DisplayBook(eBookshop.Books[i]);
            }

            Console.WriteLine();
        }


        static void EncryptMessage()
        {
            //string input = "Mami, co bude dnes k obědu? Budou bramborové knedlíky, zelí a pečená krůta?";
            string input = "Mami, co bude dnes k obedu? Budou bramborove knedliky, zeli a pecena kruta?";
            Console.WriteLine(input);

            string output = input.ToUpper();
            Console.WriteLine(output);

            string outputTmp = output;
            for (int i = 0; i < output.Length; i++)
            {
                char c = output[i];
                if ('A' <= c && c < 'Z')
                {
                    int ci = (int)c;
                    int di = ci + 1;
                    char d = (char)di;
                    //output[i] = d;
                    // AHOJ MAMI
                    // BIPK MAMI
                    outputTmp = outputTmp.Substring(0, i) + d.ToString() + outputTmp.Substring(i + 1);
                }
                else if (c == 'Z')
                {
                    outputTmp = outputTmp.Substring(0, i) + "A" + outputTmp.Substring(i + 1);
                }
            }
            output = outputTmp;

            Console.WriteLine(output);
        }

        static void TestGenericList()
        {
            List<int> inputList = new List<int>();
            inputList.Add(10);
            inputList.Add(3);
            inputList.Add(-10);
            inputList.Add(8);
            inputList.Add(27);
            inputList.Add(9);
            inputList.Add(8);
            inputList.Add(7);
            inputList.Add(4);
            inputList.Add(5);
            inputList.Add(-2);
            inputList.Add(12);
            inputList.Add(2);
            inputList.Add(4);
            inputList.Add(-7);
            inputList.Add(0);
            inputList.Add(1);
            inputList.Add(2);
            for (int i = 0; i < inputList.Count; i++)
            {
                Console.WriteLine(inputList[i]);
            }

            Console.WriteLine();
            Console.WriteLine();

            //List<int> inputList = new List<int>();
            inputList = new List<int>();
            inputList.Add(10);
            inputList.Add(-2);
            inputList.Add(12);
            inputList.Add(3);
            inputList.Add(4);
            inputList.Add(3);
            inputList.Add(10);
            inputList.Add(9);
            inputList.Add(8);
            inputList.Add(7);
            inputList.Add(4);
            inputList.Add(2);
            inputList.Add(0);
            inputList.Add(0);
            inputList.Add(5);
            inputList.Add(27);
            inputList.Add(1);
            inputList.Add(2);
            for (int i = 0; i < inputList.Count; i++)
            {
                Console.WriteLine(inputList[i]);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.ReadKey(true);
        }


    }
}
