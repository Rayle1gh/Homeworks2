using System;
using System.Collections.Generic;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;

namespace Reminder
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new InMemoryReminderStorage();
            var item = new ReminderItem(Guid.NewGuid(), "TeleBot", DateTimeOffset.Now, "Hello man");
            storage.Add(item);
            Console.WriteLine(storage.Get(item.Id));
            storage.Remove(item.Id);

        }
    }
}
