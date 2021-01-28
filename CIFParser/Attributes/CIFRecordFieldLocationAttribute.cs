using System;

namespace CIF.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CIFRecordFieldLocationAttribute : Attribute
    {
        /// <summary>
        /// This uses 1-based indexing, simply because the specification uses it.
        /// </summary>
        public int startPosition;
        public int length;

        public CIFRecordFieldLocationAttribute(int length, int startPosition)
        {
            this.startPosition = startPosition;
            this.length = length;
        }
    }
}
