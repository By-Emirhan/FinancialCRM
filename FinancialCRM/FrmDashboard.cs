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
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }
        int Count = 0;
        FinancialCRMDbEntities DB = new FinancialCRMDbEntities();
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            lblUserName.Text += Username.KullaniciAdi;

            // Bankalardaki Bakiyelerin Toplamı
            var totalBalance = DB.Banks.Sum(x => x.BankBalance);
            lblTotalbalance.Text = totalBalance.ToString() + " ₺";
            //

            // Son Yapılan İşlem
            var lastBankProcessAmount = DB.BankProcesses.OrderByDescending(x => x.BankProcessID)
                .Take(1).FirstOrDefault();
            lblLastBankProcessAmount.Text = lastBankProcessAmount.Amount.ToString() + " ₺";

            // Chart 1 Kullanımı
            var bankData1 = DB.Banks.Select(x => new
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();
            chart1.Series.Clear();
            var series1 = chart1.Series.Add("Bakiyeler");
            foreach (var item in bankData1)
            {
                series1.Points.AddXY(item.BankTitle, item.BankBalance);
            }

            // Chart 2 Kullanımı
            var bankData2 = DB.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach (var item in bankData2)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)// Son 4 fatura saniyede bir görünecek //
        {
            Count++;
            if (Count % 4 == 0)
            {
                var billTitle = DB.Bills.OrderByDescending(x => x.BiLLID).Take(1).FirstOrDefault();
                lblBillTitle.Text = billTitle.BillTitle;
                lblBillAmount.Text=billTitle.BillAmount.ToString() + " ₺";
            }
            if (Count % 4 == 1)
            {
                var billTitle = DB.Bills.OrderByDescending(x => x.BiLLID).Take(2).Skip(1).FirstOrDefault();
                lblBillTitle.Text = billTitle.BillTitle;
                lblBillAmount.Text = billTitle.BillAmount.ToString() + " ₺";
            }
            if (Count % 4 == 2)
            {
                var billTitle = DB.Bills.OrderByDescending(x => x.BiLLID).Take(3).Skip(2).FirstOrDefault();
                lblBillTitle.Text = billTitle.BillTitle;
                lblBillAmount.Text = billTitle.BillAmount.ToString() + " ₺";
            }
            if (Count % 4 == 3)
            {
                var billTitle = DB.Bills.OrderByDescending(x => x.BiLLID).Take(4).Skip(3).FirstOrDefault();
                lblBillTitle.Text = billTitle.BillTitle;
                lblBillAmount.Text = billTitle.BillAmount.ToString() + " ₺";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks Banks = new FrmBanks();
            Banks.Show();
            this.Close();
        }

        private void btnBillsForm_Click(object sender, EventArgs e)
        {
            FrmBilling Bills = new FrmBilling();
            Bills.Show();
            this.Close();
        }

        private void btnSpendingForm_Click(object sender, EventArgs e)
        {
            FrmSpending spending = new FrmSpending();
            spending.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmSettings settings = new FrmSettings();
            settings.Show();
            this.Close();
        }
    }
}
