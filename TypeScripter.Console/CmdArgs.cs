using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScripter.Console
{
    public class CmdArgs
    {
        public CmdArgs()
        {
            IgnoreFunctions = false;
        }

        [Option('i', "input", Required = true,
                HelpText = "Input file to be processed.")]
        public string InputFile { get; set; }

        // Omitting long name, default --verbose
        [Option(
          HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [Option('n', "namespace", Required = false,
        HelpText = "Namespace of classes to parse.")]
        public string InputNamespace { get; set; }

        [Option('o', "output", Required = true,
            HelpText = "Folder to generate files into")]
        public string OutputFolder { get; set; }

        [Option('m', "module", Required = true,
                    HelpText = "TypeScript module name in which to create output")]
        public string ModuleName { get; set; }

        [Option('f', "skipfunctions", Required = false,
            HelpText = "Ignore functions when generating TypeScript files")]
        public bool IgnoreFunctions { get; set; }
    }
}

