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
    public partial class frmCategoryEdit : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public int Id;
        public frmCategoryEdit()
        {
            InitializeComponent();
        }

        private void frmCategoryEdit_Load(object sender, EventArgs e)
        {
            Category category = new Category();
       


            category.Id = Id;
            if (category.SelectById())
            {
                txtName.Text = category.Name;
                txtDescription.Text = category.Description;
             
            }


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
            category.Id = Id;
            category.Name = txtName.Text;
            category.Description = txtDescription.Text;


            if (category.Update())
            {
                MessageBox.Show(@"data Saved");
            }
            else
            {
                MessageBox.Show(category.Error);
            }
        }
    }
}
