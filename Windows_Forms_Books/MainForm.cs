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
    public partial class MainForm : Form
    {
        private List<ViewForm> views;
        private BookList books;

        public MainForm(BookList books)
        {
            views = new List<ViewForm>();
            this.books = books;
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateView();
        }

        private void MDIForm_Load(object sender, EventArgs e)
        {
            CreateView();
        }

        private void CreateView()
        {
            ViewForm view = new ViewForm(books)
            {
                MdiParent = this
            };
            view.FormClosing += ViewFormClosing;
            views.Add(view);
            view.Show();
        }

        private void ViewFormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.views.Count <= 1 && e.CloseReason != CloseReason.MdiFormClosing)
                e.Cancel = true;
            else
                views.Remove((ViewForm)sender);
        }

        public void AddBook()
        {
            BookDetails form = new BookDetails();
            if (form.ShowDialog() == DialogResult.OK)
            {
                books.Add(form.titleTextBox.Text, form.authorTextBox.Text, form.dateTimePicker.Value, form.categoryControl.GetCurrentCategoryStr());
            }
        }

        public void EditBook(Book book)
        {
            BookDetails form = new BookDetails();
            form.SetBookDetails(book);
            if (form.ShowDialog() == DialogResult.OK)
            {
                book.SetProperties(form.titleTextBox.Text, form.authorTextBox.Text, form.dateTimePicker.Value, form.categoryControl.GetCurrentCategoryStr());
                books.Edit(book);
            }
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

    }
}
