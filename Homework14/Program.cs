using System;
using System.Collections.Generic;

namespace Homework14
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AbstractLogWriter> list = new List<AbstractLogWriter>
            {
                ConsoleLogWriter.GetInstance(), FileLogWriter.GetInstance()
            };
            MultipleLogWriter mlw = MultipleLogWriter.GetInstance(list);
            mlw.LogError("Error message");
            mlw.LogInfo("Info message");
            mlw.LogWarning("Warning message");
            Console.ReadKey();
        }
    }
}
