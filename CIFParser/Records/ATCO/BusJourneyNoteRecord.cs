using CIF.Attributes;

namespace CIF.Records.ATCO
{
    [CIFRecordIdentity(CIFRecordIdentity.QN)]
    public class BusJourneyNoteRecord : ATCOCIFRecord
    {
        public override CIFRecordIdentity RecordIdentity { get; } = CIFRecordIdentity.QN;

        [CIFRecordFieldLocation(5, 3)]
        public string NoteCode { get; set; }
        [CIFRecordFieldLocation(72, 8)]
        public string NoteText { get; set; }
    }
}
