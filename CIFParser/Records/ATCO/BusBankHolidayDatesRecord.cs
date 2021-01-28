using CIF.Attributes;
using System;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QH)]
    public class BusBankHolidayDatesRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QH;

        /// <summary>
        /// N = New;
        /// D = Delete;
        /// R = Revise
        /// </summary>
        [CIFRecordFieldLocation(1, 3)]
        public string TransactionType { get; set; }
        [CIFRecordFieldLocation(8, 4)]
        [CIFRecordFieldConvertToDateTime("yyyyMMdd")]
        public DateTime DateOfBankHoliday { get; set; }
    }
}
