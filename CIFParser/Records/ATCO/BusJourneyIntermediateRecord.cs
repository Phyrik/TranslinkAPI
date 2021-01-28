using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QI)]
    public class BusJourneyIntermediateRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QI;

        [CIFRecordFieldLocation(12, 3)]
        public string Location { get; set; }
        [CIFRecordFieldLocation(4, 15)]
        [CIFRecordFieldConvertToDateTime("HHmm")]
        public DateTime PublishedArrivalTime { get; set; }
        [CIFRecordFieldLocation(4, 19)]
        [CIFRecordFieldConvertToDateTime("HHmm")]
        public DateTime PublishedDepartureTime { get; set; }
        /// <summary>
        /// B = Both Pick up and Set down;
        /// P = Pick up only;
        /// S = Set down only;
        /// N = Neither pick up nor set down (pass only)
        /// </summary>
        [CIFRecordFieldLocation(1, 23)]
        public string ActivityFlag { get; set; }
        [CIFRecordFieldLocation(3, 24)]
        public string BayNumber { get; set; }
        [CIFRecordFieldLocation(2, 27)]
        [CIFRecordFieldConvertToBool("T1", "T0")]
        public bool TimingPointIndicator { get; set; }
        [CIFRecordFieldLocation(2, 29)]
        [CIFRecordFieldConvertToBool("T1", "T0")]
        public bool FareStageIndicator { get; set; }
    }
}
