using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QO)]
    public class BusJourneyOriginRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QO;

        [CIFRecordFieldLocation(12, 3)]
        public string Location { get; set; }
        [CIFRecordFieldLocation(4, 15)]
        [CIFRecordFieldConvertToDateTime("HHmm")]
        public DateTime PublishedDepartureTime { get; set; }
        [CIFRecordFieldLocation(3, 19)]
        public string BayNumber { get; set; }
        [CIFRecordFieldLocation(2, 22)]
        [CIFRecordFieldConvertToBool("T1", "T0")]
        public bool TimingPointIndicator { get; set; }
        [CIFRecordFieldLocation(2, 24)]
        [CIFRecordFieldConvertToBool("F1", "F0")]
        public bool FareStageIndicator { get; set; }
    }
}
