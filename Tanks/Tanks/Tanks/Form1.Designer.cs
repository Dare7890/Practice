namespace Tanks
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTheEnd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCountOfTanks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.lblTheEnd.Location = new System.Drawing.Point(24, 389);
            this.lblTheEnd.Name = "lblTheEnd";
            this.lblTheEnd.Size = new System.Drawing.Size(0, 17);
            this.lblTheEnd.TabIndex = 7;
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
            this.label2.Location = new System.Drawing.Point(27, 165);
            this.label2.MaximumSize = new System.Drawing.Size(130, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCountOfTanks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTheEnd);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStart);
            this.KeyPreview = true;
            this.Name = "Form1";
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
    }
}

