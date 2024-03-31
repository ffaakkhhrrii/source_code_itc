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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataLKSFakhriDataContext db = new DataLKSFakhriDataContext();
            Employee employee = db.Employees.Where(x => x.Email.Equals(tbEmail.Text)
            && x.Password.Equals(tbPassword.Text)).FirstOrDefault();
            if (employee != null)
            {
//                DataStorage dataStorage = new DataStorage();
                FormMain formMain = new FormMain();
                DataStorage.roleId = employee.PositionId;
                DataStorage.EmployeeID = employee.Id;
                formMain.ShowDialog();
                formMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Try Again, Your Data is not Valid!");
            }
        }
    }
}
