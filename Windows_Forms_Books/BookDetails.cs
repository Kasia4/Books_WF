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

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
