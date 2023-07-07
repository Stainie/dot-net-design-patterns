using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    /*
     * Async factory variation is good for async object creation.
     * Since we cannot use async constructor, we use async factory method.
     */
    public class AsyncFactory
    {
        private int _property;

        internal AsyncFactory(int property)
        {
            _property = property;
        }
        public class Factory
        {
            private static async Task<AsyncFactory> InitAsync(int property)
            {
                await Task.Delay(1000);
                return new AsyncFactory(property);
            }

            public static async Task<AsyncFactory> CreateAsync(int property) => await InitAsync(property);
        }
    }
}
