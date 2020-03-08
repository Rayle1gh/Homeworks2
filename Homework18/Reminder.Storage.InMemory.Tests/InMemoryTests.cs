using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.InMemory;
using Reminder.Storage.Core;
using System;

namespace Reminder.Storage.InMemory.Tests
{
    [TestClass]
    public class InMemoryTests
    {
        [TestMethod()]
        public void RemoveAllTest()
        {
            var storage = new InMemoryReminderStorage();
            var item = new ReminderItem(Guid.NewGuid(), "TelegaBot", DateTimeOffset.Now, "Test ALO");
            storage.Add(item);
            var item1 = new ReminderItem(Guid.NewGuid(), "TelegaBot", DateTimeOffset.Now, "Test ALO");
            storage.Add(item1);
            var item2 = new ReminderItem(Guid.NewGuid(), "TelegaBot", DateTimeOffset.Now, "Test ALO");
            storage.Add(item2);
            storage.RemoveAll();
            var count = storage.GetList().Count;
            Assert.AreEqual(count, 0);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            var storage = new InMemoryReminderStorage();
            var item = new ReminderItem(Guid.NewGuid(), "TelegaBot", DateTimeOffset.Now, "Test ALO");
            storage.Add(item);
            storage.Remove(item.Id);
            var count = storage.GetList().Count;
            Assert.AreEqual(count, 0);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var storage = new InMemoryReminderStorage();
            var item = new ReminderItem(Guid.NewGuid(), "TelegaBot", DateTimeOffset.Now, "Test ALO");
            storage.Add(item);
            var item1 = new ReminderItem(Guid.NewGuid(), "TelegaBotYes", DateTimeOffset.Now, "Test HALLO");
            storage.Update(item.Id, item1);
            var getItem = storage.Get(item1.Id);
            Assert.AreEqual(item1, getItem);
        }

        [TestMethod()]
        public void AddTest()
        {
            var storage = new InMemoryReminderStorage();
            var item = new ReminderItem(Guid.NewGuid(), "TelegaBot", DateTimeOffset.Now, "Test ALO");
            storage.Add(item);
            var count = storage.GetList().Count;
            Assert.AreEqual(count, 1);
        }

        [TestMethod()]
        public void GetTest()
        {
            var storage = new InMemoryReminderStorage();
            var item = new ReminderItem(Guid.NewGuid(), "TelegaBot", DateTimeOffset.Now, "Test ALO");
            storage.Add(item);
            var getItem = storage.Get(item.Id);
            Assert.AreEqual(item, getItem);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var storage = new InMemoryReminderStorage();
            var item = new ReminderItem(Guid.NewGuid(), "TelegaBot", DateTimeOffset.Now, "Test ALO");
            storage.Add(item);
            var count = storage.GetList().Count;
            Assert.AreEqual(count, 1);
        }
    }
}
