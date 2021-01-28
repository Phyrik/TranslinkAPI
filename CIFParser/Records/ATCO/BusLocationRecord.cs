using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    /// <summary>
    /// Note: this is not the location of a bus, rather the location of a bus stop.
    /// </summary>
    [CIFRecordIdentity(CIFRecordIdentity.QL)]
    public class BusLocationRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QL;

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
        [CIFRecordFieldLocation(1, 65)]
        public string PointType { get; set; }
        [CIFRecordFieldLocation(8, 66)]
        public string NationalGazetteerId { get; set; }
    }
}
