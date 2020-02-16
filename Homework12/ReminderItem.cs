using System;

namespace Homework11
{
    public class ReminderItem : IReminderItem
    {
        public DateTimeOffset AlarmDate { get; set; }
        public string AlarmMessage { get; set; }
        public TimeSpan TimeToAlarm { get { return DateTimeOffset.Now - AlarmDate; } }
        public bool IsOutdated
        {
            get
            {
                if (TimeToAlarm.TotalMilliseconds >= 0)
                    return true;
                return false;
            }
        }
        public virtual void WriteProperties()
        {
            Console.WriteLine("\n{0}:\n\nAlarmDate: {1}\nAlarmMessage: {2}\nTimeToAlarm: {3:%d} days {3:%h} hours {3:%m} minutes {3:%s} seconds\nIsOutdated: {4}",
                 GetType().Name, AlarmDate.DateTime, AlarmMessage, TimeToAlarm, IsOutdated);
        }

        public ReminderItem(DateTimeOffset date, string message)
        {
            AlarmDate = date;
            AlarmMessage = message;
        }
    }
}
