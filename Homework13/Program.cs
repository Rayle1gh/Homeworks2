using System;
using System.Collections.Generic;

namespace Homework13
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AbstractLogWriter> list = new List<AbstractLogWriter>();
            list.Add(new ConsoleLogWriter());
            list.Add(new FileLogWriter());
            MultipleLogWriter mlw = new MultipleLogWriter(list);
            mlw.LogError("Error message");
            mlw.LogInfo("Info message");
            mlw.LogWarning("Warning message");
            Console.ReadKey();
        }
    }
}
