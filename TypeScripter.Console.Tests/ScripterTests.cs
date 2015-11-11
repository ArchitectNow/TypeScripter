using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;

namespace TypeScripter.Console.Tests
{
    [TestClass]
    public class ScripterTests
    {
        [TestMethod]
        public void GenerationTests()
        {

            var _args = new CmdArgs();

            var _asmPath = GetCurrentAssemblyPath();

            _args.InputFile = Path.Combine(_asmPath,"TypeScripter.Console.Tests.dll");
            _args.OutputFolder = Path.Combine(_asmPath, "testout");

            Directory.Delete(_args.OutputFolder,true);

            _args.InputNamespace = "TypeScripter.Console.Tests.TestModels";
           
            var _generator = new TSGenerator();

            var _types = _generator.GenerateTypeScript(_args);

            Assert.AreEqual(1, _types.Count);
            Assert.AreEqual("TypeScripter.Console.Tests.TestModels.Person", _types[0]);

            var _outputFile = Path.Combine(_args.OutputFolder, "TypeScripter.Console.Tests.TestModels.d.ts");

            Assert.IsTrue(Directory.Exists(_args.OutputFolder));
            Assert.IsTrue(File.Exists(_outputFile));     
        }

        [TestMethod]
        public void NamespaceFilterTests()
        {
            var _args = new CmdArgs();

            var _asmPath = GetCurrentAssemblyPath();

            _args.InputFile = Path.Combine(_asmPath, "TypeScripter.Console.Tests.dll");
            _args.OutputFolder = Path.Combine(_asmPath, "testout");

            Directory.Delete(_args.OutputFolder, true);

            _args.InputNamespace = "TypeScripter.Console.Tests.TestModels2";

            var _generator = new TSGenerator();

            var _types = _generator.GenerateTypeScript(_args);

            Assert.AreEqual(0, _types.Count);

            var _outputFile = Path.Combine(_args.OutputFolder, "TypeScripter.Console.Tests.TestModels.d.ts");

            Assert.IsTrue(Directory.Exists(_args.OutputFolder));
            Assert.IsFalse(File.Exists(_outputFile));
        }

        private string GetCurrentAssemblyPath()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}
