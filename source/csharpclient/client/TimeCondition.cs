using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBApi
{
    public class TimeCondition : OperatorCondition
    {
        const string header = "time";

        protected override string Value
        {
            get
            {
                return Time;
            }
            set
            {
                Time = value;
            }
        }

        public override string ToString()
        {
            return header + base.ToString();
        }

        public string Time { get; set; }

        protected override bool TryParse(string cond)
        {
            if (!cond.StartsWith(header))
                return false;

            cond = cond.Replace(header, "");
            return base.TryParse(cond);
        }
    }
}
