using System;

namespace CIF.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CIFRecordFieldConvertToDateTimeAttribute : Attribute
    {
        public string format;

        public CIFRecordFieldConvertToDateTimeAttribute(string format)
        {
            this.format = format;
        }
    }
}
