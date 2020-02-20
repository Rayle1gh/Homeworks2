using System;
using System.Collections.Generic;
using System.Text;

namespace Homework13
{
    public class LogWriterFactory
    {
        private static LogWriterFactory instance;

        private LogWriterFactory()
        {

        }

        public T GetLogWriter<T>(params AbstractLogWriter[] abstractLogWriters) where T : AbstractLogWriter, new()
        {
            T logWriter = new T();

            if (abstractLogWriters != null)
            {
                switch (logWriter)
                {
                    case MultipleLogWriter mlw:
                        mlw.LogWriters.AddRange(abstractLogWriters);
                        break;
                }
            }

            return logWriter;
        }

        public static LogWriterFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new LogWriterFactory();
            }
            return instance;
        }
    }
}
