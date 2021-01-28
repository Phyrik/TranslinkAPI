using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QA)]
    public class BusAlternativeLocationRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QA;

        /// <summary>
        /// N = New;
        /// D = Delete;
        /// R = Revise
        /// </summary>
        [CIFRecordFieldLocation(1, 3)]
        public string TransactionType { get; set; }
        [CIFRecordFieldLocation(12, 4)]
        public string Location { get; set; }
        [CIFRecordFieldLocation(48, 16)]
        public string FullLocation { get; set; }
        [CIFRecordFieldLocation(1, 64)]
        public string GazetteerCode { get; set; }
    }
}
