using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.Core
{
    interface IReminderStorage
    {
        void Add(ReminderItem reminderItem);

        void Update(ReminderItem reminderItem);

        ReminderItem Get(Guid id);

        void Remove(Guid id);
        void Update(Guid id, ReminderItem item);
        void RemoveAll();
    }
}
