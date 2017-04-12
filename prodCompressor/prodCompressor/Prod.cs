using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace prodCompressor
{
    class Prod
    {
        string path = "";
        public Prod(string path)
        {
            this.path = path;
        }
        public void Operate(string path)
        {
            var sampleXml = File.ReadAllText(this.path);
            var minifiedXml = new XMLMinifier(XMLMinifierSettings.Aggressive).Minify(sampleXml);
            File.WriteAllText(path, minifiedXml);
        }
    }
}
