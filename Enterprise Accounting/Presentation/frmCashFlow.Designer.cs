namespace BDJ.Enterprise.Presentation
{
    partial class frmCashFlow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCashFlow = new MyContorls.MyGrid();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLedger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVoucher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDLedger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDdebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucDate1 = new MyContorls.UcDate();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashFlow)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(666, 25);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(757, 25);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(838, 25);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(920, 25);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(1001, 25);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgvCashFlow
            // 
            this.dgvCashFlow.AllowUserToAddRows = false;
            this.dgvCashFlow.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            this.dgvCashFlow.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCashFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCashFlow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCashFlow.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvCashFlow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashFlow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colLedger,
            this.colVoucher,
            this.colNumber,
            this.colDate,
            this.colCredit,
            this.colDebit,
            this.colEmployee,
            this.colRemarks,
            this.colDLedger,
            this.colDdebit,
            this.colDCredit,
            this.colDRemarks});
            this.dgvCashFlow.Location = new System.Drawing.Point(-1, 89);
            this.dgvCashFlow.Name = "dgvCashFlow";
            this.dgvCashFlow.ReadOnly = true;
            this.dgvCashFlow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashFlow.Size = new System.Drawing.Size(1091, 390);
            this.dgvCashFlow.TabIndex = 2;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colLedger
            // 
            this.colLedger.DataPropertyName = "ledger";
            this.colLedger.HeaderText = "Ledger";
            this.colLedger.Name = "colLedger";
            this.colLedger.ReadOnly = true;
            // 
            // colVoucher
            // 
            this.colVoucher.DataPropertyName = "voucher";
            this.colVoucher.HeaderText = "Voucher";
            this.colVoucher.Name = "colVoucher";
            this.colVoucher.ReadOnly = true;
            // 
            // colNumber
            // 
            this.colNumber.DataPropertyName = "number";
            this.colNumber.HeaderText = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "date";
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colCredit
            // 
            this.colCredit.DataPropertyName = "credit";
            this.colCredit.HeaderText = "Credit";
            this.colCredit.Name = "colCredit";
            this.colCredit.ReadOnly = true;
            // 
            // colDebit
            // 
            this.colDebit.DataPropertyName = "debit";
            this.colDebit.HeaderText = "Debit";
            this.colDebit.Name = "colDebit";
            this.colDebit.ReadOnly = true;
            // 
            // colEmployee
            // 
            this.colEmployee.DataPropertyName = "employee";
            this.colEmployee.HeaderText = "Employee";
            this.colEmployee.Name = "colEmployee";
            this.colEmployee.ReadOnly = true;
            // 
            // colRemarks
            // 
            this.colRemarks.DataPropertyName = "remarks";
            this.colRemarks.HeaderText = "Remarks";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            // 
            // colDLedger
            // 
            this.colDLedger.DataPropertyName = "DLedger";
            this.colDLedger.HeaderText = "DLedger";
            this.colDLedger.Name = "colDLedger";
            this.colDLedger.ReadOnly = true;
            // 
            // colDdebit
            // 
            this.colDdebit.DataPropertyName = "Ddebit";
            this.colDdebit.HeaderText = "DDebit";
            this.colDdebit.Name = "colDdebit";
            this.colDdebit.ReadOnly = true;
            // 
            // colDCredit
            // 
            this.colDCredit.DataPropertyName = "Dcredit";
            this.colDCredit.HeaderText = "DCredit";
            this.colDCredit.Name = "colDCredit";
            this.colDCredit.ReadOnly = true;
            // 
            // colDRemarks
            // 
            this.colDRemarks.DataPropertyName = "Dremarks";
            this.colDRemarks.HeaderText = "DRemarks";
            this.colDRemarks.Name = "colDRemarks";
            this.colDRemarks.ReadOnly = true;
            // 
            // ucDate1
            // 
            this.ucDate1.BackColor = System.Drawing.Color.Transparent;
            this.ucDate1.DateFrom = new System.DateTime(2017, 12, 3, 18, 6, 6, 2);
            this.ucDate1.DateTo = new System.DateTime(2017, 12, 3, 18, 6, 5, 999);
            this.ucDate1.Location = new System.Drawing.Point(153, 4);
            this.ucDate1.Name = "ucDate1";
            this.ucDate1.Size = new System.Drawing.Size(408, 79);
            this.ucDate1.TabIndex = 3;
            // 
            // frmCashFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1088, 481);
            this.Controls.Add(this.ucDate1);
            this.Controls.Add(this.dgvCashFlow);
            this.MinimumSize = new System.Drawing.Size(751, 520);
            this.Name = "frmCashFlow";
            this.Text = "DashBoard[CashFlow]";
            this.Load += new System.EventHandler(this.frmCashFlow_Load);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.dgvCashFlow, 0);
            this.Controls.SetChildIndex(this.ucDate1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashFlow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyContorls.MyGrid dgvCashFlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLedger;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoucher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDLedger;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDdebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDRemarks;
        private MyContorls.UcDate ucDate1;
    }
}
