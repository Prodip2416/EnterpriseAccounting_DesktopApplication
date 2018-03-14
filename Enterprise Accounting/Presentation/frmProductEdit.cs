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
    public partial class frmProductEdit : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public int Id;
        public frmProductEdit()
        {
            InitializeComponent();
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
            if (txtCode.Text == "")
            {
                er++;
                ep.SetError(txtCode, "Required");
            }
            if (txtType.Text == "")
            {
                er++;
                ep.SetError(txtOffer, "Required");
            }
            if (txtTag.Text == "")
            {
                er++;
                ep.SetError(txtTag, "Required");
            }

            if (txtDiscount.Text == "")
            {
                er++;
                ep.SetError(txtDiscount, "Required");
            }
            if (cmbCategory.SelectedValue == null || cmbCategory.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbCategory, "Select One");
            }
            if (cmbBrand.SelectedValue == null || cmbBrand.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbBrand, "Select One");
            }
            if (er > 0)
                return;

            DAL.Product p = new DAL.Product();
            p.Id = Id;
            p.BrandId = Convert.ToInt32(cmbBrand.SelectedValue);
            p.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            p.Code = txtCode.Text;
            p.Description = txtDescription.Text;
            p.Discount = Convert.ToDouble(txtDiscount.Text);
            p.Name = txtName.Text;
            p.Offers = txtOffer.Text;
            p.Tag = txtTag.Text;
            p.Type = txtType.Text;
            if (p.Update())
            {
                MessageBox.Show("Data Saved");
            }
            else
            {
                MessageBox.Show(p.Error);
            }
        }

        private void frmProductEdit_Load(object sender, EventArgs e)
        {
            this.MinimumSize = Size;
            this.MaximumSize = Size;

            Category category= new Category();
            cmbCategory.Source(category.Select());

            Brand brand= new Brand();
            cmbBrand.Source(brand.Select());

            Product product= new Product();
            product.Id = Id;

            if (product.SelectById())
            {
                txtName.Text = product.Name;
                txtCode.Text = product.Code;
                txtDescription.Text = product.Description;
                txtDiscount.Text = product.Discount.ToString();
                txtTag.Text = product.Tag;
                txtType.Text = product.Type;
                txtOffer.Text = product.Offers;
                cmbBrand.SelectedValue = product.BrandId;
                cmbCategory.SelectedValue = product.CategoryId;
            }
        }
    }
}
