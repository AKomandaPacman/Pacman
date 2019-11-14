using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Singleton
{
    public class Logger
    {
        private static readonly Logger _instance = new Logger();

        private string LastLog;

        private Logger()
        {
            if (File.Exists("log.txt")) File.Delete("log.txt");
        }

        public static Logger GetLogger()
        {
            return _instance;
        }

        public static void Error(String text)
        {

        }

        public void Log(String text)
        {
            Console.WriteLine(text);

            using(StreamWriter w = File.AppendText("log.txt"))
            {
                w.WriteLine(text);
            }

            this.LastLog = text;
        }

        public string GetLastLog()
        {
            return LastLog;
        }
    }
}
