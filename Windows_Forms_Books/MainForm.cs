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
    public partial class MDIForm : Form
    {
        private List<ViewForm> views;

        public MDIForm()
        {
            views = new List<ViewForm>();
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
            ViewForm view = new ViewForm
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
    }
}
