using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    /*
     *   Per thread singleton implementation
     *     *     *
     *     *     * Pros:
     *     *     * - Lazy initialization
     *     *     * - Thread safe
     *     *     * - Testable
     *     *     * - This implementation allows us to have a different instance of the singleton for each thread
     *     *     *
     *     *     * Cons:
     *     *     * - Violates Single Responsibility Principle
     *     *     * - Violates Open/Closed Principle
     *     *     * - Violates Dependency Inversion Principle
     *     *     * - Violates Interface Segregation Principle
     *     *     * - Violates Liskov Substitution Principle
     *     *
     *     */
    public sealed class PerThreadSingleton
    {
        private static readonly ThreadLocal<PerThreadSingleton> instance = new(() => new PerThreadSingleton());
        public static PerThreadSingleton Instance => instance.Value;

        private PerThreadSingleton()
        {
        }

        public void DoSomething(string input)
        {
            Console.WriteLine($"PerThreadSingleton: {input}");
        }
    }
}
