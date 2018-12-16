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
    public partial class BookDetails : Form
    {
        public BookDetails()
        {
            InitializeComponent();
        }
        public void SetBookDetails(String title, String author, DateTime date, String category)
        {
            this.titleTextBox.Text = title;
            this.authorTextBox.Text = author;
            this.dateTimePicker.Value = date;
            this.categoryTextBox.Text = category;
        }

        public void SetBookDetails(Book book)
        {
            this.titleTextBox.Text = book.Title;
            this.authorTextBox.Text = book.Author;
            this.dateTimePicker.Value = book.Date;
            this.categoryTextBox.Text = book.Category;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void titleTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateTextBox(titleTextBox, e);
        }

        private void categoryTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateTextBox(categoryTextBox, e);
        }

        private void dateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            if (this.dateTimePicker.Value > DateTime.Now)
            {
                e.Cancel = true;
                errorHandler.SetError(dateTimePicker, "Date can't be in the future");
            }
        }

        private void authorTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateTextBox(authorTextBox, e);
        }

        private void validateTextBox(TextBox textBox, CancelEventArgs e)
        {
            if (textBox.Text.Length == 0)
            {
                e.Cancel = true;
                errorHandler.SetError(textBox, "This field can't be empty");
            }
        }

        private void resetError(Control box)
        {
                errorHandler.SetError(box, "");
        }

        private void titleTextBox_Validated(object sender, EventArgs e)
        {
            resetError(titleTextBox);
        }

        private void authorTextBox_Validated(object sender, EventArgs e)
        {
            resetError(authorTextBox);
        }

        private void dateTimePicker_Validated(object sender, EventArgs e)
        {
            resetError(dateTimePicker);
        }

        private void categoryTextBox_Validated(object sender, EventArgs e)
        {
            resetError(categoryTextBox);
        }
    }
}
