using System;

namespace UtilitiesMain.DataClasses
{


    public class Book
    {

        //public string title;
        //public int publishedIn;
        //public Person author;
        //public Publisher publisher;

        private string title;
        private int publishedIn;
        private Person author;
        private Publisher publisher;

        public Book()
        {
        }

        public Book(string title, int publishedIn, Person author, Publisher publisher)
        {
            this.title = title;
            this.publishedIn = publishedIn;
            this.author = author;
            this.publisher = publisher;
        }

        public string Title
        {
            get { return this.title; }
        }
        public int PublishedIn
        {
            get
            {
                return this.publishedIn;
            }
            set
            {
                if (value >= this.publisher.Since)
                {
                    this.publishedIn = value;
                }
                else
                {
                    throw new ArgumentException("The year of publishing cannot be earlier than the year of the publisher's foundation.");
                }
            }
        }
        public Person Author
        {
            get
            {
                return this.author;
            }
        }
        public Publisher Publisher
        {
            get
            {
                return this.publisher;
            }
        }

        //public string GetTitle()
        //{
        //    return this.title;
        //}
        //public int GetPublishedIn()
        //{
        //    return this.publishedIn;
        //}
        ////public void SetPublishedIn(int publishedIn)
        ////{
        ////    this.publishedIn = publishedIn;
        ////}
        //public Person GetAuthor()
        //{
        //    return this.author;
        //}
        //public Publisher GetPublisher()
        //{
        //    return this.publisher;
        //}
    }


}
