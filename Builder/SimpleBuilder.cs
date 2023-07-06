using System.Text;

namespace Builder
{
    // Use Simple builder when you have a complex object that needs to be built in steps but not in exact order.
    public class SimpleModel
    {
        public string? Name { get; set; }

        public SimpleModel(string? name)
        {
            Name = name;
        }

        public SimpleModel()
        {
            
        }

        public List<SimpleModel> Children { get; set; } = new();

        public override string ToString()
        {
            var stringBuilder= new StringBuilder();
            stringBuilder.AppendLine($"{nameof(Name)} : {Name}");

            foreach (var child in Children)
            {
                stringBuilder.Append(child.ToString());
            }

            return stringBuilder.ToString();
        }
    }

    public class SimpleBuilder
    {
        readonly SimpleModel _simpleModel = new();

        private readonly string? _rootName;

        public SimpleBuilder(string? rootName)
        {
            this._rootName = rootName;
            _simpleModel.Name = rootName;
        }

        public SimpleBuilder AddChild(string? childName)
        {
            var child = new SimpleModel(childName);
            _simpleModel.Children.Add(child);
            return this;
        }

        public override string ToString()
        {
            return _simpleModel.ToString();
        }
    }
}
