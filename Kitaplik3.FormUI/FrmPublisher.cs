using Kitaplik3.Business.Concrete;
using Kitaplik3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitaplik3.FormUI
{
    public partial class FrmPublisher : Form
    {
        PublisherManager _publisherManager = new();
        int _id = 0;
        public FrmPublisher()
        {
            InitializeComponent();
            YayıncıListele();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
        }

        void YayıncıListele()
        {
            dataGridView1.DataSource = _publisherManager.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Publisher publisher = new Publisher();
            publisher.Name = textBox1.Text;
            _publisherManager.Add(publisher);
            YayıncıListele();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Publisher publisher = _publisherManager.GetById(_id);
            _publisherManager.Delete(publisher);
            YayıncıListele();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Publisher publisher = _publisherManager.GetById(_id);
            publisher.Name = textBox1.Text;
            _publisherManager.Update(publisher);
            YayıncıListele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                _id = int.Parse(row.Cells[0].Value.ToString());

                Publisher publisher= _publisherManager.GetById(_id);
                textBox1.Text = publisher.Name;
            }
        }
    }
}
