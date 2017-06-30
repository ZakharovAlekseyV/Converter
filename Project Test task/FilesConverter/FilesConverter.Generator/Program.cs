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
            int numberСonvert = Convert.ToInt32(options.Number);
            Console.WriteLine($"Output: {options.Output}");
            Console.WriteLine($"Number: {options.Number}");

            Random randomId = new Random(DateTime.Now.Millisecond);
            Random randomAccount = new Random(DateTime.Now.Millisecond);
            Random randomVolume = new Random(DateTime.Now.Millisecond);
            Random randomComment = new Random();

            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(options.Output, FileMode.OpenOrCreate)))
                {
                    for (int j = 0; j < numberСonvert; j++)
                    {
                        int tempId = randomId.Next(255);
                        Console.WriteLine(tempId);
                        writer.Write(tempId);

                        int tempAccount = randomAccount.Next(255);
                        Console.WriteLine(tempAccount);
                        writer.Write(tempAccount);

                        double tempVolume = Convert.ToDouble(randomVolume.Next(-100, 100) / 10.0);
                        Console.WriteLine(tempVolume);
                        writer.Write(tempVolume);

                        string random = string.Empty;
                        for (int i = 0; i < 6; i++)
                        {
                            random += (char)randomComment.Next('a', 'z');
                        }

                        Console.WriteLine(random);
                        writer.Write(random);

                    }
                   
                                        
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            Console.ReadKey();

            //TradeRecord traderecord = new TradeRecord();
        }
    }
}
