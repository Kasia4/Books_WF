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
    public enum Category
    {
        crime,
        fairytale,
        romance
    };
    public partial class CategoryControl : PictureBox
    {
        public event EventHandler CategoryChanged;

        protected virtual void OnCategoryChanged()
        {
            EventHandler handler = CategoryChanged;
            if (handler != null)
            {
                handler(this, null);
            }
        }

        private Category currentCategory;
        private static Image[] images = {
            ImagesRes.crime,
            ImagesRes.fairytale,
            ImagesRes.romance
        };

        [Category("Category")]
        [Editor(typeof(CategoryEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Browsable(true)]
        public Category CurrentCategory
        {
            get => currentCategory;
            set
            {
                this.currentCategory = value;
                this.Image = images[(uint)currentCategory];
            }
        }
        public CategoryControl(Category category)
        {
            
            InitializeComponent();
            this.Size = new Size(50, 50);
            this.CurrentCategory = category;
            OnCategoryChanged();
            this.Click += CategoryControlClicked;
        }

        public CategoryControl() : this(Category.crime) {}

        private void CategoryControlClicked(object sender, EventArgs e)
        {
            this.CurrentCategory = (Category)((uint)(this.currentCategory + 1) % 3);
            OnCategoryChanged();
        }

        public String GetCurrentCategoryStr()
        {
            return currentCategory.ToString();
        }

        public void SetCurrentCategory(string category)
        {
            Category currCategory;
            if (Enum.TryParse<Category>(category, out currCategory))
            {
                this.CurrentCategory = currCategory;
                OnCategoryChanged();
            }

        }

    }
}
