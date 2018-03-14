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
    public partial class frmCountryEdit : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public int Id;
        public frmCountryEdit()
        {

            InitializeComponent(); 
        }

        private void frmCountryEdit_Load(object sender, EventArgs e)

        {
            this.MinimumSize = Size;
            this.MaximumSize = Size;

            Country country = new Country();
            country.Id = Id;
            if (country.SelectById())
            {
                txtName.Text = country.Name;
            }
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
            if (er > 0)
                return;

            Country country = new Country();
            country.Id = Id;
            country.Name = txtName.Text;

            if (country.Update())
            {
                MessageBox.Show("Updated");
              
            }
            else
            {
                MessageBox.Show(country.Error);
            }
        }
    }
}
