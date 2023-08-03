using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using System.Text;

namespace Flyweight
{
    /*
     * Flyweight pattern lets you fit more objects into the available amount of RAM
     * by sharing common parts of state between multiple objects
     */
    public class Flyweight
    {
        string _name;

        public Flyweight(string name)
        {
            this._name = name;
        }
    }

    public class FlyweightOptimized
    {
        static List<string> _strings = new List<string>();
        private int[] _names;
        public FlyweightOptimized(string name)
        {
            int getOrAdd(string s)
            {
                int idx = _strings.IndexOf(s);
                if (idx != -1) return idx;
                else
                {
                    _strings.Add(s);
                    return _strings.Count - 1;
                }
            }

            _names = name.Split(' ').Select(getOrAdd).ToArray();
        }

        public string FullName => string.Join(" ", _names.Select(i => _strings[i]));
    }

    [TestFixture]
    public class Demo
    {
        static void Main(string[] args)
        {
        }

        [Test]
        public void TestNames()
        {
            var names = Enumerable.Range(0, 100).Select(_ => RandomString()).ToList();
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString()).ToList();

            var flyweights = new List<Flyweight>();

            foreach (var name in names)
            {
                foreach (var lastName in lastNames)
                {
                    flyweights.Add(new Flyweight($"{name} {lastName}"));
                }
            }

            GarbageCollect();

            dotMemory.Check(memory =>
            {
                Console.WriteLine(memory.SizeInBytes);
                Assert.That(memory.SizeInBytes, Is.LessThan(10000));
            });
        }

        [Test]
        public void TestOptimizedNames()
        {
            var names = Enumerable.Range(0, 100).Select(_ => RandomString()).ToList();
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString()).ToList();

            var flyweights = new List<FlyweightOptimized>();

            foreach (var name in names)
            {
                foreach (var lastName in lastNames)
                {
                    flyweights.Add(new FlyweightOptimized($"{name} {lastName}"));
                }
            }
            
            GarbageCollect();
            dotMemory.Check(memory =>
            {
                Console.WriteLine(memory.SizeInBytes);
                Assert.That(memory.SizeInBytes, Is.LessThan(10000));
            });
        }

        private void GarbageCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private string RandomString()
        {
            Random random = new Random();

            return new string(Enumerable.Range(0, 10).Aggregate("", (s, _) => s + (char)('a' + random.Next(0, 26))));
        }
    }

    public class Sentence
    {
        static List<string> _words = new List<string>();
        WordToken[] _tokens;
        public Sentence(string plainText)
        {
            WordToken getOrAdd(string s)
            {
                int idx = _words.IndexOf(s);
                if (idx == -1) return new WordToken { Capitalize = false };
                else
                {
                    _words.Add(s);
                    return new WordToken { Capitalize = false };
                }
            }

            _tokens = plainText.Split(' ').Select(getOrAdd).ToArray();
        }

        public WordToken this[int index]
        {
            get
            {
                return _tokens[index];
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _tokens.Length; i++)
            {
                var token = _tokens[i];
                sb.Append(token.Capitalize ? _words[i].ToUpper() : _words[i]);
                sb.Append(" ");
            }

            return sb.ToString().Trim();
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
}