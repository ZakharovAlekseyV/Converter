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

        static void Main(string[] args)
        {
            IConverter converter = new ClassConverter();
            string output = GetOption(args).Output;
            string input = GetOption(args).Input;
            Generator.Program.WriterTradeRecord(Generator.Program.GetOptions(args));
            converter.Converter(output, input);
            
            //Task task = Class.Convert();
            //Console.WriteLine(task.Status);
            
            
        }
    }
}
