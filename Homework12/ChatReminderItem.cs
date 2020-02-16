using System;
using System.Collections.Generic;
using System.Text;

namespace Homework11
{
    class ChatReminderItem:ReminderItem
    {
        public string ChatName { get; set; }
        public string AccountName { get; set; }
        public override void WriteProperties()
        {
            base.WriteProperties();
            Console.WriteLine($"ChatName: {ChatName}\nAccountName: {AccountName}");
        }
        public ChatReminderItem(string chatName, string accountName, DateTimeOffset date, string message) : base(date, message)
        {
            ChatName = chatName;
            AccountName = accountName;
        }
    }
}
