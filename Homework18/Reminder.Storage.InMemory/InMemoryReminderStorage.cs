using System;
using System.Collections.Generic;
using System.Linq;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory
{
    public class InMemoryReminderStorage
    {
        internal readonly Dictionary<Guid, ReminderItem> reminders = new Dictionary<Guid, ReminderItem>();

        public void Add(ReminderItem item)
        {
            reminders.Add(item.Id, item);
        }

        public ReminderItem Get(Guid id)
        {
            if (reminders.ContainsKey(id))
                return reminders[id];
            else
                throw new Exception("Не найдено");
        }

        public List<ReminderItem> GetList()
        {
            return reminders.Select(a => a.Value).ToList();
        }

        public void Remove(Guid id)
        {
            if (reminders.ContainsKey(id))
            {
                reminders.Remove(id);
            }
        }

        public void Update(Guid id, ReminderItem item)
        {
            Remove(id);
            Add(item);
        }

        public void RemoveAll()
        {
            reminders.Clear();
        }
    }
}
