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
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }

        FinancialCRMDbEntities DB = new FinancialCRMDbEntities();
        private void FrmBilling_Load(object sender, EventArgs e)// Sayfa Yüklendiğinde Listeyi Otomatik Getirme... //
        {
            lblUserName.Text += Username.KullaniciAdi;

            var values = DB.Bills.ToList();
            dataGridView1.DataSource = values;
        }
        private void btnBillList_Click(object sender, EventArgs e)// butona Tıkllandığında Listeleme... //
        {
            var values = DB.Bills.ToList();
            dataGridView1.DataSource = values;
        }
        private void btnBanks_Click(object sender, EventArgs e)// Bankalar Penceresini Açma... //
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }

        private void btnCreateBill_Click(object sender, EventArgs e)// Yeni Ödeme Oluşturma... //
        {
            string title = txtBillTitle.Text;
            decimal Amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            Bills bills = new Bills();
            bills.BillTitle = title;
            bills.BillAmount = Amount;
            bills.BillPeriod = period;
            DB.Bills.Add(bills);
            DB.SaveChanges();
            MessageBox.Show("Fatura planınız başarıyla Eklendi...", "Fatura Formu");

            var values = DB.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnRemoveBill_Click(object sender, EventArgs e)// Ödeme Silme İşlemi... //
        {
            int ID = int.Parse(txtBillId.Text);
            var removeValue = DB.Bills.Find(ID);
            DB.Bills.Remove(removeValue);
            DB.SaveChanges();
            MessageBox.Show("Fatura planınız başarıyla Silindi...", "Fatura Formu");

            var values = DB.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)// Ödeme Güncelleme İşlemi... //
        {
            int ID = int.Parse(txtBillId.Text);
            string title = txtBillTitle.Text;
            decimal Amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            var values = DB.Bills.Find(ID);
            values.BillTitle = title;
            values.BillAmount = Amount;
            values.BillPeriod = period;
            DB.SaveChanges();
            MessageBox.Show("Fatura planınız başarıyla Güncellendi...", "Fatura Formu");

            var values1 = DB.Bills.ToList();
            dataGridView1.DataSource = values1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
