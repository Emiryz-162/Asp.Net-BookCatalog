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
    public partial class FrmCategories : Form
    {
        CategoryManager _categoryManager = new();
        int _id = -1;
        public FrmCategories()
        {
            InitializeComponent();
            KategoriListele();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
        }

        void KategoriListele()
        {
            dataGridView1.DataSource = _categoryManager.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new();
            category.Name = textBox1.Text;

            _categoryManager.Add(category);

            MessageBox.Show("Ekleme işlemi başarılı");
            textBox1.Clear();
            KategoriListele();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Category category = _categoryManager.GetById(_id);
            _categoryManager.Delete(category);
            KategoriListele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                _id = int.Parse(row.Cells[0].Value.ToString());

                Category category = _categoryManager.GetById(_id);
                textBox1.Text = category.Name;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            Category category = _categoryManager.GetById(_id);
            category.Name = textBox1.Text;
            _categoryManager.Update(category);
            KategoriListele();
        }
    }
}
