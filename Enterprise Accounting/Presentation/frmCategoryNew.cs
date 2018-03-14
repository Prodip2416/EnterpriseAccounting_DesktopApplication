using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmCategoryNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmCategoryNew()
        {
            InitializeComponent();
        }

        private void frmCategoryNew_Load(object sender, EventArgs e)
        {
            Category category = new Category();
            cmbCategory.Source(category.Select());

            this.MinimumSize = Size;
            this.MaximumSize = Size;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            if (txtName.Text == "")
            {
                er++;
                ep.SetError(txtName, "Required");
            }
            if (txtDescription.Text == "")
            {
                er++;
                ep.SetError(txtDescription, "Required");
            }
            if (er > 0)
                return;

            Category category = new Category();

            category.Name = txtName.Text;
            category.Description = txtDescription.Text;

            if (cmbCategory.SelectedValue != null && cmbCategory.SelectedValue.ToString() != "")
            {
                category.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            }

            if (category.Insert())
            {
                MessageBox.Show("data Saved");
                txtName.Text = "";
                txtDescription.Text = "";
                cmbCategory.SelectedValue = -1;
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(category.Error);
            }
        }
    }
}
