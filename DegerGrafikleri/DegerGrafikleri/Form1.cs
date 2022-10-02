using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace DegerGrafikleri
{
    public partial class Form1 : Form
    {
        string sonuc;
        long maksm = 4, minm = 0;
        string sonuc2;
        long maksm2 = 4, minm2 = 0;
        public Form1()
        {
            InitializeComponent();
            serialPort1.PortName="COM3";
            serialPort1.BaudRate = 9600;
            serialPort2.PortName = "COM8";
            serialPort2.BaudRate = 9600;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
            serialPort2.Open();
            timer1.Start();
            button1.Enabled = false;

        }

        private void label3_Click(object sender, EventArgs e)
        {
 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            serialPort2.Close();
            timer1.Stop();
            button1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Minimum = minm;
            chart1.ChartAreas[0].AxisX.Maximum = maksm;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 200;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(minm, maksm);

            chart2.ChartAreas[0].AxisX.Minimum = minm2;
            chart2.ChartAreas[0].AxisX.Maximum = maksm2;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = 500;
            chart2.ChartAreas[0].AxisX.ScaleView.Zoom(minm2, maksm2);
            //serialPort1.Write("1");
            sonuc = serialPort1.ReadLine();
            if(sonuc!=null )
            {
                label1.Text = sonuc + "";
                this.chart1.Series[0].Points.AddXY((minm + maksm) / 2, sonuc);
                maksm++;
                minm++;
            }
            // serialPort2.Write("2");
            sonuc2 = serialPort2.ReadLine();
            if (sonuc2 != null)
            {
                label2.Text = sonuc2 + "";
                this.chart2.Series[0].Points.AddXY((minm2 + maksm2) / 2, sonuc2);
                maksm2++;
                minm2++;
            }

            serialPort1.DiscardInBuffer();
            serialPort2.DiscardInBuffer();
        }

    }
}
