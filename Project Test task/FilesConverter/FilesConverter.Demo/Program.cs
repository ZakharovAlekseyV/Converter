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
    /*class Options
    {
        [Option('o', "output", Required = true)]
        public string Output { get; set; }
        [Option('n', "number", Required = true)]
        public int Number { get; set; }
        [Option ('i', "input",Required = true)]
        public string Input { get; set; }
    }*/

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
            Generator.Program.WriterTradeRecord(Generator.Program.GetOptions(args));
            string output = GetOption(args).Output;
            string input = GetOption(args).Input;
            Class.Convert(output, input);
        }
    }
}
