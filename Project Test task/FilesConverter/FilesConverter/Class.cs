using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace FilesConverter
{
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TradeRecord
        {   
            public int id;
            public int account;
            public double volume;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string comment;

            public TradeRecord (int a, int b, double c, string d)
            {
                id = a;
                account = b;
                volume = c;
                comment = d;
            }
        } 
        
        public class Class
        {
            static TradeRecord tr;
            public static void Convert(string Output, string Input)
            {
                using (BinaryReader reader = new BinaryReader(File.Open(Output, FileMode.Open), Encoding.ASCII))
                {
                    using (StreamWriter sw = new StreamWriter(Input, false, Encoding.Default))
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
           
            static void Main(string[] args)
            {
            }
        }      
    }      

