using CIF.Records;
using System;

namespace CIF.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CIFRecordIdentityAttribute : Attribute
    {
        public CIFRecordIdentity cifRecordIdentity;

        public CIFRecordIdentityAttribute(CIFRecordIdentity cifRecordIdentity)
        {
            this.cifRecordIdentity = cifRecordIdentity;
        }
    }
}
