using FinancialCRM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCRM
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        FinancialCRMDbEntities DB = new FinancialCRMDbEntities();
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            lblUserName.Text += Username.KullaniciAdi;

            //
            // Bankadaki Bakiye Bilgilerini Getirme...
            //
            var akbankBalance = DB.Banks.Where(x => x.BankTitle == "Akbank")
                .Select(y => y.BankBalance).FirstOrDefault();
            var yapiKrediBalance = DB.Banks.Where(x => x.BankTitle == "Yapı Kredi")
                .Select(y => y.BankBalance).FirstOrDefault();
            var garantiBBVABalance = DB.Banks.Where(x => x.BankTitle == "Garanti BBVA")
                .Select(y => y.BankBalance).FirstOrDefault();

            lblAkbankBalance.Text = akbankBalance.ToString() + " ₺";
            lblYapiKrediBalance.Text = yapiKrediBalance.ToString() + " ₺";
            lblGarantiBBVABalance.Text = garantiBBVABalance.ToString() + " ₺";

            //
            // Banka Hareketlerini Tabloya Aktarma...
            //
            var bankProcess1 = DB.BankProcesses
                .OrderByDescending(x => x.BankProcessID).Take(1).FirstOrDefault();
            lblDescription1.Text= bankProcess1.Description;
            lblDate1.Text = Convert.ToDateTime(bankProcess1.ProcessDate).ToShortDateString();
            lblProcessType1.Text=bankProcess1.ProcessType.ToString();
            lblAmount1.Text=bankProcess1.Amount.ToString() + " ₺";

            var bankProcess2 = DB.BankProcesses
                .OrderByDescending(x => x.BankProcessID).Take(2).Skip(1).FirstOrDefault();
            lblDescription2.Text = bankProcess2.Description;
            lblDate2.Text = Convert.ToDateTime(bankProcess2.ProcessDate).ToShortDateString();
            lblProcessType2.Text = bankProcess2.ProcessType.ToString();
            lblAmount2.Text = bankProcess2.Amount.ToString() + " ₺";

            var bankProcess3 = DB.BankProcesses
                .OrderByDescending(x => x.BankProcessID).Take(3).Skip(2).FirstOrDefault();
            lblDescription3.Text = bankProcess3.Description;
            lblDate3.Text = Convert.ToDateTime(bankProcess3.ProcessDate).ToShortDateString();
            lblProcessType3.Text = bankProcess3.ProcessType.ToString();
            lblAmount3.Text = bankProcess3.Amount.ToString() + " ₺";

            var bankProcess4 = DB.BankProcesses
                .OrderByDescending(x => x.BankProcessID).Take(4).Skip(3).FirstOrDefault();
            lblDescription4.Text = bankProcess4.Description;
            lblDate4.Text = Convert.ToDateTime(bankProcess4.ProcessDate).ToShortDateString();
            lblProcessType4.Text = bankProcess4.ProcessType.ToString();
            lblAmount4.Text = bankProcess4.Amount.ToString() + " ₺";

            var bankProcess5 = DB.BankProcesses
                .OrderByDescending(x => x.BankProcessID).Take(5).Skip(4).FirstOrDefault();
            lblDescription5.Text = bankProcess5.Description;
            lblDate5.Text = Convert.ToDateTime(bankProcess5.ProcessDate).ToShortDateString();
            lblProcessType5.Text = bankProcess5.ProcessType.ToString();
            lblAmount5.Text = bankProcess5.Amount.ToString() + " ₺";

            var bankProcess6 = DB.BankProcesses
                .OrderByDescending(x => x.BankProcessID).Take(6).Skip(5).FirstOrDefault();
            lblDescription6.Text = bankProcess6.Description;
            lblDate6.Text = Convert.ToDateTime(bankProcess6.ProcessDate).ToShortDateString();
            lblProcessType6.Text = bankProcess6.ProcessType.ToString();
            lblAmount6.Text = bankProcess6.Amount.ToString() + " ₺";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBillFrom_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnSettingsForm_Click(object sender, EventArgs e)
        {
            FrmSettings settings = new FrmSettings();
            settings.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDashboard dashboard = new FrmDashboard();
            dashboard.Show();
            this.Close();
        }

        private void btnSpendingForm_Click(object sender, EventArgs e)
        {
            FrmSpending spending = new FrmSpending();
            spending.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmCategories categories = new FrmCategories();
            categories.Show();
        }
    }
}
