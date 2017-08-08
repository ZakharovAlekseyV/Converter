using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesConverter
{
    public enum ConvertationType
    {
        BinaryToCsv,
        CsvToBinary
    }
    public static class ConverterFactory
    {
        public static IConverter CreateConverter (ConvertationType type)
        {
            switch (type)
            {
                case ConvertationType.BinaryToCsv:
                    return new ConverterBinaryToCsv();
                case ConvertationType.CsvToBinary:
                    throw new NotSupportedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
               
            }
        }
    }
}
