using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true)]
    public class ComList<ComT, T> : ComWrapper<List<T>>, IList<ComT>
        where ComT : class, new()
        where T : class, new()
    {
        public ComList(List<T> data) { this.data = data; }

        public int IndexOf(ComT item)
        {
            return data.IndexOf(ChangeType<T, ComT>(item));
        }

        static Tr ChangeType<Tr, Ta>(Ta value)
            where Ta : new()
            where Tr : class, new()
        {
            return value is ComWrapper<Tr> ? (value as ComWrapper<Tr>).ConvertTo() : (new Tr() as ComWrapper<Ta>).ConvertFrom(value) as Tr;
        }

        public void Insert(int index, ComT item)
        {
            data.Insert(index, ChangeType<T, ComT>(item));
        }

        public void RemoveAt(int index)
        {
            data.RemoveAt(index);
        }

        public ComT this[int index]
        {
            get
            {
                return ChangeType<ComT, T>(data[index]);
            }
            set
            {
                data[index] = ChangeType<T, ComT>(value);
            }
        }

        public void Add(ComT item)
        {
            data.Add(ChangeType<T, ComT>(item));
        }

        public void Clear()
        {
            data.Clear();
        }

        public bool Contains(ComT item)
        {
            return data.Contains(ChangeType<T, ComT>(item));
        }

        public void CopyTo(ComT[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return data.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(ComT item)
        {
            return data.Remove(ChangeType<T, ComT>(item));
        }

        public IEnumerator<ComT> GetEnumerator()
        {
            return data.Select(x => ChangeType<ComT, T>(x)).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}
