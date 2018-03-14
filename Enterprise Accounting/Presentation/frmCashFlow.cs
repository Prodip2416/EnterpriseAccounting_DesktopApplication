using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BDJ.Enterprise.Reports;
using DAL;
using MyContorls;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmCashFlow : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmCashFlow()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Reports reports= new DAL.Reports();
            dgvCashFlow.DataSource = reports.CashFlow(ucDate1.DateFrom,ucDate1.DateTo).Tables[0];


        }

        private void ucDate1_Load(object sender, EventArgs e)
        {

        }

        private void frmCashFlow_Load(object sender, EventArgs e)
        {
           
            ucDate1.DateTo = DateTime.Now;
            ucDate1.DateFrom = DateTime.Now.AddMonths(-1);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReports rpt = new frmReports(dgvCashFlow);
            rpt.MdiParent = this.MdiParent;
            rpt.Show();
            rpt.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
