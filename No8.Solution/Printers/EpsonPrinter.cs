namespace No8.Solution.Printers
{
    internal class EpsonPrinter:Printers.Printer
    {
        public override string Name => "Epson";
        public EpsonPrinter(string model):base(model) {}
    }
}