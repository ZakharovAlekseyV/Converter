using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter;
using System.IO;
using CsvHelper;
using CommandLine;


namespace FilesConverter.Generator
{
    class Program
    {
        private static TradeRecord GetRandomTradeRecord ()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int id = random.Next(255);            
            int account = random.Next(255);
            double volume = random.Next(-100,100)/10.0;
            string comment = $"{id} {account} {volume}";
            TradeRecord tradeRecord = new TradeRecord(id, account, volume, comment);
            return tradeRecord;
        }
        
        private static Options GetOptions(string[] args)
        {
            Options options = new Options();
            if (!Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine("Invalid arguments. Press any key for exit");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            Console.WriteLine($"Output: {options.Output}");
            Console.WriteLine($"Number: {options.Number}");
            return options;
        }

        private static void WriterTradeRecord(Options options)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(options.Output, FileMode.Create, FileAccess.Write)))
            {
                for (int i = 0; i < options.Number; i++)
                {
                    TradeRecord tradeRecord = GetRandomTradeRecord();
                    writer.Write(tradeRecord.id);
                    writer.Write(tradeRecord.account);
                    writer.Write(tradeRecord.volume);
                    writer.Write(tradeRecord.comment);
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                WriterTradeRecord(GetOptions(args));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
