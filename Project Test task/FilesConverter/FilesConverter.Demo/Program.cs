using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using System.IO;
using FilesConverter;


namespace FilesConverter.Demo
{
    class Options
    {
        [Option ('i', "input",Required = true)]
        public string Input { get; set; }
        [Option ('o', "output", Required = true)]
        public string Output { get; set; }
    }

    class Program
    {
        static TradeRecord tr;
        private static void MethodBinaryReader_Writer(Options options)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(options.Output, FileMode.Open), Encoding.ASCII))
            {
                using (StreamWriter sw = new StreamWriter(options.Input, false, Encoding.Default))
                {
                    while (reader.PeekChar() > -1)
                    {
                        tr.id = reader.ReadInt32();
                        tr.account = reader.ReadInt32();
                        tr.volume = reader.ReadDouble();
                        tr.comment = reader.ReadString();
                        Console.WriteLine(tr.id);
                        Console.WriteLine(tr.account);
                        Console.WriteLine(tr.volume);
                        Console.WriteLine(tr.comment);

                        sw.Write(tr.id);
                        sw.Write(tr.account);
                        sw.Write(tr.volume);
                        sw.WriteLine(tr.comment);
                    }
                }
            }
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
            Console.WriteLine($"Input: {option.Input}");
            Console.WriteLine($"Output: {option.Output}");
            return option;
        }

        static void Main(string[] args)
        {
            MethodBinaryReader_Writer(GetOption(args));
        }
    }
}
