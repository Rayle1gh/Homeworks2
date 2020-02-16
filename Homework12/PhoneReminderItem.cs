using System;
using System.Collections.Generic;
using System.Text;

namespace Homework11
{
    class PhoneReminderItem:ReminderItem
    {
        public string PhoneNumber { get; set; }
        public override void WriteProperties()
        {
            base.WriteProperties();
            Console.WriteLine($"PhoneNumber: {PhoneNumber}");
        }
        public PhoneReminderItem(string phoneNumber, DateTimeOffset date, string message) : base(date, message)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
