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
    public partial class frmDamageNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmDamageNew()
        {
            InitializeComponent();
        }

        private void frmDamageNew_Load(object sender, EventArgs e)
        {
            this.MinimumSize = Size;
            this.MaximumSize = Size;

            MyContorls.Hylper.Numeric(txtQuentity);

            Product product = new Product();
            cmbProduct.Source(product.Select());

            Ledger ledger= new Ledger();
            cmbEmployee.Source(ledger.Select());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            int er = 0;
            if (cmbProduct.SelectedValue == null || cmbProduct.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbProduct,"Select One");
            }
            if (cmbEmployee.SelectedValue == null || cmbEmployee.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbEmployee, "Select One");
            }
            if (txtRemarks.Text == "")
            {
                er++;
                ep.SetError(txtRemarks,"Required");
            }
            if (txtQuentity.Text == "")
            {
                er++;
                ep.SetError(txtQuentity, "Required");
            }

            if (er > 0)
                return;

            Damage damage= new Damage();
            damage.ProductId = Convert.ToInt32(cmbProduct.SelectedValue);
            damage.DateTime = dtDateTime.Value;
            damage.Quentity = Convert.ToDouble(txtQuentity.Text);
            damage.Remark = txtRemarks.Text;
            damage.EmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue);

            if (damage.Insert())
            {
                MessageBox.Show(@"Data Saved");
                MyContorls.Hylper.Clear(this);
                cmbProduct.Focus();
            }
            else
            {
                MessageBox.Show(damage.Error);
            }
        }
    }
}
