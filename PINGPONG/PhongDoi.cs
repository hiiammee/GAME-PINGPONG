using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace PINGPONG
{
    public partial class PhongDoi : Form
    {
        public PhongDoi()
        {
            InitializeComponent();
            Listen();
        }

        IPEndPoint ip;
        Socket server;
        List<Socket> ClientList;

        string temp1;
        string temp2;
        string temp3;
        public static string p1nickname;

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

        void Listen()
        {
            ClientList = new List<Socket>();
            ip = new IPEndPoint(IPAddress.Any, 7007);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            server.Bind(ip);

            Thread listen = new Thread(() =>
            {
                try

                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        ClientList.Add(client);
                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }

                catch
                {
                    ip = new IPEndPoint(IPAddress.Any, 7007);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            listen.IsBackground = true;
            listen.Start();
        }

        void Receive(object obj)
        {
            Socket? client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 5000];
                    client.Receive(buffer);

                    string data = (string)Deserialize(buffer);
                    string[] temp = data.Split('+');
                    temp1 = temp[0];
                    temp2 = temp[1];
                    temp3 = temp[2];
                    Check();
                    /*
                    foreach (var item in ClientList)
                    {
                        if (item != null && item != client)
                            item.Send(Serialize(message));
                    }
                    */
                }
            }
            catch
            {
                ClientList.Remove(client);
                client.Close();
            }
        }

        void Send(int signal)
        {
            foreach (Socket item in ClientList)
            {
                item.Send(Serialize(signal));
            }
        }

        void Check()
        {
            if (temp1 == tbNickname.Text && temp2 == tbId.Text)
            {
                DialogResult dlr = MessageBox.Show("Có người chơi mời bạn vào phòng đấu!\nBạn có đồng ý tham gia không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlr == DialogResult.Yes)
                {
                    MessageBox.Show("Chấp nhận lời mời!");
                    p1nickname = temp3; 
                    Send(1);
                }
                else if (dlr == DialogResult.No)
                {
                    MessageBox.Show("Từ chối lời mời!");
                    Send(3);
                }
            }
            else
            {
                Send(2);
            }
        }

        private void PhongDoi_Load(object sender, EventArgs e)
        {
            tbId.Text = DangNhap.id.ToString();
            tbNickname.Text = DangNhap.nickname;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PongClient2 pongClient2 = new PongClient2();
            pongClient2.Show();
            this.Hide();
        }

    }
}
