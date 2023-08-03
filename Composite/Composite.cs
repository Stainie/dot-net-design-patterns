using System.Collections;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Composite
{
    /*
     *     * The Composite pattern is used when you want to treat a group of objects in a similar way to a single object.
     *         * It composes objects into tree structures to represent part-whole hierarchies.
     *             * It lets clients treat individual objects and compositions of objects uniformly.
     *                 */
    public class CompositeBase
    {
        public virtual string Name { get; set; } = "Base";

        private readonly Lazy<List<CompositeBase>> _children = new();
        public List<CompositeBase> Children => _children.Value;

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }

        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string('*', depth)).AppendLine($"Name: {Name}");
            foreach (var child in Children)
            {
                child.Print(sb, depth + 1);
            }
        }
    }

    public class Composite1 : CompositeBase
    {
        public override string Name { get; set; } = "Composite 1";
    }

    public class Composite2 : CompositeBase
    {
        public override string Name { get; set; } = "Composite 2";
    }
}