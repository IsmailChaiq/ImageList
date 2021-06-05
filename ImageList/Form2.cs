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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private  void affecterImage(int index)
        {
            pictureBox1.Image = imageList1.Images[index];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                Thread t1 = new Thread(delegate () { affecterImage(i); });

                t1.Start();
                Application.DoEvents();

                Thread.Sleep(500);


            }
        }
    }
}
