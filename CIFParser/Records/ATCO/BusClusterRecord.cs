using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    /// <summary>
    /// Note: this is not a cluster of buses, rather a cluster of bus stops.
    /// </summary>
    [CIFRecordIdentity(CIFRecordIdentity.QC)]
    public class BusClusterRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QC;

        /// <summary>
        /// N = New;
        /// D = Delete;
        /// R = Revise
        /// </summary>
        [CIFRecordFieldLocation(1, 3)]
        public string TransactionType { get; set; }
        [CIFRecordFieldLocation(12, 4)]
        public string ClusterCode { get; set; }
        [CIFRecordFieldLocation(48, 16)]
        public string ClusterName { get; set; }
        [CIFRecordFieldLocation(12, 64)]
        public string Location { get; set; }
    }
}
