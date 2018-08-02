using System;

namespace No8.Solution
{
    public class PrintFinishEventArgs:EventArgs
    {
        public PrintFinishEventArgs(string name, string model, string message)
        {
            Name = name;
            Model = model;
            Message = message;
        }

        public string Name { get; private set; }
        public string Model { get; private set; }
        public string Message { get; private set; }
    }
}