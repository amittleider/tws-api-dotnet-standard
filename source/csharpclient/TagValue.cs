using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBApi
{
    public class TagValue
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
    }
}
