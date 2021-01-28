using CIF;
using CIF.Records;
using CIF.Records.ATCO;
using CIF.Records.RJIS;
using System;
using System.IO;

namespace TranslinkAPITesting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] atcoCifLines = File.ReadAllLines("PIRISHA.CIF");

            RJISCIFFileHeaderRecord atcoCifFileHeaderRecord = (RJISCIFFileHeaderRecord)CIFParser.ParseRecord(atcoCifLines[0], CIFRecordIdentity.HD);

            Console.ReadKey();
        }
    }
}
