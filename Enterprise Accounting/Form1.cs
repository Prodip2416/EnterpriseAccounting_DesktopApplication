using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BDJ.Enterprise.Presentation;
using DAL;

namespace BDJ.Enterprise
{
    public partial class Form1 : Form
    {
        frmCity city = new frmCity();
        frmHead head = new frmHead();
        frmCategory category = new frmCategory();
        frmCountry country = new frmCountry();
        frmProduct product = new frmProduct();
        frmProductPrice productPrice = new frmProductPrice();
        frmProductImage productImage = new frmProductImage();
        frmLedger ledger = new frmLedger();
        frmBrand brand = new frmBrand();
        frmUnit unit = new frmUnit();
        frmVoucher voucher = new frmVoucher();
        frmFormula formula = new frmFormula();
        frmProductManual productManual = new frmProductManual();
        frmPurchase purchase= new frmPurchase();
        frmSales sales= new frmSales();
        frmDamage damage= new frmDamage();
        frmProduction production= new frmProduction();






        frmCashFlow cashFlow= new frmCashFlow(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Login.............

            ACL.Name = "Enterprice Accounting";
            ACL.Address = "Email : abcd@gmail.com";
            ACL.Address1 = " Dhaka Bangladesh";





            Voucher v = new Voucher();
            DataTable dt = v.Select().Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ToolStripMenuItem tsm = new ToolStripMenuItem();
                tsm.Text = dt.Rows[i].ItemArray[1].ToString();
                tsm.Tag = dt.Rows[i].ItemArray[0].ToString();
                tsm.Click += Tsm_Click;
                mnuVoucher.DropDownItems.Add(tsm);
            }
        }

        private void Tsm_Click(object sender, EventArgs e)
        {
            frmJournal journal = new frmJournal();
            journal.VouncherId = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);
            journal.MdiParent = this;
            journal.Text = ((ToolStripMenuItem) sender).Text;
            journal.Show();
            journal.BringToFront();
        }

        private void cityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (city.IsDisposed)
                city = new frmCity();
            city.BringToFront();
            city.MdiParent = this;
            city.Show();

        }

        private void headToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (head.IsDisposed)
                head = new frmHead();
            head.MdiParent = this;
            head.Show();
            head.BringToFront();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (category.IsDisposed)
                category = new frmCategory();
            category.MdiParent = this;
            category.BringToFront();
            category.Show();
        }

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (country.IsDisposed)
                country = new frmCountry();
            country.MdiParent = this;
            country.BringToFront();
            country.Show();
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (product.IsDisposed)
                product = new frmProduct();
            product.MdiParent = this;
            product.BringToFront();
            product.Show();
        }

        private void priceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productPrice.IsDisposed)
                productPrice = new frmProductPrice();
            productPrice.MdiParent = this;
            productPrice.Show();
            productPrice.BringToFront();
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productImage.IsDisposed)
                productImage = new frmProductImage();
            productImage.MdiParent = this;
            productImage.Show();
            productImage.BringToFront();
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ledger.IsDisposed)
                ledger = new frmLedger();
            ledger.MdiParent = this;
            ledger.Show();
            ledger.BringToFront();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (brand.IsDisposed)
                brand = new frmBrand();
            brand.MdiParent = this;
            brand.Show();
            brand.BringToFront();
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (unit.IsDisposed)
                unit = new frmUnit();
            unit.MdiParent = this;
            unit.Show();
            unit.BringToFront();
        }

        private void voucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (voucher.IsDisposed)
                voucher = new frmVoucher();
            voucher.MdiParent = this;
            voucher.Show();
            voucher.BringToFront();
        }

        private void formulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formula.IsDisposed)
                formula = new frmFormula();
            formula.MdiParent = this;
            formula.Show();
            formula.BringToFront();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productManual.IsDisposed)
                productManual = new frmProductManual();
            productManual.MdiParent = this;
            productManual.Show();
            productManual.BringToFront();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void parchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(purchase.IsDisposed)
                purchase= new frmPurchase();
            purchase.MdiParent = this;
            purchase.Show();
            purchase.BringToFront();
        }

        private void cashFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(cashFlow.IsDisposed)
                cashFlow=new frmCashFlow();
            cashFlow.MdiParent = this;
            cashFlow.Show();
            cashFlow.BringToFront();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(sales.IsDisposed)
                sales= new frmSales();
            sales.MdiParent = this;
            sales.Show();
            sales.BringToFront();
        }

        private void damageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(damage.IsDisposed)
                damage= new frmDamage();
            damage.MdiParent = this;
            damage.Show();
            damage.BringToFront();
        }

        private void productionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(production.IsDisposed)
                production= new frmProduction();
            production.MdiParent = this;
            production.Show();
            production.BringToFront();
        }
    }
}
