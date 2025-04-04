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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        FinancialCRMDbEntities DB = new FinancialCRMDbEntities();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var kullaniciAdi = txtUser.Text;
            var Sifre = txtPass.Text;

            var user = DB.Users.FirstOrDefault(x => x.Username == kullaniciAdi);

            try// Kullanıcı Girişi //
            {
                if (user != null && user.Password == Sifre)
                {
                    MessageBox.Show("Hoş geldiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmDashboard Dashboard = new FrmDashboard();
                    Dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.\nLütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Clear();
                    txtPass.Clear();
                    txtUser.Focus();
                }
            }
            catch(Exception ex)// Veritabanında olası hataları göstermek için //
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
