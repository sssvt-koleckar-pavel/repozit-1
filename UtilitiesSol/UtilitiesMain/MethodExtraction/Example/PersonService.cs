using System;



namespace UtilitiesMain.MethodExtraction.Example
{



    public class PersonService
    {



        public void MethodToRefactor()
        {

            // Create some objects of type Person.
            Person john = new Person("John", 25);
            Person mary = new Person("Mary", 31);
            Person jane = new Person("Jane", 15);
            Person michael = new Person("Michael", 19);
            Person harry = new Person("Harry", 26);

            // Create an array of 5 persons.
            Person[] persons = { john, mary, jane, michael, harry };

            // Display the persons on the console.
            Console.WriteLine("Input array of persons:");
            foreach (Person person in persons)
            {
                Console.WriteLine($"Name: {person.Name}   Age: {person.Age}");
            }
            Console.WriteLine();

            // Sort the persons by their names.
            for (int i = 1; i < persons.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    // If j-th person shall aphabetically go AFTER (j + 1)-th person.
                    if (persons[j].Name.CompareTo(persons[j + 1].Name) > 0)
                    {
                        // Just swap them.
                        Person p = persons[j];
                        persons[j] = persons[j + 1];
                        persons[j + 1] = p;
                    }
                }
            }

            // Display the persons on the console.
            // This time: They're sorted by name.
            Console.WriteLine("Sorted array of persons:");
            foreach (Person person in persons)
            {
                Console.WriteLine($"Name: {person.Name}   Age: {person.Age}");
            }
            Console.WriteLine();

            // Wait for the user to press a key.
            Console.ReadKey(true);

        }



        public void RefactoredMethod()
        {

            // Create some objects of type Person.
            Person john = new Person("John", 25);
            Person mary = new Person("Mary", 31);
            Person jane = new Person("Jane", 15);
            Person michael = new Person("Michael", 19);
            Person harry = new Person("Harry", 26);

            // Create an array of 5 persons.
            Person[] persons = { john, mary, jane, michael, harry };

            // Display the persons on the console.
            this.DisplayPersons(persons, "Input array of persons:");

            // Sort the persons by their names.
            this.SortPersons(persons);

            // Display the persons on the console.
            // This time: They're sorted by name.
            this.DisplayPersons(persons, "Sorted array of persons:");

            // Wait for the user to press a key.
            Console.ReadKey(true);

        }



        public void SortPersons(Person[] persons)
        {
            for (int i = 1; i < persons.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    // If j-th person shall aphabetically go AFTER (j + 1)-th person.
                    if (persons[j].Name.CompareTo(persons[j + 1].Name) > 0)
                    {
                        // Just swap them.
                        Person p = persons[j];
                        persons[j] = persons[j + 1];
                        persons[j + 1] = p;
                    }
                }
            }
        }



        public void DisplayPersons(Person[] persons, string reportTitle)
        {
            Console.WriteLine(reportTitle);
            foreach (Person person in persons)
            {
                Console.WriteLine($"Name: {person.Name}   Age: {person.Age}");
            }
            Console.WriteLine();
        }



    }



}
