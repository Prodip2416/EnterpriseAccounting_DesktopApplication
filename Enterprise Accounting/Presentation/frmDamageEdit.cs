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
    public partial class frmDamageEdit : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public int Id;
        public frmDamageEdit()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            int er = 0;
            if (cmbProduct.SelectedValue == null || cmbProduct.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbProduct, "Select One");
            }
            if (cmbEmployee.SelectedValue == null || cmbEmployee.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbEmployee, "Select One");
            }
            if (txtRemarks.Text == "")
            {
                er++;
                ep.SetError(txtRemarks, "Required");
            }
            if (txtQuentity.Text == "")
            {
                er++;
                ep.SetError(txtQuentity, "Required");
            }

            if (er > 0)
                return;

            Damage damage = new Damage();
            damage.Id = Id;
            damage.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
            damage.DateTime = dtDateTime.Value;
            damage.Quentity = Convert.ToDouble(txtQuentity.Text);
            damage.Remark = txtRemarks.Text;
            damage.EmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue);

            if (damage.Update())
            {
                MessageBox.Show(@"Data Saved");
            }
            else
            {
                MessageBox.Show(damage.Error);
            }
        }

        private void frmDamageEdit_Load(object sender, EventArgs e)
        {
            Product product = new Product();
            cmbProduct.Source(product.Select());

            Ledger ledger = new Ledger();
            cmbEmployee.Source(ledger.Select());

            Damage damage= new Damage();
            damage.Id = Id;
            if (damage.SelectById())
            {
                cmbProduct.SelectedValue = damage.ProductId;
                dtDateTime.Value = damage.DateTime;
                txtQuentity.Text = damage.Quentity.ToString();
                txtRemarks.Text = damage.Remark;
                cmbEmployee.SelectedValue = damage.EmployeeId;
            }
        }
    }
}
