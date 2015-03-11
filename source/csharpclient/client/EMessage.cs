using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBApi
{
    public class EMessage
    {
        byte[] buf;

        public EMessage(byte[] buf)
        {
            this.buf = buf;
        }

        public byte[] GetBuf()
        {
            return buf;
        }
    }
}
