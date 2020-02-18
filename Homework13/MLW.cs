using System;
using System.Collections.Generic;
using System.Text;

namespace Homework13
{
    class MultipleLogWriter : AbstractLogWriter
    {

        private List<AbstractLogWriter> _list;
        public MultipleLogWriter(List<AbstractLogWriter> list)
        {
            _list = list;
        }
        public override void LogWriting(string message)
        {
            foreach (AbstractLogWriter a in _list)
            {
                a.LogWriting(message);
            }
        }
    }
}
