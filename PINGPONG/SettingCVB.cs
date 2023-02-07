namespace PINGPONG
{
    public partial class SettingCVB : Form
    {
        public SettingCVB()
        {
            InitializeComponent();
            label2.Focus();
        }

        public static string nicknameset;
        public static int idset;        

        private void SettingCVB_Load(object sender, EventArgs e)
        {
            lbCreator_name.Text = DangNhap.nickname;
            tbP1id.Text = DangNhap.id.ToString();
            tbP1name.Text = DangNhap.nickname;
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChonCheDo form = new ChonCheDo();
            form.Show();
            this.Hide();
        }

        private void btnInvite_Click(object sender, EventArgs e)
        {
            MoiBan moiBan = new MoiBan();
            moiBan.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {            
            PongServer pongServer = new PongServer();
            pongServer.Show();
            PongClient1 pongClient1 = new PongClient1();
            pongClient1.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (nicknameset != null && idset != 0)
            {
                timer1.Stop();
                tbP2name.Text = nicknameset;
                tbP2id.Text = idset.ToString();
            }
        }
    }
}
