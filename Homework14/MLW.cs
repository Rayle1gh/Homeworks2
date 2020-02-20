using System;
using System.Collections.Generic;
using System.Text;

namespace Homework13
{
    class MultipleLogWriter : AbstractLogWriter
    {
        public List<AbstractLogWriter> LogWriters { get; private set; }

        public MultipleLogWriter()
        {
            LogWriters = new List<AbstractLogWriter>();
        }

        public override void LogWriting(string message)
        {
            foreach (var item in LogWriters)
            {
                item.LogWriting(message);
            }
        }
    }
}
