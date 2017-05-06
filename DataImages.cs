using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MNIST_basic
{

    public class Pattern
    {
        public byte val;
        public byte[] rawData;
        public double[] data;

        public Pattern()
        {
            rawData = new byte[784];
            data = new double[784];
        }

        public void normalize()
        {
            for (int i = 0; i < 784; i++)
                data[i] = 2.0 / 255 * rawData[i] - 1;
        }
    }


    public class DataImages
    {
        string fileName;
        MemoryStream memStream;

        public void loadPattern(int index, Pattern p)
        {
            memStream.Position = index * (p.data.Length + 1);
            p.val = (Byte)memStream.ReadByte();
            memStream.Read(p.rawData, 0, p.data.Length);
            p.normalize();
        }

        public DataImages(string fileName)
        {
            this.fileName = fileName;
            memStream = new MemoryStream();
            FileStream fs = File.OpenRead(fileName);
            fs.CopyTo(memStream);
            fs.Close();
        }

        ~DataImages()
        {
            memStream.Close();
        }
    }
}
