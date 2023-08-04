using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    /*
     * Composite proxy is used for a big collection of objects,
     * where modifying a same property in a group of items is a costly operation.
     * Commonly used in game development or UI frameworks.
     */
    internal struct CompositeProxyItem
    {
        internal string Name { get; set; }
        internal int Value { get; set; }
        internal CompositeProxyItem(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }

    public class CPItems
    {
        private readonly int size;
        public string[] names;
        public int[] values;

        public CPItems(int size)
        {
            this.size = size;
            names = new string[size];
            values = new int[size];
        }

        public struct CPItemsProxy
        {
            private readonly CPItems _items;
            private readonly int _index;

            public CPItemsProxy(CPItems items, int index)
            {
                _items = items;
                _index = index;
            }

            public ref string Name => ref _items.names[_index];
            public ref int Value => ref _items.values[_index];
        }

        public IEnumerator<CPItemsProxy> GetEnumerator()
        {
            for (var pos = 0; pos < size; pos++)
            {
                yield return new CPItemsProxy(this, pos);
            }
        }
    }
}
