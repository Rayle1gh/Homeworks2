using System;

namespace Homework11
{
    class Program
    {
        static void Main(string[] args)
        {
            ReminderItem values = new ReminderItem(new DateTime(2020, 02, 17, 08, 00, 00), "Проснись тварь");
            ReminderItem values1 = new ReminderItem(new DateTime(2020, 03, 01, 10, 30, 00), "Проснись киберспортсмен");
            values.WriteProperties();
            values1.WriteProperties();
            Console.ReadKey();
        }
    }
}
