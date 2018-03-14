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
    public partial class frmProductImage : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmProductImage()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProductImageNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void frmProductImage_Load(object sender, EventArgs e)
        {
            Product product = new Product();
            cmbProduct.Source(product.Select());

            ucDate1.DateFrom = DateTime.Now;
            ucDate1.DateTo = DateTime.Now.AddMonths(-1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProductImage pi = new ProductImage();

            pi.Title = txtSearch.Text;

            try
            {
                pi.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
            }
            catch { }

            if (ucDate1.chkDateSearch.Checked)
            {
                pi.DateSearch = true;
                pi.DateFrom = ucDate1.DateFrom;
                pi.DateTo = ucDate1.DateTo;

            }

            dgvImage.DataSource = pi.Select().Tables[0];
        }

        private void dgvImage_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucDate1_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReports rpt = new frmReports(dgvImage);
            rpt.MdiParent = this.MdiParent;
            rpt.Show();
            rpt.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvImage.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Please Select One");
                return;
            }
            DialogResult dr = MessageBox.Show("R U Sure?", "Delete Confirmation", MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            DAL.ProductImage productImage = new ProductImage();
            productImage.Id = Convert.ToInt32(dgvImage.SelectedRows[0].Cells["colId"].Value);

            if (productImage.Delete())
            {
                MessageBox.Show("Data deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(productImage.Error);
            }
        }
    }
}
