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

        private delegate bool Filter(Book book);
        private Filter _filter;
        private Filter filter
        {
            get
            {
                return this._filter;
            }
            set
            {
                this._filter = value;
                this.listViewForm.Items.Clear();
                foreach (Book book in books)
                {
                    if (filter(book))
                    {
                        AddBookViewItem(book);
                    }
                }
                this.CountLabel.Text = this.listViewForm.Items.Count.ToString();
            }
        }
        private bool EmptyFilter(Book book)
        {
            return true;
        }
        private bool IsBefore2000(Book book)
        {
            return (book.Date.Year < 2000);
        }
        private bool IsAfter2000(Book book)
        {
            return (book.Date.Year >= 2000);
        }

        public ViewForm(BookList books)
        {
            InitializeComponent();
            this.books = books;
            this.books.BookAdded += HandleBookAddedEvent;
            this.books.BookRemoved += HandleBookRemovedEvent;
            this.books.BookEdited += HandleBookEditedEvent;
            this.filter = EmptyFilter;
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
            this.CountLabel.Text = this.listViewForm.Items.Count.ToString();
        }

        private void HandleBookAddedEvent(object sender, BookEventArgs args)
        {
            Book book = args.Book;
            if(filter(book))
                AddBookViewItem(book);           
        }

        private void HandleBookRemovedEvent(object sender, BookEventArgs args)
        {
            ListViewItem bookViewItem = FindBookViewItem(args.Book);
            if (bookViewItem != null)
            {
                listViewForm.Items.Remove(bookViewItem);
                this.CountLabel.Text = this.listViewForm.Items.Count.ToString();
            }
        }

        // TODO: extract common code from HandleBookEditedEvent and AddBookViewItem methods
        private void HandleBookEditedEvent(object sender, BookEventArgs args)
        {
            Book book = args.Book;
            ListViewItem bookViewItem = FindBookViewItem(args.Book);
            if (bookViewItem != null)
            {
                if (filter(book))
                {
                    bookViewItem.SubItems[0].Text = book.Title;
                    bookViewItem.SubItems[1].Text = book.Author;
                    bookViewItem.SubItems[2].Text = book.Category;
                    bookViewItem.SubItems[3].Text = book.Date.ToShortDateString();
                }
                else
                {
                    listViewForm.Items.Remove(bookViewItem);
                    this.CountLabel.Text = this.listViewForm.Items.Count.ToString();
                }
            }
            else if (filter(book))
            {
                AddBookViewItem(book);
            }
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
           // foreach(Book book in books)
           // {
            //    AddBookViewItem(book);
            //}
        }

        private void listViewForm_Enter(object sender, EventArgs e)
        {
            ToolStripManager.Merge(this.statusStrip1, ((MainForm)this.MdiParent).statusStrip1);
        }

        private void listViewForm_Leave(object sender, EventArgs e)
        {
            ToolStripManager.RevertMerge(((MainForm)this.MdiParent).statusStrip1, this.statusStrip1);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm mdiContainer = (MainForm)this.MdiParent;
            mdiContainer.AddBook();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewForm.SelectedItems.Count == 1)
            {
                MainForm mdiContainer = (MainForm)this.MdiParent;
                mdiContainer.RemoveBook((Book)this.listViewForm.SelectedItems[0].Tag);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listViewForm.SelectedItems.Count == 1)
            {
                MainForm mdiContainer = (MainForm)this.MdiParent;
                mdiContainer.EditBook((Book)this.listViewForm.SelectedItems[0].Tag);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            filter = IsBefore2000;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            filter = IsAfter2000;
        }

        private void emptyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filter = EmptyFilter;
        }
    }
}
