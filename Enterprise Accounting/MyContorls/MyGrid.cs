using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContorls
{
    public class MyGrid:DataGridView
    {
        public MyGrid():base()
        {
            this.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.AlternatingRowsDefaultCellStyle.BackColor=Color.MistyRose;
            this.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            this.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
           | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.ReadOnly = true;
        }
    }
}
