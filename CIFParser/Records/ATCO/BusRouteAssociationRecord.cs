using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QX)]
    public class BusRouteAssociationRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QX;

        /// <summary>
        /// N = New;
        /// D = Delete;
        /// R = Revise
        /// </summary>
        [CIFRecordFieldLocation(1, 3)]
        public string TransactionType { get; set; }
        [CIFRecordFieldLocation(4, 4)]
        public string Operator1 { get; set; }
        [CIFRecordFieldLocation(4, 8)]
        public string RouteNumber1 { get; set; }
        [CIFRecordFieldLocation(1, 12)]
        public string RouteDirection1 { get; set; }
        [CIFRecordFieldLocation(4, 13)]
        public string Operator2 { get; set; }
        [CIFRecordFieldLocation(4, 17)]
        public string RouteNumber2 { get; set; }
        [CIFRecordFieldLocation(1, 21)]
        public string RouteDirection2 { get; set; }
        [CIFRecordFieldLocation(8, 22)]
        [CIFRecordFieldConvertToDateTime("yyyyMMdd")]
        public DateTime FirstDateOfOperation { get; set; }
        [CIFRecordFieldLocation(8, 30)]
        [CIFRecordFieldConvertToDateTime("yyyyMMdd")]
        public DateTime? LastDateOfOperation { get; set; }
        [CIFRecordFieldLocation(1, 38)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnMondays { get; set; }
        [CIFRecordFieldLocation(1, 39)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnTuedays { get; set; }
        [CIFRecordFieldLocation(1, 40)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnWednesdays { get; set; }
        [CIFRecordFieldLocation(1, 41)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnThursdays { get; set; }
        [CIFRecordFieldLocation(1, 42)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnFridays { get; set; }
        [CIFRecordFieldLocation(1, 43)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnSaturdays { get; set; }
        [CIFRecordFieldLocation(1, 44)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnSundays { get; set; }
        [CIFRecordFieldLocation(12, 45)]
        public string Location { get; set; }
        /// <summary>
        /// J = Journeys join – journey 1 should be through;
        /// S = Journeys split – journey 1 should be through;
        /// B = Journeys cross border;
        /// G = Guaranteed connection;
        /// C = Vehicles change route number
        /// </summary>
        [CIFRecordFieldLocation(1, 57)]
        public string AssociationType { get; set; }
    }
}
