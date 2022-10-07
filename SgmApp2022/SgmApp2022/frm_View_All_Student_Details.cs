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
    public partial class frm_View_All_Student_Details : Form
    {
        public frm_View_All_Student_Details()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=student_DB;Integrated Security=True");

        void Con_Open()
        {
            if (Con.State != ConnectionState.Open)
            {
                Con_Open();
            }
        }

        void Con_Close()
        {
            if (Con.State != ConnectionState.Closed)
            {
                Con_Close();
            }
        }

        private void btn_Add_New_Student_Click(object sender, EventArgs e)
        {
         frm_Add_New_Student Obj= new frm_Add_New_Student();
            Obj.Show();
            this.Hide();
        }
        

        private void frm_View_All_Student_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'student_App_DBDataSet.Student_Details' table. You can move, or remove it, as needed.
            this.student_DetailsTableAdapter.Fill(this.student_App_DBDataSet.Student_Details);

        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            frm_Login Obj = new frm_Login();
            Obj.Show();
            this.Hide();
        }

        private void frm_View_All_Student_Details_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sgmApp2022_DBDataSet1.Student_Details' table. You can move, or remove it, as needed.
            this.student_DetailsTableAdapter1.Fill(this.sgmApp2022_DBDataSet1.Student_Details);

        }
    }
}
