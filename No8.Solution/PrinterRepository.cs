using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Interface;
using No8.Solution.Printers;
using No8.Solution.Mappers;

namespace No8.Solution
{
    internal class PrinterRepository : IRepository<Printers.Printer>
    {
        private List<DalPrinter> printers = new List<DalPrinter>();

        public void Add(Printer item)
        {
            if (printers.Contains(item.ToDalPrinter()))
            {
                throw new InvalidOperationException($"This printer already exist");
            }

            printers.Add(item.ToDalPrinter());
        }

        public IEnumerable<Printer> GetAll()
        {
            if (printers.Count == 0)
            {
                throw new ArgumentException($"There is currently no printer");
            }

            IEnumerable<Printer> GetPrinters()
            {
                foreach (var item in printers)
                {
                    yield return item.ToPrinter();
                }
            }

            return GetPrinters();
        }

        public void Remove(Printer item)
        {
            if (!printers.Contains(item.ToDalPrinter()))
            {
                throw new InvalidOperationException($"This printer is not exist");
            }

            printers.Remove(item.ToDalPrinter());
        }
    }
}
