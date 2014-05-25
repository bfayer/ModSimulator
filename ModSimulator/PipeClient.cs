using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ModSimulator
{
    class PipeClient
    {
        public void Transmit(object transmitPack)
        {
            try
            {
                //Create Client to connect to server Pipe named: dpipe
                System.IO.Pipes.NamedPipeClientStream clientStream = new NamedPipeClientStream("dpipe");
                clientStream.Connect(60);


                StreamWriter sw = new StreamWriter(clientStream);
                XmlSerializer serializer = new XmlSerializer(typeof(DR));

                serializer.Serialize(sw, transmitPack);

                clientStream.Close();
                ReportError("");

            }
            catch (System.TimeoutException)
            {
                ReportError("Server Timed Out");
            }
            catch (System.IO.IOException)
            {
                ReportError("Server Not Available");
            }
            catch (Exception)
            { }


        }

        public event ErrorEventHandler myErrorLog;
        
        private void ReportError (string theNewData)
        {
            if (this.myErrorLog != null) // will be null if no subscribers
            {
                this.myErrorLog(theNewData);

            }

       }




    }
}
