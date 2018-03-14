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
    public partial class frmBrandEdit : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public int Id;
        public frmBrandEdit()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
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

            DAL.Brand brand = new DAL.Brand();
            brand.Id = Id;
            brand.Name = txtName.Text;
            brand.Description = txtDescription.Text;

            if (brand.Update())
            {
                MessageBox.Show(@"Data Saved");
            }
            else
            {
                MessageBox.Show(brand.Error);
            }
        }

        private void frmBrandEdit_Load(object sender, EventArgs e)
        {
            this.MinimumSize = Size;
            this.MaximumSize = Size;

            Brand brand= new Brand();
            brand.Id = Id;

            if (brand.SelectById())
            {
                txtName.Text = brand.Name;
                txtDescription.Text = brand.Description;
            }
           
        }
    }
}
