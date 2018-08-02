using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Printers;

namespace No8.Solution.Interface
{
    public interface IPrinterService
    {
        void Print(Printer item);
        void Add(Printer item);
        void Remove(Printer item);
        IEnumerable<Printer> GetPrinters();

    }
}
