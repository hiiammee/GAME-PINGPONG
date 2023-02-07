using System.Data;
using System.Data.SqlClient;

namespace PINGPONG
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        // Connection variables
        string strConnection = "Data Source=DAEMON;Initial Catalog=PING_PONG_GAME;Integrated Security=True";
        SqlConnection conn;
        SqlCommand command;

        private void tbUsername_Enter(object sender, EventArgs e)
        {
            if (tbUsername.Text == "Tên đăng nhập (Tối đa 30 kí tự)")
            {
                tbUsername.Text = "";
                tbUsername.ForeColor = Color.Black;
            }
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                tbUsername.Text = "Tên đăng nhập (Tối đa 30 kí tự)";
                tbUsername.ForeColor = Color.Silver;
            }
        }

        private void tbNickname_Enter(object sender, EventArgs e)
        {
            if (tbNickname.Text == "Nickname (Tối đa 30 kí tự)")
            {
                tbNickname.Text = "";
                tbNickname.ForeColor = Color.Black;
            }
        }

        private void tbNickname_Leave(object sender, EventArgs e)
        {
            if (tbNickname.Text == "")
            {
                tbNickname.Text = "Nickname (Tối đa 30 kí tự)";
                tbNickname.ForeColor = Color.Silver;
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

        private void tbRetype_Enter(object sender, EventArgs e)
        {
            if (tbRetype.Text == "Nhập lại mật khẩu")
            {
                tbRetype.Text = "";
                tbRetype.PasswordChar = '*';
                tbRetype.ForeColor = Color.Black;
            }
        }

        private void tbRetype_Leave(object sender, EventArgs e)
        {
            if (tbRetype.Text == "")
            {
                tbRetype.Text = "Nhập lại mật khẩu";
                tbRetype.PasswordChar = '\0';
                tbRetype.ForeColor = Color.Silver;
            }
        }

        private void btnSignup_Click_1(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string nickname = tbNickname.Text;
            string retype = tbRetype.Text;

            if (username == "" || password == "" || nickname == "" || retype == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (password != retype)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (username.Length > 30 || password.Length > 30 || nickname.Length > 30 || retype.Length > 30)
            {
                MessageBox.Show("Thông tin điền vào quá độ dài quy định!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
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
                    MessageBox.Show("Đăng kí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                    DangNhap form = new DangNhap();
                    form.Show();
                    this.Hide();
                }
                else if (x == 1)
                {
                    MessageBox.Show("Nickname đã tồn tại. Vui lòng nhập lại!", "Cảnh báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                else if (x == 0)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại. Vui lòng nhập lại!", "Cảnh báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            Menu form = new Menu();
            form.Show();
            this.Hide();
        }
    }
}

