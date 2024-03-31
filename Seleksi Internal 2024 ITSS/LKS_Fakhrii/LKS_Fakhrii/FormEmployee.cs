using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LKS_Fakhrii
{
    public partial class FormEmployee : Form
    {
        string status = "";
        int currentSelectedRow = -1;
        public FormEmployee()
        {
            InitializeComponent();
        }

        private void loadCBRole()
        {
            DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
            cbPosition.DataSource = db.Roles;
            cbPosition.ValueMember = "Id";
            cbPosition.DisplayMember = "Name";
        }

        private void enabled(bool e)
        {
            tbName.Enabled = e;
            tbEmail.Enabled = e;
            tbPhoneNumber.Enabled = e;
            dateEmployee.Enabled = e;
            cbPosition.Enabled = e;
            tbConfirmPassword.Enabled = e;
            tbPassword.Enabled = e;
            btninsert.Enabled = !e;
            btnUpdate.Enabled = !e;
            btnDelete.Enabled = !e;
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
        }

        private void loadDgv()
        {
            dgvEmployee.Rows.Clear();
            getId();
            DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
            IQueryable<Employee> employees = db.Employees.Where(x => x.Name.Contains(tbSearch.Text)
            || x.Email.Contains(tbSearch.Text) || x.PhoneNumber.Contains(tbSearch.Text));
            foreach (Employee employee in employees)
            {
                dgvEmployee.Rows.Add(employee.Id, employee.Name, employee.Email, employee.PhoneNumber,employee.BirthDate,employee.Password,employee.PositionId);
            }

        }

        private void getId()
        {
            DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
            int lastId = db.Employees.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;

            tbEmployeeId.Text = lastId.ToString();
        }

        private void clearFields()
        {
            getId();
            tbName.Text = "";
            tbEmail.Text = "";
            tbPhoneNumber.Text = "";
            dateEmployee.Value = DateTime.Now;
            cbPosition.SelectedIndex = -1;
            tbPassword.Text = "";
            tbConfirmPassword.Text = "";
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            loadDgv();
            loadCBRole();
            enabled(false);
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectedRow = e.RowIndex;
            for (int i = 0; i < dgvEmployee.Rows.Count; i++)
            {
                tbEmployeeId.Text = dgvEmployee.Rows[currentSelectedRow].Cells[0].Value.ToString();
                tbName.Text = dgvEmployee.Rows[currentSelectedRow].Cells[1].Value.ToString();
                tbEmail.Text = dgvEmployee.Rows[currentSelectedRow].Cells[2].Value.ToString();
                tbPhoneNumber.Text = dgvEmployee.Rows[currentSelectedRow].Cells[3].Value.ToString();
                dateEmployee.Text = dgvEmployee.Rows[currentSelectedRow].Cells[4].Value.ToString();
                cbPosition.SelectedValue = Convert.ToInt32(dgvEmployee.Rows[currentSelectedRow].Cells[6].Value);
                tbPassword.Text = dgvEmployee.Rows[currentSelectedRow].Cells[5].Value.ToString();
            }
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
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
                    Employee employee = db.Employees.Where(x => x.Id.Equals(tbEmployeeId.Text)).FirstOrDefault();
                    db.Employees.DeleteOnSubmit(employee);
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

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            loadDgv();
        }

        private bool valid()
        {
            if (tbName.Text == "")
            {
                MessageBox.Show("Nama harus diisi");
                return false;
            }
            else if (tbEmail.Text == "")
            {
                MessageBox.Show("Email harus diisi");
                return false;
            }
            else if (tbPhoneNumber.Text == "")
            {
                MessageBox.Show("Phone harus diisi");
                return false;
            }else if(tbPassword.Text != tbConfirmPassword.Text)
            {
                MessageBox.Show("Password dan Confirm Password harus sama");
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
                        Employee employee = new Employee();
                        employee.Name = tbName.Text;
                        employee.Email = tbEmail.Text;
                        employee.PhoneNumber = tbPhoneNumber.Text;
                        employee.Password = tbPassword.Text;
                        employee.PositionId = Convert.ToInt32(cbPosition.SelectedValue);
                        employee.BirthDate = Convert.ToDateTime(dateEmployee.Value);
                        db.Employees.InsertOnSubmit(employee);
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
                        Employee employee = db.Employees.Where(x => x.Id.Equals(tbEmployeeId.Text)).FirstOrDefault();
                        employee.Name = tbName.Text;
                        employee.Email = tbEmail.Text;
                        employee.PhoneNumber = tbPhoneNumber.Text;
                        employee.BirthDate = Convert.ToDateTime(dateEmployee.Value);
                        employee.Password = tbPassword.Text;
                        employee.PositionId = Convert.ToInt32(cbPosition.SelectedValue);
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
    }
}
