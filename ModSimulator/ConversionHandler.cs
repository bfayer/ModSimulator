using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ModSimulator
{
    class ConversionHandler
    {


        static public void ObjectToXMLFile(DR beanstoexport) //this is for testing output to verify format
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DR));
            TextWriter textWriter = new StreamWriter(@"E:\ModSimulatorOutput.xml");
            serializer.Serialize(textWriter, beanstoexport);

            textWriter.Close();
        }
    }
}
