using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace __Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)

        {
            bool isTrue = 100f == 100d;
            bool isd = 100f != 100d;
            bool isf = 5 > 'a';
            bool fd = "string" == "String";
            Console.WriteLine(isTrue);
            Console.WriteLine(isd);
            Console.WriteLine(isf);
            Console.WriteLine(fd);

        }
    }
}
