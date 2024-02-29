namespace WebApplication_AuthenticationService
{
    public class Logger : ILogger
    {
        private ReaderWriterLockSlim lock_ = new ReaderWriterLockSlim();
        private string logDirectory { get; set; }
        public Logger()
        {
            logDirectory = AppDomain.CurrentDomain.BaseDirectory + @"/_logs/" + DateTime.Now.ToString("dd-MM-yy HH-mm-ss") + @"/";

            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);
        }

        public void WriteEvent(string eventMessage)
        {
            lock_.EnterWriteLock();
            try
            {
                using (StreamWriter writer = new StreamWriter(logDirectory + "events.txt", append: true))
                {
                    writer.WriteLine(eventMessage);
                }
            }
            finally
            {
                lock_.ExitWriteLock();
            }
        }
        public void WriteError(string errorMessage)
        {
            lock_.EnterWriteLock();
            try
            {
                using (StreamWriter writer = new StreamWriter("errors.txt", append: true))
                {
                    writer.WriteLine(errorMessage);
                }
            }
            finally
            {
                lock_.ExitWriteLock();
            }
        }
    }
}
