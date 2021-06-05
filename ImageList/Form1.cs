using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ImageList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int Num = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            imageList.Images.Add(Image.FromFile(@"C:\Users\Lil Nex\Pictures\1.png"));
            imageList.Images.Add(Image.FromFile(@"C:\Users\Lil Nex\Pictures\2.jpg"));
            imageList.Images.Add(Image.FromFile(@"C:\Users\Lil Nex\Pictures\3.jpg"));
            imageList.Images.Add(Image.FromFile(@"C:\Users\Lil Nex\Pictures\4.jpg"));
            imageList.Images.Add(Image.FromFile(@"C:\Users\Lil Nex\Pictures\5.jpg"));
        }

        private void btnPremier_Click(object sender, EventArgs e)
        {
            Num = 0;
            pictureBox1.Image = imageList.Images[Num];
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            if (Num == 0)
            {
                Num = imageList.Images.Count - 1;

            }
            else Num -= 1;
            pictureBox1.Image = imageList.Images[Num];

        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            if (Num == imageList.Images.Count - 1)
            {
                Num = 0;

            }
            else Num += 1;
            pictureBox1.Image = imageList.Images[Num];
        }

        private void btnDernier_Click(object sender, EventArgs e)
        {
            Num = imageList.Images.Count - 1;
            pictureBox1.Image = imageList.Images[Num];
        }
        System.Timers.Timer timer = new System.Timers.Timer(750);

        private void btnDiapo_Click(object sender, EventArgs e)
        {
            /*
            timer.Elapsed += OnTimedEvent;    
            timer.Start();
            pictureBox1.Image = imageList.Images[0];
            */
            imageList.ImageSize = new Size(255, 255);
            Graphics g = Graphics.FromHwnd(this.Handle);
            for (int i = 0; i < imageList.Images.Count; i++)
            {
                //imageList.Draw(g, new Point(40, 40), i);
                //MessageBox.Show("test");
                pictureBox1.Image = imageList.Images[i];

                Application.DoEvents();

                Thread.Sleep(1000);


            }
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Num++;
            if(Num< imageList.Images.Count )
            {
                pictureBox1.Image = imageList.Images[Num];
                timer.Start();

            }
            else { 
                Num = 0;
                timer.Stop();
            }


        }
    }
}
