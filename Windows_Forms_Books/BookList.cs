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

