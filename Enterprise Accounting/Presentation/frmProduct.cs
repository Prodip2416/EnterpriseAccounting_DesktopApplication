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
    public partial class frmProduct : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmProductNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Product product= new Product();

            product.Search = txtSearch.Text;

            try
            {
                product.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                product.BrandId = Convert.ToInt32(cmbBrand.SelectedValue);
            }
            catch { }

            dgvProduct.DataSource = product.Select().Tables[0];
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            Category category= new Category();
            cmbCategory.Source(category.Select());

            Brand brand= new Brand();
            cmbBrand.Source(brand.Select());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReports rpt = new frmReports(dgvProduct);
            rpt.MdiParent = this.MdiParent;
            rpt.Show();
            rpt.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Please Select One");
                return;
            }
            DialogResult dr = MessageBox.Show("R U Sure?", "Delete Confirmation", MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            DAL.Product product = new Product();
            product.Id = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells["colId"].Value);

            if (product.Delete())
            {
                MessageBox.Show("Data deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(product.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count <= 0)
                return;

            frmProductEdit productEdit= new frmProductEdit();
            productEdit.Id = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells["colId"].Value);
            productEdit.ShowDialog();
            btnSearch.PerformClick();
        }
    }
}
