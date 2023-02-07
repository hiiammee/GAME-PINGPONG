namespace PINGPONG
{
    public partial class SanhCho : Form
    {
        int id;
        string nickname;

        public static string player_name_temp = "";
        public static int player_id_temp = 0;

        public SanhCho()
        {
            InitializeComponent();
            id = DangNhap.id;
            nickname = DangNhap.nickname;
        }

        private void SanhCho_Load(object sender, EventArgs e)
        {           
            tbId.Text = id.ToString();
            tbNickname.Text = nickname;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            player_name_temp = tbNickname.Text;
            player_id_temp = Convert.ToInt32(tbId.Text);
            ChonCheDo formz = new ChonCheDo();          
            formz.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
            form.Show();
            this.Hide();
        }

        private void tbld_Enter(object sender, EventArgs e)
        {
            if (tbId.Text == "Nhập ID")
            {
                tbId.Text = "";
                tbId.ForeColor = Color.Black;
            }
        }

        private void tbld_Leave(object sender, EventArgs e)
        {
            if (tbId.Text == "")
            {
                tbId.Text = "Nhập ID";
                tbId.ForeColor = Color.Silver;
            }
        }

        private void tbNickname_Leave(object sender, EventArgs e)
        {
            if (tbNickname.Text == "")
            {
                tbNickname.Text = "Nhập Nickname";
                tbNickname.ForeColor = Color.Silver;
            }
        }

        private void tbNickname_Enter(object sender, EventArgs e)
        {
            if (tbNickname.Text == "Nhập Nickname")
            {
                tbNickname.Text = "";
                tbNickname.ForeColor = Color.Silver;
            }
        }
    }
}
