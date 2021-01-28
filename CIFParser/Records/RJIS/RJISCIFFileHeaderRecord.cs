using CIF.Attributes;
using System;

namespace CIF.Records.RJIS
{
    [CIFRecordIdentity(CIFRecordIdentity.HD)]
    public class RJISCIFFileHeaderRecord : CIFFileHeaderRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.HD;

        [CIFRecordFieldLocation(20, 3)]
        public string FileIdentity { get; set; }
        [CIFRecordFieldLocation(10, 23)]
        [CIFRecordFieldConvertToDateTime("ddMMyyHHmm")]
        public DateTime DateTimeOfExtract { get; set; }
        [CIFRecordFieldLocation(7, 33)]
        public string CurrentFileReference { get; set; }
        [CIFRecordFieldLocation(7, 40)]
        public string LastFileReference { get; set; }
        [CIFRecordFieldLocation(1, 47)]
        [CIFRecordFieldConvertToBool("U", "F")]
        public bool UpdateIndicator { get; set; }
        [CIFRecordFieldLocation(1, 48)]
        public string Version { get; set; }
        [CIFRecordFieldLocation(6, 49)]
        [CIFRecordFieldConvertToDateTime("ddMMyy")]
        public DateTime ExtractStartDate { get; set; }
        [CIFRecordFieldLocation(6, 55)]
        [CIFRecordFieldConvertToDateTime("ddMMyy")]
        public DateTime ExtractEndDate { get; set; }
        [CIFRecordFieldLocation(20, 61)]
        public string Spare { get; set; }
    }
}
