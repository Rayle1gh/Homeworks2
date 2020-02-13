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
        public void WriteProperties()
        {
            Console.WriteLine("AlarmDate: {0}\nAlarmMessage: {1}\nTimeToAlarm: {2:%d} days {2:%h} hours {2:%m} minutes {2:%s} seconds\nIsOutdated: {3}",
                 AlarmDate.DateTime, AlarmMessage, TimeToAlarm, IsOutdated);
        }
        public ReminderItem(DateTimeOffset date, string message)
        {
            AlarmDate = date;
            AlarmMessage = message;
        }
    }
}
