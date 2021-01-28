using CIF.Records;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System;
using System.Linq;
using CIF.Attributes;

namespace CIFParserTests
{
    [TestClass]
    public class CIFRecordAccessTests
    {
        [TestMethod]
        public void CIFRecordClassesArePublic()
        {
            Assembly cifRecordAssembly = typeof(CIFRecord).Assembly;
            Type[] cifRecordClasses = cifRecordAssembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(CIFRecord)))
                .Where(type => type.IsClass && !type.IsAbstract)
                .ToArray();
            foreach (Type cifRecordClass in cifRecordClasses)
            {
                Assert.IsTrue(cifRecordClass.IsPublic, $"Class: {cifRecordClass.FullName}");
            }
        }

        [TestMethod]
        public void CIFRecordFieldsArePublic()
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
                    PropertyInfo cifRecordFieldProperty = cifRecordFieldProperties[fieldIndex];

                    Assert.IsTrue(cifRecordFieldProperty.GetGetMethod(true).IsPublic, $"Property: {cifRecordClass.FullName}.{cifRecordFieldProperty.Name}");
                    Assert.IsTrue(cifRecordFieldProperty.GetSetMethod(true).IsPublic, $"Property: {cifRecordClass.FullName}.{cifRecordFieldProperty.Name}");
                }
            }
        }
    }
}
