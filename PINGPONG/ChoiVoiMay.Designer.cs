﻿namespace PINGPONG
{
    partial class ChoiVoiMay
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
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMedium
            // 
            this.btnMedium.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnMedium.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMedium.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btnMedium.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMedium.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMedium.Location = new System.Drawing.Point(91, 391);
            this.btnMedium.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(135, 52);
            this.btnMedium.TabIndex = 15;
            this.btnMedium.Text = "Trung Bình";
            this.btnMedium.UseVisualStyleBackColor = false;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnEasy
            // 
            this.btnEasy.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnEasy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEasy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btnEasy.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEasy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEasy.Location = new System.Drawing.Point(91, 338);
            this.btnEasy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(135, 45);
            this.btnEasy.TabIndex = 19;
            this.btnEasy.Text = "Dễ";
            this.btnEasy.UseVisualStyleBackColor = false;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // btnHard
            // 
            this.btnHard.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnHard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHard.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btnHard.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnHard.Location = new System.Drawing.Point(91, 451);
            this.btnHard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(135, 40);
            this.btnHard.TabIndex = 20;
            this.btnHard.Text = "Khó";
            this.btnHard.UseVisualStyleBackColor = false;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBack.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBack.Location = new System.Drawing.Point(91, 499);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(135, 43);
            this.btnBack.TabIndex = 21;
            this.btnBack.Text = "Trở Về";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(44, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 46);
            this.label1.TabIndex = 22;
            this.label1.Text = "Chọn Độ Khó";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ChoiVoiMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PINGPONG.Properties.Resources.Pong1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(320, 587);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.btnEasy);
            this.Controls.Add(this.btnMedium);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChoiVoiMay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHƠI VỚI MÁY";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnMedium;
        private Button btnEasy;
        private Button btnHard;
        private Button btnBack;
        private Label label1;
    }
}