using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Forms_Books
{
    public class Book
    {
        private String title;
        private String author;
        private DateTime date;
        private String category;

        public Book(String title, String author, DateTime date, String category)
        {
            this.title = title;
            this.author = author;
            this.date = date;
            this.category = category;

        }

        public String Title
        {
            get { return title; }
        }
        public String Author
        {
            get { return author; }
        }
        public DateTime Date
        {
            get { return date; }
        }
        public String Category
        {
            get { return category; }
        }
    }

    public class BookList : IEnumerable<Book>
    {
        private List<Book> bookList;

        public delegate void BookEventHandler(object sender, EventArgs args);
        public event BookEventHandler RaiseAddEvent;
        public event BookEventHandler RaiseDeleteEvent;
        public event BookEventHandler RaiseEditEvent;

        public IEnumerator<Book> GetEnumerator()
        {
            return bookList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return bookList.GetEnumerator();
        }
    }
}
