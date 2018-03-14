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
    public partial class frmCountryNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmCountryNew()
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

            if (er > 0)
                return;

            Country country = new Country();
            country.Name = txtName.Text;

            if (country.Insert())
            {
                MessageBox.Show("Data Saved.");
                txtName.Text = "";
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(country.Error);
            }
        }

        private void frmCountryNew_Load(object sender, EventArgs e)
        {
            this.MinimumSize = Size;
            this.MaximumSize = Size;
        }
    }
}
