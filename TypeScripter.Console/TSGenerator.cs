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
    public class TSGenerator
    {
        public List<string> GenerateTypeScript(CmdArgs Args)
        {

            AssemblyLocator.Init();

            var _assembly = LoadAssembly(Args.InputFile);

            if (_assembly == null)
            {
                ReportError("Invalid input file");
            }

            return GenerateFiles(_assembly, Args.InputNamespace, Args.OutputFolder, Args.ModuleName, Args.IgnoreFunctions);
        }

        private void ReportError(string Error)
        {
            var _oldColor = System.Console.ForegroundColor;

            System.Console.ForegroundColor = System.ConsoleColor.Red;

            System.Console.WriteLine(Error);

            System.Console.ForegroundColor = _oldColor;

        }

        private Assembly LoadAssembly(string InputFile)
        {

            try
            {
                if (!File.Exists(InputFile))
                {
                    ReportError(string.Format("Input file '{0}' not found", InputFile));
                    return null;
                }

                var _fullPath = Path.GetFullPath(InputFile);

                var _asm = Assembly.LoadFrom(_fullPath);

                return _asm;
            }
            catch (Exception ex)
            {
                ReportError("Error loading input assemblies: " + ex.Message);
                return null;
            }

        }

        private List<string> GenerateFiles(Assembly Assembly, string InputNamespace, string OutputPath, string TSModule, bool IgnoreFunctions = false)
        {
            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }

            var scripter = new TypeScripter.Scripter();

            scripter.IgnoreFunctions = IgnoreFunctions;
            scripter.UsingAssembly(Assembly);
            scripter.UsingTypeFilter(t => t.Namespace == InputNamespace && t.GetCustomAttribute(typeof(Newtonsoft.Json.JsonObjectAttribute)) != null);

            scripter.AddTypes(Assembly);

            var _modules = scripter.Modules().SelectMany(x => x.Types.Select(y => y.Name.ToString()));

            scripter.SaveToDirectory(OutputPath);

            return _modules.ToList();
        }
    }
}
