using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QS)]
    public class BusJourneyHeaderRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QS;

        /// <summary>
        /// N = New;
        /// D = Delete;
        /// R = Revise
        /// </summary>
        [CIFRecordFieldLocation(1, 3)]
        public string TransactionType { get; set; }
        [CIFRecordFieldLocation(4, 4)]
        public string Operator { get; set; }
        [CIFRecordFieldLocation(6, 8)]
        public string UniqueJourneyIdentifier { get; set; }
        [CIFRecordFieldLocation(8, 14)]
        [CIFRecordFieldConvertToDateTime("yyyyMMdd")]
        public DateTime FirstDateOfOperation { get; set; }
        [CIFRecordFieldLocation(8, 22)]
        [CIFRecordFieldConvertToDateTime("yyyyMMdd")]
        public DateTime? LastDateOfOperation { get; set; }
        [CIFRecordFieldLocation(1, 30)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnMondays { get; set; }
        [CIFRecordFieldLocation(1, 31)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnTuedays { get; set; }
        [CIFRecordFieldLocation(1, 32)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnWednesdays { get; set; }
        [CIFRecordFieldLocation(1, 33)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnThursdays { get; set; }
        [CIFRecordFieldLocation(1, 34)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnFridays { get; set; }
        [CIFRecordFieldLocation(1, 35)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnSaturdays { get; set; }
        [CIFRecordFieldLocation(1, 36)]
        [CIFRecordFieldConvertToBool("1", "0")]
        public bool OperatesOnSundays { get; set; }
        /// <summary>
        /// [blank] = Operates days defined above;
        /// S = Operates school term time only;
        /// H = Operates school holidays only
        /// </summary>
        [CIFRecordFieldLocation(1, 37)]
        public string SchoolTermTime { get; set; }
        /// <summary>
        /// [blank] = Operates days defined above;
        /// A = Operates additionally on bank holidays;
        /// B = Operates on bank holidays only;
        /// X = Operates except on bank holidays
        /// </summary>
        [CIFRecordFieldLocation(1, 38)]
        public string BankHolidays { get; set; }
        [CIFRecordFieldLocation(4, 39)]
        public string RouteNumber { get; set; }
        [CIFRecordFieldLocation(6, 43)]
        public string RunningBoard { get; set; }
        [CIFRecordFieldLocation(8, 49)]
        public string VehicleType { get; set; }
        [CIFRecordFieldLocation(8, 57)]
        public string RegistrationNumber { get; set; }
        [CIFRecordFieldLocation(1, 65)]
        public string RouteDirection { get; set; }
    }
}
