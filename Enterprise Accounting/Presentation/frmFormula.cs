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
    public partial class frmFormula : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmFormula()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmFormulaNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FormulaDetails f= new FormulaDetails();

            f.Search = txtSearch.Text;

            try
            {
                f.FormulaId = Convert.ToInt32(cmbFormula.SelectedValue);
            }
            catch { }

            try
            {
                f.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
            }
            catch { }

            dgvFormula.DataSource = f.Select().Tables[0];
        }

        private void frmFormula_Load(object sender, EventArgs e)
        {
            Product p = new Product();
            cmbProduct.Source(p.Select());

            Formula f= new Formula();
            cmbFormula.Source(f.Select());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReports rpt = new frmReports(dgvFormula);
            rpt.MdiParent = this.MdiParent;
            rpt.Show();
            rpt.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFormula.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Please Select One");
                return;
            }

            DialogResult dr = MessageBox.Show(@"R U Sure?", @"Delete Confirmation", MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            DAL.Formula formula = new Formula();
            formula.Id = Convert.ToInt32(dgvFormula.SelectedRows[0].Cells["colId"].Value);

            if (formula.Delete())
            {
                MessageBox.Show(@"Data deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(formula.Error);
            }
        }
    }
}
