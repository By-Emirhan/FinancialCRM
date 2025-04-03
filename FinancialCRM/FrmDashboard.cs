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
            var totalBalance = DB.Banks.Sum(x => x.BankBalance);
            lblTotalbalance.Text = totalBalance.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Count++;
            if (Count % 4 == 0)
            {
                var billTitle = DB.Bills.OrderByDescending(x => x.BiLLID).Take(1).FirstOrDefault();
                lblBillTitle.Text = billTitle.BillTitle;
                lblBillAmount.Text=billTitle.BillAmount.ToString();
            }
            if (Count % 4 == 1)
            {
                var billTitle = DB.Bills.OrderByDescending(x => x.BiLLID).Take(2).Skip(1).FirstOrDefault();
                lblBillTitle.Text = billTitle.BillTitle;
                lblBillAmount.Text = billTitle.BillAmount.ToString();
            }
            if (Count % 4 == 2)
            {
                var billTitle = DB.Bills.OrderByDescending(x => x.BiLLID).Take(3).Skip(2).FirstOrDefault();
                lblBillTitle.Text = billTitle.BillTitle;
                lblBillAmount.Text = billTitle.BillAmount.ToString();
            }
            if (Count % 4 == 3)
            {
                var billTitle = DB.Bills.OrderByDescending(x => x.BiLLID).Take(4).Skip(3).FirstOrDefault();
                lblBillTitle.Text = billTitle.BillTitle;
                lblBillAmount.Text = billTitle.BillAmount.ToString();
            }
        }
    }
}
