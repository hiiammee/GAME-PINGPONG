using System.Data;
using System.Data.SqlClient;

namespace PINGPONG
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        // Connection variables
        string strConnection = "Data Source=DAEMON;Initial Catalog=PING_PONG_GAME;Integrated Security=True";
        SqlConnection conn;
        SqlCommand command;

        // Data variables
        string username;
        string password;
        public static string nickname;
        public static int id;

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
            form.Show();
            this.Hide();
        }

        private void btnSignin_Click_1(object sender, EventArgs e)
        { 
            username = tbUsername.Text;
            password = tbPassword.Text;

            if (username == "Tên đăng nhập" || password == "Nhập mật khẩu")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (username.Length > 30 || password.Length > 30)
            {
                MessageBox.Show("Thông tin điền vào quá độ dài quy định!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn = new SqlConnection(strConnection);
                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SIGN_IN";
                command.Parameters.AddWithValue("@USERNAME", username);
                command.Parameters.AddWithValue("@PASSWORD", password);
                command.Connection = conn;
                conn.Open();

                object codegeass = command.ExecuteScalar();
                int x = Convert.ToInt32(codegeass);

                if (x == 1)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    conn = new SqlConnection(strConnection);
                    command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DATA_POURING";
                    command.Parameters.AddWithValue("@USERNAME", username);
                    command.Parameters.AddWithValue("@PASSWORD", password);
                    command.Connection = conn;
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["ID"]);
                        nickname = Convert.ToString(reader["NICKNAME"]);
                    }

                    SanhCho form1 = new SanhCho();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu sai. Vui lòng nhập lại!", "Cảnh báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void tbUsername_Enter(object sender, EventArgs e)
        {
            if (tbUsername.Text == "Tên đăng nhập")
            {
                tbUsername.Text = "";
                tbUsername.ForeColor = Color.Black;
            }
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.Text == "Nhập mật khẩu")
            {
                tbPassword.Text = "";
                tbPassword.PasswordChar = '*';
                tbPassword.ForeColor = Color.Black;
            }
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text == "")
            {
                tbPassword.Text = "Nhập mật khẩu";
                tbPassword.PasswordChar = '\0';
                tbPassword.ForeColor = Color.Silver;
            }
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                tbUsername.Text = "Tên đăng nhập";
                tbUsername.PasswordChar = '\0';
                tbUsername.ForeColor = Color.Silver;
            }
        }
    }
}
