using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    /*
     *  Simple singleton implementation
     *     *
     *     * Pros:
     *     * - Lazy initialization
     *     * - Thread safe
     *     *
     *     * Cons:
     *     * - Not testable
     *     * - Violates Single Responsibility Principle
     *     * - Violates Open/Closed Principle
     *     * - Violates Dependency Inversion Principle
     *     * - Violates Interface Segregation Principle
     *     * - Violates Dependency Inversion Principle
     *     * - Violates Liskov Substitution Principle
     *     
     */
    public interface ISingleton
    {
        void DoSomething(string input);
    }
    public class SimpleSingleton : ISingleton
    {
        private static readonly Lazy<SimpleSingleton> instance = new();
        public static SimpleSingleton Instance => instance.Value;

        private SimpleSingleton()
        {
        }
        public void DoSomething(string input)
        {
            Console.WriteLine($"SimpleSingleton: {input}");
        }
    }

    /* This way we allow the singleton to be testable, by being able to add a dummy implementation of the singleton when performing the tests
     * This is better done with a DI container, but for the sake of simplicity we will do it manually
     */
    public class SingletonDIWrapper
    {
        private ISingleton singleton;

        public SingletonDIWrapper(ISingleton singleton)
        {
            this.singleton = singleton;
        }

        public void DoSomething(IEnumerable<string> input)
        {
            foreach (var i in input)
            {
                singleton.DoSomething(i);
            }
        }
    }
}
