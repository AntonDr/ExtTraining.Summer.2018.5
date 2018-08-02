namespace No8.Solution.Printers
{
    public class CanonPrinter:Printers.Printer
    {
        public override string Name => "Canon";
        public CanonPrinter(string model):base(model){ }
    }
}