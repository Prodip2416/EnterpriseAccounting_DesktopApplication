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
    public partial class frmCountry : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmCountry()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Country country = new Country();
            country.Search = txtSearch.Text;

            dgvCountry.DataSource = country.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmCountryNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void frmCountry_Load(object sender, EventArgs e)
        {
           
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReports rpt = new frmReports(dgvCountry);
            rpt.MdiParent = this.MdiParent;
            rpt.Show();
            rpt.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCountry.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Please Select One");
                return;
            }

            DialogResult dr = MessageBox.Show(@"R U Sure?", @"Delete Confirmation", MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            DAL.Country br = new Country();
            br.Id = Convert.ToInt32(dgvCountry.SelectedRows[0].Cells["colId"].Value);

            if (br.Delete())
            {
                MessageBox.Show(@"Data deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(br.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCountry.SelectedRows.Count <= 0)
                return;
            frmCountryEdit countryEdit= new frmCountryEdit();
            countryEdit.Id = Convert.ToInt32(dgvCountry.SelectedRows[0].Cells["colId"].Value);
            countryEdit.ShowDialog();
            btnSearch.PerformClick();
        }
    }
}
