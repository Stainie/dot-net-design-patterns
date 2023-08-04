using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public struct ValueProxy
    {
        private readonly int value;

        internal ValueProxy(int value)
        {
            this.value = value;
        }

        public static implicit operator int(ValueProxy proxy)
        {
            return proxy.value;
        }

        public static ValueProxy operator +(ValueProxy proxy, int value)
        {
            return new ValueProxy(value + proxy.value);
        }

        public static ValueProxy operator -(ValueProxy proxy, int value)
        {
            return new ValueProxy(proxy.value - value);
        }

        public static ValueProxy operator *(ValueProxy proxy, int value)
        {
            return new ValueProxy(proxy.value * value);
        }

        public static ValueProxy operator /(ValueProxy proxy, int value)
        {
            return new ValueProxy(proxy.value / value);
        }

        public static ValueProxy operator %(ValueProxy proxy, int value)
        {
            return new ValueProxy(proxy.value % value);
        }

        public override string ToString()
        {
            return $"{value} proxied";
        }
    }

    public static class ValueProxyExtensions
    {
        public static ValueProxy ToValueProxy(this int value)
        {
            return new ValueProxy(value * 1);
        }
    }
}
