using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    /* SimpleFactory is used when there is a need to create a large number of similar objects.
     * To avoid the complex switch logic in constructor, or a lot of model inheriting the original one, we use factory pattern.
     */
    public class SimpleFactory
    {
        private int _property1, _property2;

        private SimpleFactory(int property1, int property2)
        {
            this._property1 = property1;
            this._property2 = property2;
        }

        public static class Factory
        {
            public static SimpleFactory CreateNormal(int property1, int property2)
            {
                return new SimpleFactory(property1, property2);
            }

            public static SimpleFactory CreateReversed(int property1, int property2)
            {
                return new SimpleFactory(property2, property1);
            }
        }
    }
}
