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
       /* public static bool CheckValidXml(String filename)
        {
            try
            {
                ParseXml(xml);
                return true;
            }
            catch (XmlException e)
            {
                return false;
            }
        }*/
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
            string filename = @"Resources\validtst.xml";
            bool flag = !CheckValidHeader(filename);
            Console.WriteLine(flag);
            string readyToMin = "";
            string headerToKeep = "";
            //Valid header to dispose
            if (flag)
            {
                Console.WriteLine("Valid header to dispose");
                string text = File.ReadAllText(filename);

                int startIndex = text.IndexOf('<');
                int endIndex = text.IndexOf('<', text.IndexOf('<') + 1);
                headerToKeep = text.Substring(startIndex, endIndex - startIndex);

                Console.WriteLine(headerToKeep);
                // This is the fixed XML FILE
                readyToMin = text.Substring(0, startIndex) + "" +
                      text.Substring(endIndex);
            }

            System.Threading.Thread.Sleep(5000);
           
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
