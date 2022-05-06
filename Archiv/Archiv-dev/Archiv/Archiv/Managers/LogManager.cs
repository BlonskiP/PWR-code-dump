using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archiv.Managers
{
    
    public static class LogManager
    {
        static StreamWriter sw;
        static string logFilePath;
        public static bool isOn = true;
        static LogManager()
        {
            if (isOn)
            {
                string dirPath = Directory.GetCurrentDirectory() + @"\" + "ArchivLogs";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                logFilePath = dirPath + @"\ArchivLog-" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".txt";
                if (!File.Exists(logFilePath))
                {
                    FileStream fs = File.Create(logFilePath);
                    fs.Close();

                }
                using (sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine("Nowa sesja Archiv rozpoczęta: " + DateTime.Now);
                }
            }
        }
        public static void LogMessage(string messageToLog)
        {
            if(isOn)
            using (sw = File.AppendText(logFilePath))
            {
                string logMessage = DateTime.Now + " : " + messageToLog;
                sw.WriteLine(logMessage);
                Console.WriteLine(logMessage);
            }
        }
    }
}
