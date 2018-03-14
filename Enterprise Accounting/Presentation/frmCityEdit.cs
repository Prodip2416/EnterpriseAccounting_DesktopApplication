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
    public partial class frmCityEdit : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public int Id;
        public frmCityEdit()
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
            if (cmbCountry.SelectedValue == null || cmbCountry.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbCountry, "Required");
            }
            if (er > 0)
                return;

            DAL.City city = new DAL.City();
            city.Id = Id;
            city.Name = txtName.Text;
            city.CountryId = Convert.ToInt32(cmbCountry.SelectedValue);
            if (city.Update())
            {
                MessageBox.Show(@"Data Updated");
            }
            else
            {
                MessageBox.Show(city.Error);
            }
        }

        private void frmCityEdit_Load(object sender, EventArgs e)
        {
            this.MinimumSize = Size;
            this.MaximumSize = Size;

            Country country = new Country();
            cmbCountry.Source(country.Select());

            City city= new City();
            city.Id = Id;
            if (city.SelectById())
            {
                txtName.Text = city.Name;
                cmbCountry.SelectedValue = city.CountryId;
            }
        }
    }
}
