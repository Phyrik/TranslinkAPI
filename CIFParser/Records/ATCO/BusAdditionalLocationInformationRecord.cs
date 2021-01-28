using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QB)]
    public class BusAdditionalLocationInformationRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QB;

        /// <summary>
        /// N = New;
        /// D = Delete;
        /// R = Revise
        /// </summary>
        [CIFRecordFieldLocation(1, 3)]
        public string TransactionType { get; set; }
        [CIFRecordFieldLocation(12, 4)]
        public string Location { get; set; }
        [CIFRecordFieldLocation(8, 16)]
        public string GridReferenceEasting { get; set; }
        [CIFRecordFieldLocation(8, 24)]
        public string GridReferenceNorthing { get; set; }
        [CIFRecordFieldLocation(24, 32)]
        public string DistrictName { get; set; }
        [CIFRecordFieldLocation(24, 56)]
        public string TownName { get; set; }
    }
}
