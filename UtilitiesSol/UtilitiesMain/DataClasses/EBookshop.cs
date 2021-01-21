using System;
using System.Collections.Generic;



namespace UtilitiesMain.DataClasses
{
    public class EBookshop
    {

        //List<T>

        //public string url;
        ////public Book[] books;
        //public List<Book> books;

        private string url;
        private List<Book> books;

        public EBookshop(string url)
        {
            this.url = url;
            this.books = new List<Book>();
        }

        public string Url
        {
            get { return this.url; }
        }
        public List<Book> Books
        {
            get { return this.books; }
        }

        //public string GetUrl()
        //{
        //    return this.url;
        //}
        //public List<Book> GetBooks()
        //{
        //    return this.books;
        //}

    }
}
