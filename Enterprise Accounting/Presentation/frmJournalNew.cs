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
    public partial class frmJournalNew : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public int VoucherId { get; set; }  
        private Voucher voucher= new Voucher();
        public frmJournalNew()
        {
            InitializeComponent();
        }

        private void frmJournalNew_Load(object sender, EventArgs e)
        {
            Ledger l= new Ledger();
            cmbLedger.Source(l.Select());
            cmbEmployeeLedger.Source(l.Select());

            cmbVoucher.Source(new Voucher().Select());
            cmbVoucher.SelectedValue =VoucherId;

            colLedger.DataSource = l.Select().Tables[0];
            colLedger.DisplayMember = "name";
            colLedger.ValueMember = "id";

            voucher.Id = VoucherId;
            voucher.SelectById();

            this.MaximumSize = Size;
            this.MaximumSize = Size;

            loadNumber();
        }

        private void loadNumber()
        {
            if (voucher.AutoNumber)
            {
                txtNumber.ReadOnly = true;
                string s = voucher.Prefix;
                for (int i = 0;
                    i <
                    voucher.Length - voucher.Prefix.Length - voucher.Postfix.Length - voucher.CurrentNumber.ToString().Length;
                    i++)
                {
                    s += "0";
                }
                s += voucher.CurrentNumber.ToString() + voucher.Postfix;
                txtNumber.Text = s;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbLedger_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            int er = 0;

            if (txtNumber.Text == "")
            {
                er++;
                ep.SetError(txtNumber, "Required");
            }
            if (cmbLedger.SelectedValue == null || cmbLedger.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbLedger, "Select");
            }

            if (dgvDetails.Rows.Count < 2)
            {
                er++;
                ep.SetError(dgvDetails, "Enter Details");
            }

            if (er > 0)
                return;

            DAL.Journal jr = new DAL.Journal();

            jr.Date = dtpDateTime.Value;
            jr.EmpoloyeeId = Convert.ToInt32(cmbEmployeeLedger.SelectedValue);
            jr.LedgerId = Convert.ToInt32(cmbLedger.SelectedValue);
            jr.Number = txtNumber.Text;
            jr.ReMarks = txtRemarks.Text;
            jr.VoucherId = Convert.ToInt32(cmbVoucher.SelectedValue);

            if (voucher.Nature == "Debit")
            {
                jr.Debit = 0;
                jr.Credit = 100;
            }
            else
            {
                jr.Credit = 0;
                jr.Debit = 100;
            }

            if (jr.Insert())
            {
                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                {
                    try
                    {
                        JournalDetails jrd = new JournalDetails();
                        jrd.JournalId = jr.LastId;
                        jrd.LedgerId = Convert.ToInt32(dgvDetails.Rows[i].Cells["colLedger"].Value);
                        jrd.Remarks = dgvDetails.Rows[i].Cells["colRemarks"].Value.ToString();
                        if (voucher.Nature == "Debit")
                        {
                            jrd.Credit = 0;
                            jrd.Debit = Convert.ToDecimal(dgvDetails.Rows[i].Cells["colAmount"].Value);
                        }
                        else
                        {
                            jrd.Credit = Convert.ToDecimal(dgvDetails.Rows[i].Cells["colAmount"].Value);
                            jrd.Debit = 0;
                        }
                        jrd.Insert();
                    }
                    catch { }
                }
                MessageBox.Show(voucher.Name + @" Journal Inserted");
                voucher.CurrentNumber += 1;
                voucher.Update();
               
                MyContorls.Hylper.Clear(this);
                dgvDetails.Rows.Clear();
                loadNumber();

            }
            else
            {
                MessageBox.Show(jr.Error);
            }
        }
    }
}
