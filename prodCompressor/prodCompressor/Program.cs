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
        static void Main(string[] args)
        {
            var sampleXml = File.ReadAllText(@"Resources\1.xmf");
            var minifiedXml = new XMLMinifier(XMLMinifierSettings.Aggressive).Minify(sampleXml);
            var path = @"Resources\Result\1.xmf";
            File.WriteAllText(path, minifiedXml);
            Console.WriteLine("Done");
        }
    }
}
