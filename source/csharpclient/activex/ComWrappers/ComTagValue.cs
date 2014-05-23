using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true)]
    public class ComTagValue : ComWrapper<TagValue>, ITagValue
    {
        public ComTagValue() { }
        public ComTagValue(string tag, string value)           
        {
            data.Tag = tag;
            data.Value = value;
        }

        public string Tag { get { return data != null ? data.Tag : default(string); } set { if (data != null) data.Tag = value; } }
        public string Value { get { return data != null ? data.Value : default(string); } set { if (data != null) data.Value = value; } }

        public static explicit operator TagValue(ComTagValue ctv)
        {
            return ctv.ConvertTo();
        }

        public static explicit operator ComTagValue(TagValue tv)
        {
            return new ComTagValue().ConvertFrom(tv) as ComTagValue;
        }

        string ITagValue.tag
        {
            get
            {
                return Tag;
            }
            set
            {
                Tag = value;
            }
        }

        string ITagValue.value
        {
            get
            {
                return Value;
            }
            set
            {
                Value = value;
            }
        }
    }
}
