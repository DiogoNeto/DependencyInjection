namespace SimpleDI
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger;

            //Choose object type
            //String loggerType = "text";
            String loggerType = "database";

            switch (loggerType)
            {
                case "database":
                    logger = new DatabaseLogger();
                    break;
                default:
                    logger = new TextLogger();
                    break;
            }

            LogManager logManager = new LogManager(logger);

            try
            {
                throw new DivideByZeroException();
            }
            catch (Exception e)
            {
                logManager.Log(e.Message);
                Console.ReadLine();
            }
        }
    }
    
    class LogManager
    {
        private ILogger _logger;

        public LogManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(String message)
        {
            _logger.Log(message);
        }
    }

    interface ILogger
    {
        void Log(string message);
    }


    class TextLogger : ILogger
    {
        public void Log(String message)
        {
            Console.WriteLine("Log to a text file: " + message);
        }
    }

    class DatabaseLogger: ILogger 
    {
        public void Log(String message)
        {
            Console.WriteLine("Log to a database: " + message);
        }
    }
}