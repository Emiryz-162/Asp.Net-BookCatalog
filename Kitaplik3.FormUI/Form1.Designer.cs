namespace Kitaplik3.FormUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCategories = new Button();
            btnAuthors = new Button();
            btnPublishers = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            txtName = new TextBox();
            label1 = new Label();
            txtIsbn = new TextBox();
            label2 = new Label();
            cbAuthor = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            cbCategories = new ComboBox();
            label5 = new Label();
            cbPublisher = new ComboBox();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnCategories
            // 
            btnCategories.Location = new Point(12, 12);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(75, 30);
            btnCategories.TabIndex = 0;
            btnCategories.Text = "Kategoriler";
            btnCategories.UseVisualStyleBackColor = true;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnAuthors
            // 
            btnAuthors.Location = new Point(93, 12);
            btnAuthors.Name = "btnAuthors";
            btnAuthors.Size = new Size(75, 30);
            btnAuthors.TabIndex = 0;
            btnAuthors.Text = "Yazarlar";
            btnAuthors.UseVisualStyleBackColor = true;
            btnAuthors.Click += btnAuthors_Click;
            // 
            // btnPublishers
            // 
            btnPublishers.Location = new Point(174, 12);
            btnPublishers.Name = "btnPublishers";
            btnPublishers.Size = new Size(75, 30);
            btnPublishers.TabIndex = 0;
            btnPublishers.Text = "Yayıncılar";
            btnPublishers.UseVisualStyleBackColor = true;
            btnPublishers.Click += btnPublishers_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(29, 125);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(192, 39);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(270, 125);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(194, 39);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            txtName.Location = new Point(81, 58);
            txtName.Name = "txtName";
            txtName.Size = new Size(140, 23);
            txtName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 61);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 3;
            label1.Text = "Adı:";
            // 
            // txtIsbn
            // 
            txtIsbn.Location = new Point(81, 87);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(140, 23);
            txtIsbn.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 90);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 3;
            label2.Text = "ISBN:";
            // 
            // cbAuthor
            // 
            cbAuthor.FormattingEnabled = true;
            cbAuthor.Location = new Point(343, 24);
            cbAuthor.Name = "cbAuthor";
            cbAuthor.Size = new Size(121, 23);
            cbAuthor.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(279, 27);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 3;
            label3.Text = "Yazar: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(279, 58);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 3;
            label4.Text = "Kategori: ";
            // 
            // cbCategories
            // 
            cbCategories.FormattingEnabled = true;
            cbCategories.Location = new Point(343, 55);
            cbCategories.Name = "cbCategories";
            cbCategories.Size = new Size(121, 23);
            cbCategories.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(279, 92);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 3;
            label5.Text = "YayınEvi: ";
            // 
            // cbPublisher
            // 
            cbPublisher.FormattingEnabled = true;
            cbPublisher.Location = new Point(343, 89);
            cbPublisher.Name = "cbPublisher";
            cbPublisher.Size = new Size(121, 23);
            cbPublisher.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 170);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(469, 185);
            dataGridView1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 367);
            Controls.Add(dataGridView1);
            Controls.Add(cbPublisher);
            Controls.Add(label5);
            Controls.Add(cbCategories);
            Controls.Add(label4);
            Controls.Add(cbAuthor);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtIsbn);
            Controls.Add(txtName);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnPublishers);
            Controls.Add(btnAuthors);
            Controls.Add(btnCategories);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCategories;
        private Button btnAuthors;
        private Button btnPublishers;
        private Button btnAdd;
        private Button btnUpdate;
        private TextBox txtName;
        private Label label1;
        private TextBox txtIsbn;
        private Label label2;
        private ComboBox cbAuthor;
        private Label label3;
        private Label label4;
        private ComboBox cbCategories;
        private Label label5;
        private ComboBox cbPublisher;
        private DataGridView dataGridView1;
    }
}
