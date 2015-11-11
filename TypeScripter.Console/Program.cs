using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using System.Reflection;
using System.IO;

namespace TypeScripter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = CommandLine.Parser.Default.ParseArguments<CmdArgs>(args);

            if (result.Errors.Count() == 0)
            {
                var _args = result.Value;

                var _generator = new TSGenerator();

                _generator.GenerateTypeScript(_args);
             
            }
        }
    }
}
