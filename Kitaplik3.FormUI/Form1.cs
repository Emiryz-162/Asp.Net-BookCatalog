using Kitaplik3.Business.Concrete;
using Kitaplik3.Entities.Concrete;

namespace Kitaplik3.FormUI
{
    public partial class Form1 : Form
    {
        BookManager _bookManager = new BookManager();
        CategoryManager _categoryManager = new CategoryManager();
        AuthorManager _authorManager = new AuthorManager();
        PublisherManager _publisherManager = new PublisherManager();

        public Form1()
        {
            InitializeComponent();

            cbCategories.DataSource = _categoryManager.GetAll();
            cbCategories.DisplayMember = "Name";
            cbCategories.ValueMember = "Id";

            cbAuthor.DataSource = _authorManager.GetAll();
            cbAuthor.DisplayMember = "Name";
            cbAuthor.ValueMember = "Id";

            cbPublisher.DataSource = _publisherManager.GetAll();
            cbPublisher.DisplayMember = "Name";
            cbPublisher.ValueMember = "Id";

            KitapListele();

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[9].Visible = false;
        }

        void KitapListele()
        {
            dataGridView1.DataSource = _bookManager.GetAll();
        }


        private void btnCategories_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new();
            frm.ShowDialog();
        }

        private void btnAuthors_Click(object sender, EventArgs e)
        {
            FrmAuthors authors = new FrmAuthors();
            authors.ShowDialog();
        }

        private void btnPublishers_Click(object sender, EventArgs e)
        {
            FrmPublisher publisher = new FrmPublisher();
            publisher.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            dynamic authorId = (cbAuthor.SelectedItem as dynamic).Id;
            dynamic publisherId = (cbPublisher.SelectedItem as dynamic).Id;
            dynamic categoryId = (cbCategories.SelectedItem as dynamic).Id;

            book.Name = txtName.Text;
            book.ISBN = txtIsbn.Text;
            book.AuthorId = Convert.ToInt32(authorId);
            book.PublisherId = Convert.ToInt32(publisherId);
            book.CategoryId = Convert.ToInt32(categoryId);

            _bookManager.Add(book);
            KitapListele();
        }
    }
}
