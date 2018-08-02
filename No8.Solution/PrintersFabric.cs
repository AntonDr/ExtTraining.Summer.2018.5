using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Printers;

namespace No8.Solution
{
    public static class PrintersFabric
    {
        public static Printer Create(string name, string model)
        {
            switch (name)
            {
                case "Epson":
                    return new EpsonPrinter(model);
                case "Canon":
                    return new CanonPrinter(model);
                default:
                    throw new  ArgumentException($"Invalid {name}");
            }
        }
    }
}
