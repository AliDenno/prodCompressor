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
            //Console.WriteLine(Directory.GetCurrentDirectory());
            Prod prod = new Prod(@"Resources\1.xmf");
            prod.Operate(@"Resources\Result\1.xmf");
        }
    }
}
