using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    /* 
     * We use Value proxy for proxying primitive values, to have extra control over the implicit operations 
     */
    public struct ValueProxy
    {
        private readonly int value;

        public ValueProxy(int value)
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
