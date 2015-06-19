using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace IBApi
{
    public class EReader
    {
        EClientSocket eClientSocket;
        EReaderSignal eReaderSignal;
        Queue<EMessage> msgQueue = new Queue<EMessage>();
        EDecoder processMsgsDecoder;
        EDecoder threadReadDecoder;

        bool UseV100Plus
        {
            get
            {
                return eClientSocket.UseV100Plus;
            }
        }


        static EWrapper defaultWrapper = new DefaultEWrapper();

        public EReader(EClientSocket clientSocket, EReaderSignal signal)
        {
            eClientSocket = clientSocket;
            eReaderSignal = signal;
            threadReadDecoder = new EDecoder(eClientSocket.ServerVersion, defaultWrapper);
            processMsgsDecoder = new EDecoder(eClientSocket.ServerVersion, eClientSocket.Wrapper, eClientSocket);
        }

        public void Start()
        {
            new Thread(() =>
            {
                while (eClientSocket.IsConnected())
                    if (!putMessageToQueue())
                        break;
            }) { IsBackground = true }.Start();
        }

        EMessage getMsg()
        {
            lock (msgQueue)
                return msgQueue.Count == 0 ? null : msgQueue.Dequeue();
        }

        public void processMsgs()
        {
            EMessage msg = getMsg();

            while (msg != null && processMsgsDecoder.ParseAndProcessMsg(msg.GetBuf()) > 0)
                msg = getMsg();
        }

        public bool putMessageToQueue()
        {
            try
            {
                EMessage msg = readSingleMessage();

                if (msg == null)
                    return false;

                lock (msgQueue)
                    msgQueue.Enqueue(msg);

                eReaderSignal.issueSignal();

                return true;
            }
            catch (Exception ex)
            {
                if (eClientSocket.IsConnected())
                    eClientSocket.Wrapper.error(ex);

                return false;
            }
        }

        List<byte> inBuf = new List<byte>(short.MaxValue / 8);

        private EMessage readSingleMessage()
        {
            var msgSize = 0;

            if (UseV100Plus)
            {
                msgSize = eClientSocket.ReadInt();

                if (msgSize > Constants.MaxMsgSize)
                {
                    throw new EClientException(EClientErrors.BAD_LENGTH);
                }

                var buf = new List<byte>();
                var offset = 0;

                while (offset < msgSize)
                {
                    var readBuf = eClientSocket.ReadByteArray(msgSize - offset);

                    buf.AddRange(readBuf);

                    offset += readBuf.Length;
                }

                return new EMessage(buf.ToArray());
            }

            if (inBuf.Count == 0)
                inBuf.AddRange(eClientSocket.ReadByteArray(inBuf.Capacity - inBuf.Count));

            msgSize = threadReadDecoder.ParseAndProcessMsg(inBuf.ToArray());
            
            var msgBuf = new byte[msgSize];

            inBuf.CopyTo(0, msgBuf, 0, msgSize);
            inBuf.RemoveRange(0, msgSize);

            return new EMessage(msgBuf);
        }
    }
}
