using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace BDJ.Enterprise.Presentation
{
    public partial class frmLedgerNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public frmLedgerNew()
        {
            InitializeComponent();
        }

        private void frmLedgerNew_Load(object sender, EventArgs e)
        {
            DAL.Head head = new DAL.Head();
            cmbHead.Source(head.Select());

            Country country= new Country();
            cmbCountry.Source(country.Select());

            Ledger ledger= new Ledger();
            cmbEmployee.Source(ledger.Select());

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
            if (txtContact.Text == "")
            {
                er++;
                ep.SetError(txtContact, "Required");

            }
            if (txtDescription.Text == "")
            {
                er++;
                ep.SetError(txtDescription, "Required");
            }
            if (txtAddress.Text == "")
            {
                er++;
                ep.SetError(txtAddress, "Required");
            }
            if (txtContactPerson.Text == "")
            {
                er++;
                ep.SetError(txtContactPerson, "Required");
            }
            if (txtContactPerson.Text == "")
            {
                er++;
                ep.SetError(txtContactPerson, "Required");
            }

            if (txtPassword.Text == "")
            {
                er++;
                ep.SetError(txtPassword, "Required");
            }
            if (cmbCity.SelectedValue == null || cmbCity.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbCity, "Required");
            }
            if (cmbHead.SelectedValue == null || cmbHead.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbHead, "Required");
            }
            if (cmbEmployee.SelectedValue == null || cmbEmployee.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbEmployee, "Required");
            }

            if (er > 0)
                return;

            DAL.Ledger ledger = new DAL.Ledger();
            ledger.Name = txtName.Text;
            ledger.Contact = txtContact.Text;
            ledger.ContactPerson = txtContactPerson.Text;
            ledger.Address = txtAddress.Text;
            ledger.Description = txtDescription.Text;
            ledger.Email = txtEmail.Text;
            ledger.EmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
            ledger.Password = txtPassword.Text;
            ledger.HeadId = Convert.ToInt32(cmbHead.SelectedValue);
            ledger.CityId = Convert.ToInt32(cmbCity.SelectedValue);
            ledger.CountryId = Convert.ToInt32(cmbCountry.SelectedValue);
            ledger.CreateDate = dtpDate.Value;

            if (ledger.Insert())
            {
                MessageBox.Show("Data Saved");
                MyContorls.Hylper.Clear(this);
                txtName.Focus();

            }
            else
            {
                MessageBox.Show(ledger.Error);
            }
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? countryId = cmbCountry.SelectedValue as int?;
            if (countryId == null)
                return;
            DAL.City city = new DAL.City();
            cmbCity.Source(city.SelectCountry(countryId));
        }
    }
}
