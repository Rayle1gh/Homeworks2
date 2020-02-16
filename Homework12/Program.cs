using System;
using System.Collections.Generic;

namespace Homework11
{
    class Program
    {
        static void Main(string[] args)
        {
            List < ReminderItem > list = new List<ReminderItem>();
            var value1 = new ReminderItem(new DateTime(2020, 03, 01, 10, 30, 00), "WAKE UP!");
            var value2 = new PhoneReminderItem("+79998887766", new DateTime(2020, 02, 17, 08, 00, 00), "Important call");
            var value3 = new ChatReminderItem("MoscowNeverSleep", "charaz123", new DateTime(2020, 02, 17, 08, 00, 00), "Hello");
            list.Add(value1);
            list.Add(value2);
            list.Add(value3);
            list.ForEach((l) => l.WriteProperties());
            Console.ReadKey();
        }
    }
}
