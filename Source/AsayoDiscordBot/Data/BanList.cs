using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayoDiscordBot.Data
{
    public class BanList : IList<ulong>
    {
        List<ulong> bans;
        public BanList()
        {
            bans = new List<ulong>();
        }

        public ulong this[int index] { get => ((IList<ulong>)bans)[index]; set => ((IList<ulong>)bans)[index] = value; }

        public int Count => ((IList<ulong>)bans).Count;

        public bool IsReadOnly => ((IList<ulong>)bans).IsReadOnly;

        public void Add(ulong item)
        {
            ((IList<ulong>)bans).Add(item);
        }

        public void Clear()
        {
            ((IList<ulong>)bans).Clear();
        }

        public bool Contains(ulong item)
        {
            return ((IList<ulong>)bans).Contains(item);
        }

        public void CopyTo(ulong[] array, int arrayIndex)
        {
            ((IList<ulong>)bans).CopyTo(array, arrayIndex);
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            return ((IList<ulong>)bans).GetEnumerator();
        }

        public int IndexOf(ulong item)
        {
            return ((IList<ulong>)bans).IndexOf(item);
        }

        public void Insert(int index, ulong item)
        {
            ((IList<ulong>)bans).Insert(index, item);
        }

        public bool Remove(ulong item)
        {
            return ((IList<ulong>)bans).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<ulong>)bans).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<ulong>)bans).GetEnumerator();
        }

        public bool IsBan(ulong id)
        {
            return bans.IndexOf(id) != -1;
        }
    }
}
