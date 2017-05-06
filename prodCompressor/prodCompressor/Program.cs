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
        /////////////////////////////////////////////////////EXPERIMENTAL////////////////////////////////////////////////////////
        public static void Operate(String assetName)
        {
            string filename = assetName;
            bool flag = !CheckValidHeader(filename);

            string readyToMin = "";
            string headerToKeep = "";
            //Valid header to dispose
            if (flag)
            {
                
                string text = File.ReadAllText(filename);
                int startIndex = text.IndexOf('<');
                int endIndex = text.IndexOf('<', text.IndexOf('<') + 1);
                headerToKeep = text.Substring(startIndex, endIndex - startIndex);
                // This is the fixed XML FILE
                readyToMin = text.Substring(0, startIndex) + "" +
                      text.Substring(endIndex);
            }
            else
            {
                readyToMin = File.ReadAllText(filename);
            }
            //System.Threading.Thread.Sleep(5000);

            var minifiedXml = new XMLMinifier(XMLMinifierSettings.Aggressive).Minify(readyToMin);
            File.WriteAllText(assetName, headerToKeep.Replace(System.Environment.NewLine, "") + minifiedXml);
            Console.WriteLine("DONE");
        }
            /////////////////////////////////////////////////////EXPERIMENTAL////////////////////////////////////////////////////////
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
            /////////////////////////////////////////////////////EXPERIMENTAL////////////////////////////////////////////////////////
            //-xaf, XAF-xmf, XMF-XSF, xsf-xml, XML-XRF, xrf-
            string[] fileEntries = Directory.GetFiles(@"C:\Users\ali-d\Desktop\In Progress\IMVU_Publishing\TESTSIZE\TESTPROGRAM");
           
            foreach (string fileName in fileEntries)
            {
                Console.WriteLine(fileName);
                string temp = Path.GetExtension(fileName);
                if (temp == ".xml" || temp == ".XML" || temp ==".xaf" || temp == ".XAF" || temp == ".xmf" || temp == ".XMF" || temp == ".xrf" || temp == ".XRF" || temp == ".xsf" || temp == ".XSF")
                {
                    Operate(fileName);
                }
                
            }
            Console.WriteLine("Congrats");

            /////////////////////////////////////////////////////EXPERIMENTAL////////////////////////////////////////////////////////


            /*
            //////////////////Once you get back here start working on traversing CHKN File and altering it//////////////////////

            string filename = @"Resources\Lux.xmf";
            bool flag = !CheckValidHeader(filename);

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
                // This is the fixed XML FILE
                readyToMin = text.Substring(0, startIndex) + "" +
                      text.Substring(endIndex);
            }
            else
            {
                readyToMin= File.ReadAllText(filename);
            }
            //System.Threading.Thread.Sleep(5000);
           
            var minifiedXml = new XMLMinifier(XMLMinifierSettings.Aggressive).Minify(readyToMin);
            File.WriteAllText(@"Resources\resultLux.xmf", headerToKeep.Replace(System.Environment.NewLine, "") + minifiedXml);
            Console.WriteLine("DONE");

            
              //The prod class would make sense once u start working on traversing the chkn file
            
          */
        }
    }
}
