using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBApi
{
    public class MarginCondition : OperatorCondition
    {
        const string header = "the margin cushion percent";

        protected override string Value
        {
            get
            {
                return Percent.ToString();
            }
            set
            {
                Percent = int.Parse(value);
            }
        }

        public override string ToString()
        {
            return header + base.ToString();
        }

        public int Percent { get; set; }

        protected override bool TryParse(string cond)
        {
            if (!cond.StartsWith(header))
                return false;

            cond = cond.Replace(header, "");

            return base.TryParse(cond);
        }
    }
}
