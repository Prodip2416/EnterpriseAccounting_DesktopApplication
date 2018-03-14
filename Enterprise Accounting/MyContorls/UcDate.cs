using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContorls
{
    public partial class UcDate : UserControl
    {
        public UcDate()
        {
            InitializeComponent();
            dateTimePicker1.Enabled = chkDateSearch.Checked;
            dateTimePicker2.Enabled = chkDateSearch.Checked;
        }

        public DateTime DateFrom
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }
        public DateTime DateTo
        {
            get { return dateTimePicker2.Value; }
            set { dateTimePicker2.Value = value; }
        }

        private void chkDateSearch_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = chkDateSearch.Checked;
            dateTimePicker2.Enabled = chkDateSearch.Checked;
        }
    }
}
