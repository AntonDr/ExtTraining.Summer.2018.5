using System;
using Ninject;
using No8.Solution;
using No8.Solution.Interface;
using No8.Solution.Printers;

namespace No8.Solution.Console
{
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            InteractiveMenu.Start();
        }
    }
}
