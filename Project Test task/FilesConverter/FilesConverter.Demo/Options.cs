using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CommandLine;

namespace FilesConverter.Demo
{
    class Options
    {
        [Option('o', "output", Required = true)]
        public string Output { get; set; }
        [Option('n', "number", Required = true)]
        public int Number { get; set; }
        [Option('i', "input", Required = true)]
        public string Input { get; set; }
    }
}
