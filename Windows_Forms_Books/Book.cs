using System;
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
            SetProperties(title, author, date, category);
        }

        public void SetProperties(String title, String author, DateTime date, String category)
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

}
