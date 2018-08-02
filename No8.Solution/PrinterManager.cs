using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using No8.Solution.Interface;
using No8.Solution.Printers;

namespace No8.Solution
{
    //public delegate void PrinterDelegate(string arg);


    //не забыть поменять на internal
    public sealed class PrinterManager : IPrinterService
    {
        public event EventHandler<PrintStartEventArgs> PrintStartEventHandler = delegate { };
        public event EventHandler<PrintFinishEventArgs> PrintFinishEventHandler = delegate { };

        
        private readonly ILogger<string> logger;
        private readonly IRepository<Printer> repository;


        public PrinterManager(ILogger<string> logger,IRepository<Printer> repository)
        {
            if (logger ==null || repository == null)
            {
                throw new ArgumentNullException();
            }

            this.logger = logger;
            this.repository = repository;
        }

        //static PrinterManager()
        //{
        //    Printers = new List<Printer>();
        //}

        //public static List<object> Printers { get; set; }

        public void Add(Printer printer)
        {
            //Console.WriteLine("Enter printer name");
            //p1.Name = Console.ReadLine();
            //Console.WriteLine("Enter printer model");
            //p1.Model = Console.ReadLine();
            
            repository.Add(printer);
            logger.Log($"Printer {printer.Name} {printer.Model} added");
            //if (!printers.Contains(printer))
            //{
            //    printers.Add(printer);
            //    //Console.WriteLine("Printer added");
            //}
        }

        public void Remove(Printer printer)
        {
            repository.Remove(printer);
            logger.Log($"Printer {printer.Name} {printer.Model} removed");
        }

        public void Print(Printer printer)
        { 
            OnPrintStartEventArgs(new PrintStartEventArgs(printer.Name,printer.Model,"start working"));

            var o = new OpenFileDialog();
            o.ShowDialog();
            var f = File.OpenRead(o.FileName);

            printer.Print(f);

            OnPrintFinishEventArgs(new PrintFinishEventArgs(printer.Name, printer.Model, "start working"));
        }

        public IEnumerable<Printer> GetPrinters() => repository.GetAll();

        private void OnPrintStartEventArgs(PrintStartEventArgs e)
        {
            logger.Log($"Printer {e.Name} {e.Model} start printing");
            PrintStartEventHandler(this, e);
        }

        private void OnPrintFinishEventArgs(PrintFinishEventArgs e)
        {
            logger.Log($"Printer {e.Name} {e.Model} finished printing");
            PrintFinishEventHandler(this, e);
        }
        //public static void Print(CanonPrinter p1)
        //{
        //    Log("Print started");
        //    var o = new OpenFileDialog();
        //    o.ShowDialog();
        //    var f = File.OpenRead(o.FileName);
        //    p1.Print(f);
        //    Log("Print finished");
        //}

        //public static event PrinterDelegate OnPrinted;
    }
}