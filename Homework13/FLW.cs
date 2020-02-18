using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Homework13
{
    class FileLogWriter : AbstractLogWriter, IDisposable
    {
        private StreamWriter _writer;
        public FileLogWriter(string logFile = "log.txt")
        {
            _writer = new StreamWriter(File.Open(logFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read));
            _writer.BaseStream.Seek(0, SeekOrigin.End);
        }
        public override void LogWriting(string message)
        {
            _writer.WriteLine(message);
            _writer.Flush();
        }
        public void Dispose()
        {
            if (_writer != null)
            {
                _writer.Dispose();
            }
        }
    }
}
