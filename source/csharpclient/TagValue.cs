/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IBApi
{
    [ComVisible(true)]
    public class TagValue : TWSApi.ITagValue
    {
        public string tag;
        public string value;

        public TagValue()
        {
        }

        public TagValue(string p_tag, string p_value)
        {
            tag = p_tag;
            value = p_value;
        }

        public bool Equals(Object other)
        {

            if (this == other)
                return true;

            if (other == null)
                return false;

            TagValue l_theOther = (TagValue)other;

            if (Util.StringCompare(tag, l_theOther.tag) != 0 ||
                Util.StringCompare(value, l_theOther.value) != 0)
            {
                return false;
            }

            return true;
        }

        string TWSApi.ITagValue.tag
        {
            get
            {
                return this.tag;
            }
            set
            {
                this.tag = value;
            }
        }

        string TWSApi.ITagValue.value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }
}
