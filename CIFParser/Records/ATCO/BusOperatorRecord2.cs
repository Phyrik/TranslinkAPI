using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QQ)]
    public class BusOperatorRecord2 : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QQ;

        [CIFRecordFieldLocation(78, 3)]
        public string OperatorAddress { get; set; }
    }
}
