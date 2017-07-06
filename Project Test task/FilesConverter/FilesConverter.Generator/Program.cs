using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using FilesConverter;
using System.IO;
using CsvHelper;


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
        static int RandomMethodInt (Random random)
        {
            random = new Random(DateTime.Now.Millisecond);
            int temp = random.Next(255);
            return temp;
        }

        static double RandomMethodDouble (Random random)
        {
            random = new Random(DateTime.Now.Millisecond);
            double temp = random.Next(-100 , 100) /10.0;
            return temp;
        }

        static void Main(string[] args)
        {
            var options = new Options();
            if (!Parser.Default.ParseArguments(args, options))
                Console.WriteLine("Invalid arguments. Press any key for exit");
            int numberСonvert = Convert.ToInt32(options.Number);
            Console.WriteLine($"Output: {options.Output}");
            Console.WriteLine($"Number: {options.Number}");

            Random randomId = null, randomAccount = null, randomVolume=null;
            int Id, Account,tempId, tempAccount;
            double tempVolume;
            string Comment, tempComment, traderecord;
            string writePath = @"D:\Project\CSV.csv";
            double Volume;

            try
            {
                File.WriteAllText(options.Output, "");
                using (BinaryWriter writer = new BinaryWriter(File.Open(options.Output, FileMode.OpenOrCreate)))
                {
                    
                    for (int i = 0; i < numberСonvert; i++)
                    {
                        TradeRecord tradeRecord = new TradeRecord (tempId = RandomMethodInt(randomId), tempAccount = RandomMethodInt(randomAccount),
                                                                  tempVolume = RandomMethodDouble(randomVolume),
                                                                  tempComment = $"{tempId}  {tempAccount}  {tempVolume}");
                        writer.Write(tempId);
                        writer.Write(tempAccount);
                        writer.Write(tempVolume);
                        writer.Write(tempComment);

                        traderecord = string.Format("{0} {1} {2} {3}", tempId, tempAccount, tempVolume,
                                                    $"{tempId}  {tempAccount}  {tempVolume}");
                        Console.WriteLine(traderecord);
                    }
                }   
                
                string path = @"D:\Test\trade.dat";
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open),Encoding.ASCII))
                {
                    while (reader.PeekChar() > -1)
                    {
                        Id = reader.ReadInt32();
                        Account = reader.ReadInt32();
                        Volume = reader.ReadDouble();
                        Comment = reader.ReadString();

                        TradeRecord tradeRecordW = new TradeRecord(Id, Account, Volume, Comment);
                        Console.WriteLine("{0}  {1}  {2}  {3} ", Id , Account, Volume, Comment);
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

           /* using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default))
            {
                sw.Write(11);
                sw.Write(22);
                sw.Write(33);
                sw.WriteLine("trololo");
            }*/
            Console.ReadLine();
            
        }
    }
}
