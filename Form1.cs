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
    }
}
