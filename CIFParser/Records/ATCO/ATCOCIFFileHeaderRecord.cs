using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.ATCOCIFFileHeader)]
    public class ATCOCIFFileHeaderRecord : CIFFileHeaderRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.ATCOCIFFileHeader;

        [CIFRecordFieldLocation(8, 1)]
        public string FileType { get; set; }
        [CIFRecordFieldLocation(2, 9)]
        public string VersionMajor { get; set; }
        [CIFRecordFieldLocation(2, 11)]
        public string VersionMinor { get; set; }
        [CIFRecordFieldLocation(32, 13)]
        public string FileOriginator { get; set; }
        [CIFRecordFieldLocation(16, 45)]
        public string SourceProduct { get; set; }
        [CIFRecordFieldLocation(14, 61)]
        [CIFRecordFieldConvertToDateTime("yyyyMMddHHmmss")]
        public DateTime ProductionDateTime { get; set; }
    }
}
