namespace Windows_Forms_Books
{
    partial class ViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewForm = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewForm
            // 
            this.listViewForm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Author,
            this.Category,
            this.Date});
            this.listViewForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewForm.Location = new System.Drawing.Point(0, 0);
            this.listViewForm.Name = "listViewForm";
            this.listViewForm.Size = new System.Drawing.Size(358, 283);
            this.listViewForm.TabIndex = 0;
            this.listViewForm.UseCompatibleStateImageBehavior = false;
            this.listViewForm.View = System.Windows.Forms.View.Details;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            // 
            // Author
            // 
            this.Author.Text = "Author";
            this.Author.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Category
            // 
            this.Category.Text = "Category";
            this.Category.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Category.Width = 90;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Date.Width = 50;
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 283);
            this.Controls.Add(this.listViewForm);
            this.Name = "ViewForm";
            this.Text = "Books";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewForm;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Author;
        private System.Windows.Forms.ColumnHeader Category;
        private System.Windows.Forms.ColumnHeader Date;
    }
}