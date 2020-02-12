using System;

namespace Homework11
{
    public interface IReminderItem
    {
        DateTimeOffset AlarmDate { get; set; }
        string AlarmMessage { get; set; }
        TimeSpan TimeToAlarm { get; }
        bool IsOutdated { get; }
        void WriteProperties();
    }
}
