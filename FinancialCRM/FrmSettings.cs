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
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }
        FinancialCRMDbEntities DB = new FinancialCRMDbEntities();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            FrmDashboard Dashboard = new FrmDashboard();
            Dashboard.Show();
            this.Close();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            try
            {     
                if(txtPass.Text == txtPassRepeat.Text)
                {
                    var name = Username.KullaniciAdi;
                    var changePass = DB.Users.Where(x => x.Username == name).FirstOrDefault();
                    var pass = txtPass.Text;

                    changePass.Username = name;
                    changePass.Password = pass;
                    DB.SaveChanges();
                    MessageBox.Show("Şifreniz Güncellendi...", "Başarılı...");
                }
                else
                {
                    MessageBox.Show("Şifreniz Uyuşmamaktadır!!!", "Başarısız..!");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata Aldınız: " + ex);
            }
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            lblUserName.Text += Username.KullaniciAdi;
        }
    }
}
