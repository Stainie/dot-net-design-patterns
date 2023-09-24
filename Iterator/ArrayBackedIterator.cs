using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    /*
     * This is not an iterator per se, but shows how we can use iterator pattern to implement a model
     * This helps us manipulate the properties in the way we want
     */
    public class ArrayBackedIteratorModel : IEnumerable<int>
    {
        private const int prop1 = 0;
        private const int prop2 = 1;
        private const int prop3 = 2;

        private int[] props = new int[3];
        public int Prop1 { get => props[prop1]; set => props[prop1] = value; }
        public int Prop2
        {
            get => props[prop2];
            set => props[prop2] = value;
        }
        public int Prop3 { 
            get => props[prop3];
            set => props[prop3] = value;
        }

        public double Average => props.Average();

        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)props).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return props.GetEnumerator();
        }

        public int this[int index]
        {
            get => props[index];
            set => props[index] = value;
        }
    }
}
