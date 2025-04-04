using FinancialCRM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCRM
{
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            InitializeComponent();
        }
        FinancialCRMDbEntities DB = new FinancialCRMDbEntities();
        private void FrmCategories_Load(object sender, EventArgs e)
        {
            var kategori = DB.Categories.Select(x => new
            {
                Kategori_ID = x.CategoryID,
                Kategori_Adı = x.CategoryName
            }).ToList();
            dataGridView1.DataSource = kategori;
        }

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            string kategoriAdi = txtCategoryName.Text;

            Categories categories = new Categories();
            categories.CategoryName = kategoriAdi;
            DB.Categories.Add(categories);
            DB.SaveChanges();
            MessageBox.Show("Kategori Eklendi...", "Kategori Kartları");

            var kategori = DB.Categories.Select(x => new
            {
                Kategori_ID = x.CategoryID,
                Kategori_Adı = x.CategoryName
            }).ToList();
            dataGridView1.DataSource = kategori;
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtCategoryID.Text);
            var removeCategory = DB.Categories.Find(ID);
            DB.Categories.Remove(removeCategory);
            DB.SaveChanges();
            MessageBox.Show("Kategori Silindi...", "Kategori Kartları");

            var kategori = DB.Categories.Select(x => new
            {
                Kategori_ID = x.CategoryID,
                Kategori_Adı = x.CategoryName
            }).ToList();
            dataGridView1.DataSource = kategori;
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtCategoryID.Text);
            string kategoriAdi = txtCategoryName.Text;

            var values = DB.Categories.Find(ID);
            values.CategoryName = kategoriAdi;
            DB.SaveChanges();
            MessageBox.Show("Kategori Güncellendi...", "Kategori Kartları");

            var kategori = DB.Categories.Select(x => new
            {
                Kategori_ID = x.CategoryID,
                Kategori_Adı = x.CategoryName
            }).ToList();
            dataGridView1.DataSource = kategori;
        }
    }
}
