using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LKS_Fakhrii
{
    public partial class FormTransaction : Form
    {

        int currentSelectedRow = -1;
        int currentSelectedOrder = -1;
        
        public FormTransaction()
        {
            InitializeComponent();
        }
        private void loadDgv()
        {
            dgv1.Rows.Clear();
            DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
            IQueryable<Product> products = db.Products.Where(x => x.Name.Contains(tbSearch.Text) || x.Brand.Name.Contains(tbSearch.Text)
            || x.Id.Contains(tbSearch.Text));
            foreach (Product product in products)
            {
                dgv1.Rows.Add(product.Id, product.Name, product.Brand.Name, product.Specification, product.Price, product.BrandId);
            }

        }
        private void FormTransaction_Load(object sender, EventArgs e)
        {
            loadDgv();
            enableButton(false);
            btnRemove.Enabled = false;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            loadDgv();
        }

        private void enableButton(bool e)
        {
            btnAdd.Enabled = e;
            tbQty.Enabled = e;
        }


        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectedRow = e.RowIndex;
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                tbProductName.Text = dgv1.Rows[currentSelectedRow].Cells[0].Value.ToString();
                tbPrice.Text = dgv1.Rows[currentSelectedRow].Cells[4].Value.ToString();
            }
            tbQty.Text = "";
            enableButton(true);
        }

        private void generateTotal()
        {
            int a = 0;
            for(int i = 0; i < dgvOrder.Rows.Count; i++)
            {
                a += Convert.ToInt32(dgvOrder.Rows[i].Cells[4].Value);
            }

            labelTotal.Text = a.ToString("N");
        }

        private void clearAll()
        {
            tbProductName.Text = "";
            tbQty.Text = "";
            tbPrice.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbQty.Text) < 0)
            {
                MessageBox.Show("Qty harus lebih dari 0");
            }
            else
            {
                dgvOrder.Rows.Add(
                        tbProductName.Text,
                        dgv1.Rows[currentSelectedRow].Cells[1].Value.ToString(),
                        tbQty.Text,
                        tbPrice.Text,
                        Convert.ToInt32(tbQty.Text) * Convert.ToInt32(tbPrice.Text));
                clearAll();
                generateTotal();
            }
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectedOrder = e.RowIndex;
            btnRemove.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(currentSelectedOrder != -1)
            {
                dgvOrder.Rows.RemoveAt(currentSelectedOrder);
                generateTotal();
                currentSelectedOrder = -1;
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin dihapus");
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            FormPayment formPayment = new FormPayment(dgvOrder,labelTotal.Text);
            formPayment.Show();
        }
    }
}
