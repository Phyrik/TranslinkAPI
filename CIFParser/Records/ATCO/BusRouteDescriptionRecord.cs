using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QD)]
    public class BusRouteDescriptionRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QD;

        /// <summary>
        /// N = New;
        /// D = Delete;
        /// R = Revise
        /// </summary>
        [CIFRecordFieldLocation(1, 3)]
        public string TransactionType { get; set; }
        [CIFRecordFieldLocation(4, 4)]
        public string Operator { get; set; }
        [CIFRecordFieldLocation(4, 8)]
        public string RouteNumber { get; set; }
        [CIFRecordFieldLocation(1, 12)]
        public string RouteDirection { get; set; }
        [CIFRecordFieldLocation(68, 13)]
        public string RouteDescription { get; set; }
    }
}
