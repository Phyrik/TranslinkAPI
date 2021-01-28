namespace CIF.Records
{
    public abstract class CIFRecord
    {
        public abstract CIFRecordIdentity RecordIdentity { get; }
    }

    public enum CIFRecordIdentity
    {
        Unknown,
        /// <summary>
        /// Not an actual record identity, but used to identify ATCO-CIF file header records.
        /// </summary>
        ATCOCIFFileHeader,
        /// <summary>
        /// Bus Journey Header
        /// </summary>
        QS,
        /// <summary>
        /// Bus Journey Date Running
        /// </summary>
        QE,
        /// <summary>
        /// Bus Journey Note
        /// </summary>
        QN,
        /// <summary>
        /// Bus Journey Origin
        /// </summary>
        QO,
        /// <summary>
        /// Bus Journey Intermediate
        /// </summary>
        QI,
        /// <summary>
        /// Bus Journey Destination
        /// </summary>
        QT,
        /// <summary>
        /// Bus Journey Repetition
        /// </summary>
        QR,
        /// <summary>
        /// Bus Location
        /// </summary>
        QL,
        /// <summary>
        /// Bus Additional Location Information
        /// </summary>
        QB,
        /// <summary>
        /// Bus Alternative Location
        /// </summary>
        QA,
        /// <summary>
        /// Bus Cluster
        /// </summary>
        QC,
        /// <summary>
        /// Bus Operator
        /// </summary>
        QP,
        /// <summary>
        /// Bus Operator Continuation
        /// </summary>
        QQ,
        /// <summary>
        /// Bus Location Interchange
        /// </summary>
        QG,
        /// <summary>
        /// Bus Cluster Interchange
        /// </summary>
        QJ,
        /// <summary>
        /// Bus Cluster Walk Link
        /// </summary>
        QW,
        /// <summary>
        /// Bus Vehicle Type
        /// </summary>
        QV,
        /// <summary>
        /// Bus Route Description
        /// </summary>
        QD,
        /// <summary>
        /// Bus Bank Holiday
        /// </summary>
        QH,
        /// <summary>
        /// Bus Route Association
        /// </summary>
        QX,
        /// <summary>
        /// Bus Journey Association
        /// </summary>
        QY,
        /// <summary>
        /// RJIS-CIF Header Record
        /// </summary>
        HD,
        /// <summary>
        /// Train Basic Schedule
        /// </summary>
        BS,
        /// <summary>
        /// Train Basic Schedule Extra Details
        /// </summary>
        BX,
        /// <summary>
        /// Train Origin Location
        /// </summary>
        LO,
        /// <summary>
        /// Train Intermediate Location
        /// </summary>
        LI,
        /// <summary>
        /// Train Changes En Route
        /// </summary>
        CR,
        /// <summary>
        /// Train Terminating Location
        /// </summary>
        LT,
        /// <summary>
        /// Train Association
        /// </summary>
        AA,
        /// <summary>
        /// Train TIPLOC Insert
        /// </summary>
        TI,
        /// <summary>
        /// Train TIPLOC Amend
        /// </summary>
        TA,
        /// <summary>
        /// Train TIPLOC Delete
        /// </summary>
        TD,
        /// <summary>
        /// Train Trailer Record
        /// </summary>
        ZZ
    }
}
