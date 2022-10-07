using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SgmApp2022
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }
        private void tb_Username_TextChanged(object sender, EventArgs e)
        {
            lbl_Error.Visible = false;
            tb_Password.Enabled = true;

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {

            if (tb_Username.Text == "K" && tb_Password.Text == "P")
            {
                MessageBox.Show("Login Successful", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm_Add_New_Student Obj = new frm_Add_New_Student();
                Obj.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Invalid Username or Password", "Retry", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

            tb_Username.Clear();
            tb_Password.Clear();
            tb_Password.Enabled = false;
            btn_Submit.Enabled = false;

            tb_Username.Focus();

        }

        private void tb_Password_TextChanged(object sender, EventArgs e)
        {
            btn_Submit.Enabled = true;
        }

       

    }
}
