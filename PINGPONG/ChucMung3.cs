namespace PINGPONG
{
    public partial class ChucMung3 : Form
    {
        public ChucMung3()
        {
            InitializeComponent();
        }

        private void ChucMung3_Load(object sender, EventArgs e)
        {
            lbCongrat.Parent = background;
            lbCongrat.BackColor = Color.Transparent;
            btnRetry.Parent = background;
            btnRetry.BackColor = Color.Transparent;
            btnHistory.Parent = background;
            btnHistory.BackColor = Color.Transparent;
            btnGoback.Parent = background;
            btnGoback.BackColor = Color.Transparent;
            lbCongrat.Text = PongClient2.congrats;
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            ChonCheDo form = new ChonCheDo();
            form.Show();
            this.Hide();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            LichSuDau form = new LichSuDau();
            form.Show();
            this.Hide();
        }

        private void btnGoback_Click(object sender, EventArgs e)
        {
            SanhCho sanhCho = new SanhCho();
            sanhCho.Show();
            this.Hide();
        }
        
    }
}
