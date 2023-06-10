using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using RestSharp;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace AddWatermarkOnVideos
{
    public partial class Form1 : Form
    {
        public string filename;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(filename);
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            filename = openFileDialog1.FileName;
            label1.Text = filename;
            label1.ForeColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (filename == null || filename=="")
            
            {
                MessageBox.Show("Выберите видео!");
                return;
            }

            var client = new RestClient("http://work.zxcvbnm.online");
           
            var request = new RestRequest("tester/watermark/", Method.Post);
            request.AddFile("video", filename);
            var response = client.Execute<Form1>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                File.WriteAllBytes("example.mp4", response.RawBytes);
                label1.ForeColor = Color.Green;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://work.zxcvbnm.online");

            var request = new RestRequest("/get/version/app/", Method.Post);
            request.AddFile("video", "D:\\Downloads\\response6.mp4");
            var response = client.Execute<Form1>(request);
            Console.WriteLine(response.Content);
            MessageBox.Show(response.ErrorMessage);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (label1.ForeColor == Color.Green){
                Process.Start("example.mp4");
            }
        }
    }
}
