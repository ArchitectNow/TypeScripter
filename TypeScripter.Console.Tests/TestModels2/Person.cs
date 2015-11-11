using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScripter.Console.Tests.TestModels2
{

    public class Person
    {
        public string NameFirst { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Person> Children { get; set; }

        public bool? NullableBool { get; set;  }
    }
}
