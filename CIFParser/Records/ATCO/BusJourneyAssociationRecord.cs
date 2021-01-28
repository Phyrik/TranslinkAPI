using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QY)]
    public class BusJourneyAssociationRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QY;

        /// <summary>
        /// N = New;
        /// D = Delete;
        /// R = Revise
        /// </summary>
        [CIFRecordFieldLocation(1, 3)]
        public string TransactionType { get; set; }
        [CIFRecordFieldLocation(4, 4)]
        public string Operator1 { get; set; }
        [CIFRecordFieldLocation(6, 8)]
        public string JourneyIdentifier1 { get; set; }
        [CIFRecordFieldLocation(4, 14)]
        public string Operator2 { get; set; }
        [CIFRecordFieldLocation(6, 18)]
        public string JourneyIdentifier2 { get; set; }
        [CIFRecordFieldLocation(8, 24)]
        [CIFRecordFieldConvertToDateTime("yyyyMMdd")]
        public DateTime FirstDateOfOperation { get; set; }
        [CIFRecordFieldLocation(8, 32)]
        [CIFRecordFieldConvertToDateTime("yyyyMMdd")]
        public DateTime? LastDateOfOperation { get; set; }
        [CIFRecordFieldLocation(1, 40)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnMondays { get; set; }
        [CIFRecordFieldLocation(1, 41)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnTuedays { get; set; }
        [CIFRecordFieldLocation(1, 42)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnWednesdays { get; set; }
        [CIFRecordFieldLocation(1, 43)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnThursdays { get; set; }
        [CIFRecordFieldLocation(1, 44)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnFridays { get; set; }
        [CIFRecordFieldLocation(1, 45)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnSaturdays { get; set; }
        [CIFRecordFieldLocation(1, 46)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnSundays { get; set; }
        [CIFRecordFieldLocation(12, 47)]
        public string Location { get; set; }
        /// <summary>
        /// J = Journeys join – journey 1 should be through;
        /// S = Journeys split – journey 1 should be through;
        /// B = Journeys cross border;
        /// G = Guaranteed connection;
        /// C = Vehicles change route number
        /// </summary>
        [CIFRecordFieldLocation(1, 59)]
        public string AssociationType { get; set; }
    }
}
