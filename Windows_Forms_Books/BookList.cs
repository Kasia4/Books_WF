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

        public delegate void BookEventHandler(object sender, BookEventArgs args);
        public event BookEventHandler BookAdded;
        public event BookEventHandler BookRemoved;
        public event BookEventHandler BookEdited;

        public BookList()
        {
            bookList = new List<Book>();
            Add("The Moonstone", "Wilkie Collins", new DateTime(1868, 1, 1), "crime");
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return bookList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return bookList.GetEnumerator();
        }

        public Book this[int i]
        {
            get
            {
                return bookList[i];
            }
        }

        public void Add(String title, String author, DateTime date, String category)
        {
            Book book = new Book(title, author, date, category);
            bookList.Add(book);
            OnBookAdded(book);
        }

        public void Remove(Book book)
        {
            bookList.Remove(book);
            OnBookRemoved(book);
        }

        public void Edit(Book book)
        {
            OnBookEdited(book);
        }

        //TODO: make generic method for all events
        protected virtual void OnBookAdded(Book b)
        {
            BookAdded?.Invoke(this, new BookEventArgs(b));
        }

        protected virtual void OnBookRemoved(Book b)
        {
            BookRemoved?.Invoke(this, new BookEventArgs(b));
        }

        protected virtual void OnBookEdited(Book b)
        {
            BookEdited?.Invoke(this, new BookEventArgs(b));
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

