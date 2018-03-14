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
    public partial class frmDamage : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmDamage()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Damage damage= new Damage();
            damage.Search = txtSearch.Text;
            try
            {
                damage.ProductId = Convert.ToInt32(cmbLedger.SelectedValue);
            }
            catch { }
            dgvDamage.DataSource = damage.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmDamageNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReports rpt = new frmReports(dgvDamage);
            rpt.MdiParent = this.MdiParent;
            rpt.Show();
            rpt.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDamage.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Please Select One");
                return;
            }

            DialogResult dr = MessageBox.Show(@"R U Sure?", @"Delete Confirmation", MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            DAL.Damage damage = new Damage();
            damage.Id = Convert.ToInt32(dgvDamage.SelectedRows[0].Cells["colId"].Value);

            if (damage.Delete())
            {
                MessageBox.Show(@"Data deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(damage.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDamage.SelectedRows.Count <= 0)
                return;
            frmDamageEdit damageEdit= new frmDamageEdit();
            damageEdit.Id = Convert.ToInt32(dgvDamage.SelectedRows[0].Cells["colId"].Value);
            damageEdit.ShowDialog();
            btnSearch.PerformClick();
        }

        private void frmDamage_Load(object sender, EventArgs e)
        {
            Product product= new Product();
            cmbLedger.Source(product.Select());
        }
    }
}
