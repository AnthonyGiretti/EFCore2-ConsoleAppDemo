using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;

namespace ConsoleAppEFCore2.Pluralization
{
    public class CustomPluralizer : IPluralizer
    {
        public string Pluralize(string name)
        {
            return Inflector.Inflector.Pluralize(name) ?? name;
        }

        public string Singularize(string name)
        {
            return Inflector.Inflector.Singularize(name) ?? name;
        }
    }
}
