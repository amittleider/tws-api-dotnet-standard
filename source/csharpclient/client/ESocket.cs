using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace IBApi
{
    class ESocket : ETransport, IDisposable
    {
        BinaryWriter tcpWriter;

        public ESocket(TcpClient clientSocket)
        {
            tcpWriter = new BinaryWriter(clientSocket.GetStream());
        }

        public void Send(EMessage msg)
        {
            tcpWriter.Write(msg.GetBuf());
        }

        public void Dispose()
        {
            tcpWriter.Dispose();
        }
    }
}
