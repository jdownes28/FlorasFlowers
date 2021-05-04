using BenchBackend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Text;

namespace BenchBackend.Services
{
    public class DataSerializer
    {
        public byte[] Serialize<T>(T myObject)
        {
            using MemoryStream stream = new();
            XmlTextWriter xmlWriter = new(stream, Encoding.UTF8);

            var serializer = new DataContractSerializer(myObject.GetType());
            serializer.WriteObject(xmlWriter, myObject);
            xmlWriter.Flush();
            var filename = $"Orders_{DateTime.Now}.xml";

            return stream.ToArray();
        }
    }
}
