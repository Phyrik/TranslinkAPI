using CIF.Records.ATCO;
using CIF.Records.RJIS;
using System.Collections.Generic;

namespace CIF
{
    public abstract class CIFFile
    {
        public abstract CIFFileType Type { get; }
    }

    public class ATCOCIFFile : CIFFile
    {
        public override CIFFileType Type { get; } = CIFFileType.ATCOCIF;
        public ATCOCIFFileHeaderRecord FileHeaderRecord { get; private set; }
        public List<ATCOCIFRecord> Records { get; private set; }

        public ATCOCIFFile(ATCOCIFFileHeaderRecord fileHeaderRecord)
        {
            this.FileHeaderRecord = fileHeaderRecord;
        }
    }

    public class RJISCIFFile : CIFFile
    {
        public override CIFFileType Type { get; } = CIFFileType.RJISCIF;
        public RJISCIFFileHeaderRecord FileHeaderRecord { get; private set; }
        public List<RJISCIFRecord> Records { get; private set; }

        public RJISCIFFile(RJISCIFFileHeaderRecord fileHeaderRecord)
        {
            this.FileHeaderRecord = fileHeaderRecord;
        }
    }
}