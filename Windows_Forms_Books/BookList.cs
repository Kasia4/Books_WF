using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Forms_Books
{
    public class BookList : IEnumerable<Book>
    {
        private List<Book> bookList;

        public delegate void BookEventHandler(object sender, EventArgs args);
        public event BookEventHandler BookAdded;
        public event BookEventHandler BookRemoved;
        public event BookEventHandler BookEdited;

        public IEnumerator<Book> GetEnumerator()
        {
            return bookList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return bookList.GetEnumerator();
        }

        //TODO: make generic function for all events
        protected virtual void OnBookAdded(Book b)
        {
            BookEventHandler handler = BookAdded;
            if (handler != null)
            {
                handler(this, new BookEventArgs(b));
            }
        }

        protected virtual void OnBookRemoved(Book b)
        {
            BookEventHandler handler = BookRemoved;
            if (handler != null)
            {
                handler(this, new BookEventArgs(b));
            }
        }

        protected virtual void OnBookEdited(Book b)
        {
            BookEventHandler handler = BookEdited;
            if (handler != null)
            {
                handler(this, new BookEventArgs(b));
            }
        }
    }

    public class BookEventArgs : EventArgs
    {
        private Book book;
        public BookEventArgs(Book book)
        {
            this.book = book;
        }
        public Book Book
        {
            get
            {
                return this.book;
            }
        }
    }
}

