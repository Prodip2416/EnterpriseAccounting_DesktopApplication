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
    public partial class frmHead : BDJ.Enterprise.Presentation.frmDashboard
    {
        public frmHead()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Head head= new Head();
            dgvHead.DataSource = head.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmHeadNew().ShowDialog();
            btnSearch.PerformClick();
        }

        private void frmHead_Load(object sender, EventArgs e)
        {
            Head head= new Head();
            DataTable dt = head.Select("where h1.headId is null").Tables[0];
   
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dt.Rows[i].ItemArray[1].ToString();
                tn.Tag = dt.Rows[i].ItemArray[0].ToString();
                AddChild(Convert.ToInt32(dt.Rows[i].ItemArray[0]), tn);
                tvHead.Nodes.Add(tn);
            }
        }

        private void AddChild(int pId, TreeNode tn)
        {
            Head head = new Head();
            DataTable dt = head.Select("where h1.headId = "+pId.ToString()).Tables[0];


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tn2 = new TreeNode();
                tn2.Text = dt.Rows[i].ItemArray[1].ToString();
                tn2.Tag = dt.Rows[i].ItemArray[0].ToString();
                AddChild(Convert.ToInt32(dt.Rows[i].ItemArray[0]), tn2);
                tn.Nodes.Add(tn2);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReports rpt = new frmReports(dgvHead);
            rpt.MdiParent = this.MdiParent;
            rpt.Show();
            rpt.BringToFront();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvHead.SelectedRows.Count <= 0)
            {
                MessageBox.Show(@"Please Select One");
                return;
            }

            DialogResult dr = MessageBox.Show("R U Sure?", "Delete Confirmation", MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            DAL.Head head = new Head();
            head.Id = Convert.ToInt32(dgvHead.SelectedRows[0].Cells["colId"].Value);

            if (head.Delete())
            {
                MessageBox.Show("Data deleted");
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show(head.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvHead.SelectedRows.Count<=0)
                return;
            frmHeadEdit headEdit= new frmHeadEdit();
            headEdit.Id = Convert.ToInt32(dgvHead.SelectedRows[0].Cells["colId"].Value);
            headEdit.ShowDialog();
            btnSearch.PerformClick();
        }
    }
}
