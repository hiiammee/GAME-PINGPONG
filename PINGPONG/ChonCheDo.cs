namespace PINGPONG
{
    public partial class ChonCheDo : Form
    {

        public ChonCheDo()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
        }

        private void btnPvE_Click(object sender, EventArgs e)
        {
            ChoiVoiMay form = new ChoiVoiMay();
            form.Show();
            this.Hide();
        }

        private void btnPvP_Click(object sender, EventArgs e)
        {
            ChoiVoiBan form = new ChoiVoiBan();
            form.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SanhCho form = new SanhCho();
            form.Show();
            this.Hide();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            LichSuDau form = new LichSuDau();
            form.Show();
            this.Hide();
        }
    }
}
