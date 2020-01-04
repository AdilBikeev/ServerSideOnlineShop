using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace HttpServer.Common.Loggers
{
    public class Logger
    {
        /// <summary>
        /// Путь к дерриктории с логами
        /// </summary>
        public static string Path { get; set; }

        /// <summary>
        /// Имя лог-файла
        /// </summary>
        public string FileName { get; set; }

        public Logger(string fileName)
        {
            this.FileName = $"{fileName}.log";
        }

        public async void Log (string text)
        {
            try
            {
                StreamWriter sw;
                var allNamePath = $"{Path}/{this.FileName}";
                if (File.Exists(allNamePath))
                {
                    using(sw = new StreamWriter(allNamePath, true, System.Text.Encoding.Default))
                    {
                        await sw.WriteAsync($"{DateTime.Now} {text}\n");
                    }
                }
                else
                {
                    using (sw = new StreamWriter(allNamePath, false, System.Text.Encoding.Default))
                    {
                        await sw.WriteAsync($"{DateTime.Now} {text}\n");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
