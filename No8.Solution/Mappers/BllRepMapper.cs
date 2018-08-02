using No8.Solution.Printers;

namespace No8.Solution.Mappers
{
    public static class BllRepMapper
    {
        public static DalPrinter ToDalPrinter(this Printer printer)
        {
            return new DalPrinter()
            {
                Name = printer.Name,
                Model = printer.Model
            };
        }

        public static Printer ToPrinter(this DalPrinter printer)
        {
            return PrintersFabric.Create(printer.Name, printer.Model);
        }
    }
}