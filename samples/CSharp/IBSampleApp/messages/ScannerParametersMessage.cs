using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.messages
{
    public class ScannerParametersMessage : IBMessage
    {
        private string xmlData;
        
        public ScannerParametersMessage(string data)
        {
            Type = MessageType.ScannerParameters;
            XmlData = data;
        }

        public string XmlData
        {
            get { return xmlData; }
            set { xmlData = value; }
        }
    }
}
