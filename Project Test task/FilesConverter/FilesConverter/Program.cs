using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FilesConverter
{
        /*[StructLayout(LayoutKind.Sequential, Pack = 1)]*/
        public struct TradeRecord
        {
            public int id;
            public int account;
            public double volume;
            /*[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]*/
            public string comment;

            public TradeRecord (int a, int b, double c, string d)
            {
                id = a;
                account = b;
                volume = c;
                comment = d;
            }
        } 
        
        class Program
        { 
            static void Main(string[] args)
        {
            TradeRecord traderecord = new TradeRecord ( 1, 2, 3.5, "good" );
            Console.WriteLine("Укажите путь для создаваемого бинарного файла (например: D/Project/..) :");
            try
            {
                string path = Console.ReadLine();
                Console.WriteLine(path);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        }
}
