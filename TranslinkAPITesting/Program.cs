using CIF;
using System;

namespace TranslinkAPITesting
{
    class Program
    {
        static void Main(string[] args)
        {
            ATCOCIFFile atcoCifFile = (ATCOCIFFile)CIFParser.ParseCIFFile("UB_GVS_LISBURN_210111.cif", true);

            Console.ReadKey();
        }
    }
}
