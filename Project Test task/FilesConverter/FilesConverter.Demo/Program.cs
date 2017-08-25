using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using System.IO;
using FilesConverter;
using FilesConverter.Generator;


namespace FilesConverter.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = GetOption(args).Output;
            string input = GetOption(args).Input;
            FilesConverter.Generator.Program.WriterTradeRecord(FilesConverter.Generator.Program.GetOptions(args));
            ILogger log = new ConsoleLogger();// создал объект чтобы проинициализировать свойство
            ConverterFactory cf = new ConverterFactory();
            cf.ConverterLogger = log;
            IConverter ConverterBinaryToCSV = cf.CreateConverter(ConvertationType.BinaryToCsv);
            Task task = new Task(() => ConverterBinaryToCSV.Convert(output, input));
            task.Start();
            
            task.Wait();
            Console.ReadLine();
        }

        private static Options GetOption(string[] args)
        {
            Options option = new Options();
            if (!Parser.Default.ParseArguments(args, option))
            {
                Console.WriteLine("Invalid arguments. Press any key for exit");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            return option;
        }
    }
}
