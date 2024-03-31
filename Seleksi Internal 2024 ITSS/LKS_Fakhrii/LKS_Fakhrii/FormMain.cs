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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            accessible(true);
        }

        private void accessible(bool e)
        {
            if (DataStorage.roleId == 1)
            {
                memberMenu.Enabled = e;
                employeeMenu.Enabled = e;
                brandMenu.Enabled = e;
                productMenu.Enabled = e;
                buyMenu.Enabled = e;
            }else if(DataStorage.roleId == 2)
            {
                memberMenu.Enabled = e;
                employeeMenu.Enabled = !e;
                brandMenu.Enabled = !e;
                productMenu.Enabled = !e;
                buyMenu.Enabled= e;
            }
        }

        private void logoutMenu_Click(object sender, EventArgs e)
        {
            DataStorage.roleId = 0;
            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void memberMenu_Click(object sender, EventArgs e)
        {
            FormMember formMember = new FormMember();
            formMember.MdiParent = this;
            formMember.Show();
        }

        private void employeeMenu_Click(object sender, EventArgs e)
        {
            FormEmployee formEmployee = new FormEmployee();
            formEmployee.MdiParent = this;
            formEmployee.Show();
        }

        private void brandMenu_Click(object sender, EventArgs e)
        {
            FormBrand formBrand = new FormBrand();
            formBrand.MdiParent = this;
            formBrand.Show();
        }

        private void productMenu_Click(object sender, EventArgs e)
        {
            FormProduct formProduct = new FormProduct();
            formProduct.MdiParent = this;
            formProduct.Show();
        }

        private void buyMenu_Click(object sender, EventArgs e)
        {
            FormTransaction formTransaction = new FormTransaction();
            formTransaction.MdiParent = this;
            formTransaction.Show();
        }
    }
}
