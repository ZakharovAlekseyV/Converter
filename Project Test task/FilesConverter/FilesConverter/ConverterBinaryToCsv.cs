﻿using System;
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
    
    class ConverterBinaryToCsv : IConverter
    {
        ILogger _logger;

        public ConverterBinaryToCsv(ILogger logger)
        {
            _logger = logger;
        }

        TradeRecord tr;
        public void Convert(string output, string input)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(output, FileMode.Open), Encoding.ASCII))
            {
                using (StreamWriter sw = new StreamWriter(input, false, Encoding.Default))
                {
                    while (reader.PeekChar() > -1)
                    {
                        tr.id = reader.ReadInt32();
                        tr.account = reader.ReadInt32();
                        tr.volume = reader.ReadDouble();
                        byte[] cmnt = reader.ReadBytes(64);
                        tr.comment = Encoding.ASCII.GetString(cmnt);

                        sw.Write(tr.id + ";" + tr.account + ";" + tr.volume + ";" + tr.comment +"\r\n" );

                    }
                }
            }
             _logger?.Info("Логирование из библиотеки");
        }
        
        /*public void GetStatusTask (string output, string input)
        {
            var classConverter = new ConverterBinaryToCsv(_logger);
            Task task = new Task(() => classConverter.Convert(output, input));
            task.Start();
            Console.WriteLine($"Статус задачи: {task.Status}");
            _logger.Info($"Статус задачи: {task.Status}");
            Console.ReadLine();
        }*/

        static void Main(string[] args)
        {
        }
    }      
}      

