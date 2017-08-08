using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesConverter
{
    public interface IConverter
    {
        void Converter(string output, string input);
        
    }
}
