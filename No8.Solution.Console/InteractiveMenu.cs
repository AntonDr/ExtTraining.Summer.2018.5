using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using No8.Solution.Interface;

namespace No8.Solution.Console
{
    public static class InteractiveMenu
    {
        private static readonly IKernel resolver;
        private static readonly IPrinterService service;

        static InteractiveMenu()
        {
            resolver = new StandardKernel(new NinjectSettings());
            resolver.Configure();
            service = resolver.Get<IPrinterService>();
        }


        public static void Start()
        {
            while (true)
            {
                StartMenu();
            } 
           
        }

        private static void CreatePrinter()
        {
            System.Console.Clear();
            System.Console.WriteLine("Enter printer name");
            string name = System.Console.ReadLine();
            System.Console.WriteLine("Enter printer model");
            string model = System.Console.ReadLine();
            service.Add(PrintersFabric.Create(name, model));
        }

        private static void RemovePrinter()
        {
            System.Console.Clear();
            System.Console.WriteLine("Enter printer name");
            string name = System.Console.ReadLine();
            System.Console.WriteLine("Enter printer model");
            string model = System.Console.ReadLine();
            service.Remove(PrintersFabric.Create(name, model));
        }

        private static void GetListPrinters()
        {
            System.Console.Clear();
            int i = 1;

            foreach (var item in service.GetPrinters())
            {
                System.Console.WriteLine($"{i++}: {item.Name} {item.Model} ");
            }

            System.Console.WriteLine($"{i}:To main menu");

            var key = System.Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                CreatePrinter();
            }
        }

        private static void StartMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("Select your choice:");
            System.Console.WriteLine("1:Add new printer");
            System.Console.WriteLine("2:Get a list of printers");
            System.Console.WriteLine("3:Remove printer");
            System.Console.WriteLine("4:Print on selected printer");

            var key = System.Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                CreatePrinter();
            }

            if (key.Key == ConsoleKey.D2)
            {
                GetListPrinters();
            }

            if (key.Key == ConsoleKey.D3)
            {
                RemovePrinter();
            }

            if (key.Key == ConsoleKey.D4)
            {
                
                Print();
            }
        }

        private static void Print()
        {
            System.Console.Clear();
            System.Console.WriteLine("Enter printer name");
            string name = System.Console.ReadLine();
            System.Console.WriteLine("Enter printer model");
            string model = System.Console.ReadLine();
            service.Print(PrintersFabric.Create(name, model));

        }
    }
}
