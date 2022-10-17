using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SgmApp2022
{
    public partial class frm_Search_Student_Details : Form
    {
        public frm_Search_Student_Details()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SgmApp2022_DB;Integrated Security=True");
        void Con_Open()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Open();
            }
        }

        void Con_Close()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Close();
            }
        }
        private void Only_Numeric(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (Char)Keys.Back)))
            {
                e.Handled = true;
            }

        }

        void Clear_Controls()
        {
            tb_RollNo.Text = "";
            tb_Name.Clear();
            tb_MobileNo.Clear();
            cmb_Course.SelectedIndex = -1;
            dtp_DOB.Text = "31-12-2002";
        }

        private void frm_Search_Student_Details_Load(object sender, EventArgs e)
        {
            Clear_Controls();
            tb_RollNo.Focus();
        }
       private void btn_Search_Click(object sender, EventArgs e)
        {
            Con_Open();
            {
                SqlCommand Cmd = new SqlCommand("Select * From Student_Details where RollNo=@RNo", Con);

                Cmd.Parameters.Add("RNo", SqlDbType.Int).Value = tb_RollNo.Text;

                SqlDataReader Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    tb_Name.Text = Dr.GetString(Dr.GetOrdinal("Name"));
                    tb_MobileNo.Text = (Dr["MobileNo"].ToString());
                    cmb_Course.Text = Dr.GetString(Dr.GetOrdinal("Course"));
                    dtp_DOB.Text = (Dr["DOB"].ToString());
                }
                else
                {
                    MessageBox.Show("No Record Found", "Invalid RollNo");
                    tb_RollNo.Clear();

                }
                Con_Close();
            }

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear_Controls();
        }

        private void btn_Add_New_Student_Click(object sender, EventArgs e)
        {
            frm_Add_New_Student Obj = new frm_Add_New_Student();
            Obj.Show();
            this.Hide();
        }

        private void btn_View_All_Student_List_Click(object sender, EventArgs e)
        {
            frm_View_All_Student_Details Obj = new frm_View_All_Student_Details();
            Obj.Show();
            this.Hide();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure You Want To Logout ??", "LOGOUT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                frm_Login Obj = new frm_Login();
                Obj.Show();
                this.Hide();
            }
        }
    }
}

