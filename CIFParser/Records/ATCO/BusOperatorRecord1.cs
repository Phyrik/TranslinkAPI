using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QP)]
    public class BusOperatorRecord1 : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QP;

        /// <summary>
        /// N = New;
        /// D = Delete;
        /// R = Revise
        /// </summary>
        [CIFRecordFieldLocation(1, 3)]
        public string TransactionType { get; set; }
        [CIFRecordFieldLocation(4, 4)]
        public string Operator { get; set; }
        [CIFRecordFieldLocation(24, 8)]
        public string OperatorShortForm { get; set; }
        [CIFRecordFieldLocation(48, 32)]
        public string OperatorLegalName { get; set; }
        [CIFRecordFieldLocation(12, 80)]
        public string EnquiryPhone { get; set; }
        [CIFRecordFieldLocation(12, 92)]
        public string ContactPhone { get; set; }
    }
}
