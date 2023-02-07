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

namespace PINGPONG
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        string strConnection = "Data Source=DAEMON;Initial Catalog=PING_PONG_GAME;Integrated Security=True";
        SqlConnection conn;
        SqlCommand command;

        private void button1_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPass.Text;

            conn = new SqlConnection(strConnection);
            command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SIGN_IN";
            command.Parameters.AddWithValue("@USERNAME", username);
            command.Parameters.AddWithValue("@PASSWORD", password);
            command.Connection = conn;
            conn.Open();

            object result = command.ExecuteScalar();
            int x = Convert.ToInt32(result);   

            if (x == 1)
            {
                MessageBox.Show("Đăng nhập thành công!");
                GioiThieu form = new GioiThieu();
                form.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai. Vui lòng nhập lại!");
            }

            conn.Close();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPass.Text;
            string nickname = tbNickname.Text;

            conn = new SqlConnection(strConnection);
            command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SIGN_UP";
            command.Parameters.AddWithValue("@USERNAME", username);
            command.Parameters.AddWithValue("@PASSWORD", password);
            command.Parameters.AddWithValue("@NICKNAME", nickname);
            command.Connection = conn;
            conn.Open();

            object result = command.ExecuteScalar();
            int x = Convert.ToInt32(result);

            if (x == 2)
            {
                MessageBox.Show("Đăng kí thành công!");                
            }
            else if(x == 1)
            {
                MessageBox.Show("Nickname đã tồn tại. Vui lòng nhập lại!");
            }
            else if (x == 0)
            {
                MessageBox.Show("Tên tài khoản đã tồn tại. Vui lòng nhập lại!");
            }

            conn.Close();
        }
    }
}
