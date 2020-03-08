using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.Core
{
    public class ReminderItem
    {
		public Guid Id { get; }

		public string ContactId { get; set; }

		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public ReminderItemStatus Status { get; set; } = ReminderItemStatus.Awaiting;

		public TimeSpan TimeToAlarm => Date - DateTimeOffset.Now;

		public ReminderItem(
			Guid id,
			string contactId,
			DateTimeOffset date,
			string message)
		{
			Id = id;
			ContactId = contactId;
			Date = date;
			Message = message;
		}

		public override string ToString()
		{
			return $"{typeof(ReminderItem).Name}" +
				   $":{Id}; " +
				   $"Status: {Status}; " +
				   $"Fire Date: {Date:s}; " +
				   $"Contact ID: {ContactId}; " +
				   $"Message: \"{Message}\"";
		}
	}
}
