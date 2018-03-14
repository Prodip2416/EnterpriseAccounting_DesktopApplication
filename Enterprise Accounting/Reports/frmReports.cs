using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BDJ.Enterprise.Reports
{
    public partial class frmReports : Form
    {
        public frmReports(DataGridView dgv)
        {
            InitializeComponent();
            string s = "";

            s += loadHeader();

            s += "<table border='1'>";

            // Adding header...........
            for (int i = 0; i < 1; i++)
            {
                s += "<tr>";
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    s += String.Format("<th>{0}</th>", dgv.Columns[j].HeaderText);
                }
                s += "</tr>";
            }

            //Adding Rows,,,,,,,,,,,,,,,,,
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                s += "<tr>";
                for (int j = 0; j < dgv.Rows[i].Cells.Count; j++)
                {
                    s += "<td>" + dgv.Rows[i].Cells[j].Value + "</tr>";
                }
                s += "</tr>";
            }
            s += "</table>";
            s += loadFooter();
            webBrowser1.DocumentText = s;
        }



        private string loadFooter()
        {
            string s = @"<div class='footer'>Develop by Aushomapto</div>
                            </body> 
                     
                  </html> ";
            return s;
        }

        private string loadHeader()
        {
            string s = "";
            s = @"<html>
                    <head> <title>Report</title>
                    </head>
                   <body>
                  ";

            s += "<div class='header'>";
            s += String.Format("<h1>{0}</h1><h2>{1}</h2><h3>{2}</h3>", ACL.Name, ACL.Address, ACL.Address1);
            s += "</div>";
            return s;
        }

        private void frmReports_Load(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
