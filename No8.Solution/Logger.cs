using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using No8.Solution.Interface;

namespace No8.Solution
{
    internal class Logger:ILogger<string>
    {
        public Logger(string destinationPath)
        {
            DestinationPath = destinationPath;
        }

        public string DestinationPath{ get; private set; }

        public void Log(string s)
        {
            using (var sw = new StreamWriter(Path.GetFullPath(DestinationPath), true, System.Text.Encoding.Default))
            {
                sw.WriteLine(s);
            }
        }
        //File.AppendText(Path.GetFullPath(DestinationPath)).Write(s);
    }
}
