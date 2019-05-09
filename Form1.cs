using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Video.FFMPEG;
using AForge.Video;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Opacity = 0.5; 

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        VideoFileWriter writer = new VideoFileWriter();
        int i = 0;
        int width = Screen.PrimaryScreen.Bounds.Width; 
        int height = Screen.PrimaryScreen.Bounds.Height;


        private void button1_Click_1(object sender, EventArgs e)
        {          
            i = 1; //включение
            
            Form1 form1 = new Form1();
            int w = this.Width;
            int h = this.Height;
    
            writer.Open(DateTime.Now.ToString("ddMMyyyy" + ".avi"), width, height, 115, VideoCodec.MPEG4); //создание файла
            Bitmap image = new Bitmap(width, height); 
            Graphics g = Graphics.FromImage(image); 


            while (i == 1)
            {
                Application.DoEvents();
                int x = this.Left;
                int y = this.Top;
                g = Graphics.FromImage(image); 
                g.CopyFromScreen(x, y, 0, 0, new Size(w, h)); 
                writer.WriteVideoFrame(image); 

            }
            
        
            g.Save(); 


            writer.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            width = Convert.ToInt32(textBox1.Text);
            height = Convert.ToInt32(textBox2.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            i = 0;
            writer.Close();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            int x = this.Left;
            int y = this.Top;
            Form1 form1 = new Form1();
            this.Left = x;
            this.Top = y;
        }

    }
}
