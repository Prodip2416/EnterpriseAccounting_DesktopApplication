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
    public partial class frmHeadEdit : BDJ.Enterprise.Presentation.frmNewEdit
    {
        public int Id;
        public frmHeadEdit()
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

            if (er > 0)
                return;

            DAL.Head head = new DAL.Head();
           
            head.Id = Id;
          

            head.Name = txtName.Text;
            head.Description = txtDescription.Text;

            if (cmbHead.SelectedValue != null && cmbHead.SelectedValue.ToString() != "")
                head.HeadId = Convert.ToInt32(cmbHead.SelectedValue);

            if (head.Update())
            {
                MessageBox.Show("Data Saved");
            }
            else
            {
                MessageBox.Show(head.Error);
            }
        }

        private void frmHeadEdit_Load(object sender, EventArgs e)
        {
            this.MinimumSize = Size;
            this.MaximumSize = Size;

            DAL.Head head = new DAL.Head();
            cmbHead.Items.Add("Select");
            cmbHead.Source(head.Select());
         
      

            head.Id = Id;
            if (head.SelectById())
            {
                txtName.Text = head.Name;
                txtDescription.Text = head.Description;
                cmbHead.SelectedValue = head.HeadId;
             
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }
    }
}
