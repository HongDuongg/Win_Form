using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace Login
{
    
    public partial class Login : Form
    {
        public bool Chose;
        //Chuỗi kết nối CSDL
        String StrConnection = @"Data Source=DESKTOP-53F7O5P\MISASME2017;Initial Catalog=Login;Integrated Security=True";
        SqlConnection Connection;
        SqlCommand Command; //tương tác với cơ sở dữ liệu
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Connection = new SqlConnection(StrConnection); //kết nối CSDL
            Connection.Open();
            String sql = "SELECT COUNT(*) FROM [Login].[dbo].[tbLogin] WHERE Ussername =@usser AND Password = @pass ";
            Command = new SqlCommand(sql, Connection);

            Command.Parameters.Add(new SqlParameter("@usser", txtUsername.Text));
            Command.Parameters.Add(new SqlParameter("@pass", txtPassword.Text));

            int x = (int)Command.ExecuteScalar(); //ExecuteScalar trả về 1 đối tượng dùng hàm count
            if(x == 1)
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo");

                this.Close();
                Chose = true;
            }
            else
            {
                lblKQS.Text = "Bạn nhập sai ";
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }
        }

        private void ckbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

    }
}
