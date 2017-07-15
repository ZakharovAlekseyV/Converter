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
        
        class Class
        {
       
          static void Main(string[] args)
          {
          }
      }      
  }      

