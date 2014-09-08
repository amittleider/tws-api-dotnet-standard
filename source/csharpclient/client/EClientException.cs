using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBApi
{
    class EClientException : Exception
    {
        public CodeMsgPair Err { get; private set; }

        public EClientException(CodeMsgPair err)
        {
            this.Err = err;
        }
    }
}
