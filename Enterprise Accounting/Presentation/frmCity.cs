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
    public partial class frmCity : BDJ.Enterprise.Presentation.frmDashboard
    {
       //frmCityNew cityNew= new frmCityNew();
        public frmCity()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            City city= new City();

            city.Search = txtSearch.Text;

            try
            {
                city.CountryId = Convert.ToInt32(cmbCountry.SelectedValue);
            }
            catch { }

            dgvGridView.DataSource = city.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmCityNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void frmCity_Load(object sender, EventArgs e)
        {
            Country country= new Country();
            cmbCountry.Source(country.Select());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReports rpt = new frmReports(dgvGridView);
            rpt.MdiParent = this.MdiParent;
            rpt.Show();
            rpt.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGridView.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Please Select One");
                return;
            }

            DialogResult dr = MessageBox.Show("R U Sure?", "Delete Confirmation", MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            DAL.City city = new City();
            city.Id = Convert.ToInt32(dgvGridView.SelectedRows[0].Cells["colId"].Value);

            if (city.Delete())
            {
                MessageBox.Show("Data deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(city.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvGridView.SelectedRows.Count <= 0)
                return;
            frmCityEdit cityEdit= new frmCityEdit();
            cityEdit.Id = Convert.ToInt32(dgvGridView.SelectedRows[0].Cells["colId"].Value);
            cityEdit.ShowDialog();
            btnSearch.PerformClick();
        }
    }
}
