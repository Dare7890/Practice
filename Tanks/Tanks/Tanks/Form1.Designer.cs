namespace Tanks
{
    partial class Tanks
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tanks));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTheEnd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCountOfTanks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.tbCountOfApple = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAmountApple = new System.Windows.Forms.Label();
            this.btnStatistic = new System.Windows.Forms.Button();
            this.tbSpeed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnWrite = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Enemy.png");
            this.imageList1.Images.SetKeyName(1, "Player.png");
            this.imageList1.Images.SetKeyName(2, "highWall.png");
            this.imageList1.Images.SetKeyName(3, "smallWall.png");
            this.imageList1.Images.SetKeyName(4, "wideWall.png");
            this.imageList1.Images.SetKeyName(5, "Border.png");
            this.imageList1.Images.SetKeyName(6, "Player_down.png");
            this.imageList1.Images.SetKeyName(7, "Player_left.png");
            this.imageList1.Images.SetKeyName(8, "Player_right.png");
            this.imageList1.Images.SetKeyName(9, "Enemy_Right.png");
            this.imageList1.Images.SetKeyName(10, "Enemy_Up.png");
            this.imageList1.Images.SetKeyName(11, "Enemy_Down.png");
            this.imageList1.Images.SetKeyName(12, "Apple.png");
            this.imageList1.Images.SetKeyName(13, "Shot.png");
            this.imageList1.Images.SetKeyName(14, "Enemy_Shot.png");
            this.imageList1.Images.SetKeyName(15, "Explosion1.png");
            this.imageList1.Images.SetKeyName(16, "Explosion2.png");
            this.imageList1.Images.SetKeyName(17, "Explosion3.png");
            this.imageList1.Images.SetKeyName(18, "Brick1.png");
            this.imageList1.Images.SetKeyName(19, "Brick2.png");
            this.imageList1.Images.SetKeyName(20, "Brick3.png");
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(27, 38);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(130, 34);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "New game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(184, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 400);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // lblTheEnd
            // 
            this.lblTheEnd.AutoSize = true;
            this.lblTheEnd.Font = new System.Drawing.Font("Microsoft YaHei UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTheEnd.Location = new System.Drawing.Point(480, 549);
            this.lblTheEnd.Name = "lblTheEnd";
            this.lblTheEnd.Size = new System.Drawing.Size(0, 50);
            this.lblTheEnd.TabIndex = 7;
            this.lblTheEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Количество танков";
            // 
            // tbCountOfTanks
            // 
            this.tbCountOfTanks.Location = new System.Drawing.Point(27, 136);
            this.tbCountOfTanks.Name = "tbCountOfTanks";
            this.tbCountOfTanks.Size = new System.Drawing.Size(130, 22);
            this.tbCountOfTanks.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(27, 170);
            this.label2.MaximumSize = new System.Drawing.Size(130, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 10;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(27, 272);
            this.lblError.MaximumSize = new System.Drawing.Size(130, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            this.lblError.TabIndex = 13;
            // 
            // tbCountOfApple
            // 
            this.tbCountOfApple.Location = new System.Drawing.Point(27, 243);
            this.tbCountOfApple.Name = "tbCountOfApple";
            this.tbCountOfApple.Size = new System.Drawing.Size(130, 22);
            this.tbCountOfApple.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Количество яблок";
            // 
            // lblAmountApple
            // 
            this.lblAmountApple.AutoSize = true;
            this.lblAmountApple.Location = new System.Drawing.Point(27, 98);
            this.lblAmountApple.MaximumSize = new System.Drawing.Size(135, 0);
            this.lblAmountApple.Name = "lblAmountApple";
            this.lblAmountApple.Size = new System.Drawing.Size(0, 17);
            this.lblAmountApple.TabIndex = 14;
            // 
            // btnStatistic
            // 
            this.btnStatistic.Enabled = false;
            this.btnStatistic.Location = new System.Drawing.Point(26, 450);
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.Size = new System.Drawing.Size(130, 34);
            this.btnStatistic.TabIndex = 16;
            this.btnStatistic.TabStop = false;
            this.btnStatistic.Text = "Statistic";
            this.btnStatistic.UseVisualStyleBackColor = true;
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(28, 352);
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(130, 22);
            this.tbSpeed.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Скорость";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(28, 393);
            this.label6.MaximumSize = new System.Drawing.Size(130, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 20;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(32, 582);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(130, 34);
            this.btnWrite.TabIndex = 21;
            this.btnWrite.TabStop = false;
            this.btnWrite.Text = "Запись";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 549);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Записать информацию об объектах";
            // 
            // Tanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnStatistic);
            this.Controls.Add(this.lblAmountApple);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.tbCountOfApple);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCountOfTanks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTheEnd);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStart);
            this.KeyPreview = true;
            this.Name = "Tanks";
            this.Text = "Tanks";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTheEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCountOfTanks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox tbCountOfApple;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAmountApple;
        private System.Windows.Forms.Button btnStatistic;
        private System.Windows.Forms.TextBox tbSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label label3;
    }
}

