namespace PINGPONG
{
    partial class ChucMung2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnGoback = new System.Windows.Forms.Button();
            this.btnRetry = new System.Windows.Forms.Button();
            this.lbCongrat = new System.Windows.Forms.Label();
            this.background = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHistory
            // 
            this.btnHistory.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btnHistory.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnHistory.Location = new System.Drawing.Point(248, 261);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(230, 60);
            this.btnHistory.TabIndex = 9;
            this.btnHistory.Text = "Lịch sử đấu";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnGoback
            // 
            this.btnGoback.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btnGoback.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnGoback.Location = new System.Drawing.Point(485, 261);
            this.btnGoback.Name = "btnGoback";
            this.btnGoback.Size = new System.Drawing.Size(155, 60);
            this.btnGoback.TabIndex = 8;
            this.btnGoback.Text = "Quay lại";
            this.btnGoback.UseVisualStyleBackColor = true;
            this.btnGoback.Click += new System.EventHandler(this.btnGoback_Click);
            // 
            // btnRetry
            // 
            this.btnRetry.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRetry.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btnRetry.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnRetry.Location = new System.Drawing.Point(86, 261);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(155, 60);
            this.btnRetry.TabIndex = 7;
            this.btnRetry.Text = "Chơi lại";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // lbCongrat
            // 
            this.lbCongrat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCongrat.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbCongrat.ForeColor = System.Drawing.Color.SlateBlue;
            this.lbCongrat.Location = new System.Drawing.Point(86, 65);
            this.lbCongrat.Name = "lbCongrat";
            this.lbCongrat.Size = new System.Drawing.Size(554, 169);
            this.lbCongrat.TabIndex = 6;
            this.lbCongrat.Text = "THUA MẤT RỒI!!\r\nTHỬ LẠI NGAY THÔI!!";
            this.lbCongrat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // background
            // 
            this.background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.background.Image = global::PINGPONG.Properties.Resources.congrats;
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(727, 383);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.background.TabIndex = 5;
            this.background.TabStop = false;
            // 
            // ChucMung2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 383);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnGoback);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.lbCongrat);
            this.Controls.Add(this.background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChucMung2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChucMung2";
            this.Load += new System.EventHandler(this.ChucMung2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnHistory;
        private Button btnGoback;
        private Button btnRetry;
        private Label lbCongrat;
        private PictureBox background;
    }
}