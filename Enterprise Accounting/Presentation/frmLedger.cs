using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BDJ.Enterprise.Reports;
using DAL;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmLedger : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmLedger()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmLedgerNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Ledger ledger= new Ledger();
            ledger.Search = txtSearch.Text;

            try
            {
                ledger.HeadId = Convert.ToInt32(cmbHead.SelectedValue);
            }
            catch { }


            if (ucDate1.chkDateSearch.Checked)
            {
                ledger.DateSearch = true;
                ledger.DateFrom = ucDate1.DateFrom;
                ledger.DateTo = ucDate1.DateTo;
              
            }


            dgvLedger.DataSource = ledger.Select().Tables[0];
        }

        private void frmLedger_Load(object sender, EventArgs e)
        {
            Head head= new Head();
            cmbHead.Source(head.Select());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReports rpt= new frmReports(dgvLedger);
            rpt.MdiParent = this.MdiParent;
            rpt.Show();
            rpt.BringToFront();

        }

        private void ucDate1_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLedger.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Please Select One");
                return;
            }

            DialogResult dr = MessageBox.Show("R U Sure?", "Delete Confirmation", MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            DAL.Ledger ledger = new Ledger();
            ledger.Id = Convert.ToInt32(dgvLedger.SelectedRows[0].Cells["colId"].Value);

            if (ledger.Delete())
            {
                MessageBox.Show("Data deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(ledger.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLedger.SelectedRows.Count <= 0)
                return;
            frmLedgerEdit ledgerEdit= new frmLedgerEdit();
            ledgerEdit.Id = Convert.ToInt32(dgvLedger.SelectedRows[0].Cells["colId"].Value);
            ledgerEdit.ShowDialog();
            btnSearch.PerformClick();
        }
    }
}
