using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Data.SqlClient;

namespace PINGPONG
{
    public partial class PongServer : Form
    {
        public PongServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Listen();
            bottomEdge = 376;
            xMidpoint = ClientSize.Width / 2;
            yMidpoint = ClientSize.Height / 2;
            countdown = 3;
            spaceBarClicked = 0;
        }

        IPEndPoint ip;
        Socket server;
        List<Socket> ClientList;

        string strConnection = "Data Source=DAEMON;Initial Catalog=PING_PONG_GAME;Integrated Security=True";
        SqlConnection conn;
        SqlCommand command;

        public static int signal = 0;
        int startsignal = 1;
        bool Player1DetectedUp = false;
        bool Player1DetectedDown = false;
        bool Player2DetectedUp = false;
        bool Player2DetectedDown = false;
        int bottomEdge;
        int xMidpoint;
        int yMidpoint;
        int X = 10;
        int Y = 10;
        int countdown;
        int spaceBarClicked;
        int winScore = 4;
        int player1Score = 0;
        int player2Score = 0;

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
            ip = new IPEndPoint(IPAddress.Any, 7076);
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
                    ip = new IPEndPoint(IPAddress.Any, 7076);
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
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    signal = (int)Deserialize(data);
                }
            }
            catch
            {
                ClientList.Remove(client);
                client.Close();
            }
        }

        void SendCoordinates()
        {
            string YXr1r2s1s2ss = ball.Top.ToString() + "+" + ball.Left.ToString()
            + "+" + racket1.Top + "+" + racket2.Top 
            + "+" + player1Score + "+" + player2Score
            + "+" + startsignal.ToString();
            foreach (Socket item in ClientList)
            {
                item.Send(Serialize(YXr1r2s1s2ss));
            }
        }

        void Check()
        {
            if (signal == 1)
            {
                Player1DetectedUp = true;
            }
            if (signal == 2)
            {
                Player1DetectedDown = true;
            }
            if (signal == 3)
            {
                Player2DetectedUp = true;
            }
            if (signal == 4)
            {
                Player2DetectedDown = true;

            }
            if (signal == 0)
            {
                Player1DetectedDown = false;
                Player1DetectedUp = false;
                Player2DetectedDown = false;
                Player2DetectedUp = false;
            }
        }

        private void PongServer_Load(object sender, EventArgs e)
        {
            player2_score.Parent = play_ground;
            player2_score.BackColor = Color.Transparent;
            player1_score.Parent = play_ground;
            player1_score.BackColor = Color.Transparent;
            player2_name.Parent = play_ground;
            player2_name.BackColor = Color.Transparent;
            player1_name.Parent = play_ground;
            player1_name.BackColor = Color.Transparent;
            lbCountdown.Parent = play_ground;
            lbCountdown.BackColor = Color.Transparent;
            lbCountdown.BackColor = Color.Transparent;
            player1_name.Text = DangNhap.nickname;
            player2_name.Text = SettingCVB.nicknameset;
        }

        private void pongTimer_Tick(object sender, EventArgs e)
        {
            Random newBallSpot = new Random();
            int newSpot = newBallSpot.Next(150, ClientSize.Height - 100);
            lbCountdown.Hide();
            Check();
            ball.Top += Y;
            ball.Left += X;

            if (ball.Top < 0 || ball.Top + ball.Height > ClientSize.Height)
            {
                Y = -Y;
            }

            if (ball.Bounds.IntersectsWith(racket1.Bounds) || ball.Bounds.IntersectsWith(racket2.Bounds))
            {
                X = -X;
            }

            if (ball.Left < 0)
            {
                ball.Left = xMidpoint;
                ball.Top = newSpot;
                X = -X;
                player2Score++;
                player2_score.Text = player2Score.ToString();
            }

            if (ball.Left + ball.Width > ClientSize.Width)
            {
                ball.Left = xMidpoint;
                ball.Top = newSpot;
                X = -X;
                player1Score++;
                player1_score.Text = player1Score.ToString();               
            }

            if (player1Score >= winScore || player2Score >= winScore)
            {
                pongTimer.Stop();
                string winner = "";
                if (player1Score > player2Score)
                {
                    winner = "Score: " + player1Score.ToString() + "-" + player2Score.ToString()
                        + " [Winner:" + player1_name.Text + "]";
                }
                else if (player1Score < player2Score)
                {
                    winner = "Score: " + player1Score.ToString() + "-" + player2Score.ToString()
                        + " [Winner:" + player2_name.Text + "]";
                }

                conn = new SqlConnection(strConnection);
                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "STORED_HISTORY";
                command.Parameters.AddWithValue("@PLAYER1_NAME", player1_name.Text);
                command.Parameters.AddWithValue("@PLAYER2_NAME", player2_name.Text);
                command.Parameters.AddWithValue("@PLAYER1_ID", DangNhap.id);
                command.Parameters.AddWithValue("@PLAYER2_ID", SettingCVB.idset);
                command.Parameters.AddWithValue("@RESULT", winner);
                command.Connection = conn;
                conn.Open();

                object codegeass = command.ExecuteScalar();
                int x = Convert.ToInt32(codegeass);

                if (x == 1)
                {
                    MessageBox.Show("Cập nhật lịch sử đấu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
                this.Close();
            }

            if (Player1DetectedDown == true && racket1.Top < bottomEdge)
            {
                racket1.Top += 30;
            }

            if (Player1DetectedUp == true && racket1.Top > 0)
            {
                racket1.Top -= 30;
            }

            if (Player2DetectedDown == true && racket2.Top < bottomEdge)
            {
                racket2.Top += 30;
            }

            if (Player2DetectedUp == true && racket2.Top > 0)
            {
                racket2.Top -= 30;
            }

            SendCoordinates();
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            lbCountdown.Font = new System.Drawing.Font("OCR A Extended", 65F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbCountdown.Text = countdown--.ToString();
            if (countdown < 0)
            {
                lbCountdown.Text = "LET'S GO!!";
            }

            if (countdown < -1)
            {
                countdownTimer.Stop();
                pongTimer.Start();
            }
        }

        private void PongServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendCoordinates();
                countdownTimer.Start();
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

    }
}
