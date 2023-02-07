using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace PINGPONG
{
    public partial class MoiBan : Form
    {
        public MoiBan()
        {
            InitializeComponent();
        }

        IPEndPoint ip;
        Socket client;

        public static string nickname;
        public static int id;
        string p1nickname;
        int signal;

        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();

        }

        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);

        }

        void Connect()
        {
            ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7007);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(ip);
            }
            catch
            {
                MessageBox.Show("Người chơi hiên tại không trực tuyến!");
                return;
            }
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 5000];
                    client.Receive(buffer);
                    signal = (int)Deserialize(buffer);
                }              
            }
            catch
            {
                Close();
            }
        }

        void Send(string message)
        {
            client.Send(Serialize(message));
        }     

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInvite_Click(object sender, EventArgs e)
        {
            Connect();
            nickname = tbName.Text;
            id = Convert.ToInt32(tbID.Text);
            p1nickname = DangNhap.nickname;
            string package = nickname + "+" + id.ToString() + "+" + p1nickname;
            Send(package);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (signal == 1)
            {
                timer1.Stop();
                MessageBox.Show("Mời thành công" + nickname + "!");
                SettingCVB.nicknameset = nickname;
                SettingCVB.idset = id;                              
            }
            if (signal == 2)
            {
                timer1.Stop();
                MessageBox.Show("Nickname hoặc id sai!\nVui lòng kiểm tra lại!");
                tbName.Clear();
                tbID.Clear();              
            }
            if (signal == 3)
            {
                timer1.Stop();
                MessageBox.Show("Người chơi từ chối lời mời!\nVui lòng thử lại sau!");
                tbName.Clear();
                tbID.Clear();               
            }
            signal = 0;
        }
    }
}
