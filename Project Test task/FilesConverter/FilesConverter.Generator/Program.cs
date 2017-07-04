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
            int tempId, tempAccount;
            double tempVolume;
            string tempComment, traderecord;

            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(options.Output, FileMode.OpenOrCreate)))
                {
                    for (int i = 0; i < numberСonvert; i++)
                    {
                        TradeRecord tradeRecord = new TradeRecord(tempId = randomId.Next(255), tempAccount = randomAccount.Next(255), tempVolume = randomVolume.Next(-100, 100) / 10.0, tempComment = $"{tempId}  {tempAccount}  {tempVolume}");
                        writer.Write(tempId);
                        writer.Write(tempAccount);
                        writer.Write(tempVolume);
                        writer.Write(tempComment);

                        traderecord = string.Format("{0} {1} {2} {3}", tempId, tempAccount, tempVolume, $"{tempId}  {tempAccount}  {tempVolume}");
                        Console.WriteLine(traderecord);
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }




            /*using (FileStream fstream = File.OpenRead(options.Output))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine("Текст из файла: {0}", textFromFile);

            } */
            Console.ReadLine();

            
            
        }
    }
}
