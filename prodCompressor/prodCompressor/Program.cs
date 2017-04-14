using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Linq;

namespace prodCompressor
{
    class Program
    {
        public static bool CheckValidHeader(String filename)
        {
            string line1 = "";
            using (StreamReader reader = new StreamReader(filename))
            {
                line1 = reader.ReadLine();
            }
            return (line1.LastIndexOf("HEADER") <= 0);
        }
   
        static void Main(string[] args)
        {
            string filename = @"Resources\test.xml";
            bool flag = !CheckValidHeader(filename);
            Console.WriteLine(flag);

            string text = File.ReadAllText(@"Resources\test.xml");

            int startIndex = text.IndexOf('<');
            int endIndex = text.IndexOf('<', text.IndexOf('<') + 1);
            string header = text.Substring(startIndex, endIndex - startIndex);

            // This is the fixed XML FILE
            string readyToMin = text.Substring(0, startIndex) + "" +
                  text.Substring(endIndex);
            //Console.WriteLine(replaced);
            //System.Threading.Thread.Sleep(5000);
            var minifiedXml = new XMLMinifier(XMLMinifierSettings.Aggressive).Minify(readyToMin);
            File.WriteAllText(@"C:\Users\ali-d\Desktop\Programming\prodCompressor\prodCompressor\prodCompressor\bin\Debug\Resources\Result\res.xmf", minifiedXml);


            //Console.WriteLine(Directory.GetCurrentDirectory());
            //Prod prod = new Prod(@"Resources\1.xmf");
            //prod.Operate(@"Resources\Result\1.xmf");
        }
    }
}
