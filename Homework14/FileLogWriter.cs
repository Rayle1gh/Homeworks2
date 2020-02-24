using System;
using System.IO;

namespace Homework14
{
    class FileLogWriter : AbstractLogWriter, IDisposable
    {
        private static FileLogWriter _fileLogWriter;
        private static StreamWriter _writer;

        private FileLogWriter() { }
        public override void LogWriting(string message)
        {
            _writer.WriteLine(message);
            _writer.Flush();
        }
        public override void Dispose()
        {
            _writer?.Dispose();
        }

        public static FileLogWriter GetInstance(string logFile = "log.txt")
        {
            _writer = new StreamWriter(File.Open(logFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read));
            _writer.BaseStream.Seek(0, SeekOrigin.End);
            return _fileLogWriter ??= new FileLogWriter();
        }
    }
}
