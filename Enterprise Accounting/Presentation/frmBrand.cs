using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BDJ.Enterprise.Reports;
using DAL;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmBrand : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmBrand()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Brand brand = new Brand();

            brand.Search = txtSearch.Text;
            dgvBrand.DataSource = brand.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmBrandNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReports rpt = new frmReports(dgvBrand);
            rpt.MdiParent = this.MdiParent;
            rpt.Show();
            rpt.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBrand.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Please Select One");
                return;
            }

            DialogResult dr = MessageBox.Show(@"R U Sure?", @"Delete Confirmation", MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            DAL.Brand br = new Brand();
            br.Id = Convert.ToInt32(dgvBrand.SelectedRows[0].Cells["colId"].Value);

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
            if(dgvBrand.SelectedRows.Count <=0)
                return;
            frmBrandEdit brandEdit= new frmBrandEdit();
            brandEdit.Id = Convert.ToInt32(dgvBrand.SelectedRows[0].Cells["colId"].Value);
            brandEdit.ShowDialog();
            btnSearch.PerformClick();
        }
    }
}
