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
    public partial class frmLedgerEdit : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public int Id;
        public frmLedgerEdit()
        {
            InitializeComponent();
        }

        private void frmLedgerEdit_Load(object sender, EventArgs e)
        {
            this.MinimumSize = Size;
            this.MaximumSize = Size;


            Head head =new Head();
            cmbHead.Source(head.Select());
           
            Ledger ledger= new Ledger();
            cmbEmployee.Source(ledger.Select());

            ledger.Id = Id;
            if (ledger.SelectById())
            {
                txtName.Text = ledger.Name;
                txtContact.Text = ledger.Contact;
                txtContactPerson.Text = ledger.ContactPerson;
                txtEmail.Text = ledger.Email;
                txtPassword.Text = ledger.Password;
                txtAddress.Text = ledger.Address;
                txtDescription.Text = ledger.Description;
                cmbHead.SelectedValue = ledger.HeadId;
                
                dtpDate.Value = ledger.CreateDate;
                cmbEmployee.SelectedValue = ledger.EmployeeId;
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
            ledger.Id = Id;
            ledger.Name = txtName.Text;
            ledger.Contact = txtContact.Text;
            ledger.ContactPerson = txtContactPerson.Text;
            ledger.Address = txtAddress.Text;
            ledger.Description = txtDescription.Text;
            ledger.Email = txtEmail.Text;
            ledger.EmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
            ledger.Password = txtPassword.Text;
            ledger.HeadId = Convert.ToInt32(cmbHead.SelectedValue);
            ledger.CreateDate = dtpDate.Value;

            if (ledger.Update())
            {
                MessageBox.Show(@"Data Updated");

            }
            else
            {
                MessageBox.Show(ledger.Error);
            }
        }
    }
}
