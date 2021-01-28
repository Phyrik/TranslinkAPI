using CIF.Attributes;
using CIF.Records;
using CIF.Records.ATCO;
using CIF.Records.RJIS;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CIF
{
    public class CIFParser
    {
        public static CIFFile ParseCIFFile(string filePath)
        {
            string[] cifFileLines = File.ReadAllLines(filePath);
            string fileHeaderRecordString = cifFileLines[0];

            CIFFileType cifFileType = IdentifyCIFFileType(fileHeaderRecordString);

            switch (cifFileType)
            {
                case CIFFileType.Unknown:
                    throw new Exception("Unknown CIF file format.");

                case CIFFileType.ATCOCIF:
                    return ParseATCOCIFFile(cifFileLines);

                case CIFFileType.RJISCIF:
                    return ParseRJISCIFFile(cifFileLines);

                default:
                    return null;
            }
        }

        public static CIFFileType IdentifyCIFFileType(string fileHeaderRecordString)
        {
            if (fileHeaderRecordString.Substring(0, 8) == "ATCO-CIF") return CIFFileType.ATCOCIF;
            if (fileHeaderRecordString.Substring(0, 2) == "HD") return CIFFileType.RJISCIF;
            return CIFFileType.Unknown;
        }

        public static ATCOCIFFile ParseATCOCIFFile(string[] cifFileLines)
        {
            ATCOCIFFileHeaderRecord fileHeaderRecord = (ATCOCIFFileHeaderRecord)ParseRecord(cifFileLines[0], CIFRecordIdentity.ATCOCIFFileHeader);

            ATCOCIFFile atcoCifFile = new ATCOCIFFile(fileHeaderRecord);

            for (int lineNumber = 0; lineNumber < cifFileLines.Length; lineNumber++)
            {
                if (lineNumber == 0) continue;

                string recordString = cifFileLines[lineNumber];
                CIFRecordIdentity recordIdentity = IdentifyRecord(recordString);
                ATCOCIFRecord record = (ATCOCIFRecord)ParseRecord(recordString, recordIdentity);
                atcoCifFile.Records.Add(record);
            }

            return atcoCifFile;
        }

        public static RJISCIFFile ParseRJISCIFFile(string[] cifFileLines)
        {
            RJISCIFFileHeaderRecord fileHeaderRecord = (RJISCIFFileHeaderRecord)ParseRecord(cifFileLines[0], CIFRecordIdentity.HD);

            RJISCIFFile rjisCifFile = new RJISCIFFile(fileHeaderRecord);

            for (int lineNumber = 0; lineNumber < cifFileLines.Length; lineNumber++)
            {
                if (lineNumber == 0) continue;

                string recordString = cifFileLines[lineNumber];
                CIFRecordIdentity recordIdentity = IdentifyRecord(recordString);
                RJISCIFRecord record = (RJISCIFRecord)ParseRecord(recordString, recordIdentity);
                rjisCifFile.Records.Add(record);
            }

            return rjisCifFile;
        }

        public static CIFRecordIdentity IdentifyRecord(string recordString)
        {
            if (recordString.Substring(0, 8) == "ATCO-CIF") return CIFRecordIdentity.ATCOCIFFileHeader;
            
            try
            {
                return (CIFRecordIdentity)Enum.Parse(typeof(CIFRecordIdentity), recordString.Substring(0, 2));
            }
            catch (ArgumentException)
            {
                return CIFRecordIdentity.Unknown;
            }
        }

        public static Type CIFRecordIdentityToRecordClass(CIFRecordIdentity cifRecordIdentity)
        {
            Assembly cifRecordAssembly = typeof(CIFRecord).Assembly;
            Type[] cifRecordClasses = cifRecordAssembly.GetTypes().Where(type => type.IsSubclassOf(typeof(CIFRecord))).ToArray();
            foreach (Type cifRecordClass in cifRecordClasses)
            {
                CIFRecordIdentityAttribute cifRecordIdentityAttribute = (CIFRecordIdentityAttribute)Attribute.GetCustomAttribute(cifRecordClass, typeof(CIFRecordIdentityAttribute));

                if (cifRecordIdentityAttribute != null)
                {
                    if (cifRecordIdentityAttribute.cifRecordIdentity == cifRecordIdentity)
                    {
                        return cifRecordClass;
                    }
                }
            }

            throw new Exception("No record class exists for this record identity.");
        }

        public static CIFRecord ParseRecord(string recordString, CIFRecordIdentity cifRecordIdentity)
        {
            Type cifRecordClass = CIFRecordIdentityToRecordClass(cifRecordIdentity);

            dynamic recordToReturn = Activator.CreateInstance(cifRecordClass);

            foreach (PropertyInfo property in cifRecordClass.GetProperties())
            {
                CIFRecordFieldLocationAttribute cifRecordFieldLocationAttribute = (CIFRecordFieldLocationAttribute)Attribute.GetCustomAttribute(property, typeof(CIFRecordFieldLocationAttribute));

                if (cifRecordFieldLocationAttribute != null)
                {
                    CIFRecordFieldConvertToBoolAttribute cifRecordFieldConvertToBoolAttribute = (CIFRecordFieldConvertToBoolAttribute)Attribute.GetCustomAttribute(property, typeof(CIFRecordFieldConvertToBoolAttribute));
                    CIFRecordFieldConvertToDateTimeAttribute cifRecordFieldConvertToDateTimeAttribute = (CIFRecordFieldConvertToDateTimeAttribute)Attribute.GetCustomAttribute(property, typeof(CIFRecordFieldConvertToDateTimeAttribute));

                    string fieldStringValue = recordString.Substring(cifRecordFieldLocationAttribute.startPosition - 1, cifRecordFieldLocationAttribute.length);
                    object propertyValue;

                    if (cifRecordFieldConvertToBoolAttribute != null)
                    {
                        if (fieldStringValue == cifRecordFieldConvertToBoolAttribute.trueString) propertyValue = true;
                        else if (fieldStringValue == cifRecordFieldConvertToBoolAttribute.falseString) propertyValue = false;
                        else throw new Exception("Malformed record.");
                    }
                    else if (cifRecordFieldConvertToDateTimeAttribute != null)
                    {
                        try
                        {
                            propertyValue = DateTime.ParseExact(fieldStringValue, cifRecordFieldConvertToDateTimeAttribute.format, CultureInfo.InvariantCulture);
                        }
                        catch (FormatException)
                        {
                            if (fieldStringValue == "99999999") propertyValue = null;
                            else throw new Exception("Invalid DateTime value.");
                        }
                    }
                    else
                    {
                        propertyValue = fieldStringValue;
                    }

                    property.SetValue(recordToReturn, propertyValue);
                }
            }

            return recordToReturn;
        }
    }
}
