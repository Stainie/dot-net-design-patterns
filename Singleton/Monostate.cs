using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    /*
     *     *  Monostate implementation
     *     *     *
     *     *     * Pros:
     *     *     * - Lazy initialization
     *     *     * - Thread safe
     *     *     * - Testable
     *             - Allows regular instantiation, but keeps the fields static
     *     *     *
     *     *     * Cons:
     *     *     * - Violates Single Responsibility Principle
     *     *     * - Violates Open/Closed Principle
     *     *     * - Violates Dependency Inversion Principle
     *     *     * - Violates Interface Segregation Principle
     *     *     * - Violates Liskov Substitution Principle
     *     *
     *     */
     
    public class Monostate
    {
        private static string _name;
        private static int _age;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public override string ToString()
        {
            return $"Name: {_name}, Age: {_age}";
        }
    }
}
