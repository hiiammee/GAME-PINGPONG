using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace PINGPONG
{
    public partial class PongClient2 : Form
    {
        public PongClient2()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
            Send();
            Y = ball.Top;
            X = ball.Left;
            bottomEdge = 376;
            racket1Pos = racket2.Top;
            countdown = 4;
            spaceBarClicked = 0;
            countdownTimer.Start();
        }

        IPEndPoint ip;
        Socket client;

        int client_signal = 0;
        int startsignal = 0;
        bool PlayerDetectedUp = false;
        bool PlayerDetectedDown = false;
        int bottomEdge;
        int X;
        int Y;
        int racket1Pos;
        int countdown;
        int spaceBarClicked;
        int winScore = 4;
        int player1Score = 0;
        int player2Score = 0;
        public static string congrats;

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
            ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7076);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(ip);
            }
            catch
            {
                MessageBox.Show("An error occured: Can not connect to the server!!!");
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
                    //Y X r1 r2 s1 s2 ss
                    byte[] buffer = new byte[1024 * 5000];
                    client.Receive(buffer);
                    string data = (string)Deserialize(buffer);
                    string[] temp = data.Split('+');
                    Y = Convert.ToInt32(temp[0]);
                    X = Convert.ToInt32(temp[1]);
                    racket1Pos = Convert.ToInt32(temp[2]);
                    player1Score = Convert.ToInt32(temp[4]);
                    player2Score = Convert.ToInt32(temp[5]);
                    startsignal = Convert.ToInt32(temp[6]);
                }
            }
            catch
            {
                Close();
            }
        }

        void Send()
        {
            client.Send(Serialize(client_signal));
        }

        void Congrats(int sign)
        {
            if (sign == 1)
            {
                this.Hide();
                congrats = "CHÚC MỪNG BẠN ĐÃ GIÀNH CHIẾN THẮNG!!";
                ChucMung3 chucMung3 = new ChucMung3();
                chucMung3.Show();
            }
            else if (sign == 2)
            {
                this.Hide();
                congrats = "THUA MẤT RỒI!!\nTHỬ LẠI NGAY THÔI!!";
                ChucMung3 chucMung3 = new ChucMung3();
                chucMung3.Show();
            }
        }

        private void PongClient2_Load(object sender, EventArgs e)
        {
            player1_score.Parent = play_ground;
            player1_score.BackColor = Color.Transparent;
            player2_score.Parent = play_ground;
            player2_score.BackColor = Color.Transparent;
            player1_name.Parent = play_ground;
            player1_name.BackColor = Color.Transparent;
            player2_name.Parent = play_ground;
            player2_name.BackColor = Color.Transparent;
            lbCountdown.Parent = play_ground;
            lbCountdown.BackColor = Color.Transparent;
            lbCountdown.BackColor = Color.Transparent;
            player2_name.Text = DangNhap.nickname;
            player1_name.Text = PhongDoi.p1nickname;
        }

        private void pongTimer_Tick(object sender, EventArgs e)
        {
            Send();
            racket1.Top = racket1Pos;
            if (PlayerDetectedDown == true && racket2.Top < bottomEdge)
            {
                racket2.Top += 30;
            }
            if (PlayerDetectedUp == true && racket2.Top > 0)
            {
                racket2.Top -= 30;
            }
            ball.Top = Y;
            ball.Left = X;
            player1_score.Text = player1Score.ToString();
            player2_score.Text = player2Score.ToString();
            if (player2Score == winScore)
            {
                pongTimer.Stop();
                Congrats(1);
            }
            else if (player1Score == winScore)
            {
                pongTimer.Stop();
                Congrats(2);
            }
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {

            if (startsignal != 0)
            {
                lbCountdown.Text = countdown--.ToString();

                if (countdown < 0)
                {
                    lbCountdown.Text = "LET'S GO!!";
                }

                if (countdown < -1)
                {
                    countdownTimer.Stop();
                    lbCountdown.Hide();
                    pongTimer.Start();
                }
            }           
        }

        private void PongClient2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                client_signal = 3;
                PlayerDetectedUp = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                client_signal = 4;
                PlayerDetectedDown = true;              
            }

            if (e.KeyCode == Keys.Space)
            {
                if (spaceBarClicked % 2 == 0)
                {
                    pongTimer.Stop();
                    lbCountdown.Show();
                    lbCountdown.Text = "PAUSE";
                }
                else
                {
                    pongTimer.Start();
                }
            }
            spaceBarClicked++;
        }

        private void PongClient2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                client_signal = 0;
                PlayerDetectedUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                client_signal = 0;
                PlayerDetectedDown = false;
            }
        }
    }
}
