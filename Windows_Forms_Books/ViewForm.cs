using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Forms_Books
{
    public partial class ViewForm : Form
    {
        private BookList books;
        public ViewForm()
        {
            InitializeComponent();
            //add handlers to events from model
        }

        public ViewForm(BookList books)
        {
            InitializeComponent();
            this.books = books;
            this.books.BookAdded += HandleBookAddedEvent;
            this.books.BookRemoved += HandleBookRemovedEvent;
            this.books.BookEdited += HandleBookEditedEvent;
        }

        private ListViewItem FindBookViewItem(Book book)
        {
            foreach(ListViewItem item in listViewForm.Items)
            {
                if((Book)item.Tag == book)
                    return item;
            }
            return null;
        }

        private void AddBookViewItem(Book book)
        {
            ListViewItem item = new ListViewItem
            {
                Tag = book
            };

            item.SubItems[0].Text = book.Title;
            item.SubItems[1].Text = book.Author;
            item.SubItems[2].Text = book.Date.ToShortDateString();
            item.SubItems[3].Text = book.Category;
            listViewForm.Items.Add(item);
        }

        private void HandleBookAddedEvent(object sender, BookEventArgs args)
        {
            Book book = args.Book;
            AddBookViewItem(book);           
        }

        private void HandleBookRemovedEvent(object sender, BookEventArgs args)
        {
            ListViewItem bookViewItem = FindBookViewItem(args.Book);
            if (bookViewItem != null)
            {
                listViewForm.Items.Remove(bookViewItem);
            }
        }

        // TODO: extract common code from HandleBookEditedEvent and AddBookViewItem methods
        private void HandleBookEditedEvent(object sender, BookEventArgs args)
        {
            ListViewItem bookViewItem = FindBookViewItem(args.Book);
            if (bookViewItem != null)
            {
                Book book = (Book)bookViewItem.Tag;
                bookViewItem.SubItems[0].Text = book.Title;
                bookViewItem.SubItems[1].Text = book.Author;
                bookViewItem.SubItems[2].Text = book.Date.ToShortDateString();
                bookViewItem.SubItems[3].Text = book.Category;
            }
        }
    }
}
