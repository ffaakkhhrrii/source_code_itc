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
    public partial class FormMember : Form
    {
        string status = "";
        int currentSelectedRow = -1;

        public FormMember()
        {
            InitializeComponent();
        }

        private void loadDgv()
        {
            dgvMember.Rows.Clear();
            getId();
            DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
            IQueryable<Member> members = db.Members.Where(x => x.Name.Contains(tbSearch.Text)
            || x.Email.Contains(tbSearch.Text)|| x.PhoneNumber.Contains(tbSearch.Text));
            foreach (Member member in members)
            {
                dgvMember.Rows.Add(member.Id, member.Name, member.Email, member.PhoneNumber);
            }

        }

        private void FormMember_Load(object sender, EventArgs e)
        {
            loadDgv();
            enabled(false);
            getId();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            loadDgv();
        }

        private void clearFields()
        { 
            getId();
            tbName.Text = "";
            tbEmail.Text = "";
            tbPhoneNumber.Text = "";
        }

        private void dgvMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectedRow = e.RowIndex;
            for(int i = 0; i < dgvMember.Rows.Count; i++)
            {
                tbMemberId.Text = dgvMember.Rows[currentSelectedRow].Cells[0].Value.ToString();
                tbName.Text = dgvMember.Rows[currentSelectedRow].Cells[1].Value.ToString();
                tbEmail.Text = dgvMember.Rows[currentSelectedRow].Cells[2].Value.ToString();
                tbPhoneNumber.Text = dgvMember.Rows[currentSelectedRow].Cells[3].Value.ToString();
            }
        }

        private void enabled(bool e)
        {
            tbName.Enabled = e; 
            tbEmail.Enabled = e;
            tbPhoneNumber.Enabled = e;
            btninsert.Enabled = !e;
            btnUpdate.Enabled = !e;
            btnDelete.Enabled = !e;
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
        }

        private void getId()
        {
            DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
            String lastId = db.Members.OrderByDescending(x=> x.Id).FirstOrDefault().Id;

            int id = lastId != null ? (int.Parse(lastId.Substring(5,5)) + 1) : 1;

            string result = $"M{DateTime.Now.Year.ToString()}{id.ToString().PadLeft(5,'0')}";

            tbMemberId.Text = result;
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
                var dialog = MessageBox.Show("Yakin ingin menghapus data ini?","Delete",MessageBoxButtons.YesNo) ;
                if (dialog == DialogResult.Yes)
                {
                    DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
                    Member member = db.Members.Where(x=> x.Id.Equals(tbMemberId.Text)).FirstOrDefault();
                    db.Members.DeleteOnSubmit(member);
                    db.SubmitChanges();
                    clearFields();
                    loadDgv();
                }
            }
            else
            {
                MessageBox.Show("Click Row!");
            }
        }

        private bool valid()
        {
            if(tbName.Text == "")
            {
                MessageBox.Show("Nama harus diisi");
                return false;
            }else if(tbEmail.Text == "")
            {
                MessageBox.Show("Email harus diisi");
                return false;
            }else if (tbPhoneNumber.Text == "")
            {
                MessageBox.Show("Phone harus diisi");
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
                        Member member = new Member();
                        member.Id = tbMemberId.Text;
                        member.Name = tbName.Text;
                        member.Email = tbEmail.Text;
                        member.PhoneNumber = tbPhoneNumber.Text;
                        db.Members.InsertOnSubmit(member);
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
                        Member member = db.Members.Where(x => x.Id.Equals(tbMemberId.Text)).FirstOrDefault();
                        member.Name = tbName.Text;
                        member.Email = tbEmail.Text;
                        member.PhoneNumber = tbPhoneNumber.Text;
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
