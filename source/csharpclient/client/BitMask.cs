using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBApi
{
    class BitMask
    {
        private int m_mask;

        public BitMask(int p)
        {
            this.m_mask = p;
        }

        public int GetMask()
        {
            return m_mask;
        }

        public void Clear()
        {
            m_mask = 0;
        }

        public bool this[int index]
        {
            get
            {
                if (index >= 32)
                {
                    throw new IndexOutOfRangeException();
                }

                return (m_mask & (1 << index)) != 0;
            }
            set
            {
                if (index >= 32)
                {
                    throw new IndexOutOfRangeException();
                }

                if (value)
                {
                    m_mask |= 1 << index;
                }
                else
                {
                    m_mask &= ~(1 << index);
                }
            }
        }
    }
}
