using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QE)]
    public class BusJourneyDateRunningRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QE;

        [CIFRecordFieldLocation(8, 3)]
        [CIFRecordFieldConvertToDateTime("yyyyMMdd")]
        public DateTime StartOfExceptionalPeriod { get; set; }
        [CIFRecordFieldLocation(8, 11)]
        [CIFRecordFieldConvertToDateTime("yyyyMMdd")]
        public DateTime EndOfExceptionalPeriod { get; set; }
        /// <summary>
        /// <c>true</c> if the journey operates between these dates, <c>false</c> otherwise.
        /// </summary>
        [CIFRecordFieldLocation(1, 19)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperationCode { get; set; }
    }
}
