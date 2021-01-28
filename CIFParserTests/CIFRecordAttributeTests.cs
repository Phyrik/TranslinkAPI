using CIF.Attributes;
using CIF.Records;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace CIFParserTests
{
    [TestClass]
    public class CIFRecordAttributeTests
    {
        [TestMethod]
        public void CIFRecordFieldLocationAttributesValid()
        {
            Assembly cifRecordAssembly = typeof(CIFRecord).Assembly;
            Type[] cifRecordClasses = cifRecordAssembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(CIFRecord)))
                .Where(type => type.IsClass && !type.IsAbstract)
                .ToArray();
            foreach (Type cifRecordClass in cifRecordClasses)
            {
                PropertyInfo[] cifRecordFieldProperties = cifRecordClass.GetProperties()
                    .Where(property => property.IsDefined(typeof(CIFRecordFieldLocationAttribute), false))
                    .OrderBy(property => ((CIFRecordFieldLocationAttribute)property.GetCustomAttribute(typeof(CIFRecordFieldLocationAttribute))).startPosition)
                    .ToArray();

                for (int fieldIndex = 0; fieldIndex < cifRecordFieldProperties.Length; fieldIndex++)
                {
                    CIFRecordFieldLocationAttribute thisCifRecordFieldLocationAttribute = (CIFRecordFieldLocationAttribute)cifRecordFieldProperties[fieldIndex].GetCustomAttribute(typeof(CIFRecordFieldLocationAttribute));

                    Assert.IsTrue(thisCifRecordFieldLocationAttribute.startPosition > 0, $"Property: {cifRecordClass.FullName}.{cifRecordFieldProperties[fieldIndex].Name}"); // not >= as it is 1-base indexed

                    if (fieldIndex == 0) continue;

                    CIFRecordFieldLocationAttribute lastCifRecordFieldLocationAttribute = (CIFRecordFieldLocationAttribute)cifRecordFieldProperties[fieldIndex - 1].GetCustomAttribute(typeof(CIFRecordFieldLocationAttribute));

                    Assert.AreEqual(lastCifRecordFieldLocationAttribute.startPosition + lastCifRecordFieldLocationAttribute.length, thisCifRecordFieldLocationAttribute.startPosition, $"Property: {cifRecordFieldProperties[fieldIndex].Name}");
                }
            }
        }

        [TestMethod]
        public void CIFRecordFieldConvertToDateTimeAttributesValid()
        {
            Assembly cifRecordAssembly = typeof(CIFRecord).Assembly;
            Type[] cifRecordClasses = cifRecordAssembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(CIFRecord)))
                .Where(type => type.IsClass && !type.IsAbstract)
                .ToArray();
            foreach (Type cifRecordClass in cifRecordClasses)
            {
                PropertyInfo[] cifRecordFieldProperties = cifRecordClass.GetProperties()
                    .Where(property => property.IsDefined(typeof(CIFRecordFieldLocationAttribute), false))
                    .Where(property => property.IsDefined(typeof(CIFRecordFieldConvertToDateTimeAttribute), false))
                    .ToArray();

                for (int fieldIndex = 0; fieldIndex < cifRecordFieldProperties.Length; fieldIndex++)
                {
                    CIFRecordFieldLocationAttribute cifRecordFieldLocationAttribute = (CIFRecordFieldLocationAttribute)cifRecordFieldProperties[fieldIndex].GetCustomAttribute(typeof(CIFRecordFieldLocationAttribute));
                    CIFRecordFieldConvertToDateTimeAttribute cifRecordFieldConvertToDateTimeAttribute = (CIFRecordFieldConvertToDateTimeAttribute)cifRecordFieldProperties[fieldIndex].GetCustomAttribute(typeof(CIFRecordFieldConvertToDateTimeAttribute));

                    Assert.AreEqual(cifRecordFieldLocationAttribute.length, cifRecordFieldConvertToDateTimeAttribute.format.Length, $"Property: {cifRecordClass.FullName}.{cifRecordFieldProperties[fieldIndex].Name}");
                }
            }
        }

        [TestMethod]
        public void CIFRecordFieldConvertToBoolAttributesValid()
        {
            Assembly cifRecordAssembly = typeof(CIFRecord).Assembly;
            Type[] cifRecordClasses = cifRecordAssembly.GetTypes()
                 .Where(type => type.IsSubclassOf(typeof(CIFRecord)))
                 .Where(type => type.IsClass && !type.IsAbstract)
                 .ToArray();
            foreach (Type cifRecordClass in cifRecordClasses)
            {
                PropertyInfo[] cifRecordFieldProperties = cifRecordClass.GetProperties()
                    .Where(property => property.IsDefined(typeof(CIFRecordFieldLocationAttribute), false))
                    .Where(property => property.IsDefined(typeof(CIFRecordFieldConvertToBoolAttribute), false))
                    .ToArray();

                for (int fieldIndex = 0; fieldIndex < cifRecordFieldProperties.Length; fieldIndex++)
                {
                    CIFRecordFieldLocationAttribute cifRecordFieldLocationAttribute = (CIFRecordFieldLocationAttribute)cifRecordFieldProperties[fieldIndex].GetCustomAttribute(typeof(CIFRecordFieldLocationAttribute));
                    CIFRecordFieldConvertToBoolAttribute cifRecordFieldConvertToBoolAttribute = (CIFRecordFieldConvertToBoolAttribute)cifRecordFieldProperties[fieldIndex].GetCustomAttribute(typeof(CIFRecordFieldConvertToBoolAttribute));

                    Assert.AreEqual(cifRecordFieldLocationAttribute.length, cifRecordFieldConvertToBoolAttribute.trueString.Length, $"Property: {cifRecordClass.FullName}.{cifRecordFieldProperties[fieldIndex].Name}");
                    Assert.AreEqual(cifRecordFieldLocationAttribute.length, cifRecordFieldConvertToBoolAttribute.falseString.Length, $"Property: {cifRecordClass.FullName}.{cifRecordFieldProperties[fieldIndex].Name}");
                }
            }
        }

        [TestMethod]
        public void CIFRecordIdentityAttributesValid()
        {
            Assembly cifRecordAssembly = typeof(CIFRecord).Assembly;
            Type[] cifRecordClasses = cifRecordAssembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(CIFRecord)))
                .Where(type => type.IsClass && !type.IsAbstract)
                .ToArray();
            foreach (Type cifRecordClass in cifRecordClasses)
            {
                CIFRecordIdentityAttribute cifRecordIdentityAttribute = (CIFRecordIdentityAttribute)cifRecordClass.GetCustomAttribute(typeof(CIFRecordIdentityAttribute));

                Assert.AreNotEqual(CIFRecordIdentity.Unknown, cifRecordIdentityAttribute.cifRecordIdentity, $"Class: {cifRecordClass.FullName}");
            }
        }

        [TestMethod]
        public void CIFRecordFieldsHaveConvertAttributes()
        {
            Assembly cifRecordAssembly = typeof(CIFRecord).Assembly;
            Type[] cifRecordClasses = cifRecordAssembly.GetTypes()
                 .Where(type => type.IsSubclassOf(typeof(CIFRecord)))
                 .Where(type => type.IsClass && !type.IsAbstract)
                 .ToArray();
            foreach (Type cifRecordClass in cifRecordClasses)
            {
                PropertyInfo[] cifRecordFieldProperties = cifRecordClass.GetProperties()
                    .Where(property => property.IsDefined(typeof(CIFRecordFieldLocationAttribute), false))
                    .ToArray();

                for (int fieldIndex = 0; fieldIndex < cifRecordFieldProperties.Length; fieldIndex++)
                {
                    PropertyInfo cifRecordFieldProperty = cifRecordFieldProperties[fieldIndex];

                    if (cifRecordFieldProperty.PropertyType == typeof(DateTime) && !cifRecordFieldProperty.IsDefined(typeof(CIFRecordFieldConvertToDateTimeAttribute), false))
                    {
                        Assert.Fail($"Type: DateTime; Property: {cifRecordClass.FullName}.{cifRecordFieldProperty.Name}");
                    }

                    if (cifRecordFieldProperty.PropertyType == typeof(bool) && !cifRecordFieldProperty.IsDefined(typeof(CIFRecordFieldConvertToBoolAttribute), false))
                    {
                        Assert.Fail($"Type: bool; Property: {cifRecordClass.FullName}.{cifRecordFieldProperty.Name}");
                    }
                }
            }
        }
    }
}
