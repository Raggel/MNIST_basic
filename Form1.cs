using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basic_Neuron_Network;

namespace MNIST_basic
{

    public partial class Form1 : Form
    {
        public DataImages TrainBaseMemStream = new DataImages(Application.StartupPath + @"\TrainMNIST-60k.dat");
        public DataImages TestBaseMemStream = new DataImages(Application.StartupPath + @"\TestMNIST-10k.dat");
        NeuronNetwork nNet;
        public NeuronNetRepository NetRep = new NeuronNetRepository(Application.StartupPath + @"\Network1.dat");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nNet = new NeuronNetwork(784, 300);
            nNet.addLayer(10, layerType.OutputLayer);
            new NeuronNetRepository(Application.StartupPath + @"\Network1.dat");
            NetRep.loadNet(nNet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pattern p = new Pattern();
            TrainBaseMemStream.loadPattern(2, p);
            double[] target = new double[10];
            for (int i = 0; i < 10; i++)
                target[i] = 0;
            target[p.val] = 1;
            nNet.trainSingle(p.data, target);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pattern p = new Pattern();
            Random rnd = new Random();
            int iRnd = new int();
            double[] target = new double[10];
            for (int i = 0; i < 1200000; i++)
            {
                iRnd = rnd.Next(0, 60000);
                TrainBaseMemStream.loadPattern(iRnd, p);
                for (int j = 0; j < 10; j++)
                    target[j] = 0;
                target[p.val] = 1;
                nNet.trainSingle(p.data, target);
                this.Text = i.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pattern p = new Pattern();
            Random rnd = new Random();
            int iRnd = new int();
            iRnd = rnd.Next(0, 60000);
            TrainBaseMemStream.loadPattern(iRnd, p);
            nNet.getAnswer(p.data);
            double[] result = nNet.getAnswer(p.data);
            label1.Text = result[0].ToString("N8");
            label2.Text = result[1].ToString("N8");
            label3.Text = result[2].ToString("N8");
            label4.Text = result[3].ToString("N8");
            label5.Text = result[4].ToString("N8");
            label6.Text = result[5].ToString("N8");
            label7.Text = result[6].ToString("N8");
            label8.Text = result[7].ToString("N8");
            label9.Text = result[8].ToString("N8");
            label10.Text = result[9].ToString("N8");
            label11.Text = p.val.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NetRep.saveNet(nNet);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NetRep.loadNet(nNet);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            NetRep.saveNet(nNet);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Stop";
            }
            else
            {
                checkBox1.Text = "Start";
            }
            Pattern p = new Pattern();
            Random rnd = new Random();
            int iRnd;
            int i = 0;
            double[] target = new double[10];
            while (checkBox1.Checked)
            {
                i++;
                iRnd = rnd.Next(0, 60000);
                TrainBaseMemStream.loadPattern(iRnd, p);
                for (int j = 0; j < 10; j++)
                    target[j] = 0;
                target[p.val] = 1;
                nNet.trainSingle(p.data, target);
                this.Text = i.ToString();
                Application.DoEvents();
            }
        }
    }
}
