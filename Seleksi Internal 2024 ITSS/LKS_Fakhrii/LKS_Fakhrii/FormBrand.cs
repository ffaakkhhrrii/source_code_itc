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
    public partial class FormBrand : Form
    {
        string status = "";
        int currentSelectedRow = -1;
        public FormBrand()
        {
            InitializeComponent();
        }

        private void loadDgv()
        {
            dgvBrand.Rows.Clear();
            getId();
            DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
            IQueryable<Brand> brands = db.Brands.Where(x => x.Name.Contains(tbSearch.Text));
            foreach (Brand brand in brands)
            {
                dgvBrand.Rows.Add(brand.Id, brand.Name);
            }

        }

        private void getId()
        {
            DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
            int lastId = db.Brands.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;

            tbBrandId.Text = lastId.ToString();
        }

        private void FormBrand_Load(object sender, EventArgs e)
        {
            loadDgv();
            enabled(false);
        }

        private void dgvBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectedRow = e.RowIndex;
            for (int i = 0; i < dgvBrand.Rows.Count; i++)
            {
                tbBrandId.Text = dgvBrand.Rows[currentSelectedRow].Cells[0].Value.ToString();
                tbName.Text = dgvBrand.Rows[currentSelectedRow].Cells[1].Value.ToString();
            }
        }

        private void enabled(bool e)
        {
            tbName.Enabled = e;
            btninsert.Enabled = !e;
            btnUpdate.Enabled = !e;
            btnDelete.Enabled = !e;
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            loadDgv();
        }

        private void clearFields()
        {
            getId();
            tbName.Text = "";
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            getId();
            status = "insert";
            clearFields();
            enabled(true);
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
                    Brand brand = db.Brands.Where(x => x.Id.Equals(tbBrandId.Text)).FirstOrDefault();
                    db.Brands.DeleteOnSubmit(brand);
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

        private bool valid()
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Nama harus diisi");
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
                        Brand brand = new Brand();
                        brand.Name = tbName.Text;
                        db.Brands.InsertOnSubmit(brand);
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
                        Brand brand = db.Brands.Where(x => x.Id.Equals(tbBrandId.Text)).FirstOrDefault();
                        brand.Name = tbName.Text;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            status = "";
            enabled(false);
            clearFields();
            currentSelectedRow = -1;
        }
    }
}
