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
    public partial class FrmSpending : Form
    {
        public FrmSpending()
        {
            InitializeComponent();
        }
        FinancialCRMDbEntities DB = new FinancialCRMDbEntities();
        private void FrmSpending_Load(object sender, EventArgs e)
        {
            var values = DB.Spendings.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var values = DB.Spendings.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Close();
        }
    }
}
