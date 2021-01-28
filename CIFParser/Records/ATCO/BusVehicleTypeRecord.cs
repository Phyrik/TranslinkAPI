using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QV)]
    public class BusVehicleTypeRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QV;

        /// <summary>
        /// N = New;
        /// D = Delete;
        /// R = Revise
        /// </summary>
        [CIFRecordFieldLocation(1, 3)]
        public string TransactionType { get; set; }
        [CIFRecordFieldLocation(8, 4)]
        public string VehicleType { get; set; }
        [CIFRecordFieldLocation(24, 12)]
        public string VehicleLongType { get; set; }
    }
}
