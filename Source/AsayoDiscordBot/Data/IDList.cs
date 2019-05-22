using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Data
{
    public class IDList : IList<ulong>
    {
        List<ulong> _list;

        public IDList()
        {
            _list = new List<ulong>();
        }
        public IDList(IEnumerable<ulong> list)
        {
            _list = new List<ulong>(list);
        }

        public IDList(IEnumerable<string> list)
        {
            _list = new List<ulong>();
            foreach (var item in list)
            {
                _list.Add(ulong.Parse(item));
            }
        }

        public ulong this[int index] { get => ((IList<ulong>)_list)[index]; set => ((IList<ulong>)_list)[index] = value; }

        public int Count => ((IList<ulong>)_list).Count;

        public bool IsReadOnly => ((IList<ulong>)_list).IsReadOnly;

        public static IDList Parse(string str)
        {
            return new IDList(str.Split(','));
        }

        public void Add(ulong item)
        {
            ((IList<ulong>)_list).Add(item);
        }

        public void Clear()
        {
            ((IList<ulong>)_list).Clear();
        }

        public bool Contains(ulong item)
        {
            return ((IList<ulong>)_list).Contains(item);
        }

        public void CopyTo(ulong[] array, int arrayIndex)
        {
            ((IList<ulong>)_list).CopyTo(array, arrayIndex);
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            return ((IList<ulong>)_list).GetEnumerator();
        }

        public int IndexOf(ulong item)
        {
            return ((IList<ulong>)_list).IndexOf(item);
        }

        public void Insert(int index, ulong item)
        {
            ((IList<ulong>)_list).Insert(index, item);
        }

        public bool Remove(ulong item)
        {
            return ((IList<ulong>)_list).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<ulong>)_list).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<ulong>)_list).GetEnumerator();
        }
    }
}
