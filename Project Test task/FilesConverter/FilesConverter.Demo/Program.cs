using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;


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
        static void Main(string[] args)
        {
            var options = new Options ();
            if (!Parser.Default.ParseArguments(args, options))
                Console.WriteLine("Invalid arguments. Press any key for exit");
            Console.WriteLine( $"Input: {options.Input}");
            Console.WriteLine( $"Output: {options.Output}");
            Console.ReadKey();

        }
    }
}
