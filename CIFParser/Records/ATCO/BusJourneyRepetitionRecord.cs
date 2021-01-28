using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QR)]
    public class BusJourneyRepetitionRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QR;

        [CIFRecordFieldLocation(12, 3)]
        public string Location { get; set; }
        [CIFRecordFieldLocation(4, 15)]
        [CIFRecordFieldConvertToDateTime("HHmm")]
        public DateTime PublishedDepartureTime { get; set; }
        [CIFRecordFieldLocation(6, 19)]
        public string UniqueJourneyIdentifier { get; set; }
        [CIFRecordFieldLocation(6, 25)]
        public string RunningBoard { get; set; }
        [CIFRecordFieldLocation(8, 31)]
        public string VehicleType { get; set; }
    }
}
