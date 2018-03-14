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
    public partial class frmJournal : BDJ.Enterprise.Presentation.frmDashboard
    {
        public int VouncherId { get; set; }
        public frmJournal()
        {
            InitializeComponent();
        }

        private void frmJournal_Load(object sender, EventArgs e)
        {
            cmbVoucher.Source(new Voucher().Select());
            btnSearch.PerformClick();
            cmbVoucher.SelectedValue = VouncherId;
            cmbVoucher.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmJournalNew journalNew = new frmJournalNew();
            journalNew.VoucherId = this.VouncherId;
            journalNew.ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Journal journal= new Journal();
            dgvJournal.DataSource = journal.Select().Tables[0];
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReports rpt = new frmReports(dgvJournal);
            rpt.MdiParent = this.MdiParent;
            rpt.Show();
            rpt.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
              if (dgvJournal.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Please Select One");
                return;
            }
            DialogResult dr = MessageBox.Show("R U Sure?", "Delete Confirmation", MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            DAL.Journal journal = new Journal();
            journal.Id = Convert.ToInt32(dgvJournal.SelectedRows[0].Cells["colId"].Value);

            if (journal.Delete())
            {
                MessageBox.Show("Data deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(journal.Error);
            }
        }
    }
}
