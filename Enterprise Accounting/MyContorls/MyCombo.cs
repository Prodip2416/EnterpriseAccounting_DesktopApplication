using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContorls
{
    public class MyCombo:ComboBox
    {
        public MyCombo():base()
        {
            this.AutoCompleteMode=AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource=AutoCompleteSource.ListItems;
        }

        public bool Source(DataSet ds, string Display = "name", string value = "id")
        {
            this.DataSource = ds.Tables[0];
            this.DisplayMember = Display;
            this.ValueMember = value;
            this.SelectedValue = -1;
           
            return true;
        }
     
    }
}
