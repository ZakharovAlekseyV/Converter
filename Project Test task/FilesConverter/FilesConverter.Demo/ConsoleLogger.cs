using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesConverter.Demo
{
    class ConsoleLogger:ILogger
    {
        public void Info (string msg)
        {
            Console.WriteLine($"Info : {msg}");
        }
        public void Warning (string msg)
        {
            Console.WriteLine($"Warning : {msg}");
        }
        public void Error (string msg)
        {
            Console.WriteLine($"Error : {msg}");
        }
    }
}
