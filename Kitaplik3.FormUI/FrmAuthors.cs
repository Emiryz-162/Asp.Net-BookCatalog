using Kitaplik3.Business.Concrete;
using Kitaplik3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitaplik3.FormUI
{
    public partial class FrmAuthors : Form
    {
        AuthorManager _AuthorManager = new AuthorManager();
        int _id = -1;
        public FrmAuthors()
        {
            InitializeComponent();
            YazarListele();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
        }

        void YazarListele()
        {
            dataGridView1.DataSource = _AuthorManager.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Author author = new Author();
            author.Name = textBox1.Text;

            _AuthorManager.Add(author);

            YazarListele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                _id = int.Parse(row.Cells[0].Value.ToString());

                Author author = _AuthorManager.GetById(_id);
                textBox1.Text = author.Name;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Author author = _AuthorManager.GetById(_id);
            _AuthorManager.Delete(author);
            YazarListele();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Author author = _AuthorManager.GetById( _id);
            author.Name = textBox1.Text;
            _AuthorManager.Update(author);
            YazarListele();
        }
    }
}
