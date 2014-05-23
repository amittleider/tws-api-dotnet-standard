using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWSLib
{
    public abstract class ComWrapper<T> where T : new()
    {
        protected T data = new T();

        public T ConvertTo() 
        {
            return this.data;
        }

        public ComWrapper<T> ConvertFrom(T value)
        {
            this.data = value;

            return this;
        }
    }
}
