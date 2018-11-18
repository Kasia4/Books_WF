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

        public ViewForm(BookList books)
        {
            
            this.books = books;
            this.books.BookAdded += HandleBookAddedEvent;
            this.books.BookRemoved += HandleBookRemovedEvent;
            this.books.BookEdited += HandleBookEditedEvent;
            InitializeComponent();
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
            ListViewItem bookViewItem = new ListViewItem
            {
                Tag = book
            };

            while (bookViewItem.SubItems.Count < 4)
                bookViewItem.SubItems.Add(new ListViewItem.ListViewSubItem());

            bookViewItem.SubItems[0].Text = book.Title;
            bookViewItem.SubItems[1].Text = book.Author;
            bookViewItem.SubItems[2].Text = book.Category;
            bookViewItem.SubItems[3].Text = book.Date.ToShortDateString();
            listViewForm.Items.Add(bookViewItem);
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
                bookViewItem.SubItems[2].Text = book.Category;
                bookViewItem.SubItems[3].Text = book.Date.ToShortDateString();
            }
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            foreach(Book book in books)
            {
                AddBookViewItem(book);
            }
        }

    }
}
