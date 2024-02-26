namespace WebApplication_AuthenticationService
{
    public class Logger : ILogger
    {
        private string logFolderPath;
        public Logger()
        {
            logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

            if (Directory.Exists(logFolderPath))
            {
                
                Directory.Delete(logFolderPath,true);
            }

            Directory.CreateDirectory(logFolderPath);
        }
        public void WriteEvent(string eventMessage)
        {
            Console.WriteLine(eventMessage);

            string logFilePath = Path.Combine(logFolderPath, "events.txt");

            File.AppendAllText(logFilePath, $"{DateTime.Now} - {eventMessage}\n");
        }
        public void WriteError(string errorMessage)
        {
            Console.WriteLine(errorMessage);

            string logFilePath = Path.Combine(logFolderPath, "errors.txt");

            File.AppendAllText(logFilePath, $"{DateTime.Now} - {errorMessage}\n");
        }
    }
}
