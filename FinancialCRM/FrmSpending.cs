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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinancialCRM
{
    public partial class FrmSpending : Form
    {
        public FrmSpending()
        {
            InitializeComponent();
        }
        FinancialCRMDbEntities DB = new FinancialCRMDbEntities();
        private void FrmSpending_Load(object sender, EventArgs e)
        {
            var categories = DB.Categories
                   .Select(c => new
                   {
                       c.CategoryID,
                       c.CategoryName
                   })
            .ToList();

            cmbCategory.DisplayMember = "CategoryName"; // Kullanıcıya görünen
            cmbCategory.ValueMember = "CategoryID";     // Arka planda tutulan ID
            cmbCategory.DataSource = categories;
            cmbCategory.SelectedValue = 0;// Form açıldığında ComboBox alanının boş kalması için...

            var values = DB.Spendings.Select(x => new
            {
                Harcama_NO = x.SpendingID,
                Açıklama = x.SpendingTitle,
                Harcama_Tutarı = x.SpendingAmount,
                Tarih = x.SpendingDate,
                Kategori = x.CategoryID
            }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }
        private void btnCreateSpending_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal Amount = decimal.Parse(txtBillAmount.Text);
            var tarih = Convert.ToDateTime(txtBillPeriod.Text);

            Spendings spendings = new Spendings();
            spendings.SpendingTitle = title;
            spendings.SpendingAmount = Amount;
            spendings.SpendingDate = tarih;
            spendings.CategoryID = int.Parse(cmbCategory.SelectedValue.ToString());
            DB.Spendings.Add(spendings);
            DB.SaveChanges();
            MessageBox.Show("Ödeme planınız başarıyla Eklendi...", "Fatura Formu");

            var values = DB.Spendings.Select(x => new
            {
                Harcama_NO = x.SpendingID,
                Açıklama = x.SpendingTitle,
                Harcama_Tutarı = x.SpendingAmount,
                Tarih = x.SpendingDate,
                Kategori = x.CategoryID
            }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnRemoveSpending_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtSpendingID.Text);
            var removeValue = DB.Spendings.Find(ID);
            DB.Spendings.Remove(removeValue);
            DB.SaveChanges();
            MessageBox.Show("Ödeme planınız başarıyla Silindi...", "Fatura Formu");

            var values = DB.Spendings.Select(x => new
            {
                Harcama_NO = x.SpendingID,
                Açıklama = x.SpendingTitle,
                Harcama_Tutarı = x.SpendingAmount,
                Tarih = x.SpendingDate,
                Kategori = x.CategoryID
            }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateSpending_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtSpendingID.Text);
            string title = txtBillTitle.Text;
            decimal Amount = decimal.Parse(txtBillAmount.Text);
            var tarih = Convert.ToDateTime(txtBillPeriod.Text);
            var kategori = Convert.ToInt32(cmbCategory.SelectedValue);

            var values = DB.Spendings.Find(ID);
            values.SpendingTitle = title;
            values.SpendingAmount = Amount;
            values.SpendingDate = tarih;
            values.CategoryID = kategori;
            DB.SaveChanges();
            MessageBox.Show("Ödeme planınız başarıyla Güncellendi...", "Fatura Formu");

            var values1 = DB.Spendings.Select(x => new
            {
                Harcama_NO = x.SpendingID,
                Açıklama = x.SpendingTitle,
                Harcama_Tutarı = x.SpendingAmount,
                Tarih = x.SpendingDate,
                Kategori = x.CategoryID
            }).ToList();
            dataGridView1.DataSource = values1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCategoriesForm_Click(object sender, EventArgs e)
        {
            FrmCategories categories = new FrmCategories();
            categories.Show();
        }

        private void refresh()
        {
            var categories = DB.Categories
                   .Select(c => new
                   {
                       c.CategoryID,
                       c.CategoryName
                   })
            .ToList();

            cmbCategory.DisplayMember = "CategoryName"; // Kullanıcıya görünen
            cmbCategory.ValueMember = "CategoryID";     // Arka planda tutulan ID
            cmbCategory.DataSource = categories;
            cmbCategory.SelectedValue = 0;// Form açıldığında ComboBox alanının boş kalması için...
        }
    }
}
