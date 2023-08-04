using ImpromptuInterface;
using System.Dynamic;

namespace Proxy
{
    /*
     *     * Dynamic proxy is used for proxying objects at runtime.
     *     * Used for metaprogramming - in examples such as serialization.
     *         * Commonly used in mocking frameworks.
     *          * Difference compared to a Decorator is:
     *              - a Decorator is used for adding functionality to an object,
     *                  proxy provides an identical interface to the original object.
     *              - a Decorator has a reference to the original object (often as a construction parameter),
     *                  proxy works with generics
     *             */
    public class DynamicProxy<T> : DynamicObject where T : class, new()
    {
        private Dictionary<string, int> methodCallCount = new();
        private readonly T _subject;

        public DynamicProxy(T subject)
        {
            _subject = subject ?? throw new ArgumentNullException(nameof(subject));
        }

        public static I As<I>() where I : class
        {
            if (!typeof(I).IsInterface)
            {
                throw new ArgumentException("Must be an interface type");
            }

            return new DynamicProxy<T>(new T()).ActLike<I>();
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            try
            {
                Console.WriteLine($"Invoking {_subject.GetType().Name}.{binder.Name} with arguments [{string.Join(",", args)}]");

                if (methodCallCount.ContainsKey(binder.Name))
                {
                    methodCallCount[binder.Name]++;
                }
                else
                {
                    methodCallCount.Add(binder.Name, 1);
                }

                result = _subject.GetType().GetMethod(binder.Name)?.Invoke(_subject, args);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }

    public interface IProxiedInterface
    {
        void DoSomething();
        void SomethingElse(string arg);
        string ToString();
    }

    public class ProxiedClass : IProxiedInterface
    {
        public ProxiedClass()
        {
        }

        public void DoSomething()
        {
            Console.WriteLine("Proxied class is doing something");
        }

        public void SomethingElse(string arg)
        {
            Console.WriteLine($"Proxied class is doing something else with {arg}");
        }

        public override string ToString()
        {
            return "Proxied class";
        }
    }
}
