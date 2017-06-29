using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using FilesConverter;
using System.IO;


namespace FilesConverter.Generator
{
    class Options
    {
        [Option('o', "output", Required = true)]
        public string Output { get; set; }
        [Option('n', "number", Required = true)]
        public string Number { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (!Parser.Default.ParseArguments(args, options))
                Console.WriteLine("Invalid arguments. Press any key for exit");

            /*Console.WriteLine($"Output: {options.Output}");
            Console.WriteLine($"Number: {options.Number}");
            Console.ReadKey();*/

            //TradeRecord traderecord = new TradeRecord();

            Random randomId = new Random(DateTime.Now.Millisecond);
            Random randomAccount = new Random(DateTime.Now.Millisecond);
            Random randomVolume = new Random(DateTime.Now.Millisecond);
            Random randomComment = new Random();

            for (int j = 0; j < 3; j++)
            {
                int tempId = randomId.Next(255);
                Console.WriteLine(tempId);

                int tempAccount = randomAccount.Next(255);
                Console.WriteLine(tempAccount);

                double tempVolume = Convert.ToDouble(randomVolume.Next(-100, 100) / 10.0);
                Console.WriteLine(tempVolume);

                string random = string.Empty;
                for (int i = 0; i < 6; i++)
                {
                    random += (char)randomComment.Next('a', 'z');
                }

                Console.WriteLine(random);
            }
            Console.ReadLine();




            int numberconvert = Convert.ToInt32(options.Number);
            for (int i=0; i < numberconvert; i++)
            {

            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(options.Output, FileMode.OpenOrCreate)))
            {

            }
        }
    }
}
