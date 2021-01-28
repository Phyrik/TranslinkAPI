using System;

namespace CIF.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CIFRecordFieldConvertToBoolAttribute : Attribute
    {
        public string trueString;
        public string falseString;

        public CIFRecordFieldConvertToBoolAttribute(string trueString, string falseString)
        {
            this.trueString = trueString;
            this.falseString = falseString;
        }
    }
}
