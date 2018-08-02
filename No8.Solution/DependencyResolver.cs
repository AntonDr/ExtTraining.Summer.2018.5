using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using No8.Solution.Interface;
using No8.Solution.Printers;

namespace No8.Solution
{
    public static class DependencyResolver
    {
        public static void Configure(this IKernel kernel)
        {
            kernel.Bind<IRepository<Printer>>().To<PrinterRepository>();
            kernel.Bind<ILogger<string>>().To<Logger>().WithConstructorArgument("log.txt");
            kernel.Bind<IPrinterService>().To<PrinterManager>();


        }
    }
}
