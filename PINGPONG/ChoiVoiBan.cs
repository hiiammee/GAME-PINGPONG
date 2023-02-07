namespace PINGPONG
{
    public partial class ChoiVoiBan : Form
    {
        public ChoiVoiBan()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SettingCVB formSettingCVB = new SettingCVB();
            formSettingCVB.Show();
            //this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ChonCheDo form = new ChonCheDo();
            form.Show();
            //this.Hide();
        }

        private void brnJoin_Click(object sender, EventArgs e)
        {
            PhongDoi phongDoi = new PhongDoi(); 
            phongDoi.Show();
            //this.Hide();
        }

    }
}
