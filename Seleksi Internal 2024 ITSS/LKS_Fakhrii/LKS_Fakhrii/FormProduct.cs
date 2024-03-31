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
    public partial class FormProduct : Form
    {
        String status = "";
        int currentSelectedRow = -1;
        public FormProduct()
        {
            InitializeComponent();
        }

        private void enabled(bool e)
        {
            tbName.Enabled = e;
            tbSpecification.Enabled = e;
            cbBrand.Enabled = e;
            tbPrice.Enabled = e;
            btninsert.Enabled = !e;
            btnUpdate.Enabled = !e;
            btnDelete.Enabled = !e;
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
        }

        private void loadDgv()
        {
            dgvProduct.Rows.Clear();
            getId();
            DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
            IQueryable<Product> products = db.Products.Where(x => x.Name.Contains(tbSearch.Text) || x.Brand.Name.Contains(tbSearch.Text)
            || x.Id.Contains(tbSearch.Text));
            foreach (Product product in products)
            {
                dgvProduct.Rows.Add(product.Id, product.Name, product.Brand.Name, product.Specification,product.Price,product.BrandId);
            }

        }

        private void loadCBRole()
        {
            DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
            cbBrand.DataSource = db.Brands;
            cbBrand.ValueMember = "Id";
            cbBrand.DisplayMember = "Name";
        }

        private void getId()
        {
            DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
            String lastId = db.Products.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            int id = lastId != null ? (int.Parse(lastId.Substring(2,4)) + 1) : 1;

            string result = $"PR{id.ToString().PadLeft(4, '0')}";

            tbProductId.Text = result;
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            loadDgv();
            loadCBRole();
            enabled(false);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            loadDgv();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectedRow = e.RowIndex;
            for (int i = 0; i < dgvProduct.Rows.Count; i++)
            {
                tbProductId.Text = dgvProduct.Rows[currentSelectedRow].Cells[0].Value.ToString();
                tbName.Text = dgvProduct.Rows[currentSelectedRow].Cells[1].Value.ToString();
                tbSpecification.Text = dgvProduct.Rows[currentSelectedRow].Cells[3].Value.ToString();
                cbBrand.SelectedValue = Convert.ToInt32(dgvProduct.Rows[currentSelectedRow].Cells[5].Value);
                tbPrice.Text = dgvProduct.Rows[currentSelectedRow].Cells[4].Value.ToString();
            }
        }

        private void clearFields()
        {
            getId();
            tbName.Text = "";
            tbSpecification.Text = "";
            cbBrand.Text = "";
            tbPrice.Text = "";
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            status = "insert";
            enabled(true);
            clearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentSelectedRow != -1)
            {
                status = "update";
                enabled(true);
            }
            else
            {
                MessageBox.Show("Click Row!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentSelectedRow != -1)
            {
                var dialog = MessageBox.Show("Yakin ingin menghapus data ini?", "Delete", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
                    Product product = db.Products.Where(x => x.Id.Equals(tbProductId.Text)).FirstOrDefault();
                    db.Products.DeleteOnSubmit(product);
                    db.SubmitChanges();
                    clearFields();
                    loadDgv();
                    currentSelectedRow = -1;
                }
            }
            else
            {
                MessageBox.Show("Click Row!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            status = "";
            enabled(false);
            clearFields();
            currentSelectedRow = -1;
        }

        private bool valid()
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Nama harus diisi");
                return false;
            }
            else if (tbSpecification.Text == "")
            {
                MessageBox.Show("Specification harus diisi");
                return false;
            }
            else if (tbPrice.Text == "")
            {
                MessageBox.Show("Price harus diisi");
                return false;
            }
            else if (Convert.ToInt32(tbPrice.Text) < 0)
            {
                MessageBox.Show("Price tidak boleh kurang dari 0");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                if (status == "insert")
                {
                    try
                    {
                        DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
                        Product product = new Product();
                        product.Id = tbProductId.Text;
                        product.Name = tbName.Text;
                        product.Specification = tbSpecification.Text;
                        product.BrandId = Convert.ToInt32(cbBrand.SelectedValue);
                        product.Price = Convert.ToInt32(tbPrice.Text);
                        db.Products.InsertOnSubmit(product);
                        db.SubmitChanges();
                        loadDgv();
                        enabled(false);
                        clearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (status == "update")
                {
                    try
                    {
                        DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
                        Product product = db.Products.Where(x => x.Id.Equals(tbProductId.Text)).FirstOrDefault();
                        product.Name = tbName.Text;
                        product.Specification = tbSpecification.Text;
                        product.BrandId = Convert.ToInt32(cbBrand.SelectedValue);
                        product.Price = Convert.ToInt32(tbPrice.Text);
                        db.SubmitChanges();
                        loadDgv();
                        enabled(false);
                        clearFields();
                        currentSelectedRow = -1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
