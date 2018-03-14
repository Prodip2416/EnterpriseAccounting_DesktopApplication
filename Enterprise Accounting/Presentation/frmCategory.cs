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
    public partial class frmCategory : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Category category= new Category();
            category.Search = txtSearch.Text;

            dgvCategory.DataSource = category.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmCategoryNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            Category category=new Category();
            DataTable dt = category.Select(" where c.categoryId is NULL").Tables[0];
            

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dt.Rows[i].ItemArray[1].ToString();
                tn.Tag = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                AddChild(Convert.ToInt32(dt.Rows[i].ItemArray[0]), tn);
                tvCategory.Nodes.Add(tn);
            }
        }

        private void AddChild(int pId, TreeNode tn)
        {

            Category category = new Category();
            DataTable dt = category.Select(" where c.categoryId =" + pId).Tables[0];


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tn2 = new TreeNode();
                tn2.Text = dt.Rows[i].ItemArray[1].ToString();
                tn2.Tag = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                AddChild(Convert.ToInt32(dt.Rows[i].ItemArray[0]), tn2);
                tn.Nodes.Add(tn2);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReports rpt = new frmReports(dgvCategory);
            rpt.MdiParent = this.MdiParent;
            rpt.Show();
            rpt.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Please Select One");
                return;
            }

            DialogResult dr = MessageBox.Show(@"R U Sure?", @"Delete Confirmation", MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            DAL.Category category = new Category();
            category.Id = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells["colId"].Value);

            if (category.Delete())
            {
                MessageBox.Show(@"Data deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(category.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count <= 0)
                return;
            frmCategoryEdit categoryEdit= new frmCategoryEdit();
            categoryEdit.Id = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells["colId"].Value);
            categoryEdit.ShowDialog();
            btnSearch.PerformClick();
        }
    }
}
