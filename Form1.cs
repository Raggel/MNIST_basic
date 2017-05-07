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
        public DataImages TrainBaseMemStream = new DataImages(@"C:\Users\Саша\Documents\RAD Studio\Projects\NeuroNet_MNIS\Win32\Debug\TrainMNIST-60k.dat");
        public DataImages TestBaseMemStream = new DataImages(@"C:\Users\Саша\Documents\RAD Studio\Projects\NeuroNet_MNIS\Win32\Debug\TestMNIST-10k.dat");
        NeuronNetwork nNet;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nNet = new NeuronNetwork(784, 30);
            nNet.addLayer(10, layerType.OutputLayer);
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
            for (int i = 0; i < 100000; i++)
            {
                iRnd = rnd.Next(0, 60000 - 1);
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
            iRnd = rnd.Next(0, 60000 - 1);
            TrainBaseMemStream.loadPattern(iRnd, p);
            nNet.getAnswer(p.data);
            double[] result = nNet.getAnswer(p.data);
            label1.Text = result[0].ToString("N4");
            label2.Text = result[1].ToString("N4");
            label3.Text = result[2].ToString("N4");
            label4.Text = result[3].ToString("N4");
            label5.Text = result[4].ToString("N4");
            label6.Text = result[5].ToString("N4");
            label7.Text = result[6].ToString("N4");
            label8.Text = result[7].ToString("N4");
            label9.Text = result[8].ToString("N4");
            label10.Text = result[9].ToString("N4");
            label11.Text = p.val.ToString();
        }
    }
}
