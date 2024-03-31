using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKS_Fakhrii
{
    public partial class FormPayment : Form
    {
        private DataGridView row;
        String total;
        public FormPayment(DataGridView row, String total)
        {
            InitializeComponent();
            this.row = row;
            this.total = total;
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            totalLabel.Text = total;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
            Member member = db.Members.Where(x=> x.Id.Equals(tbCheckMember.Text)).FirstOrDefault();
            if (member != null)
            {
                btnCheck.Enabled = false;
            }
            else
            {
                MessageBox.Show("Member tidak ada");
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (cashRB.Checked)
                {

                    DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
                    TransactionHeader transactionHeader = new TransactionHeader();

                    string lastId = db.TransactionHeaders.OrderByDescending(x => x.Id).FirstOrDefault().Id;

                    int id = lastId != null ? (int.Parse(lastId.Substring(6, 5)) + 1) : 1;

                    string result = $"{DateTime.Now.Year.ToString()}{DateTime.Now.Month.ToString().PadLeft(2,'0')}{id.ToString().PadLeft(5, '0')}";

                    transactionHeader.Id = result;
                    transactionHeader.EmployeeId = DataStorage.EmployeeID;
                    transactionHeader.MemberId = tbCheckMember.Text;
                    transactionHeader.Date = DateTime.Now;
                    transactionHeader.PaymentType = "Cash";
                    db.TransactionHeaders.InsertOnSubmit(transactionHeader);
                    db.SubmitChanges();

                    for (int i = 0; i < row.Rows.Count -1; i++)
                    {
                        DataLKSFakhriDataContext db2 = new DataLKSFakhriDataContext();
                        TransactionDetail transactionDetail = new TransactionDetail();
                        transactionDetail.TransactionHeaderId = result;
                        transactionDetail.ProductId = row.Rows[i].Cells[0].Value.ToString();
                        transactionDetail.Qty = Convert.ToInt32(row.Rows[i].Cells[2].Value);
                        transactionDetail.Price = Convert.ToInt32(row.Rows[i].Cells[3].Value);
                        db2.TransactionDetails.InsertOnSubmit(transactionDetail); 
                        db2.SubmitChanges();
                        this.Hide();
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
